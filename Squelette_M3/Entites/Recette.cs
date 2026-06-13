// Authors NoéA. &  ValentinB
// Classe Recette
using M3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace Squelette_M3

{

    public class Recette

    {
        public int REC_Id
        {
            get { return Id_Recette; }
            set { Id_Recette = value; }
        }

        /// <summary>
        /// Constructeur de la classe Recette
        /// </summary>
        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; } = "";
        public DateTime REC_DateHeureCreation { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();

        /// <summary>
        /// fonctions pour supprimer une recette avec ses lôts yc les opérations
        /// </summary>
        /// <param name="idRecette"></param>
        public void SupprimerRecetteAvecLots(int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                try
                {
                    connection.OpenIfNot(); // Assurez-vous que la connexion est ouverte avant de commencer la transaction Open if not already open

                    using (MySqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Récupérer tous les lots liés à cette recette
                            List<int> lotsASupprimer = new List<int>();
                            string getLotsQuery = "SELECT Id_Lot FROM lot WHERE Id_Recette = @id";

                            using (MySqlCommand cmd = new MySqlCommand(getLotsQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idRecette);
                                using (MySqlDataReader reader = cmd.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        lotsASupprimer.Add(Convert.ToInt32(reader["Id_Lot"]));
                                    }
                                }
                            }

                            // 2. Supprimer les événements de ces lots
                            if (lotsASupprimer.Count > 0)
                            {
                                string lotsIn = string.Join(",", lotsASupprimer);
                                string deleteEvenements = $"DELETE FROM evenement WHERE Id_Lot IN ({lotsIn})";

                                using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                                {
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            // 3. Supprimer les lots
                            string deleteLots = "DELETE FROM lot WHERE Id_Recette = @id";
                            using (MySqlCommand cmd = new MySqlCommand(deleteLots, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idRecette);
                                cmd.ExecuteNonQuery();
                            }

                            // 4. Supprimer les entrées dans la table associative Contenir
                            string deleteContenir = "DELETE FROM Contenir WHERE Id_Recette = @id";
                            using (MySqlCommand cmd = new MySqlCommand(deleteContenir, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idRecette);
                                cmd.ExecuteNonQuery();
                            }

                        // 5️⃣ SUPPRIMER LA RECETTE
                            string deleteRecette = "DELETE FROM recette WHERE Id_Recette = @id";
                            using (MySqlCommand cmd = new MySqlCommand(deleteRecette, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@id", idRecette);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();
                        MessageBox.Show("✅ Recette et ses lots supprimés avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                         
                        }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"❌ Erreur SQL : {mex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"❌ Erreur : {ex.Message}", "Erreur",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw;
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"❌ Erreur SQL : {ex.Message}", "Erreur",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
        }

        /// <summary>
        /// fct qui renvoie une liste de recette
        /// </summary>
        /// <returns>liste de recette</returns>
        public static List<Recette> GetAll()
        {
            List<Recette> liste = new List<Recette>();
            using (MySqlConnection connection = DBManager.GetConnection())

            {
                connection.OpenIfNot();

                string query = "SELECT Id_Recette, REC_Nom, REC_DateHeureCreation FROM recette";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new Recette
                            {
                                Id_Recette = Convert.ToInt32(reader["Id_Recette"]),
                                REC_Nom = reader["REC_Nom"]?.ToString() ?? "",
                                REC_DateHeureCreation = Convert.ToDateTime(reader["REC_DateHeureCreation"])
                            });
                        }
                    }
                }
            }
            return liste;
        }


        public static Recette GetById(int id)
        {
            Recette recette = null;

            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.OpenIfNot();

                string query = "SELECT Id_Recette, REC_Nom, REC_DateHeureCreation " +
                              "FROM recette WHERE Id_Recette = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            recette = new Recette
                            {
                                Id_Recette = Convert.ToInt32(reader["Id_Recette"]),
                                REC_Nom = reader["REC_Nom"]?.ToString() ?? "",
                                REC_DateHeureCreation = Convert.ToDateTime(reader["REC_DateHeureCreation"])
                            };
                        }
                    }
                }

                if (recette != null)
                {
                    // Jointure avec Contenir pour récupérer les opérations DANS L'ORDRE
                    string queryOps = @"SELECT o.Id_Operation, o.OPE_Nom, o.OPE_PositionMoteur,
                                       o.OPE_TempsAttente, o.OPE_CycleVerin,
                                       o.OPE_Quittance, o.OPE_SensMoteur,
                                       c.CON_NoOperation
                                FROM operation o
                                INNER JOIN Contenir c
                                    ON o.Id_Operation = c.Id_Operation_est_contenu_dans
                                WHERE c.Id_Recette = @id
                                ORDER BY c.CON_NoOperation";

                    using (MySqlCommand cmd = new MySqlCommand(queryOps, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                recette.Operations.Add(new Operation
                                {
                                    Id_Operation = Convert.ToInt32(reader["Id_Operation"]),
                                    OPE_Ordre = Convert.ToInt32(reader["CON_NoOperation"]),  // ← Ordre depuis Contenir
                                    OPE_Nom = reader["OPE_Nom"]?.ToString() ?? "",
                                    OPE_PositionMoteur = Convert.ToInt32(reader["OPE_PositionMoteur"]),
                                    OPE_TempsAttente = Convert.ToInt32(reader["OPE_TempsAttente"]),
                                    OPE_CycleVerin = Convert.ToBoolean(reader["OPE_CycleVerin"]),
                                    OPE_Quittance = Convert.ToBoolean(reader["OPE_Quittance"]),
                                    OPE_SensMoteur = Convert.ToBoolean(reader["OPE_SensMoteur"])
                                });
                            }
                        }
                    }
                }
            }
            return recette;
        }

        /// <summary>
/// Compte le nombre d'opérations liées à une recette via la table Contenir.
/// </summary>
/// <param name="idRecette">L'identifiant de la recette.</param>
/// <returns>Le nombre d'opérations.</returns>
public static int CompterOperations(int idRecette)
{
    using (MySqlConnection connection = DBManager.GetConnection())
    {
        connection.OpenIfNot();

        string query = "SELECT COUNT(*) FROM Contenir WHERE Id_Recette = @id";

        using (MySqlCommand cmd = new MySqlCommand(query, connection))
        {
            cmd.Parameters.AddWithValue("@id", idRecette);
            object result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}

        /// <summary>
        /// Supprime une recette et tous les lots associés de la base de données.
        /// </summary>
        /// <param name="nom">nom de la recette à supprimer</param>
        /// <param name="operations">liste des opérations associées</param>
        /// <returns></returns>
        /// <exception cref="Exception">exception levée en cas d'erreur de base de données</exception>
        public static int AjouterRecette(string nom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.OpenIfNot();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Insérer la recette
                        string query = "INSERT INTO recette (REC_Nom, REC_DateHeureCreation) " +
                                      "VALUES (@nom, @date)";
                        int newId;

                        using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nom", nom);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            newId = (int)cmd.LastInsertedId;
                        }

                        // 2. Insérer les opérations et les lier à la recette 
                        foreach (var op in operations)
                        {
                            int noOperation = 1;  //Compteur d'ordre
                            // Insérer l'opération
                            string insertOp = @"INSERT INTO operation
                                (OPE_Nom, OPE_PositionMoteur, OPE_TempsAttente, OPE_CycleVerin,
                                 OPE_Quittance, OPE_SensMoteur)
                                VALUES (@nom, @position, @temps, @verin, @quittance, @sens)";

                            int newOpId;

                            using (MySqlCommand cmd = new MySqlCommand(insertOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nom", op.OPE_Nom);
                                cmd.Parameters.AddWithValue("@position", op.OPE_PositionMoteur);
                                cmd.Parameters.AddWithValue("@temps", op.OPE_TempsAttente);
                                cmd.Parameters.AddWithValue("@verin", op.OPE_CycleVerin);
                                cmd.Parameters.AddWithValue("@quittance", op.OPE_Quittance);
                                cmd.Parameters.AddWithValue("@sens", op.OPE_SensMoteur);

                                cmd.ExecuteNonQuery();
                                newOpId = (int)cmd.LastInsertedId;
                            }

                            // Lier l'opération à la recette, avec l'ordre
                            string insertLien = @"INSERT INTO Contenir
                            (Id_Recette, Id_Operation_est_contenu_dans, CON_NoOperation)
                            VALUES (@idRecette, @idOperation, @noOperation)";

                            using (MySqlCommand cmdLien = new MySqlCommand(insertLien, connection, transaction))
                            {
                                cmdLien.Parameters.AddWithValue("@idRecette", newId);
                                cmdLien.Parameters.AddWithValue("@idOperation", newOpId);
                                cmdLien.Parameters.AddWithValue("@noOperation", noOperation);
                                cmdLien.ExecuteNonQuery();
                            }
                            noOperation++;  //Incrémenter pour la prochaine opération
                        }

                        transaction.Commit();
                        return newId;
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur MySQL lors de la modification :\n{mex.Message}", mex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur lors de la création :\n{ex.Message}", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Modifie une recette existante en mettant à jour son nom et en remplaçant toutes ses opérations associées par une nouvelle liste d'opérations.
        /// </summary>
        /// <param name="idRecette"></param>
        /// <param name="nouveauNom"></param>
        /// <param name="operations"></param>
        /// <exception cref="Exception"></exception>

        public static void ModifierRecette(int idRecette, string nouveauNom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.OpenIfNot();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Modifier le nom de la recette
                        string updateRecette = "UPDATE recette SET REC_Nom = @nom WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(updateRecette, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nom", nouveauNom);
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Récupérer les IDs des opérations liées à cette recette
                        List<int> anciennesOps = new List<int>();
                        string getOps = "SELECT Id_Operation_est_contenu_dans FROM Contenir WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(getOps, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                    anciennesOps.Add(Convert.ToInt32(reader["Id_Operation_est_contenu_dans"]));
                            }
                        }

                        // 3. Supprimer les liens dans Contenir
                        string deleteLiens = "DELETE FROM Contenir WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteLiens, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Supprimer les anciennes opérations
                        foreach (int opId in anciennesOps)
                        {
                            string deleteOp = "DELETE FROM operation WHERE Id_Operation = @opId";
                            using (MySqlCommand cmd = new MySqlCommand(deleteOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@opId", opId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 5. Réinsérer les opérations ET les liens CONTENIR
                        for (int i = 0; i < operations.Count; i++)
                        {
                            var op = operations[i];

                            // Insérer l'opération (SANS Id_Recette dans la table operation)
                            string insertOp = @"INSERT INTO operation
                        (OPE_Nom, OPE_PositionMoteur, OPE_TempsAttente, 
                         OPE_CycleVerin, OPE_Quittance, OPE_SensMoteur)
                        VALUES (@nom, @position, @temps, @verin, @quittance, @sens)";

                            int newOpId;

                            using (MySqlCommand cmd = new MySqlCommand(insertOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nom", op.OPE_Nom);
                                cmd.Parameters.AddWithValue("@position", op.OPE_PositionMoteur);
                                cmd.Parameters.AddWithValue("@temps", op.OPE_TempsAttente);
                                cmd.Parameters.AddWithValue("@verin", op.OPE_CycleVerin);
                                cmd.Parameters.AddWithValue("@quittance", op.OPE_Quittance);
                                cmd.Parameters.AddWithValue("@sens", op.OPE_SensMoteur);

                                cmd.ExecuteNonQuery();
                                newOpId = (int)cmd.LastInsertedId;
                            }

                            // Lier l'opération à la recette avec l'ordre
                            string insertLien = @"INSERT INTO contenir
                        (Id_Operation_est_contenu_dans, Id_Recette, CON_NoOperation)
                        VALUES (@idOp, @idRecette, @noOp)";

                            using (MySqlCommand cmd = new MySqlCommand(insertLien, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idOp", newOpId);
                                cmd.Parameters.AddWithValue("@idRecette", idRecette);
                                cmd.Parameters.AddWithValue("@noOp", i + 1);  //Numéro d'ordre
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur MySQL lors de la modification :\n{mex.Message}", mex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur lors de la modification :\n{ex.Message}", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Supprime une recette et toutes ses opérations associées de la base de données.
        /// </summary>
        /// <param name="idRecette">Identifiant de la recette à supprimer</param>
        /// <exception cref="Exception">exception levée en cas d'erreur de base de données</exception>
        public static void SupprimerRecette(int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.OpenIfNot();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Supprimer les événements associés aux lots
                        string deleteEvenements = @"DELETE FROM evenement
                            WHERE Id_Lot IN (SELECT Id_Lot FROM lot WHERE Id_Recette = @id)";

                        using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Supprimer les lots
                        string deleteLots = "DELETE FROM lot WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(deleteLots, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Supprimer les opérations
                        string deleteOperations = "DELETE FROM operation WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(deleteOperations, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 4. Supprimer la recette
                        string deleteRecette = "DELETE FROM recette WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(deleteRecette, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }
                        // 5. Supprimer les liens associés
                        transaction.Commit();
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur SQL lors de la suppression :\n{mex.Message}", mex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur lors de la suppression :\n{ex.Message}", ex);
                    }
                }
            }
        }
    }

    public static class MySqlConnectionExtensions
    {
        public static void OpenIfNot(this MySqlConnection connection)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
    }
}

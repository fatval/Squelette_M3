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
        //Les requetes SQL utilisées dans la classe Recett
        const string getNombreDeLotsRequete = "SELECT COUNT(*) FROM lot WHERE Id_Recette = @idRecette";
        
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
                    connection.OpenIfNot();

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


        // ═══════════════════════════════════════════════════════════
        // 📖 LECTURE
        // ═══════════════════════════════════════════════════════════

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

        /// <summary>
        ///fonction qui renvoie
        /// </summary>
        /// <param name="id">id de nim</param>
        /// <returns></returns>
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
                    string queryOps = @"SELECT Id_Operation, OPE_Ordre, OPE_Nom, OPE_PositionMoteur,
                                               OPE_TempsAttente, OPE_CycleVerin, OPE_Quittance, OPE_SensMoteur
                                        FROM operation WHERE Id_Recette = @id ORDER BY OPE_Ordre";

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

                            // Lier l'opération à la recette
                            string insertLien = @"INSERT INTO Contenir
                                (Id_Recette, Id_Operation_est_contenu_dans)
                                VALUES (@idRecette, @idOperation)";

                            using (MySqlCommand cmdLien = new MySqlCommand(insertLien, connection, transaction))
                            {
                                cmdLien.Parameters.AddWithValue("@idRecette", newId);
                                cmdLien.Parameters.AddWithValue("@idOperation", newOpId);
                                cmdLien.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return newId;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur lors de la création :\n{ex.Message}", ex);
                    }
                }
            }
        }

         
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

                        // 2. Supprimer les anciennes opérations
                        string deleteOps = "DELETE FROM operation WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(deleteOps, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Réinsérer les opérations
                        foreach (var op in operations)
                        {
                            string insertOp = @"INSERT INTO operation
                                (Id_Recette, OPE_Nom, OPE_PositionMoteur,
                                 OPE_TempsAttente, OPE_CycleVerin, OPE_Quittance, OPE_SensMoteur)
                                VALUES (@idRecette, @nom, @position, @temps, @verin, @quittance, @sens)";

                            using (MySqlCommand cmd = new MySqlCommand(insertOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idRecette", idRecette);
                                cmd.Parameters.AddWithValue("@nom", op.OPE_Nom);
                                cmd.Parameters.AddWithValue("@position", op.OPE_PositionMoteur);
                                cmd.Parameters.AddWithValue("@temps", op.OPE_TempsAttente);
                                cmd.Parameters.AddWithValue("@verin", op.OPE_CycleVerin);
                                cmd.Parameters.AddWithValue("@quittance", op.OPE_Quittance);
                                cmd.Parameters.AddWithValue("@sens", op.OPE_SensMoteur);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (MySqlException mex) // Spécifique à MySQL
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur MySQL lors de la modification :\n{mex.Message}", mex);
                    }
                    catch (Exception ex) // Autres exceptions
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

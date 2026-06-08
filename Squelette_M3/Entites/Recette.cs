using M3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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

        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; } = "";
        public DateTime REC_DateHeureCreation { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();


                    

                    using (MySqlCommand cmd = new MySqlCommand(getNombreDeLotsRequete, connection))
                    {
                        cmd.Parameters.AddWithValue("@idRecette", idRecette);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0; // En cas d'erreur, retourner 0
            }
        }

        /// <summary>
        /// Supprime la recette identifiée ainsi que ses lots, les événements liés et les entrées de la table
        /// associative Contenir, le tout dans une transaction.
        /// </summary>
        /// <remarks>Toutes les opérations sont effectuées dans une transaction ; la transaction est
        /// annulée en cas d'erreur et des messages d'information ou d'erreur sont affichés à l'utilisateur.</remarks>
        /// <param name="idRecette">Identifiant de la recette à supprimer.</param>

        // ─── Supprimer la Recette et ses Lots associés ─────────────────────
        public void SupprimerRecetteAvecLots(int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        
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

                        // si aucun lot n'est associé, on peut directement supprimer la recette sans se soucier des événements
                        if (lotsASupprimer.Count > 0)
                        {
                            string lotsIn = string.Join(",", lotsASupprimer);
                            string deleteEvenements = $"DELETE FROM evenement WHERE Id_Lot IN ({lotsIn})";
                            using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3️PRIMER LES LOTS
                        string deleteLots = "DELETE FROM lot WHERE Id_Recette = @id";//placeholder (@id) pour éviter les injections SQL
                        using (MySqlCommand cmd = new MySqlCommand(deleteLots, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // SUPPRIMER DANS LA TABLE ASSOCIATIVE Contenir
                        string deleteContenir = "DELETE FROM Contenir WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteContenir, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // SUPPRIMER LA RECETTE
                        string deleteRecette = "DELETE FROM recette WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteRecette, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("✅ Recette et ses lots supprimés avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (MySqlException exceptionSql)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"❌ Erreur SQL : {exceptionSql.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception exception)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"❌ Erreur : {exception.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        /// <summary>
        /// Récupère toutes les recettes enregistrées dans la base de données.
        /// </summary>
        /// <remarks>Cette méthode ouvre une connexion à la base de données pour lire les données des
        /// recettes. Elle ne lève pas d'exception si aucune recette n'est présente, mais retourne simplement une liste
        /// vide.</remarks>
        /// <returns>Une liste d'objets <see cref="Recette"/> représentant toutes les recettes. La liste est vide si aucune
        /// recette n'est trouvée.</returns>
        public static List<Recette> GetAll()
        {
            List<Recette> liste = new List<Recette>();

            
            {
                DBManager.GetConnection().Open();
                string query = "SELECT Id_Recette, REC_Nom, REC_DateHeureCreation FROM recette";

                using (MySqlCommand cmd = new MySqlCommand(query, DBManager.GetConnection()))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        liste.Add(new Recette
                        {
                            Id_Recette = Convert.ToInt32(reader["Id_Recette"]),
                            REC_Nom = reader["REC_Nom"].ToString() ?? "",
                            REC_DateHeureCreation = Convert.ToDateTime(reader["REC_DateHeureCreation"])
                        });
                    }
                }
            }
            return liste;
        }
        /// <summary>
        /// Récupère une recette spécifique à partir de son identifiant.
        /// </summary>
        /// <param name="id">L'identifiant de la recette à récupérer.</param>
        /// <returns>L'objet <see cref="Recette"/> représentant la recette trouvée, ou <c>null</c> si aucune recette n'est trouvée.</returns>
        public static Recette GetById(int id)
        {
            Recette recette = null;

            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                string query = "SELECT Id_Recette, REC_Nom, REC_DateHeureCreation FROM recette WHERE Id_Recette = @id";

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
                                REC_Nom = reader["REC_Nom"].ToString() ?? "",
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
                                    OPE_Ordre = Convert.ToInt32(reader["OPE_Ordre"]),
                                    OPE_Nom = reader["OPE_Nom"].ToString() ?? "",
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
        /// Récupère les recettes dont le nom correspond à une recherche partielle.
        /// </summary>
        /// <param name="nom">Le nom de la recette à rechercher.</param>
        /// <param name="operations">La liste des opérations associées à la recette.</param>
        /// <returns>L'identifiant de la recette créée.</returns>
        /// <exception cref="Exception"></exception>
        public static int AjouterRecette(string nom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insérer la recette
                        string query = "INSERT INTO recette (REC_Nom, REC_DateHeureCreation) VALUES (@nom, @date)";
                        int newId;
                        using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nom", nom);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            newId = (int)cmd.LastInsertedId;
                        }

                        // insérer les opérations
                        // 2️⃣ Insérer les opérations et les lier à la recette
                        foreach (var op in operations)
                        {
                            // ÉTAPE A : Insérer l'opération (id auto incrémenté par MySQL)
                            string insertOp = @"INSERT INTO operation 
    (OPE_Nom, OPE_PositionMoteur, OPE_TempsAttente, OPE_CycleVerin, OPE_Quittance, OPE_SensMoteur) 
    VALUES (@nom, @position, @temps, @verin, @quittance, @sens)";

                            int newOpId; // Pour stocker le nouvel ID de l'opération

                            using (MySqlCommand cmd = new MySqlCommand(insertOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@nom", op.OPE_Nom);
                                cmd.Parameters.AddWithValue("@position", op.OPE_PositionMoteur);
                                cmd.Parameters.AddWithValue("@temps", op.OPE_TempsAttente);
                                cmd.Parameters.AddWithValue("@verin", op.OPE_CycleVerin);
                                cmd.Parameters.AddWithValue("@quittance", op.OPE_Quittance);
                                cmd.Parameters.AddWithValue("@sens", op.OPE_SensMoteur);

                                cmd.ExecuteNonQuery();

                                // On récupère l'ID de l'opération qui vient d'être crée
                                newOpId = (int)cmd.LastInsertedId;
                            }

                            // ÉTAPE B : Insérer le lien dans la table associative
                            string insertLien = "INSERT INTO contenir (Id_Recette, Id_Operation_est_contenu_dans) VALUES (@idRecette, @idOperation)";

                            using (MySqlCommand cmdLien = new MySqlCommand(insertLien, connection, transaction))
                            {
                                cmdLien.Parameters.AddWithValue("@idRecette", newId); // L'ID de la recette (créée en 1️)
                                cmdLien.Parameters.AddWithValue("@idOperation", newOpId); // L'ID de l'opération (créée à l'étape A)
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



        /// <summary>
        /// Met à jour une recette et ses opérations associées.
        /// </summary>
        /// <param name="idRecette">L'identifiant de la recette à modifier.</param>
        /// <param name="nouveauNom">Le nouveau nom de la recette.</param>
        /// <param name="operations">La liste des opérations associées à la recette.</param>
        /// <exception cref="Exception"></exception>
        public static void ModifierRecette(int idRecette, string nouveauNom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        
                        string updateRecette = "UPDATE recette SET REC_Nom = @nom WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(updateRecette, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nom", nouveauNom);
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        
                        string deleteOps = "DELETE FROM operation WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteOps, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // Réinsérer les opérations mises à jour
                        foreach (var op in operations)
                        {
                            string insertOp = @"INSERT INTO operation 
                                (Id_Recette, OPE_Ordre, OPE_Nom, OPE_PositionMoteur, OPE_TempsAttente, OPE_CycleVerin, OPE_Quittance, OPE_SensMoteur) 
                                VALUES (@idRecette, @ordre, @nom, @position, @temps, @verin, @quittance, @sens)";

                            using (MySqlCommand cmd = new MySqlCommand(insertOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idRecette", idRecette);
                                cmd.Parameters.AddWithValue("@ordre", op.OPE_Ordre);
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
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur SQL lors de la modification :\n{mex.Message}", mex);
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
        /// Supprime une recette et toutes ses opérations associées.
        /// </summary>
        /// <param name="idRecette">L'identifiant de la recette à supprimer.</param>
        /// <exception cref="Exception"></exception>
        public static void SupprimerRecette(int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1️ Supprimer les événements associés aux lots
                        string deleteEvenements = @"DELETE FROM evenement 
                            WHERE Id_Lot IN (SELECT Id_Lot FROM lot WHERE Id_Recette = @id)";
                        using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 2️ Supprimer les lots
                        string deleteLots = "DELETE FROM lot WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteLots, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 3️⃣ Supprimer les opérations
                        string deleteOperations = "DELETE FROM operation WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteOperations, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 4️⃣ Supprimer la recette
                        string deleteRecette = "DELETE FROM recette WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteRecette, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

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
}

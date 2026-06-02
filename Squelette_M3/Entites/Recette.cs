using M3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Squelette_M3
{
    public class Recette
    {
        public int REC_Id
        {
            get { return Id_Recette; }
            set { Id_Recette = value; }
        }

        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; } = "";
        public DateTime REC_DateHeureCreation { get; set; }
        public List<Operation> Operations { get; set; } = new List<Operation>();

        // ─── Compter les Lots associés à une Recette ───────────────────────
        private int CompterLotsAssocies(int idRecette)
        {
            try
            {
                using (MySqlConnection connection = DBManager.GetConnection())
                {
                    connection.Open();


                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
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
                        // 1️⃣ RÉCUPÉRER TOUS LES LOTS LIÉS À CETTE RECETTE
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

                        // 2️⃣ SUPPRIMER LES ÉVÉNEMENTS DE CES LOTS
                        if (lotsASupprimer.Count > 0)
                        {
                            string lotsIn = string.Join(",", lotsASupprimer);
                            string deleteEvenements = $"DELETE FROM evenement WHERE Id_Lot IN ({lotsIn})";
                            using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3️⃣ SUPPRIMER LES LOTS
                        string deleteLots = "DELETE FROM lot WHERE Id_Recette = @id";//placeholder (@id) pour éviter les injections SQL
                        using (MySqlCommand cmd = new MySqlCommand(deleteLots, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 4️⃣ SUPPRIMER DANS LA TABLE ASSOCIATIVE Contenir
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
                        MessageBox.Show($"❌ Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        // ═══════════════════════════════════════════════════════════
        // 📖 LECTURE
        // ═══════════════════════════════════════════════════════════

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

            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT Id_Recette, REC_Nom, REC_DateHeureCreation FROM recette";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
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

        // ═══════════════════════════════════════════════════════════
        // ✏️ CRÉATION
        // ═══════════════════════════════════════════════════════════

        public static int AjouterRecette(string nom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Insérer la recette
                        string query = "INSERT INTO recette (REC_Nom, REC_DateHeureCreation) VALUES (@nom, @date)";
                        int newId;
                        using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nom", nom);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.ExecuteNonQuery();
                            newId = (int)cmd.LastInsertedId;
                        }

                        // 2️⃣ Insérer les opérations
                        foreach (var op in operations)
                        {
                            string insertOp = @"INSERT INTO operation 
                        (Id_Recette, OPE_Ordre, OPE_Nom, OPE_PositionMoteur, OPE_TempsAttente, OPE_CycleVerin, OPE_Quittance, OPE_SensMoteur) 
                        VALUES (@idRecette, @ordre, @nom, @position, @temps, @verin, @quittance, @sens)";

                            using (MySqlCommand cmd = new MySqlCommand(insertOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@idRecette", newId);
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


        // ═══════════════════════════════════════════════════════════
        // ✏️ MODIFICATION
        // ═══════════════════════════════════════════════════════════

        public static void ModifierRecette(int idRecette, string nouveauNom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Modifier le nom de la recette
                        string updateRecette = "UPDATE recette SET REC_Nom = @nom WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(updateRecette, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nom", nouveauNom);
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 2️⃣ Supprimer les anciennes opérations
                        string deleteOps = "DELETE FROM operation WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteOps, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 3️⃣ Réinsérer les opérations
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

        // ═══════════════════════════════════════════════════════════
        // 🗑️ SUPPRESSION
        // ═══════════════════════════════════════════════════════════

        public static void SupprimerRecette(int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ Supprimer les événements associés aux lots
                        string deleteEvenements = @"DELETE FROM evenement 
                            WHERE Id_Lot IN (SELECT Id_Lot FROM lot WHERE Id_Recette = @id)";
                        using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 2️⃣ Supprimer les lots
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

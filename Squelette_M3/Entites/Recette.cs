/*
 * Auteurs : Noé A-Hadi, Valentin Boegli
 * Date    : 2026
 * Description : Classe Recette - Représente la gamme opératoire d'un type de pièce.
 *               Une recette regroupe de 1 à 10 opérations exécutées dans un ordre précis.
 *
 * Propriétés :
 * - Id_Recette            : Identifiant unique de la recette.
 * - REC_Nom               : Nom unique de la recette (ex: "AM203").
 * - REC_DateHeureCreation : Date et heure de création de la recette.
 * - Operations            : Liste ordonnée des opérations associées (via table Contenir).
 *
 * Méthodes :
 * - GetAll()                          : Retourne toutes les recettes.
 * - GetById(int)                      : Retourne une recette et ses opérations ordonnées.
 * - CompterOperations(int)            : Compte les opérations liées à une recette.
 * - AjouterRecette(string, List)      : Crée une recette + ses opérations (transaction).
 * - ModifierRecette(int, string, List): Met à jour une recette et remplace ses opérations.
 * - SupprimerRecette(int)             : Supprime une recette, ses opérations et ses lots.
 */

using MySql.Data.MySqlClient;

namespace Squelette_M3
{
    public class Recette
    {
        // ─── Propriétés ──────────────────────────────────────────────────────
        public int Id_Recette { get; set; }                                     // PK
        public string REC_Nom { get; set; } = "";                               // Nom unique (ex: "AM203")
        public DateTime REC_DateHeureCreation { get; set; }                     // Date et heure de création
        public List<Operation> Operations { get; set; } = new List<Operation>();// Opérations ordonnées

        /// <summary>
        /// Renvoie la liste de toutes les recettes (sans leurs opérations).
        /// </summary>
        /// <returns>Liste de recettes</returns>
        public static List<Recette> GetAll()
        {
            List<Recette> liste = new List<Recette>();
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

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
        /// Renvoie une recette et la liste ordonnée de ses opérations (via la table Contenir).
        /// </summary>
        /// <param name="id">Identifiant de la recette</param>
        /// <returns>La recette correspondante, ou null si elle n'existe pas</returns>
        public static Recette GetById(int id)
        {
            Recette recette = null;

            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

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
                connection.Open();

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
        /// Crée une nouvelle recette ainsi que ses opérations associées (dans une transaction).
        /// </summary>
        /// <param name="nom">Nom de la recette à créer</param>
        /// <param name="operations">Liste des opérations à associer, dans l'ordre</param>
        /// <returns>L'identifiant de la recette créée</returns>
        /// <exception cref="Exception">Exception levée en cas d'erreur de base de données</exception>
        public static int AjouterRecette(string nom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

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
                        int noOperation = 1;  // Compteur d'ordre
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
                            noOperation++;  // Incrémenter pour la prochaine opération
                        }

                        transaction.Commit();
                        return newId;
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur MySQL lors de la création :\n{mex.Message}", mex);
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
        /// Vérifie si une recette peut être modifiée/supprimée.
        /// Retourne false si elle est liée à des lots dans un état bloquant (En attente/En cours/Erreur).
        /// </summary>
        /// <param name="idRecette">ID de la recette à vérifier</param>
        /// <param name="connection">Connexion MySQL active</param>
        /// <returns>True si la recette peut être modifiée/supprimée, False sinon</returns>
        public static bool PeutEtreModifieeOuSupprimee(int idRecette, MySqlConnection connection)
        {
            string query = @"
                SELECT COUNT(*)
                FROM lot l
                JOIN etat e ON l.Id_Etat = e.Id_Etat
                WHERE l.Id_Recette = @IdRecette
                  AND e.ETA_Libelle IN ('Terminé', 'En production', 'Erreur')";

            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@IdRecette", idRecette);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count == 0;
            }
        }

        /// <summary>
        /// Modifie une recette existante : met à jour son nom et remplace toutes
        /// ses opérations associées par une nouvelle liste d'opérations.
        /// </summary>
        /// <param name="idRecette">Identifiant de la recette à modifier</param>
        /// <param name="nouveauNom">Nouveau nom de la recette</param>
        /// <param name="operations">Nouvelle liste d'opérations, dans l'ordre</param>
        /// <exception cref="Exception">Exception levée en cas d'erreur de base de données</exception>
        /// <exception cref="InvalidOperationException">Levée si la recette est liée à des lots bloquants</exception>
        public static void ModifierRecette(int idRecette, string nouveauNom, List<Operation> operations)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                // 🔴 VÉRIFICATION DES ÉTATS BLOQUANTS AVANT TOUTE OPÉRATION
                if (!PeutEtreModifieeOuSupprimee(idRecette, connection))
                {
                    throw new InvalidOperationException(
                        "❌ Impossible de modifier cette recette : elle est liée à des lots en attente, en cours ou en erreur.\n\n" +
                        "Veuillez terminer ou annuler ces lots avant de modifier la recette.");
                }

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

                            // Insérer l'opération
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
                                cmd.Parameters.AddWithValue("@noOp", i + 1);  // Numéro d'ordre
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
        /// Supprime une recette ainsi que ses opérations, ses liens Contenir,
        /// ses lots associés et les événements de ces lots (dans une transaction).
        /// </summary>
        /// <param name="idRecette">Identifiant de la recette à supprimer</param>
        /// <exception cref="Exception">Exception levée en cas d'erreur de base de données</exception>
        /// <exception cref="InvalidOperationException">Levée si la recette est liée à des lots bloquants</exception>
        public static void SupprimerRecette(int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                //  VÉRIFICATION DES ÉTATS BLOQUANTS AVANT TOUTE OPÉRATION
                if (!PeutEtreModifieeOuSupprimee(idRecette, connection))
                {
                    throw new InvalidOperationException(
                        "❌ Impossible de supprimer cette recette : elle est liée à des lots en cours, en erreur ou terminé.");
                }

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

                        // 2. Supprimer les lots associés à cette recette
                        string deleteLots = "DELETE FROM lot WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(deleteLots, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 3. Récupérer les IDs des opérations liées à cette recette
                        List<int> opsASupprimer = new List<int>();
                        string getOps = "SELECT Id_Operation_est_contenu_dans FROM Contenir WHERE Id_Recette = @id";

                        using (MySqlCommand cmd = new MySqlCommand(getOps, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                    opsASupprimer.Add(Convert.ToInt32(reader["Id_Operation_est_contenu_dans"]));
                            }
                        }

                        // 4. Supprimer les liens dans Contenir
                        string deleteContenir = "DELETE FROM Contenir WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteContenir, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 5. Supprimer les opérations
                        foreach (int opId in opsASupprimer)
                        {
                            string deleteOp = "DELETE FROM operation WHERE Id_Operation = @opId";
                            using (MySqlCommand cmd = new MySqlCommand(deleteOp, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@opId", opId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 6. Supprimer la recette
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

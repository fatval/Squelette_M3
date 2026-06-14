/*
 * Auteur  : Noé A-Hadi, Valentin Boegli
 * Date    : 12.06.2026
 * Description : Classe Lot - Représente un lot de production dans le système de gestion.
 *               Cette classe agit également comme un DTO (Data Transfer Object) pour 
 *               faciliter la liaison de données (DataBinding) avec WinForms.
 *
 * Propriétés :
 * - Id_Lot               : Identifiant unique du lot.
 * - LOT_Nom              : Nom unique du lot.
 * - LOT_Quantite         : Quantité de pièces à produire.
 * - LOT_DateHeureCreation: Date et heure de création du lot.
 * - Id_Etat              : Identifiant de l'état du lot (FK → Etat).
 * - Id_Recette           : Identifiant de la recette associée (FK → Recette).
 *
 * Propriétés ajoutées pour l'affichage (issues de jointures SQL) :
 * - ETA_Libelle          : Libellé de l'état (Ex: "En attente", "En production", ...).
 * - REC_Nom              : Nom de la recette associée.
 *
 * Méthodes :
 * - GetAll()                  : Retourne tous les lots avec recette et état associés.
 * - GetAllAsDataTable()       : Retourne tous les lots sous forme de DataTable.
 * - GetById(int)              : Retourne le détail d'un lot par son Id.
 * - GetByName(string)         : Recherche un lot par nom et retourne son Id.
 * - AjouterLot(...)           : Crée un nouveau lot avec l'état "En attente".
 * - MettreAJourEtat(int, int) : Met à jour l'état d'un lot.
 * - SupprimerLot(int)         : Supprime un lot par son Id.
 */

using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Squelette_M3
{
    public class Lot
    {
        // ─── Propriétés de la table Lot (Miroir strict de la BDD) ────────────
        public int Id_Lot { get; set; }                             // PK
        public string LOT_Nom { get; set; } = "";                   // Nom unique du lot
        public int LOT_Quantite { get; set; }                       // Quantité de pièces à produire
        public DateTime LOT_DateHeureCreation { get; set; }         // Date et heure de création
        public int Id_Etat { get; set; }                            // FK → Etat
        public int Id_Recette { get; set; }                         // FK → Recette

        // ─── Propriétés ajoutées pour l'affichage (Vue / DTO) ────────────────
        // Ces champs sont remplis via des requêtes SQL JOIN.
        // Cela permet de les afficher facilement dans un DataGridView WinForms, 
        // ce composant gérant difficilement la composition de sous-objets.
        public string ETA_Libelle { get; set; } = "";               // Libellé de l'état
        public string REC_Nom { get; set; } = "";                   // Nom de la recette associée


        /// <summary>
        /// Retourne tous les lots avec recette et état associés.
        /// </summary>
        /// <returns>liste de lots</returns>
        public static List<Lot> GetAll()
        {
            List<Lot> liste = new List<Lot>();

            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                string query = @"SELECT l.Id_Lot, l.LOT_Nom, l.LOT_Quantite,
                                        l.LOT_DateHeureCreation, l.Id_Etat, l.Id_Recette,
                                        r.REC_Nom, e.ETA_Libelle
                                 FROM lot l
                                 JOIN recette r ON l.Id_Recette = r.Id_Recette
                                 JOIN etat e    ON l.Id_Etat    = e.Id_Etat
                                 ORDER BY l.LOT_DateHeureCreation DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            liste.Add(new Lot
                            {
                                Id_Lot = Convert.ToInt32(reader["Id_Lot"]),
                                LOT_Nom = reader["LOT_Nom"]?.ToString() ?? "",
                                LOT_Quantite = Convert.ToInt32(reader["LOT_Quantite"]),
                                LOT_DateHeureCreation = Convert.ToDateTime(reader["LOT_DateHeureCreation"]),
                                Id_Etat = Convert.ToInt32(reader["Id_Etat"]),
                                Id_Recette = Convert.ToInt32(reader["Id_Recette"]),
                                REC_Nom = reader["REC_Nom"]?.ToString() ?? "",
                                ETA_Libelle = reader["ETA_Libelle"]?.ToString() ?? ""
                            });
                        }
                    }
                }
            }
            return liste;
        }

        /// <summary>
        /// Retourne tous les lots sous forme de DataTable (pour l'affichage en grille).
        /// </summary>
        /// <returns>DataTable des lots</returns>
        public static DataTable GetAllAsDataTable()
        {
            DataTable dt = new DataTable();

            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                string query = @"SELECT 
                                    l.Id_Lot,
                                    l.LOT_Nom,
                                    l.LOT_Quantite,
                                    e.ETA_Libelle AS Etat,
                                    l.LOT_DateHeureCreation,
                                    r.REC_Nom
                                 FROM lot l
                                 LEFT JOIN etat e    ON l.Id_Etat    = e.Id_Etat
                                 LEFT JOIN recette r ON l.Id_Recette = r.Id_Recette
                                 ORDER BY l.LOT_DateHeureCreation DESC";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection))
                {
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        /// <summary>
        /// Retourne le détail d'un lot par son Id.
        /// </summary>
        /// <param name="id">Identifiant du lot</param>
        /// <returns>DataRow du lot ou null</returns>
        public static DataRow GetById(int id)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                string query = @"SELECT l.LOT_Nom, l.LOT_Quantite, e.ETA_Libelle,
                                        l.LOT_DateHeureCreation, r.REC_Nom
                                 FROM lot l
                                 LEFT JOIN etat e    ON l.Id_Etat    = e.Id_Etat
                                 LEFT JOIN recette r ON l.Id_Recette = r.Id_Recette
                                 WHERE l.Id_Lot = @id";

                DataTable dt = new DataTable();
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
                return dt.Rows.Count > 0 ? dt.Rows[0] : null;
            }
        }

        /// <summary>
        /// Recherche un lot par nom et retourne son Id.
        /// </summary>
        /// <param name="nom">Nom du lot à rechercher</param>
        /// <returns>Id du lot ou -1 si non trouvé</returns>
        public static int GetByName(string nom)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                string query = "SELECT Id_Lot FROM lot WHERE LOT_Nom = @nom";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@nom", nom);
                    object result = cmd.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        /// <summary>
        /// Crée un nouveau lot dans la base de données avec l'état "En attente".
        /// </summary>
        /// <param name="nom">Nom unique du lot</param>
        /// <param name="quantite">Quantité de pièces à produire</param>
        /// <param name="idRecette">Identifiant de la recette associée</param>
        /// <returns>Id du lot créé</returns>
        /// <exception cref="Exception">exception levée en cas d'erreur de base de données</exception>
        public static int AjouterLot(string nom, int quantite, int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Récupérer l'Id de l'état "En attente"
                        int idEtat = 1;
                        string queryEtat = "SELECT Id_Etat FROM etat WHERE ETA_Libelle = 'En attente' LIMIT 1";

                        using (MySqlCommand cmd = new MySqlCommand(queryEtat, connection, transaction))
                        {
                            object result = cmd.ExecuteScalar();
                            if (result != null)
                                idEtat = Convert.ToInt32(result);
                        }

                        // 2. Insérer le lot
                        string query = @"INSERT INTO lot 
                                         (LOT_Nom, LOT_Quantite, LOT_DateHeureCreation, Id_Etat, Id_Recette)
                                         VALUES (@nom, @quantite, @date, @etat, @recette)";
                        int newId;

                        using (MySqlCommand cmd = new MySqlCommand(query, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@nom", nom);
                            cmd.Parameters.AddWithValue("@quantite", quantite);
                            cmd.Parameters.AddWithValue("@date", DateTime.Now);
                            cmd.Parameters.AddWithValue("@etat", idEtat);
                            cmd.Parameters.AddWithValue("@recette", idRecette);
                            cmd.ExecuteNonQuery();
                            newId = (int)cmd.LastInsertedId;
                        }

                        transaction.Commit();
                        return newId;
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur MySQL lors de la création du lot :\n{mex.Message}", mex);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"❌ Erreur lors de la création du lot :\n{ex.Message}", ex);
                    }
                }
            }
        }

        /// <summary>
        /// Met à jour l'état d'un lot.
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <param name="idEtat">Identifiant du nouvel état</param>
        public static void MettreAJourEtat(int idLot, int idEtat)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                string query = "UPDATE lot SET Id_Etat = @etat WHERE Id_Lot = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", idLot);
                    cmd.Parameters.AddWithValue("@etat", idEtat);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Supprime un lot et tous ses événements associés de la base de données.
        /// </summary>
        /// <param name="idLot">Identifiant du lot à supprimer</param>
        /// <exception cref="Exception">exception levée en cas d'erreur de base de données</exception>
        public static void SupprimerLot(int idLot)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Supprimer les événements associés au lot
                        string deleteEvenements = "DELETE FROM evenement WHERE Id_Lot = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idLot);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Supprimer le lot
                        string deleteLot = "DELETE FROM lot WHERE Id_Lot = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteLot, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idLot);
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

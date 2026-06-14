/*
 * Auteur  : Noé A-Hadi, Valentin Boegli
 * Date    : 12.06.2026
 * Description : Classe Evenement - Représente un événement lié à un lot dans le système de gestion de production.
 *
 * Propriétés :
 * - Id_Evenement : Identifiant unique de l'événement.
 * - EVE_Message  : Message décrivant l'événement.
 * - EVE_DateHeure: Date et heure de l'événement.
 * - Id_Lot       : Identifiant du lot associé à l'événement.
 *
 * Méthodes :
 * - GetByLotId(int) : Retourne la liste des événements d'un lot, triés par date croissante.
 */

using MySql.Data.MySqlClient;

namespace Squelette_M3
{
    internal class Evenement
    {
        public int Id_Evenement { get; set; }       // PK
        public string? EVE_Message { get; set; }    // Message décrivant l'événement
        public DateTime EVE_DateHeure { get; set; } // Date et heure de l'événement
        public int Id_Lot { get; set; }             // FK → Lot

        /// <summary>
        /// Obtient tous les événements associés à un lot spécifique, triés par date et heure croissante.
        /// </summary>
        /// <param name="idLot">Identifiant du lot.</param>
        /// <returns>Liste des événements du lot.</returns>
        public static List<Evenement> GetByLotId(int idLot)
        {
            List<Evenement> evenements = new List<Evenement>();

            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Evenement WHERE Id_Lot = @idLot ORDER BY EVE_DateHeure ASC";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idLot", idLot);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            evenements.Add(new Evenement
                            {
                                Id_Evenement = reader.GetInt32("Id_Evenement"),
                                EVE_Message = reader.IsDBNull(reader.GetOrdinal("EVE_Message")) ? string.Empty : reader.GetString("EVE_Message"),
                                EVE_DateHeure = reader.GetDateTime("EVE_DateHeure"),
                                Id_Lot = reader.GetInt32("Id_Lot")
                            });
                        }
                    }
                }
            }

            return evenements;
        }
    }
}

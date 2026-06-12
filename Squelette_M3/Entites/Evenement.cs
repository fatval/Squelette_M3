using MySql.Data.MySqlClient;
using System.Text;
/*/*
 * Classe Evenement : Représente un événement lié à un lot dans le système de gestion de production.
 * 
 * Propriétés :
 * - Id_Evenement : Identifiant unique de l'événement.
 * - EVE_Message : Message décrivant l'événement.
 * - EVE_DateHeure : Date et heure de l'événement.
 * - Id_Lot : Identifiant du lot associé à l'événement.
 * 
 * Méthodes :
 * - AfficherTousLesEvenements() : Affiche dans la console tous les événements présents dans la base de données 'm3'.
 * 
 * Remarques :
 * - Cette classe utilise une connexion à une base de données MySQL pour récupérer les événements. Assurez-vous que la chaîne de connexion est correcte et que la base de données est accessible.
 */
namespace M3.Models
{
    internal class Evenement
    {
        public int Id_Evenement {  get; set; }
        public string EVE_Message {  get; set; }
        public DateTime EVE_DateHeure { get; set; }
        public int Id_Lot {  get; set; }


        /// <summary>
        /// Affiche dans la console tous les événements présents dans la base de données 'm3'.
        /// </summary>
        /// <returns></returns>
        public static string AfficherTousLesEvenements()
        {
            const string CONNEXION_STRING = "server=localhost;user=root;password=;database=m3";
            StringBuilder result = new StringBuilder();

            using (MySqlConnection connection = new MySqlConnection(CONNEXION_STRING))
            {
                connection.Open();
                string query = "SELECT * FROM Evenement";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.AppendLine($"ID: {reader["Id_Evenement"]}, Message: {reader["EVE_Message"]}, Date/Heure: {reader["EVE_DateHeure"]}, ID Lot: {reader["Id_Lot"]}");
                        }
                    }
                }
            }
            return result.ToString();
        }
    }
}


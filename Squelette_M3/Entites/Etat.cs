using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace M3.Entites;


internal class Etat
{
    
    public int Id_Etat { get; set; }
    public string ETA_Libelle { get; set; }

    public static void AfficherTousLesEtats()
    {
        const string CONNEXION_STRING = "server=localhost;user=root;password=;database=m3";
        StringBuilder result = new StringBuilder();
        using (MySqlConnection connection = new MySqlConnection(CONNEXION_STRING))
        {
            connection.Open();
            string query = "SELECT * FROM Etat";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.AppendLine($"ID: {reader["Id_Etat"]}, Libellé: {reader["ETA_Libelle"]}");
                    }
                }
            }
        }
        Console.WriteLine(result.ToString());
    }
}     


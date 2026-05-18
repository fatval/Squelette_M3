using MySql.Data.MySqlClient;

namespace M3.Models
{

    internal class Lot
    {
        private const string _CONNEXION_STRING = "server=localhost;database=m3;user=root;password=;";



        public int Id_Lot { get; set; }
        public string LOT_Nom { get; set; }
        public int LOT_Quantite { get; set; }
        public DateTime LOT_DateHeureCreation { get; set; }
        public int Id_Etat { get; set; }
        public int ETA_Libelle { get; set; }//En attente,En cours, Terminé,Erreur
        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; }


        //rechercher des lots par nom pour retourner leur id
        static int RechercherLotParNom(string nom)
        {
            using (MySqlConnection connection = new MySqlConnection(_CONNEXION_STRING))
            {
                connection.Open();
                string query = "SELECT Id_Lot FROM lot WHERE LOT_Nom = @LOT_Nom";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@LOT_Nom", nom);
                object result = command.ExecuteScalar();
                return result != null ? Convert.ToInt32(result) : -1; // Retourne -1 si aucun lot trouvé
            }
        }

        /// <summary>
        /// Affiche dans la console tous les lots présents dans la base de données 'm3'.
        /// </summary>
        /// <remarks>Cette méthode ouvre une connexion à la base de données MySQL locale, exécute une
        /// requête pour récupérer tous les enregistrements de la table 'lot', puis affiche les informations de chaque
        /// lot dans la console. Utiliser cette méthode à des fins de diagnostic ou d'affichage simple ; elle n'est pas
        /// adaptée à une utilisation dans une interface graphique ou dans des scénarios nécessitant la récupération des
        /// données sous forme structurée.</remarks>
        static void AfficherTousLesLots()
        {
            using (MySqlConnection connection = new MySqlConnection(_CONNEXION_STRING))
            {
                connection.Open();
                string query = "SELECT * FROM lot";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"Id_Lot: {reader["Id_Lot"]}, LOT_Nom: {reader["LOT_Nom"]}, LOT_Quantite: {reader["LOT_Quantite"]}, LOT_DateHeureCreation: {reader["LOT_DateHeureCreation"]}, Id_Etat: {reader["Id_Etat"]}, ETA_Libelle: {reader["ETA_Libelle"]}, Id_Recette: {reader["Id_Recette"]}, REC_Nom: {reader["REC_Nom"]}");
                }
                reader.Close();
            }
        }
        /// <summary>
        /// Crée un nouveau lot dans la base de données avec le nom, la quantité et l'identifiant de recette spécifiés.
        /// </summary>
        /// <param name="nom">Le nom du lot à créer. Ne peut pas être null ou vide.</param>
        /// <param name="quantite">La quantité associée au lot. Doit être supérieure à zéro.</param>
        /// <param name="idRecette">L'identifiant de la recette à associer au lot.</param>
        static void CreerLot(string nom, int quantite, int idRecette)
        {
            using (MySqlConnection connection = new MySqlConnection(_CONNEXION_STRING))
            {
                connection.Open();
                string query = "INSERT INTO lot (LOT_Nom, LOT_Quantite, Id_Recette) VALUES (@LOT_Nom, @LOT_Quantite, @Id_Recette)";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@LOT_Nom", nom);
                command.Parameters.AddWithValue("@LOT_Quantite", quantite);
                command.Parameters.AddWithValue("@Id_Recette", idRecette);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Supprime le lot correspondant à l'identifiant spécifié de la base de données.
        /// </summary>
        /// <remarks>Cette méthode supprime définitivement le lot de la base de données. Aucune exception
        /// n'est levée si l'identifiant ne correspond à aucun lot existant.</remarks>
        /// <param name="idLot">Identifiant unique du lot à supprimer. Doit correspondre à un lot existant dans la base de données.</param>
        static void SupprimerLot(int idLot)
        {
            using (MySqlConnection connection = new MySqlConnection(_CONNEXION_STRING))
            {
                connection.Open();
                string query = "DELETE FROM lot WHERE Id_Lot = @Id_Lot";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Lot", idLot);
                command.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Met à jour l'état d'un lot dans la base de données en fonction de l'identifiant du lot et de l'identifiant
        /// de l'état spécifiés.
        /// </summary>
        /// <remarks>Cette méthode effectue une mise à jour directe dans la base de données. Aucun
        /// contrôle de validité n'est effectué sur les identifiants fournis. Utiliser avec précaution pour éviter des
        /// modifications involontaires.</remarks>
        /// <param name="idLot">L'identifiant unique du lot à mettre à jour. Doit correspondre à un lot existant dans la base de données.</param>
        /// <param name="idEtat">L'identifiant de l'état à appliquer au lot. Doit correspondre à un état valide dans la base de données.</param>
        static void MettreAJourEtatLot(int idLot, int idEtat)
        {
            using (MySqlConnection connection = new MySqlConnection(_CONNEXION_STRING))
            {
                connection.Open();
                string query = "UPDATE lot SET Id_Etat = @Id_Etat WHERE Id_Lot = @Id_Lot";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id_Lot", idLot);
                command.Parameters.AddWithValue("@Id_Etat", idEtat);
                command.ExecuteNonQuery();
            }
        }
    }
}
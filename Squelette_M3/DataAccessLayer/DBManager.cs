// ============================================================
// Fichier     : DBManager.cs
// Auteurs     : Noé A-Hadi, Valentin Boegli
// Date        : 2026
// Description : Classe statique centralisée gérant la connexion
//               à la base de données MySQL. Toutes les classes
//               passent par ici pour obtenir une connexion.
// ============================================================

using MySql.Data.MySqlClient;

namespace Squelette_M3
{
    /// <summary>
    /// Gestionnaire de connexion MySQL.
    /// À initialiser une seule fois au démarrage (Program.cs) via ConnectToDB().
    /// </summary>
    public static class DBManager
    {
        // Chaîne de connexion construite une fois, réutilisée partout. Privée pour empêcher toute modif externe.
        private static string _connectionString;

        /// <summary>
        /// Configure la connexion à la base de données. Doit être appelé avant tout autre méthode.
        /// Le format de la chaîne de connexion est : "server=localhost;database=nomDB;user=nomUser;password=mot
        /// Le port est fixé à 3306 par défaut, mais peut être modifié si nécessaire.
        /// </summary>
        /// <param name="databaseName">Nom de la base (ex: "m3")</param>
        /// <param name="userName">Utilisateur MySQL (ex: "root")</param>
        /// <param name="password">Mot de passe (vide si non défini)</param>
        public static void ConnectToDB(string databaseName, string userName, string password)
        {
            _connectionString = $"server=localhost;database={databaseName};user={userName};password={password};port=3306";

        // Test de connexion
            using (MySqlConnection testConn = new MySqlConnection(_connectionString))
            {
            testConn.Open(); // Lève une exception si ça échoue
            }
        }

        /// <summary>
        /// Configure la connexion à la base de données en utilisant une chaîne de connexion complète.
        /// Doit être appelé avant tout autre méthode.
        /// </summary>
        /// <returns>Une instance de MySqlConnection.</returns>
        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        /// <summary>
        /// Teste si la connexion est fonctionnelle
        /// </summary>
        /// <returns>true si la connexion réussit, false sinon.</returns>
        public static bool TestConnexion()
        {
            bool connexionReussie = false;

            if (!string.IsNullOrEmpty(_connectionString))
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(_connectionString))
                    {
                        conn.Open();
                        connexionReussie = true;
                    }
                }
                catch
                {
                connexionReussie = false; // En cas d'erreur, on retourne false
                }
            }

            return connexionReussie;
        }
    }
}

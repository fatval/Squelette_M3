using MySql.Data.MySqlClient;

public static class DBManager
{
    static private string _connectionString;

    public static void ConnectToDB(string databaseName, string userName, string password)
    {
        _connectionString = $"server=localhost;database={databaseName};user={userName};password={password};port=3306";

        // Test de connexion
        using (MySqlConnection testConn = new MySqlConnection(_connectionString))
        {
            testConn.Open(); // Lève une exception si ça échoue
        }
    }

    // Retourne TOUJOURS une nouvelle connexion fraîche
    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }

    public static bool TestConnexion()
    {
        try
        {
            if (string.IsNullOrEmpty(_connectionString)) return false;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
}

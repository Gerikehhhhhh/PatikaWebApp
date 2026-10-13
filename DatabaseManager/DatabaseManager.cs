using MySql.Data.MySqlClient;

namespace PatikaWebApp.DatabaseManager;

public class DatabaseManager
{
    private string connection_string =
        "Server = localhost;" +
        "Database = patika;" +
        "User = root;" +
        "Password = ;";

    public MySqlConnection CreateConnection()
    {
        MySqlConnection connection = new MySqlConnection(connection_string);

        return connection;
    }
}
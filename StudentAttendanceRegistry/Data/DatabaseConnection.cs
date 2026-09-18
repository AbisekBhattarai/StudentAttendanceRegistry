using System.Configuration;
using MySql.Data.MySqlClient;

namespace StudentAttendanceRegistry.Data;

// Creates MySQL connections using the connection string in App.config
public class DatabaseConnection
{
    // Reads the connection string from App.config
    public static string GetConnectionString()
    {
        ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["AttendanceDb"];
        if (setting == null)
        {
            throw new Exception("No connection string called AttendanceDb was found in App.config.");
        }
        return setting.ConnectionString;
    }

    // Returns a connection that is already open and ready to use
    public static MySqlConnection GetOpenConnection()
    {
        MySqlConnection connection = new MySqlConnection(GetConnectionString());
        connection.Open();
        return connection;
    }

    // Tries to connect so the user can check their settings
    public static bool TestConnection()
    {
        try
        {
            using (MySqlConnection connection = GetOpenConnection())
            {
                return true;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}

using MySql.Data.MySqlClient;
using StudentAttendanceRegistry.Data;

namespace StudentAttendanceRegistry.Services;

// Makes error messages easier to read
public class ErrorMessages
{
    public static string GetFriendlyMessage(Exception ex)
    {
        // Already has a clear message
        if (ex is DatabaseException)
        {
            return ex.Message;
        }

        MySqlException? mysqlError = ex as MySqlException;
        if (mysqlError != null)
        {
            // 1062 duplicate, 1452 missing link, 1406 too long
            if (mysqlError.Number == 1062)
            {
                return "This record already exists, so it was not saved again.";
            }

            if (mysqlError.Number == 1452)
            {
                return "The student or class this record belongs to no longer exists. Please refresh and try again.";
            }

            if (mysqlError.Number == 1406)
            {
                return "One of the values is too long to be saved.";
            }

            return "The database reported a problem:" + Environment.NewLine + Environment.NewLine + ex.Message;
        }

        return "Something went wrong:" + Environment.NewLine + Environment.NewLine + ex.Message;
    }
}

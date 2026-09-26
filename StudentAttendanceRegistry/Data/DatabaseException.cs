namespace StudentAttendanceRegistry.Data;

// Thrown when something goes wrong with the database
public class DatabaseException : Exception
{
    public DatabaseException(string message) : base(message)
    {
    }

    // Keeps the original error too
    public DatabaseException(string message, Exception innerException) : base(message, innerException)
    {
    }
}

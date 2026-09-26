using MySql.Data.MySqlClient;
using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Data;

// Base class for all repositories
public abstract class BaseRepository
{
    // Opens a database connection
    protected MySqlConnection OpenConnection()
    {
        return DatabaseConnection.GetOpenConnection();
    }

    // Reads a student from the current row
    protected Student ReadStudent(MySqlDataReader reader)
    {
        Student student = new Student();
        student.StudentId = reader.GetString("StudentId");
        student.FirstName = reader.GetString("FirstName");
        student.LastName = reader.GetString("LastName");
        if (!reader.IsDBNull(reader.GetOrdinal("Email")))
        {
            student.Email = reader.GetString("Email");
        }
        return student;
    }
}

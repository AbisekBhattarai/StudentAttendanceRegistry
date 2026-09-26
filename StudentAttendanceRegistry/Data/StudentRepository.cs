using MySql.Data.MySqlClient;
using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Data;

// Stores and retrieves students in the Students table
public class StudentRepository : BaseRepository
{
    public List<Student> GetAll()
    {
        List<Student> students = new List<Student>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT StudentId, FirstName, LastName, Email FROM Students ORDER BY StudentId";
            MySqlCommand command = new MySqlCommand(sql, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    students.Add(ReadStudent(reader));
                }
            }
        }

        return students;
    }

    public Student? GetById(string studentId)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT StudentId, FirstName, LastName, Email FROM Students WHERE StudentId = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", studentId);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return ReadStudent(reader);
                }
            }
        }

        return null;
    }

    // Finds students whose id or name contains the search text
    public List<Student> Search(string searchText)
    {
        List<Student> students = new List<Student>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT StudentId, FirstName, LastName, Email FROM Students "
                       + "WHERE StudentId LIKE @text OR FirstName LIKE @text OR LastName LIKE @text "
                       + "ORDER BY StudentId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@text", "%" + searchText + "%");

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    students.Add(ReadStudent(reader));
                }
            }
        }

        return students;
    }

    public void Add(Student student)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "INSERT INTO Students (StudentId, FirstName, LastName, Email) "
                       + "VALUES (@id, @first, @last, @email)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", student.StudentId);
            command.Parameters.AddWithValue("@first", student.FirstName);
            command.Parameters.AddWithValue("@last", student.LastName);
            command.Parameters.AddWithValue("@email", student.Email);
            command.ExecuteNonQuery();
        }
    }

    public void Update(Student student)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "UPDATE Students SET FirstName = @first, LastName = @last, Email = @email "
                       + "WHERE StudentId = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@first", student.FirstName);
            command.Parameters.AddWithValue("@last", student.LastName);
            command.Parameters.AddWithValue("@email", student.Email);
            command.Parameters.AddWithValue("@id", student.StudentId);
            command.ExecuteNonQuery();
        }
    }

    public void Delete(string studentId)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "DELETE FROM Students WHERE StudentId = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", studentId);
            command.ExecuteNonQuery();
        }
    }

    // Used to stop two students having the same id
    public bool Exists(string studentId)
    {
        return GetById(studentId) != null;
    }
}

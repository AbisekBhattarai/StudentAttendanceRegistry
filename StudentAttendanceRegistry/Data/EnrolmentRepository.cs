using MySql.Data.MySqlClient;
using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Data;

// Stores and retrieves enrolments in the Enrolments table
public class EnrolmentRepository : BaseRepository
{
    // Returns the students enrolled in a class
    public List<Student> GetStudentsInClass(int classId)
    {
        List<Student> students = new List<Student>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT s.StudentId, s.FirstName, s.LastName, s.Email "
                       + "FROM Students s JOIN Enrolments e ON s.StudentId = e.StudentId "
                       + "WHERE e.ClassId = @classId ORDER BY s.StudentId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@classId", classId);

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

    // Returns the students who are not enrolled in a class yet
    public List<Student> GetStudentsNotInClass(int classId)
    {
        List<Student> students = new List<Student>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT StudentId, FirstName, LastName, Email FROM Students "
                       + "WHERE StudentId NOT IN (SELECT StudentId FROM Enrolments WHERE ClassId = @classId) "
                       + "ORDER BY StudentId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@classId", classId);

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

    public bool IsEnrolled(string studentId, int classId)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT COUNT(*) FROM Enrolments WHERE StudentId = @studentId AND ClassId = @classId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@classId", classId);

            long count = Convert.ToInt64(command.ExecuteScalar());
            return count > 0;
        }
    }

    public void Enrol(Enrolment enrolment)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "INSERT INTO Enrolments (StudentId, ClassId, EnrolledOn) "
                       + "VALUES (@studentId, @classId, @enrolledOn)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@studentId", enrolment.StudentId);
            command.Parameters.AddWithValue("@classId", enrolment.ClassId);
            command.Parameters.AddWithValue("@enrolledOn", enrolment.EnrolledOn.Date);
            command.ExecuteNonQuery();
        }
    }

    public void Unenrol(string studentId, int classId)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "DELETE FROM Enrolments WHERE StudentId = @studentId AND ClassId = @classId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@classId", classId);
            command.ExecuteNonQuery();
        }
    }
}

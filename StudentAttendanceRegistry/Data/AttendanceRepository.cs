using MySql.Data.MySqlClient;
using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Data;

// Stores and retrieves attendance marks in the Attendance table
public class AttendanceRepository : BaseRepository
{
    // Returns the marks already saved for a class on one date
    public List<AttendanceRecord> GetByClassAndDate(int classId, DateTime date)
    {
        List<AttendanceRecord> records = new List<AttendanceRecord>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT AttendanceId, StudentId, ClassId, AttendanceDate, IsPresent FROM Attendance "
                       + "WHERE ClassId = @classId AND AttendanceDate = @date ORDER BY StudentId";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@classId", classId);
            command.Parameters.AddWithValue("@date", date.Date);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(ReadRecord(reader));
                }
            }
        }

        return records;
    }

    // Returns every mark for one student in one class, oldest date first
    public List<AttendanceRecord> GetByStudentAndClass(string studentId, int classId)
    {
        List<AttendanceRecord> records = new List<AttendanceRecord>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT AttendanceId, StudentId, ClassId, AttendanceDate, IsPresent FROM Attendance "
                       + "WHERE StudentId = @studentId AND ClassId = @classId ORDER BY AttendanceDate";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@studentId", studentId);
            command.Parameters.AddWithValue("@classId", classId);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(ReadRecord(reader));
                }
            }
        }

        return records;
    }

    // Returns every mark saved on one date, for all classes
    public List<AttendanceRecord> GetByDate(DateTime date)
    {
        List<AttendanceRecord> records = new List<AttendanceRecord>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT AttendanceId, StudentId, ClassId, AttendanceDate, IsPresent FROM Attendance "
                       + "WHERE AttendanceDate = @date";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@date", date.Date);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    records.Add(ReadRecord(reader));
                }
            }
        }

        return records;
    }

    // Returns the attended and total counts for every student in every class
    public List<AttendanceSummary> GetSummaries()
    {
        List<AttendanceSummary> summaries = new List<AttendanceSummary>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT s.StudentId, s.FirstName, s.LastName, c.ClassCode, "
                       + "SUM(a.IsPresent) AS Attended, COUNT(*) AS Total "
                       + "FROM Attendance a "
                       + "JOIN Students s ON s.StudentId = a.StudentId "
                       + "JOIN Classes c ON c.ClassId = a.ClassId "
                       + "GROUP BY s.StudentId, s.FirstName, s.LastName, c.ClassCode "
                       + "ORDER BY s.StudentId, c.ClassCode";
            MySqlCommand command = new MySqlCommand(sql, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    AttendanceSummary summary = new AttendanceSummary();
                    summary.StudentId = reader.GetString("StudentId");
                    summary.StudentName = reader.GetString("FirstName") + " " + reader.GetString("LastName");
                    summary.ClassCode = reader.GetString("ClassCode");
                    summary.Attended = Convert.ToInt32(reader["Attended"]);
                    summary.Total = Convert.ToInt32(reader["Total"]);
                    summaries.Add(summary);
                }
            }
        }

        return summaries;
    }

    // True when the class already has marks saved for that date
    public bool HasAttendance(int classId, DateTime date)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT COUNT(*) FROM Attendance WHERE ClassId = @classId AND AttendanceDate = @date";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@classId", classId);
            command.Parameters.AddWithValue("@date", date.Date);

            long count = Convert.ToInt64(command.ExecuteScalar());
            return count > 0;
        }
    }

    // Adds a new mark, or changes the old one if the student was already marked that day
    public void Save(AttendanceRecord record)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string updateSql = "UPDATE Attendance SET IsPresent = @isPresent "
                             + "WHERE StudentId = @studentId AND ClassId = @classId AND AttendanceDate = @date";
            MySqlCommand updateCommand = new MySqlCommand(updateSql, connection);
            AddParameters(updateCommand, record);

            int changed = updateCommand.ExecuteNonQuery();
            if (changed > 0)
            {
                return;
            }

            string insertSql = "INSERT INTO Attendance (StudentId, ClassId, AttendanceDate, IsPresent) "
                             + "VALUES (@studentId, @classId, @date, @isPresent)";
            MySqlCommand insertCommand = new MySqlCommand(insertSql, connection);
            AddParameters(insertCommand, record);
            insertCommand.ExecuteNonQuery();
        }
    }

    // Saves every mark for one class and date
    public void SaveAll(List<AttendanceRecord> records)
    {
        foreach (AttendanceRecord record in records)
        {
            Save(record);
        }
    }

    private void AddParameters(MySqlCommand command, AttendanceRecord record)
    {
        command.Parameters.AddWithValue("@studentId", record.StudentId);
        command.Parameters.AddWithValue("@classId", record.ClassId);
        command.Parameters.AddWithValue("@date", record.AttendanceDate.Date);
        command.Parameters.AddWithValue("@isPresent", record.IsPresent);
    }

    private AttendanceRecord ReadRecord(MySqlDataReader reader)
    {
        AttendanceRecord record = new AttendanceRecord();
        record.AttendanceId = reader.GetInt32("AttendanceId");
        record.StudentId = reader.GetString("StudentId");
        record.ClassId = reader.GetInt32("ClassId");
        record.AttendanceDate = reader.GetDateTime("AttendanceDate");
        record.IsPresent = reader.GetBoolean("IsPresent");
        return record;
    }
}

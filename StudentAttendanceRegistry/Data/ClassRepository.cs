using MySql.Data.MySqlClient;
using StudentAttendanceRegistry.Models;

namespace StudentAttendanceRegistry.Data;

// Stores and retrieves classes in the Classes table
public class ClassRepository : BaseRepository
{
    public List<ClassGroup> GetAll()
    {
        List<ClassGroup> classes = new List<ClassGroup>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT ClassId, ClassCode, ClassName, Teacher FROM Classes ORDER BY ClassCode";
            MySqlCommand command = new MySqlCommand(sql, connection);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    classes.Add(ReadClass(reader));
                }
            }
        }

        return classes;
    }

    public ClassGroup? GetById(int classId)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT ClassId, ClassCode, ClassName, Teacher FROM Classes WHERE ClassId = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", classId);

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return ReadClass(reader);
                }
            }
        }

        return null;
    }

    // Finds classes whose code, name or teacher contains the search text
    public List<ClassGroup> Search(string searchText)
    {
        List<ClassGroup> classes = new List<ClassGroup>();

        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT ClassId, ClassCode, ClassName, Teacher FROM Classes "
                       + "WHERE ClassCode LIKE @text OR ClassName LIKE @text OR Teacher LIKE @text "
                       + "ORDER BY ClassCode";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@text", "%" + searchText + "%");

            using (MySqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    classes.Add(ReadClass(reader));
                }
            }
        }

        return classes;
    }

    public void Add(ClassGroup classGroup)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "INSERT INTO Classes (ClassCode, ClassName, Teacher) "
                       + "VALUES (@code, @name, @teacher)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@code", classGroup.ClassCode);
            command.Parameters.AddWithValue("@name", classGroup.ClassName);
            command.Parameters.AddWithValue("@teacher", classGroup.Teacher);
            command.ExecuteNonQuery();
        }
    }

    public void Update(ClassGroup classGroup)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "UPDATE Classes SET ClassCode = @code, ClassName = @name, Teacher = @teacher "
                       + "WHERE ClassId = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@code", classGroup.ClassCode);
            command.Parameters.AddWithValue("@name", classGroup.ClassName);
            command.Parameters.AddWithValue("@teacher", classGroup.Teacher);
            command.Parameters.AddWithValue("@id", classGroup.ClassId);
            command.ExecuteNonQuery();
        }
    }

    public void Delete(int classId)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "DELETE FROM Classes WHERE ClassId = @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@id", classId);
            command.ExecuteNonQuery();
        }
    }

    // Checks if another class already uses this code
    // Pass the class's own id when updating so it does not count itself
    public bool CodeExists(string classCode, int ignoreClassId)
    {
        using (MySqlConnection connection = OpenConnection())
        {
            string sql = "SELECT COUNT(*) FROM Classes WHERE ClassCode = @code AND ClassId <> @id";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@code", classCode);
            command.Parameters.AddWithValue("@id", ignoreClassId);

            long count = Convert.ToInt64(command.ExecuteScalar());
            return count > 0;
        }
    }

    private ClassGroup ReadClass(MySqlDataReader reader)
    {
        ClassGroup classGroup = new ClassGroup();
        classGroup.ClassId = reader.GetInt32("ClassId");
        classGroup.ClassCode = reader.GetString("ClassCode");
        classGroup.ClassName = reader.GetString("ClassName");
        if (!reader.IsDBNull(reader.GetOrdinal("Teacher")))
        {
            classGroup.Teacher = reader.GetString("Teacher");
        }
        return classGroup;
    }
}

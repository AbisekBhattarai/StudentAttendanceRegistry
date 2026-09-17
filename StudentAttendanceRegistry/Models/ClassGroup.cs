namespace StudentAttendanceRegistry.Models;

// Stores the details of one class
// Called ClassGroup because "class" is a C# keyword
public class ClassGroup
{
    public int ClassId { get; set; }
    public string ClassCode { get; set; } = "";
    public string ClassName { get; set; } = "";
    public string Teacher { get; set; } = "";

    public override string ToString()
    {
        return ClassCode + " - " + ClassName;
    }
}

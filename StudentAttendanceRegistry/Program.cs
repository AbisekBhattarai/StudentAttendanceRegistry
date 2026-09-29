using StudentAttendanceRegistry.Forms;

namespace StudentAttendanceRegistry;

static class Program
{
    // Starts the app and opens the main window
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}

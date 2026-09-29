using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;
using StudentAttendanceRegistry.Validation;

namespace StudentAttendanceRegistry.Forms;

// Marks students present or absent for a class on a date
public partial class AttendanceForm : Form
{
    private ClassRepository classRepository = new ClassRepository();
    private EnrolmentRepository enrolmentRepository = new EnrolmentRepository();
    private AttendanceRepository attendanceRepository = new AttendanceRepository();
    private AttendanceValidator validator = new AttendanceValidator();

    // true when the chosen class and date already have marks in the database
    private bool alreadySaved = false;

    public AttendanceForm()
    {
        InitializeComponent();
        Theme.Apply(this, "Tick the students who were present, then save");

        toolTip.SetToolTip(cboClass, "The class you are taking attendance for");
        toolTip.SetToolTip(dtpDate, "Pick an earlier date to see or change saved marks");
        toolTip.SetToolTip(btnAllPresent, "Tick every student (Ctrl+P)");
        toolTip.SetToolTip(btnAllAbsent, "Untick every student (Ctrl+U)");
        toolTip.SetToolTip(btnSave, "Save the marks for this class and date (Ctrl+S)");
    }

    // Keyboard shortcuts for this page
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == (Keys.Control | Keys.S))
        {
            btnSave.PerformClick();
            return true;
        }
        if (keyData == (Keys.Control | Keys.P))
        {
            SetAll(true);
            return true;
        }
        if (keyData == (Keys.Control | Keys.U))
        {
            SetAll(false);
            return true;
        }
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void AttendanceForm_Load(object sender, EventArgs e)
    {
        // attendance cannot be marked for a future date
        dtpDate.MaxDate = DateTime.Today;
        dtpDate.Value = DateTime.Today;

        try
        {
            List<ClassGroup> classes = classRepository.GetAll();
            if (classes.Count == 0)
            {
                MessageBox.Show("There are no classes yet. Please add a class on the Classes page first.", "No classes",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // setting the data source picks the first class and loads its students
            cboClass.DataSource = classes;
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadStudents();
    }

    private void dtpDate_ValueChanged(object sender, EventArgs e)
    {
        LoadStudents();
    }

    // Puts one row in the grid for each student enrolled in the chosen class
    private void LoadStudents()
    {
        dgvAttendance.Rows.Clear();
        alreadySaved = false;

        ClassGroup? classGroup = cboClass.SelectedItem as ClassGroup;
        if (classGroup == null)
        {
            UpdateSummary();
            return;
        }

        try
        {
            List<Student> students = enrolmentRepository.GetStudentsInClass(classGroup.ClassId);

            // marks that were saved for this class and date before
            List<AttendanceRecord> saved = attendanceRepository.GetByClassAndDate(classGroup.ClassId, dtpDate.Value);
            alreadySaved = saved.Count > 0;

            foreach (Student student in students)
            {
                // everyone starts as present so the teacher only has to untick absent students
                bool isPresent = true;

                foreach (AttendanceRecord record in saved)
                {
                    if (record.StudentId == student.StudentId)
                    {
                        isPresent = record.IsPresent;
                    }
                }

                dgvAttendance.Rows.Add(student.StudentId, student.FullName, isPresent);
            }

            if (students.Count == 0)
            {
                lblSummary.Text = "No students are enrolled in this class.";
                return;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }

        UpdateSummary();
    }

    private void btnAllPresent_Click(object sender, EventArgs e)
    {
        SetAll(true);
    }

    private void btnAllAbsent_Click(object sender, EventArgs e)
    {
        SetAll(false);
    }

    private void SetAll(bool isPresent)
    {
        foreach (DataGridViewRow row in dgvAttendance.Rows)
        {
            row.Cells["colPresent"].Value = isPresent;
        }
        UpdateSummary();
    }

    // Commits a tick straight away so the summary updates without leaving the cell
    private void dgvAttendance_CurrentCellDirtyStateChanged(object sender, EventArgs e)
    {
        if (dgvAttendance.IsCurrentCellDirty)
        {
            dgvAttendance.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }

    private void dgvAttendance_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        UpdateSummary();
    }

    private void btnSave_Click(object sender, EventArgs e)
    {
        ClassGroup? classGroup = cboClass.SelectedItem as ClassGroup;
        if (classGroup == null || dgvAttendance.Rows.Count == 0)
        {
            MessageBox.Show("There is nothing to save. Enrol students in this class on the Enrolments page first.",
                "Save attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        // build one record for every row in the grid
        List<AttendanceRecord> records = new List<AttendanceRecord>();
        foreach (DataGridViewRow row in dgvAttendance.Rows)
        {
            // every student must be marked present or absent
            if (row.Cells["colPresent"].Value == null)
            {
                string name = Convert.ToString(row.Cells["colStudentName"].Value) ?? "";
                MessageBox.Show("Please mark " + name + " as present or absent.", "Save attendance",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AttendanceRecord record = new AttendanceRecord();
            record.StudentId = Convert.ToString(row.Cells["colStudentId"].Value) ?? "";
            record.ClassId = classGroup.ClassId;
            record.AttendanceDate = dtpDate.Value.Date;
            record.IsPresent = Convert.ToBoolean(row.Cells["colPresent"].Value);
            records.Add(record);
        }

        string message = validator.ValidateAll(records);
        if (message != "")
        {
            MessageBox.Show(message, "Save attendance", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            attendanceRepository.SaveAll(records);
            alreadySaved = true;
            MessageBox.Show("Attendance saved for " + classGroup.ClassCode + " on " + dtpDate.Value.ToShortDateString() + ".",
                "Save attendance", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateSummary();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void UpdateSummary()
    {
        int total = dgvAttendance.Rows.Count;
        int present = 0;

        foreach (DataGridViewRow row in dgvAttendance.Rows)
        {
            if (Convert.ToBoolean(row.Cells["colPresent"].Value))
            {
                present++;
            }
        }

        lblSummary.Text = "Present: " + present + " of " + total + "    Absent: " + (total - present);

        if (alreadySaved)
        {
            lblSummary.Text = lblSummary.Text + "    (saved earlier - you can change it and save again)";
        }
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

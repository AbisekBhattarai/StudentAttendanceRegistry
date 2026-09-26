using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;
using StudentAttendanceRegistry.Validation;

namespace StudentAttendanceRegistry.Forms;

public partial class ClassForm : Form
{
    private ClassRepository repository = new ClassRepository();
    private ClassValidator validator = new ClassValidator();

    // Id of the class picked in the grid, 0 when nothing is picked
    private int selectedClassId = 0;

    public ClassForm()
    {
        InitializeComponent();
    }

    private void ClassForm_Load(object sender, EventArgs e)
    {
        LoadClasses();
    }

    private void LoadClasses()
    {
        try
        {
            ShowClasses(repository.GetAll());
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void ShowClasses(List<ClassGroup> classes)
    {
        dgvClasses.DataSource = classes;

        // the user does not need to see the database id
        DataGridViewColumn? idColumn = dgvClasses.Columns["ClassId"];
        if (idColumn != null)
        {
            idColumn.Visible = false;
        }
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        ClassGroup classGroup = ReadFormFields();

        string message = validator.Validate(classGroup);
        if (message != "")
        {
            MessageBox.Show(message, "Please check the details");
            return;
        }

        try
        {
            if (repository.CodeExists(classGroup.ClassCode, 0))
            {
                MessageBox.Show("A class with that code already exists.", "Duplicate class");
                return;
            }

            repository.Add(classGroup);
            LoadClasses();
            ClearFields();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (selectedClassId == 0)
        {
            MessageBox.Show("Please choose a class from the list first.", "No class selected");
            return;
        }

        ClassGroup classGroup = ReadFormFields();
        classGroup.ClassId = selectedClassId;

        string message = validator.Validate(classGroup);
        if (message != "")
        {
            MessageBox.Show(message, "Please check the details");
            return;
        }

        try
        {
            if (repository.CodeExists(classGroup.ClassCode, classGroup.ClassId))
            {
                MessageBox.Show("Another class already uses that code.", "Duplicate class");
                return;
            }

            repository.Update(classGroup);
            LoadClasses();
            ClearFields();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (selectedClassId == 0)
        {
            MessageBox.Show("Please choose a class from the list first.", "No class selected");
            return;
        }

        // deleting a class also removes its enrolments and attendance (ON DELETE CASCADE)
        DialogResult answer = MessageBox.Show("Delete class " + txtClassCode.Text.Trim()
            + "? Its enrolments and attendance records will also be deleted.", "Confirm delete",
            MessageBoxButtons.YesNo);
        if (answer != DialogResult.Yes)
        {
            return;
        }

        try
        {
            repository.Delete(selectedClassId);
            LoadClasses();
            ClearFields();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnSearch_Click(object sender, EventArgs e)
    {
        try
        {
            ShowClasses(repository.Search(txtSearch.Text.Trim()));
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void btnShowAll_Click(object sender, EventArgs e)
    {
        txtSearch.Text = "";
        LoadClasses();
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        ClearFields();
    }

    // Copies the details of the row the user clicked into the text boxes
    private void dgvClasses_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvClasses.SelectedRows.Count == 0)
        {
            return;
        }

        ClassGroup? classGroup = dgvClasses.SelectedRows[0].DataBoundItem as ClassGroup;
        if (classGroup == null)
        {
            return;
        }

        selectedClassId = classGroup.ClassId;
        txtClassCode.Text = classGroup.ClassCode;
        txtClassName.Text = classGroup.ClassName;
        txtTeacher.Text = classGroup.Teacher;
    }

    private ClassGroup ReadFormFields()
    {
        ClassGroup classGroup = new ClassGroup();
        classGroup.ClassCode = txtClassCode.Text.Trim().ToUpper();
        classGroup.ClassName = txtClassName.Text.Trim();
        classGroup.Teacher = txtTeacher.Text.Trim();
        return classGroup;
    }

    private void ClearFields()
    {
        selectedClassId = 0;
        txtClassCode.Text = "";
        txtClassName.Text = "";
        txtTeacher.Text = "";
        dgvClasses.ClearSelection();
        txtClassCode.Focus();
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error");
    }
}

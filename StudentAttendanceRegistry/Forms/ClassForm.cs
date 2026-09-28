using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;

namespace StudentAttendanceRegistry.Forms;

// Lists the classes; adding and editing happen in ClassEditForm
public partial class ClassForm : Form
{
    private ClassRepository repository = new ClassRepository();

    public ClassForm()
    {
        InitializeComponent();
        Theme.Apply(this, "Add, edit and remove classes");
    }

    private void ClassForm_Load(object sender, EventArgs e)
    {
        LoadClasses();
    }

    // Shows the classes that match the search box (all of them when it is empty)
    private void LoadClasses()
    {
        try
        {
            List<ClassGroup> classes = repository.Search(txtSearch.Text.Trim());
            dgvClasses.DataSource = classes;
            if (classes.Count == 1)
            {
                lblCount.Text = "1 class";
            }
            else
            {
                lblCount.Text = classes.Count + " classes";
            }

            // the user does not need to see the database id
            DataGridViewColumn? idColumn = dgvClasses.Columns["ClassId"];
            if (idColumn != null)
            {
                idColumn.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private void txtSearch_TextChanged(object sender, EventArgs e)
    {
        LoadClasses();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        using (ClassEditForm dialog = new ClassEditForm(null))
        {
            if (dialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                LoadClasses();
            }
        }
    }

    private void btnEdit_Click(object sender, EventArgs e)
    {
        EditSelectedClass();
    }

    private void dgvClasses_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        // ignore double clicks on the header row
        if (e.RowIndex >= 0)
        {
            EditSelectedClass();
        }
    }

    private void EditSelectedClass()
    {
        ClassGroup? classGroup = GetSelectedClass();
        if (classGroup == null)
        {
            MessageBox.Show("Please click a class in the list, then press Edit.", "No class selected",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        using (ClassEditForm dialog = new ClassEditForm(classGroup))
        {
            if (dialog.ShowDialog(ParentForm) == DialogResult.OK)
            {
                LoadClasses();
            }
        }
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        ClassGroup? classGroup = GetSelectedClass();
        if (classGroup == null)
        {
            MessageBox.Show("Please click a class in the list, then press Delete.", "No class selected",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        // deleting a class also removes its enrolments and attendance (ON DELETE CASCADE)
        // No is the default button so pressing Enter by mistake does not delete anything
        DialogResult answer = MessageBox.Show("Delete class " + classGroup.ClassCode
            + "? Its enrolments and attendance records will also be deleted.", "Confirm delete",
            MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        if (answer != DialogResult.Yes)
        {
            return;
        }

        try
        {
            repository.Delete(classGroup.ClassId);
            LoadClasses();
        }
        catch (Exception ex)
        {
            ShowError(ex);
        }
    }

    private ClassGroup? GetSelectedClass()
    {
        if (dgvClasses.SelectedRows.Count == 0)
        {
            return null;
        }
        return dgvClasses.SelectedRows[0].DataBoundItem as ClassGroup;
    }

    private void ShowError(Exception ex)
    {
        MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

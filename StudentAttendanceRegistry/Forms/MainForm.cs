using StudentAttendanceRegistry.Data;
using StudentAttendanceRegistry.Models;
using StudentAttendanceRegistry.Services;

namespace StudentAttendanceRegistry.Forms;

// The main window: a sidebar on the left and the open page on the right
public partial class MainForm : Form
{
    private Form? currentPage = null;
    private List<Button> navButtons = new List<Button>();

    public MainForm()
    {
        InitializeComponent();

        BackColor = Theme.Background;
        pnlContent.BackColor = Theme.Background;
        pnlSidebar.BackColor = Theme.Sidebar;
        lblAppName.ForeColor = Color.White;
        lblAppSub.ForeColor = Theme.SidebarText;
        lblWelcome.ForeColor = Theme.DarkText;
        lblWelcomeSub.ForeColor = Theme.MutedText;

        navButtons.Add(btnHome);
        navButtons.Add(btnManageStudents);
        navButtons.Add(btnManageClasses);
        navButtons.Add(btnManageEnrolments);
        navButtons.Add(btnRecordAttendance);
        navButtons.Add(btnViewHistory);
        navButtons.Add(btnViewReport);
        foreach (Button button in navButtons)
        {
            Theme.StyleNavButton(button);
        }

        StyleCard(pnlStudentsCard, pnlStudentsAccent, lblStudentsCount, lblStudentsCaption, Theme.Primary);
        StyleCard(pnlClassesCard, pnlClassesAccent, lblClassesCount, lblClassesCaption, Color.FromArgb(124, 58, 237));
        StyleCard(pnlEnrolmentsCard, pnlEnrolmentsAccent, lblEnrolmentsCount, lblEnrolmentsCaption, Color.FromArgb(13, 148, 136));
        StyleCard(pnlTodayCard, pnlTodayAccent, lblTodayPercent, lblTodayCaption, Theme.Success);

        pnlAlerts.BackColor = Color.White;
        lblAlertsTitle.ForeColor = Theme.DarkText;
        lblAlertsSub.ForeColor = Theme.MutedText;
        lblNoAlerts.ForeColor = Theme.MutedText;
        Theme.StyleGrid(dgvAlerts);
        dgvAlerts.BorderStyle = BorderStyle.None;
        dgvAlerts.DataBindingComplete += dgvAlerts_DataBindingComplete;
    }

    private void dgvAlerts_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
    {
        dgvAlerts.ClearSelection();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        ShowHome();
    }

    private void btnHome_Click(object sender, EventArgs e)
    {
        ShowHome();
    }

    private void btnManageStudents_Click(object sender, EventArgs e)
    {
        ShowPage(new StudentForm(), btnManageStudents);
    }

    private void btnManageClasses_Click(object sender, EventArgs e)
    {
        ShowPage(new ClassForm(), btnManageClasses);
    }

    private void btnManageEnrolments_Click(object sender, EventArgs e)
    {
        ShowPage(new EnrolmentForm(), btnManageEnrolments);
    }

    private void btnRecordAttendance_Click(object sender, EventArgs e)
    {
        ShowPage(new AttendanceForm(), btnRecordAttendance);
    }

    private void btnViewHistory_Click(object sender, EventArgs e)
    {
        ShowPage(new HistoryForm(), btnViewHistory);
    }

    private void btnViewReport_Click(object sender, EventArgs e)
    {
        ShowPage(new ReportForm(), btnViewReport);
    }

    // Opens a form inside the main window instead of as a pop-up
    private void ShowPage(Form page, Button navButton)
    {
        ClosePage();
        pnlHome.Visible = false;

        page.TopLevel = false;
        page.FormBorderStyle = FormBorderStyle.None;
        page.MinimumSize = Size.Empty;
        page.Dock = DockStyle.Fill;
        pnlContent.Controls.Add(page);
        page.Show();

        currentPage = page;
        SetActive(navButton);
    }

    private void ShowHome()
    {
        ClosePage();
        pnlHome.Visible = true;
        SetActive(btnHome);
        LoadDashboard();
    }

    private void ClosePage()
    {
        if (currentPage != null)
        {
            pnlContent.Controls.Remove(currentPage);
            currentPage.Close();
            currentPage = null;
        }
    }

    private void SetActive(Button activeButton)
    {
        foreach (Button button in navButtons)
        {
            Theme.SetNavActive(button, button == activeButton);
        }

        // take focus off the sidebar so no outline is drawn around the button
        ActiveControl = null;
    }

    // Fills the cards and the low attendance table
    private void LoadDashboard()
    {
        lblWelcomeSub.Text = DateTime.Today.ToString("dddd, d MMMM yyyy");

        if (!DatabaseConnection.TestConnection())
        {
            ShowDatabaseStatus(false);
            ShowAlerts(new List<AttendanceSummary>());
            return;
        }

        ShowDatabaseStatus(true);

        try
        {
            lblStudentsCount.Text = new StudentRepository().GetAll().Count.ToString();
            lblClassesCount.Text = new ClassRepository().GetAll().Count.ToString();
            lblEnrolmentsCount.Text = new EnrolmentRepository().CountAll().ToString();

            AttendanceRepository attendanceRepository = new AttendanceRepository();
            List<AttendanceRecord> today = attendanceRepository.GetByDate(DateTime.Today);
            if (today.Count == 0)
            {
                lblTodayPercent.Text = "-";
                lblTodayCaption.Text = "No attendance saved today";
            }
            else
            {
                AttendanceCalculator calculator = new AttendanceCalculator();
                lblTodayPercent.Text = calculator.GetPercentage(today) + "%";
                lblTodayCaption.Text = calculator.CountAttended(today) + " of " + today.Count + " present today";
            }

            // only keep students under the minimum
            List<AttendanceSummary> lowStudents = new List<AttendanceSummary>();
            foreach (AttendanceSummary summary in attendanceRepository.GetSummaries())
            {
                if (summary.Percentage < AttendanceCalculator.MinimumPercentage)
                {
                    lowStudents.Add(summary);
                }
            }
            ShowAlerts(lowStudents);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ErrorMessages.GetFriendlyMessage(ex), "Error");
        }
    }

    private void ShowDatabaseStatus(bool online)
    {
        if (online)
        {
            lblDbStatus.Text = "● Database online";
            lblDbStatus.ForeColor = Theme.Success;
        }
        else
        {
            lblDbStatus.Text = "● Database offline";
            lblDbStatus.ForeColor = Theme.Danger;
            lblStudentsCount.Text = "-";
            lblClassesCount.Text = "-";
            lblEnrolmentsCount.Text = "-";
            lblTodayPercent.Text = "-";
            lblTodayCaption.Text = "Start MySQL in XAMPP";
        }
    }

    private void ShowAlerts(List<AttendanceSummary> lowStudents)
    {
        dgvAlerts.DataSource = lowStudents;
        dgvAlerts.Visible = lowStudents.Count > 0;
        lblNoAlerts.Visible = lowStudents.Count == 0;

        DataGridViewColumn? percentColumn = dgvAlerts.Columns["Percentage"];
        if (percentColumn != null)
        {
            percentColumn.DefaultCellStyle.ForeColor = Theme.Danger;
            percentColumn.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        // nothing is picked here, so no row needs to look selected
        dgvAlerts.ClearSelection();
    }

    private void StyleCard(Panel card, Panel accent, Label number, Label caption, Color accentColor)
    {
        card.BackColor = Color.White;
        accent.BackColor = accentColor;
        number.ForeColor = Theme.DarkText;
        caption.ForeColor = Theme.MutedText;
    }
}

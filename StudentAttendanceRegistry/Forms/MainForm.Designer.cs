namespace StudentAttendanceRegistry.Forms;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        pnlSidebar = new Panel();
        lblAppName = new Label();
        lblAppSub = new Label();
        btnHome = new Button();
        btnManageStudents = new Button();
        btnManageClasses = new Button();
        btnManageEnrolments = new Button();
        btnRecordAttendance = new Button();
        btnViewHistory = new Button();
        btnViewReport = new Button();
        lblDbStatus = new Label();
        pnlContent = new Panel();
        pnlHome = new Panel();
        lblWelcome = new Label();
        lblWelcomeSub = new Label();
        pnlStudentsCard = new Panel();
        pnlStudentsAccent = new Panel();
        lblStudentsCount = new Label();
        lblStudentsCaption = new Label();
        pnlClassesCard = new Panel();
        pnlClassesAccent = new Panel();
        lblClassesCount = new Label();
        lblClassesCaption = new Label();
        pnlEnrolmentsCard = new Panel();
        pnlEnrolmentsAccent = new Panel();
        lblEnrolmentsCount = new Label();
        lblEnrolmentsCaption = new Label();
        pnlTodayCard = new Panel();
        pnlTodayAccent = new Panel();
        lblTodayPercent = new Label();
        lblTodayCaption = new Label();
        pnlAlerts = new Panel();
        lblAlertsTitle = new Label();
        lblAlertsSub = new Label();
        lblNoAlerts = new Label();
        dgvAlerts = new DataGridView();
        pnlSidebar.SuspendLayout();
        pnlContent.SuspendLayout();
        pnlHome.SuspendLayout();
        pnlStudentsCard.SuspendLayout();
        pnlClassesCard.SuspendLayout();
        pnlEnrolmentsCard.SuspendLayout();
        pnlTodayCard.SuspendLayout();
        pnlAlerts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAlerts).BeginInit();
        SuspendLayout();
        //
        // pnlSidebar
        //
        pnlSidebar.Controls.Add(lblDbStatus);
        pnlSidebar.Controls.Add(btnViewReport);
        pnlSidebar.Controls.Add(btnViewHistory);
        pnlSidebar.Controls.Add(btnRecordAttendance);
        pnlSidebar.Controls.Add(btnManageEnrolments);
        pnlSidebar.Controls.Add(btnManageClasses);
        pnlSidebar.Controls.Add(btnManageStudents);
        pnlSidebar.Controls.Add(btnHome);
        pnlSidebar.Controls.Add(lblAppSub);
        pnlSidebar.Controls.Add(lblAppName);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(220, 680);
        pnlSidebar.TabIndex = 0;
        //
        // lblAppName
        //
        lblAppName.AutoSize = true;
        lblAppName.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblAppName.Location = new Point(20, 24);
        lblAppName.Name = "lblAppName";
        lblAppName.Size = new Size(170, 25);
        lblAppName.TabIndex = 0;
        lblAppName.Text = "Attendance";
        //
        // lblAppSub
        //
        lblAppSub.AutoSize = true;
        lblAppSub.Location = new Point(22, 54);
        lblAppSub.Name = "lblAppSub";
        lblAppSub.Size = new Size(110, 15);
        lblAppSub.TabIndex = 1;
        lblAppSub.Text = "Student registry";
        //
        // btnHome
        //
        btnHome.Location = new Point(0, 100);
        btnHome.Name = "btnHome";
        btnHome.Size = new Size(220, 42);
        btnHome.TabIndex = 2;
        btnHome.Text = "Dashboard";
        btnHome.UseVisualStyleBackColor = true;
        btnHome.Click += btnHome_Click;
        //
        // btnManageStudents
        //
        btnManageStudents.Location = new Point(0, 142);
        btnManageStudents.Name = "btnManageStudents";
        btnManageStudents.Size = new Size(220, 42);
        btnManageStudents.TabIndex = 3;
        btnManageStudents.Text = "Students";
        btnManageStudents.UseVisualStyleBackColor = true;
        btnManageStudents.Click += btnManageStudents_Click;
        //
        // btnManageClasses
        //
        btnManageClasses.Location = new Point(0, 184);
        btnManageClasses.Name = "btnManageClasses";
        btnManageClasses.Size = new Size(220, 42);
        btnManageClasses.TabIndex = 4;
        btnManageClasses.Text = "Classes";
        btnManageClasses.UseVisualStyleBackColor = true;
        btnManageClasses.Click += btnManageClasses_Click;
        //
        // btnManageEnrolments
        //
        btnManageEnrolments.Location = new Point(0, 226);
        btnManageEnrolments.Name = "btnManageEnrolments";
        btnManageEnrolments.Size = new Size(220, 42);
        btnManageEnrolments.TabIndex = 5;
        btnManageEnrolments.Text = "Enrolments";
        btnManageEnrolments.UseVisualStyleBackColor = true;
        btnManageEnrolments.Click += btnManageEnrolments_Click;
        //
        // btnRecordAttendance
        //
        btnRecordAttendance.Location = new Point(0, 268);
        btnRecordAttendance.Name = "btnRecordAttendance";
        btnRecordAttendance.Size = new Size(220, 42);
        btnRecordAttendance.TabIndex = 6;
        btnRecordAttendance.Text = "Record Attendance";
        btnRecordAttendance.UseVisualStyleBackColor = true;
        btnRecordAttendance.Click += btnRecordAttendance_Click;
        //
        // btnViewHistory
        //
        btnViewHistory.Location = new Point(0, 310);
        btnViewHistory.Name = "btnViewHistory";
        btnViewHistory.Size = new Size(220, 42);
        btnViewHistory.TabIndex = 7;
        btnViewHistory.Text = "History";
        btnViewHistory.UseVisualStyleBackColor = true;
        btnViewHistory.Click += btnViewHistory_Click;
        //
        // btnViewReport
        //
        btnViewReport.Location = new Point(0, 352);
        btnViewReport.Name = "btnViewReport";
        btnViewReport.Size = new Size(220, 42);
        btnViewReport.TabIndex = 8;
        btnViewReport.Text = "Report";
        btnViewReport.UseVisualStyleBackColor = true;
        btnViewReport.Click += btnViewReport_Click;
        //
        // lblDbStatus
        //
        lblDbStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
        lblDbStatus.AutoSize = true;
        lblDbStatus.Location = new Point(22, 645);
        lblDbStatus.Name = "lblDbStatus";
        lblDbStatus.Size = new Size(110, 15);
        lblDbStatus.TabIndex = 9;
        lblDbStatus.Text = "● Checking database";
        //
        // pnlContent
        //
        pnlContent.AutoScroll = true;
        pnlContent.Controls.Add(pnlHome);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(220, 0);
        pnlContent.Name = "pnlContent";
        pnlContent.Padding = new Padding(10);
        pnlContent.Size = new Size(980, 680);
        pnlContent.TabIndex = 1;
        //
        // pnlHome
        //
        pnlHome.Controls.Add(pnlAlerts);
        pnlHome.Controls.Add(pnlTodayCard);
        pnlHome.Controls.Add(pnlEnrolmentsCard);
        pnlHome.Controls.Add(pnlClassesCard);
        pnlHome.Controls.Add(pnlStudentsCard);
        pnlHome.Controls.Add(lblWelcomeSub);
        pnlHome.Controls.Add(lblWelcome);
        pnlHome.Dock = DockStyle.Fill;
        pnlHome.Location = new Point(10, 10);
        pnlHome.Name = "pnlHome";
        pnlHome.Size = new Size(960, 660);
        pnlHome.TabIndex = 0;
        //
        // lblWelcome
        //
        lblWelcome.AutoSize = true;
        lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblWelcome.Location = new Point(16, 18);
        lblWelcome.Name = "lblWelcome";
        lblWelcome.Size = new Size(130, 32);
        lblWelcome.TabIndex = 0;
        lblWelcome.Text = "Dashboard";
        //
        // lblWelcomeSub
        //
        lblWelcomeSub.AutoSize = true;
        lblWelcomeSub.Font = new Font("Segoe UI", 9.5F);
        lblWelcomeSub.Location = new Point(20, 60);
        lblWelcomeSub.Name = "lblWelcomeSub";
        lblWelcomeSub.Size = new Size(200, 17);
        lblWelcomeSub.TabIndex = 1;
        lblWelcomeSub.Text = "Today";
        //
        // pnlStudentsCard
        //
        pnlStudentsCard.Controls.Add(lblStudentsCaption);
        pnlStudentsCard.Controls.Add(lblStudentsCount);
        pnlStudentsCard.Controls.Add(pnlStudentsAccent);
        pnlStudentsCard.Location = new Point(20, 106);
        pnlStudentsCard.Name = "pnlStudentsCard";
        pnlStudentsCard.Size = new Size(215, 104);
        pnlStudentsCard.TabIndex = 2;
        //
        // pnlStudentsAccent
        //
        pnlStudentsAccent.Dock = DockStyle.Left;
        pnlStudentsAccent.Location = new Point(0, 0);
        pnlStudentsAccent.Name = "pnlStudentsAccent";
        pnlStudentsAccent.Size = new Size(4, 104);
        pnlStudentsAccent.TabIndex = 0;
        //
        // lblStudentsCount
        //
        lblStudentsCount.AutoSize = true;
        lblStudentsCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblStudentsCount.Location = new Point(20, 14);
        lblStudentsCount.Name = "lblStudentsCount";
        lblStudentsCount.Size = new Size(35, 41);
        lblStudentsCount.TabIndex = 1;
        lblStudentsCount.Text = "-";
        //
        // lblStudentsCaption
        //
        lblStudentsCaption.AutoSize = true;
        lblStudentsCaption.Location = new Point(23, 68);
        lblStudentsCaption.Name = "lblStudentsCaption";
        lblStudentsCaption.Size = new Size(53, 15);
        lblStudentsCaption.TabIndex = 2;
        lblStudentsCaption.Text = "Students";
        //
        // pnlClassesCard
        //
        pnlClassesCard.Controls.Add(lblClassesCaption);
        pnlClassesCard.Controls.Add(lblClassesCount);
        pnlClassesCard.Controls.Add(pnlClassesAccent);
        pnlClassesCard.Location = new Point(255, 106);
        pnlClassesCard.Name = "pnlClassesCard";
        pnlClassesCard.Size = new Size(215, 104);
        pnlClassesCard.TabIndex = 3;
        //
        // pnlClassesAccent
        //
        pnlClassesAccent.Dock = DockStyle.Left;
        pnlClassesAccent.Location = new Point(0, 0);
        pnlClassesAccent.Name = "pnlClassesAccent";
        pnlClassesAccent.Size = new Size(4, 104);
        pnlClassesAccent.TabIndex = 0;
        //
        // lblClassesCount
        //
        lblClassesCount.AutoSize = true;
        lblClassesCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblClassesCount.Location = new Point(20, 14);
        lblClassesCount.Name = "lblClassesCount";
        lblClassesCount.Size = new Size(35, 41);
        lblClassesCount.TabIndex = 1;
        lblClassesCount.Text = "-";
        //
        // lblClassesCaption
        //
        lblClassesCaption.AutoSize = true;
        lblClassesCaption.Location = new Point(23, 68);
        lblClassesCaption.Name = "lblClassesCaption";
        lblClassesCaption.Size = new Size(45, 15);
        lblClassesCaption.TabIndex = 2;
        lblClassesCaption.Text = "Classes";
        //
        // pnlEnrolmentsCard
        //
        pnlEnrolmentsCard.Controls.Add(lblEnrolmentsCaption);
        pnlEnrolmentsCard.Controls.Add(lblEnrolmentsCount);
        pnlEnrolmentsCard.Controls.Add(pnlEnrolmentsAccent);
        pnlEnrolmentsCard.Location = new Point(490, 106);
        pnlEnrolmentsCard.Name = "pnlEnrolmentsCard";
        pnlEnrolmentsCard.Size = new Size(215, 104);
        pnlEnrolmentsCard.TabIndex = 4;
        //
        // pnlEnrolmentsAccent
        //
        pnlEnrolmentsAccent.Dock = DockStyle.Left;
        pnlEnrolmentsAccent.Location = new Point(0, 0);
        pnlEnrolmentsAccent.Name = "pnlEnrolmentsAccent";
        pnlEnrolmentsAccent.Size = new Size(4, 104);
        pnlEnrolmentsAccent.TabIndex = 0;
        //
        // lblEnrolmentsCount
        //
        lblEnrolmentsCount.AutoSize = true;
        lblEnrolmentsCount.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblEnrolmentsCount.Location = new Point(20, 14);
        lblEnrolmentsCount.Name = "lblEnrolmentsCount";
        lblEnrolmentsCount.Size = new Size(35, 41);
        lblEnrolmentsCount.TabIndex = 1;
        lblEnrolmentsCount.Text = "-";
        //
        // lblEnrolmentsCaption
        //
        lblEnrolmentsCaption.AutoSize = true;
        lblEnrolmentsCaption.Location = new Point(23, 68);
        lblEnrolmentsCaption.Name = "lblEnrolmentsCaption";
        lblEnrolmentsCaption.Size = new Size(66, 15);
        lblEnrolmentsCaption.TabIndex = 2;
        lblEnrolmentsCaption.Text = "Enrolments";
        //
        // pnlTodayCard
        //
        pnlTodayCard.Controls.Add(lblTodayCaption);
        pnlTodayCard.Controls.Add(lblTodayPercent);
        pnlTodayCard.Controls.Add(pnlTodayAccent);
        pnlTodayCard.Location = new Point(725, 106);
        pnlTodayCard.Name = "pnlTodayCard";
        pnlTodayCard.Size = new Size(215, 104);
        pnlTodayCard.TabIndex = 5;
        //
        // pnlTodayAccent
        //
        pnlTodayAccent.Dock = DockStyle.Left;
        pnlTodayAccent.Location = new Point(0, 0);
        pnlTodayAccent.Name = "pnlTodayAccent";
        pnlTodayAccent.Size = new Size(4, 104);
        pnlTodayAccent.TabIndex = 0;
        //
        // lblTodayPercent
        //
        lblTodayPercent.AutoSize = true;
        lblTodayPercent.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblTodayPercent.Location = new Point(20, 14);
        lblTodayPercent.Name = "lblTodayPercent";
        lblTodayPercent.Size = new Size(35, 41);
        lblTodayPercent.TabIndex = 1;
        lblTodayPercent.Text = "-";
        //
        // lblTodayCaption
        //
        lblTodayCaption.AutoSize = true;
        lblTodayCaption.Location = new Point(23, 68);
        lblTodayCaption.Name = "lblTodayCaption";
        lblTodayCaption.Size = new Size(95, 15);
        lblTodayCaption.TabIndex = 2;
        lblTodayCaption.Text = "Present today";
        //
        // pnlAlerts
        //
        pnlAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        pnlAlerts.Controls.Add(dgvAlerts);
        pnlAlerts.Controls.Add(lblNoAlerts);
        pnlAlerts.Controls.Add(lblAlertsSub);
        pnlAlerts.Controls.Add(lblAlertsTitle);
        pnlAlerts.Location = new Point(20, 230);
        pnlAlerts.Name = "pnlAlerts";
        pnlAlerts.Size = new Size(920, 410);
        pnlAlerts.TabIndex = 6;
        //
        // lblAlertsTitle
        //
        lblAlertsTitle.AutoSize = true;
        lblAlertsTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblAlertsTitle.Location = new Point(18, 16);
        lblAlertsTitle.Name = "lblAlertsTitle";
        lblAlertsTitle.Size = new Size(120, 20);
        lblAlertsTitle.TabIndex = 0;
        lblAlertsTitle.Text = "Low attendance";
        //
        // lblAlertsSub
        //
        lblAlertsSub.AutoSize = true;
        lblAlertsSub.Location = new Point(20, 42);
        lblAlertsSub.Name = "lblAlertsSub";
        lblAlertsSub.Size = new Size(200, 15);
        lblAlertsSub.TabIndex = 1;
        lblAlertsSub.Text = "Students below 75% attendance in a class";
        //
        // lblNoAlerts
        //
        lblNoAlerts.AutoSize = true;
        lblNoAlerts.Location = new Point(20, 80);
        lblNoAlerts.Name = "lblNoAlerts";
        lblNoAlerts.Size = new Size(200, 15);
        lblNoAlerts.TabIndex = 2;
        lblNoAlerts.Text = "No students are below 75%.";
        lblNoAlerts.Visible = false;
        //
        // dgvAlerts
        //
        dgvAlerts.AllowUserToAddRows = false;
        dgvAlerts.AllowUserToDeleteRows = false;
        dgvAlerts.AllowUserToResizeRows = false;
        dgvAlerts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAlerts.Location = new Point(20, 72);
        dgvAlerts.MultiSelect = false;
        dgvAlerts.Name = "dgvAlerts";
        dgvAlerts.ReadOnly = true;
        dgvAlerts.RowHeadersVisible = false;
        dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAlerts.Size = new Size(880, 318);
        dgvAlerts.TabIndex = 3;
        //
        // MainForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1200, 680);
        Controls.Add(pnlContent);
        Controls.Add(pnlSidebar);
        MinimumSize = new Size(1216, 719);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Student Attendance Registry";
        WindowState = FormWindowState.Maximized;
        Load += MainForm_Load;
        pnlSidebar.ResumeLayout(false);
        pnlSidebar.PerformLayout();
        pnlContent.ResumeLayout(false);
        pnlHome.ResumeLayout(false);
        pnlHome.PerformLayout();
        pnlStudentsCard.ResumeLayout(false);
        pnlStudentsCard.PerformLayout();
        pnlClassesCard.ResumeLayout(false);
        pnlClassesCard.PerformLayout();
        pnlEnrolmentsCard.ResumeLayout(false);
        pnlEnrolmentsCard.PerformLayout();
        pnlTodayCard.ResumeLayout(false);
        pnlTodayCard.PerformLayout();
        pnlAlerts.ResumeLayout(false);
        pnlAlerts.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAlerts).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlSidebar;
    private Label lblAppName;
    private Label lblAppSub;
    private Button btnHome;
    private Button btnManageStudents;
    private Button btnManageClasses;
    private Button btnManageEnrolments;
    private Button btnRecordAttendance;
    private Button btnViewHistory;
    private Button btnViewReport;
    private Label lblDbStatus;
    private Panel pnlContent;
    private Panel pnlHome;
    private Label lblWelcome;
    private Label lblWelcomeSub;
    private Panel pnlStudentsCard;
    private Panel pnlStudentsAccent;
    private Label lblStudentsCount;
    private Label lblStudentsCaption;
    private Panel pnlClassesCard;
    private Panel pnlClassesAccent;
    private Label lblClassesCount;
    private Label lblClassesCaption;
    private Panel pnlEnrolmentsCard;
    private Panel pnlEnrolmentsAccent;
    private Label lblEnrolmentsCount;
    private Label lblEnrolmentsCaption;
    private Panel pnlTodayCard;
    private Panel pnlTodayAccent;
    private Label lblTodayPercent;
    private Label lblTodayCaption;
    private Panel pnlAlerts;
    private Label lblAlertsTitle;
    private Label lblAlertsSub;
    private Label lblNoAlerts;
    private DataGridView dgvAlerts;
}

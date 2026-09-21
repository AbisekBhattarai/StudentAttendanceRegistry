namespace StudentAttendanceRegistry.Forms;

partial class AttendanceForm
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
        lblClass = new Label();
        cboClass = new ComboBox();
        lblDate = new Label();
        dtpDate = new DateTimePicker();
        btnAllPresent = new Button();
        btnAllAbsent = new Button();
        btnSave = new Button();
        lblSummary = new Label();
        dgvAttendance = new DataGridView();
        colStudentId = new DataGridViewTextBoxColumn();
        colStudentName = new DataGridViewTextBoxColumn();
        colPresent = new DataGridViewCheckBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvAttendance).BeginInit();
        SuspendLayout();
        //
        // lblClass
        //
        lblClass.AutoSize = true;
        lblClass.Location = new Point(20, 25);
        lblClass.Name = "lblClass";
        lblClass.Size = new Size(34, 15);
        lblClass.TabIndex = 0;
        lblClass.Text = "Class";
        //
        // cboClass
        //
        cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
        cboClass.Location = new Point(110, 22);
        cboClass.Name = "cboClass";
        cboClass.Size = new Size(470, 23);
        cboClass.TabIndex = 1;
        cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
        //
        // lblDate
        //
        lblDate.AutoSize = true;
        lblDate.Location = new Point(20, 60);
        lblDate.Name = "lblDate";
        lblDate.Size = new Size(31, 15);
        lblDate.TabIndex = 2;
        lblDate.Text = "Date";
        //
        // dtpDate
        //
        dtpDate.Format = DateTimePickerFormat.Short;
        dtpDate.Location = new Point(110, 57);
        dtpDate.Name = "dtpDate";
        dtpDate.Size = new Size(180, 23);
        dtpDate.TabIndex = 3;
        dtpDate.ValueChanged += dtpDate_ValueChanged;
        //
        // btnAllPresent
        //
        btnAllPresent.Location = new Point(610, 20);
        btnAllPresent.Name = "btnAllPresent";
        btnAllPresent.Size = new Size(85, 27);
        btnAllPresent.TabIndex = 4;
        btnAllPresent.Text = "All Present";
        btnAllPresent.UseVisualStyleBackColor = true;
        btnAllPresent.Click += btnAllPresent_Click;
        //
        // btnAllAbsent
        //
        btnAllAbsent.Location = new Point(700, 20);
        btnAllAbsent.Name = "btnAllAbsent";
        btnAllAbsent.Size = new Size(85, 27);
        btnAllAbsent.TabIndex = 5;
        btnAllAbsent.Text = "All Absent";
        btnAllAbsent.UseVisualStyleBackColor = true;
        btnAllAbsent.Click += btnAllAbsent_Click;
        //
        // btnSave
        //
        btnSave.Location = new Point(700, 55);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(85, 27);
        btnSave.TabIndex = 6;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        //
        // lblSummary
        //
        lblSummary.AutoSize = true;
        lblSummary.Location = new Point(20, 105);
        lblSummary.Name = "lblSummary";
        lblSummary.Size = new Size(120, 15);
        lblSummary.TabIndex = 7;
        lblSummary.Text = "Present: 0 of 0";
        //
        // dgvAttendance
        //
        dgvAttendance.AllowUserToAddRows = false;
        dgvAttendance.AllowUserToDeleteRows = false;
        dgvAttendance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvAttendance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAttendance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvAttendance.Columns.AddRange(new DataGridViewColumn[] { colStudentId, colStudentName, colPresent });
        dgvAttendance.Location = new Point(20, 130);
        dgvAttendance.MultiSelect = false;
        dgvAttendance.Name = "dgvAttendance";
        dgvAttendance.RowHeadersVisible = false;
        dgvAttendance.Size = new Size(765, 315);
        dgvAttendance.TabIndex = 8;
        dgvAttendance.CellValueChanged += dgvAttendance_CellValueChanged;
        dgvAttendance.CurrentCellDirtyStateChanged += dgvAttendance_CurrentCellDirtyStateChanged;
        //
        // colStudentId
        //
        colStudentId.HeaderText = "Student ID";
        colStudentId.Name = "colStudentId";
        colStudentId.ReadOnly = true;
        //
        // colStudentName
        //
        colStudentName.HeaderText = "Name";
        colStudentName.Name = "colStudentName";
        colStudentName.ReadOnly = true;
        //
        // colPresent
        //
        colPresent.HeaderText = "Present";
        colPresent.Name = "colPresent";
        //
        // AttendanceForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(805, 465);
        Controls.Add(dgvAttendance);
        Controls.Add(lblSummary);
        Controls.Add(btnSave);
        Controls.Add(btnAllAbsent);
        Controls.Add(btnAllPresent);
        Controls.Add(dtpDate);
        Controls.Add(lblDate);
        Controls.Add(cboClass);
        Controls.Add(lblClass);
        MinimumSize = new Size(821, 504);
        Name = "AttendanceForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Record Attendance";
        Load += AttendanceForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvAttendance).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblClass;
    private ComboBox cboClass;
    private Label lblDate;
    private DateTimePicker dtpDate;
    private Button btnAllPresent;
    private Button btnAllAbsent;
    private Button btnSave;
    private Label lblSummary;
    private DataGridView dgvAttendance;
    private DataGridViewTextBoxColumn colStudentId;
    private DataGridViewTextBoxColumn colStudentName;
    private DataGridViewCheckBoxColumn colPresent;
}

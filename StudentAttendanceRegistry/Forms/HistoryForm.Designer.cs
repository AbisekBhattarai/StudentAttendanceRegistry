namespace StudentAttendanceRegistry.Forms;

partial class HistoryForm
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
        lblStudent = new Label();
        cboStudent = new ComboBox();
        lblClass = new Label();
        cboClass = new ComboBox();
        lblMessage = new Label();
        lblStats = new Label();
        dgvHistory = new DataGridView();
        colDate = new DataGridViewTextBoxColumn();
        colStatus = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
        SuspendLayout();
        //
        // lblStudent
        //
        lblStudent.AutoSize = true;
        lblStudent.Location = new Point(20, 25);
        lblStudent.Name = "lblStudent";
        lblStudent.Size = new Size(48, 15);
        lblStudent.TabIndex = 0;
        lblStudent.Text = "Student";
        //
        // cboStudent
        //
        cboStudent.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStudent.Location = new Point(110, 22);
        cboStudent.Name = "cboStudent";
        cboStudent.Size = new Size(430, 23);
        cboStudent.TabIndex = 1;
        cboStudent.SelectedIndexChanged += cboStudent_SelectedIndexChanged;
        //
        // lblClass
        //
        lblClass.AutoSize = true;
        lblClass.Location = new Point(20, 60);
        lblClass.Name = "lblClass";
        lblClass.Size = new Size(34, 15);
        lblClass.TabIndex = 2;
        lblClass.Text = "Class";
        //
        // cboClass
        //
        cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
        cboClass.Location = new Point(110, 57);
        cboClass.Name = "cboClass";
        cboClass.Size = new Size(430, 23);
        cboClass.TabIndex = 3;
        cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
        //
        // lblMessage
        //
        lblMessage.AutoSize = true;
        lblMessage.Location = new Point(20, 100);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(0, 15);
        lblMessage.TabIndex = 4;
        //
        // lblStats
        //
        lblStats.AutoSize = true;
        lblStats.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStats.Location = new Point(20, 125);
        lblStats.Name = "lblStats";
        lblStats.Size = new Size(0, 15);
        lblStats.TabIndex = 5;
        //
        // dgvHistory
        //
        dgvHistory.AllowUserToAddRows = false;
        dgvHistory.AllowUserToDeleteRows = false;
        dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvHistory.Columns.AddRange(new DataGridViewColumn[] { colDate, colStatus });
        dgvHistory.Location = new Point(20, 150);
        dgvHistory.MultiSelect = false;
        dgvHistory.Name = "dgvHistory";
        dgvHistory.ReadOnly = true;
        dgvHistory.RowHeadersVisible = false;
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHistory.Size = new Size(520, 300);
        dgvHistory.TabIndex = 6;
        //
        // colDate
        //
        colDate.HeaderText = "Date";
        colDate.Name = "colDate";
        colDate.ReadOnly = true;
        //
        // colStatus
        //
        colStatus.HeaderText = "Status";
        colStatus.Name = "colStatus";
        colStatus.ReadOnly = true;
        //
        // HistoryForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(560, 470);
        Controls.Add(dgvHistory);
        Controls.Add(lblStats);
        Controls.Add(lblMessage);
        Controls.Add(cboClass);
        Controls.Add(lblClass);
        Controls.Add(cboStudent);
        Controls.Add(lblStudent);
        MinimumSize = new Size(576, 509);
        Name = "HistoryForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Attendance History";
        Load += HistoryForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblStudent;
    private ComboBox cboStudent;
    private Label lblClass;
    private ComboBox cboClass;
    private Label lblMessage;
    private Label lblStats;
    private DataGridView dgvHistory;
    private DataGridViewTextBoxColumn colDate;
    private DataGridViewTextBoxColumn colStatus;
}

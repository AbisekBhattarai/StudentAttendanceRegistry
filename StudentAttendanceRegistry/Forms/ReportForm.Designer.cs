namespace StudentAttendanceRegistry.Forms;

partial class ReportForm
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
        lblMessage = new Label();
        lblKey = new Label();
        dgvReport = new DataGridView();
        colStudentId = new DataGridViewTextBoxColumn();
        colName = new DataGridViewTextBoxColumn();
        colAttended = new DataGridViewTextBoxColumn();
        colAbsent = new DataGridViewTextBoxColumn();
        colPercentage = new DataGridViewTextBoxColumn();
        ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
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
        cboClass.Size = new Size(490, 23);
        cboClass.TabIndex = 1;
        cboClass.SelectedIndexChanged += cboClass_SelectedIndexChanged;
        //
        // lblMessage
        //
        lblMessage.AutoSize = true;
        lblMessage.Location = new Point(20, 60);
        lblMessage.Name = "lblMessage";
        lblMessage.Size = new Size(0, 15);
        lblMessage.TabIndex = 2;
        //
        // lblKey
        //
        lblKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblKey.AutoSize = true;
        lblKey.BackColor = Color.MistyRose;
        lblKey.ForeColor = Color.DarkRed;
        lblKey.Location = new Point(410, 60);
        lblKey.Name = "lblKey";
        lblKey.Size = new Size(185, 15);
        lblKey.TabIndex = 4;
        lblKey.Text = "Red rows: below 75% attendance";
        //
        // dgvReport
        //
        dgvReport.AllowUserToAddRows = false;
        dgvReport.AllowUserToDeleteRows = false;
        dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvReport.Columns.AddRange(new DataGridViewColumn[] { colStudentId, colName, colAttended, colAbsent, colPercentage });
        dgvReport.Location = new Point(20, 90);
        dgvReport.MultiSelect = false;
        dgvReport.Name = "dgvReport";
        dgvReport.ReadOnly = true;
        dgvReport.RowHeadersVisible = false;
        dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvReport.Size = new Size(580, 360);
        dgvReport.TabIndex = 3;
        //
        // colStudentId
        //
        colStudentId.HeaderText = "Student ID";
        colStudentId.Name = "colStudentId";
        colStudentId.ReadOnly = true;
        //
        // colName
        //
        colName.FillWeight = 180F;
        colName.HeaderText = "Name";
        colName.Name = "colName";
        colName.ReadOnly = true;
        //
        // colAttended
        //
        colAttended.HeaderText = "Attended";
        colAttended.Name = "colAttended";
        colAttended.ReadOnly = true;
        //
        // colAbsent
        //
        colAbsent.HeaderText = "Absent";
        colAbsent.Name = "colAbsent";
        colAbsent.ReadOnly = true;
        //
        // colPercentage
        //
        colPercentage.HeaderText = "Attendance %";
        colPercentage.Name = "colPercentage";
        colPercentage.ReadOnly = true;
        //
        // ReportForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(620, 470);
        Controls.Add(dgvReport);
        Controls.Add(lblKey);
        Controls.Add(lblMessage);
        Controls.Add(cboClass);
        Controls.Add(lblClass);
        MinimumSize = new Size(636, 509);
        Name = "ReportForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Attendance Summary Report";
        Load += ReportForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblClass;
    private ComboBox cboClass;
    private Label lblMessage;
    private Label lblKey;
    private DataGridView dgvReport;
    private DataGridViewTextBoxColumn colStudentId;
    private DataGridViewTextBoxColumn colName;
    private DataGridViewTextBoxColumn colAttended;
    private DataGridViewTextBoxColumn colAbsent;
    private DataGridViewTextBoxColumn colPercentage;
}

namespace StudentAttendanceRegistry.Forms;

partial class EnrolmentForm
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
        lblStudent = new Label();
        cboStudent = new ComboBox();
        btnEnrol = new Button();
        btnRemove = new Button();
        lblCount = new Label();
        dgvEnrolled = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvEnrolled).BeginInit();
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
        // lblStudent
        //
        lblStudent.AutoSize = true;
        lblStudent.Location = new Point(20, 60);
        lblStudent.Name = "lblStudent";
        lblStudent.Size = new Size(48, 15);
        lblStudent.TabIndex = 2;
        lblStudent.Text = "Student";
        //
        // cboStudent
        //
        cboStudent.DropDownStyle = ComboBoxStyle.DropDownList;
        cboStudent.Location = new Point(110, 57);
        cboStudent.Name = "cboStudent";
        cboStudent.Size = new Size(470, 23);
        cboStudent.TabIndex = 3;
        //
        // btnEnrol
        //
        btnEnrol.Location = new Point(610, 55);
        btnEnrol.Name = "btnEnrol";
        btnEnrol.Size = new Size(85, 27);
        btnEnrol.TabIndex = 4;
        btnEnrol.Text = "Enrol";
        btnEnrol.UseVisualStyleBackColor = true;
        btnEnrol.Click += btnEnrol_Click;
        //
        // btnRemove
        //
        btnRemove.Location = new Point(700, 55);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new Size(85, 27);
        btnRemove.TabIndex = 5;
        btnRemove.Text = "Remove";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += btnRemove_Click;
        //
        // lblCount
        //
        lblCount.AutoSize = true;
        lblCount.Location = new Point(20, 105);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(110, 15);
        lblCount.TabIndex = 6;
        lblCount.Text = "Students enrolled: 0";
        //
        // dgvEnrolled
        //
        dgvEnrolled.AllowUserToAddRows = false;
        dgvEnrolled.AllowUserToDeleteRows = false;
        dgvEnrolled.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvEnrolled.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvEnrolled.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvEnrolled.Location = new Point(20, 130);
        dgvEnrolled.MultiSelect = false;
        dgvEnrolled.Name = "dgvEnrolled";
        dgvEnrolled.ReadOnly = true;
        dgvEnrolled.RowHeadersVisible = false;
        dgvEnrolled.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvEnrolled.Size = new Size(765, 315);
        dgvEnrolled.TabIndex = 7;
        //
        // EnrolmentForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(805, 465);
        Controls.Add(dgvEnrolled);
        Controls.Add(lblCount);
        Controls.Add(btnRemove);
        Controls.Add(btnEnrol);
        Controls.Add(cboStudent);
        Controls.Add(lblStudent);
        Controls.Add(cboClass);
        Controls.Add(lblClass);
        MinimumSize = new Size(821, 504);
        Name = "EnrolmentForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Manage Enrolments";
        Load += EnrolmentForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvEnrolled).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblClass;
    private ComboBox cboClass;
    private Label lblStudent;
    private ComboBox cboStudent;
    private Button btnEnrol;
    private Button btnRemove;
    private Label lblCount;
    private DataGridView dgvEnrolled;
}

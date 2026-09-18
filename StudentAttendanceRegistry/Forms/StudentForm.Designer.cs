namespace StudentAttendanceRegistry.Forms;

partial class StudentForm
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
        lblStudentId = new Label();
        txtStudentId = new TextBox();
        lblFirstName = new Label();
        txtFirstName = new TextBox();
        lblLastName = new Label();
        txtLastName = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnClear = new Button();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        btnShowAll = new Button();
        dgvStudents = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
        SuspendLayout();
        //
        // lblStudentId
        //
        lblStudentId.AutoSize = true;
        lblStudentId.Location = new Point(20, 25);
        lblStudentId.Name = "lblStudentId";
        lblStudentId.Size = new Size(64, 15);
        lblStudentId.TabIndex = 0;
        lblStudentId.Text = "Student ID";
        //
        // txtStudentId
        //
        txtStudentId.Location = new Point(110, 22);
        txtStudentId.Name = "txtStudentId";
        txtStudentId.Size = new Size(180, 23);
        txtStudentId.TabIndex = 1;
        //
        // lblFirstName
        //
        lblFirstName.AutoSize = true;
        lblFirstName.Location = new Point(20, 60);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(64, 15);
        lblFirstName.TabIndex = 2;
        lblFirstName.Text = "First Name";
        //
        // txtFirstName
        //
        txtFirstName.Location = new Point(110, 57);
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(180, 23);
        txtFirstName.TabIndex = 3;
        //
        // lblLastName
        //
        lblLastName.AutoSize = true;
        lblLastName.Location = new Point(320, 60);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(63, 15);
        lblLastName.TabIndex = 4;
        lblLastName.Text = "Last Name";
        //
        // txtLastName
        //
        txtLastName.Location = new Point(400, 57);
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(180, 23);
        txtLastName.TabIndex = 5;
        //
        // lblEmail
        //
        lblEmail.AutoSize = true;
        lblEmail.Location = new Point(320, 25);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(36, 15);
        lblEmail.TabIndex = 6;
        lblEmail.Text = "Email";
        //
        // txtEmail
        //
        txtEmail.Location = new Point(400, 22);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(180, 23);
        txtEmail.TabIndex = 7;
        //
        // btnAdd
        //
        btnAdd.Location = new Point(610, 20);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(85, 27);
        btnAdd.TabIndex = 8;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        //
        // btnUpdate
        //
        btnUpdate.Location = new Point(700, 20);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(85, 27);
        btnUpdate.TabIndex = 9;
        btnUpdate.Text = "Update";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        //
        // btnDelete
        //
        btnDelete.Location = new Point(610, 55);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(85, 27);
        btnDelete.TabIndex = 10;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // btnClear
        //
        btnClear.Location = new Point(700, 55);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(85, 27);
        btnClear.TabIndex = 11;
        btnClear.Text = "Clear";
        btnClear.UseVisualStyleBackColor = true;
        btnClear.Click += btnClear_Click;
        //
        // lblSearch
        //
        lblSearch.AutoSize = true;
        lblSearch.Location = new Point(20, 105);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new Size(42, 15);
        lblSearch.TabIndex = 12;
        lblSearch.Text = "Search";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(110, 102);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(180, 23);
        txtSearch.TabIndex = 13;
        //
        // btnSearch
        //
        btnSearch.Location = new Point(300, 101);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(85, 27);
        btnSearch.TabIndex = 14;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        //
        // btnShowAll
        //
        btnShowAll.Location = new Point(395, 101);
        btnShowAll.Name = "btnShowAll";
        btnShowAll.Size = new Size(85, 27);
        btnShowAll.TabIndex = 15;
        btnShowAll.Text = "Show All";
        btnShowAll.UseVisualStyleBackColor = true;
        btnShowAll.Click += btnShowAll_Click;
        //
        // dgvStudents
        //
        dgvStudents.AllowUserToAddRows = false;
        dgvStudents.AllowUserToDeleteRows = false;
        dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStudents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvStudents.Location = new Point(20, 145);
        dgvStudents.MultiSelect = false;
        dgvStudents.Name = "dgvStudents";
        dgvStudents.ReadOnly = true;
        dgvStudents.RowHeadersVisible = false;
        dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStudents.Size = new Size(765, 300);
        dgvStudents.TabIndex = 16;
        dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;
        //
        // StudentForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(805, 465);
        Controls.Add(dgvStudents);
        Controls.Add(btnShowAll);
        Controls.Add(btnSearch);
        Controls.Add(txtSearch);
        Controls.Add(lblSearch);
        Controls.Add(btnClear);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtLastName);
        Controls.Add(lblLastName);
        Controls.Add(txtFirstName);
        Controls.Add(lblFirstName);
        Controls.Add(txtStudentId);
        Controls.Add(lblStudentId);
        MinimumSize = new Size(821, 504);
        Name = "StudentForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Manage Students";
        Load += StudentForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblStudentId;
    private TextBox txtStudentId;
    private Label lblFirstName;
    private TextBox txtFirstName;
    private Label lblLastName;
    private TextBox txtLastName;
    private Label lblEmail;
    private TextBox txtEmail;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnClear;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnShowAll;
    private DataGridView dgvStudents;
}

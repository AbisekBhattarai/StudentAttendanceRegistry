namespace StudentAttendanceRegistry.Forms;

partial class ClassForm
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
        lblClassCode = new Label();
        txtClassCode = new TextBox();
        lblClassName = new Label();
        txtClassName = new TextBox();
        lblTeacher = new Label();
        txtTeacher = new TextBox();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        btnClear = new Button();
        lblSearch = new Label();
        txtSearch = new TextBox();
        btnSearch = new Button();
        btnShowAll = new Button();
        dgvClasses = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvClasses).BeginInit();
        SuspendLayout();
        //
        // lblClassCode
        //
        lblClassCode.AutoSize = true;
        lblClassCode.Location = new Point(20, 25);
        lblClassCode.Name = "lblClassCode";
        lblClassCode.Size = new Size(64, 15);
        lblClassCode.TabIndex = 0;
        lblClassCode.Text = "Class Code";
        //
        // txtClassCode
        //
        txtClassCode.Location = new Point(110, 22);
        txtClassCode.MaxLength = 20;
        txtClassCode.Name = "txtClassCode";
        txtClassCode.Size = new Size(180, 23);
        txtClassCode.TabIndex = 1;
        //
        // lblClassName
        //
        lblClassName.AutoSize = true;
        lblClassName.Location = new Point(20, 60);
        lblClassName.Name = "lblClassName";
        lblClassName.Size = new Size(69, 15);
        lblClassName.TabIndex = 2;
        lblClassName.Text = "Class Name";
        //
        // txtClassName
        //
        txtClassName.Location = new Point(110, 57);
        txtClassName.MaxLength = 100;
        txtClassName.Name = "txtClassName";
        txtClassName.Size = new Size(470, 23);
        txtClassName.TabIndex = 3;
        //
        // lblTeacher
        //
        lblTeacher.AutoSize = true;
        lblTeacher.Location = new Point(320, 25);
        lblTeacher.Name = "lblTeacher";
        lblTeacher.Size = new Size(47, 15);
        lblTeacher.TabIndex = 4;
        lblTeacher.Text = "Teacher";
        //
        // txtTeacher
        //
        txtTeacher.Location = new Point(400, 22);
        txtTeacher.MaxLength = 100;
        txtTeacher.Name = "txtTeacher";
        txtTeacher.Size = new Size(180, 23);
        txtTeacher.TabIndex = 5;
        //
        // btnAdd
        //
        btnAdd.Location = new Point(610, 20);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(85, 27);
        btnAdd.TabIndex = 6;
        btnAdd.Text = "Add";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        //
        // btnUpdate
        //
        btnUpdate.Location = new Point(700, 20);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(85, 27);
        btnUpdate.TabIndex = 7;
        btnUpdate.Text = "Update";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        //
        // btnDelete
        //
        btnDelete.Location = new Point(610, 55);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(85, 27);
        btnDelete.TabIndex = 8;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // btnClear
        //
        btnClear.Location = new Point(700, 55);
        btnClear.Name = "btnClear";
        btnClear.Size = new Size(85, 27);
        btnClear.TabIndex = 9;
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
        lblSearch.TabIndex = 10;
        lblSearch.Text = "Search";
        //
        // txtSearch
        //
        txtSearch.Location = new Point(110, 102);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(180, 23);
        txtSearch.TabIndex = 11;
        //
        // btnSearch
        //
        btnSearch.Location = new Point(300, 101);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(85, 27);
        btnSearch.TabIndex = 12;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        //
        // btnShowAll
        //
        btnShowAll.Location = new Point(395, 101);
        btnShowAll.Name = "btnShowAll";
        btnShowAll.Size = new Size(85, 27);
        btnShowAll.TabIndex = 13;
        btnShowAll.Text = "Show All";
        btnShowAll.UseVisualStyleBackColor = true;
        btnShowAll.Click += btnShowAll_Click;
        //
        // dgvClasses
        //
        dgvClasses.AllowUserToAddRows = false;
        dgvClasses.AllowUserToDeleteRows = false;
        dgvClasses.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvClasses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClasses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvClasses.Location = new Point(20, 145);
        dgvClasses.MultiSelect = false;
        dgvClasses.Name = "dgvClasses";
        dgvClasses.ReadOnly = true;
        dgvClasses.RowHeadersVisible = false;
        dgvClasses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClasses.Size = new Size(765, 300);
        dgvClasses.TabIndex = 14;
        dgvClasses.SelectionChanged += dgvClasses_SelectionChanged;
        //
        // ClassForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(805, 465);
        Controls.Add(dgvClasses);
        Controls.Add(btnShowAll);
        Controls.Add(btnSearch);
        Controls.Add(txtSearch);
        Controls.Add(lblSearch);
        Controls.Add(btnClear);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(txtTeacher);
        Controls.Add(lblTeacher);
        Controls.Add(txtClassName);
        Controls.Add(lblClassName);
        Controls.Add(txtClassCode);
        Controls.Add(lblClassCode);
        MinimumSize = new Size(821, 504);
        Name = "ClassForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Manage Classes";
        Load += ClassForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvClasses).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblClassCode;
    private TextBox txtClassCode;
    private Label lblClassName;
    private TextBox txtClassName;
    private Label lblTeacher;
    private TextBox txtTeacher;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private Button btnClear;
    private Label lblSearch;
    private TextBox txtSearch;
    private Button btnSearch;
    private Button btnShowAll;
    private DataGridView dgvClasses;
}

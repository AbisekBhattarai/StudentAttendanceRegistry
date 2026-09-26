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
        txtSearch = new TextBox();
        lblCount = new Label();
        btnEdit = new Button();
        btnDelete = new Button();
        btnAdd = new Button();
        dgvStudents = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
        SuspendLayout();
        //
        // txtSearch
        //
        txtSearch.Font = new Font("Segoe UI", 10F);
        txtSearch.Location = new Point(20, 20);
        txtSearch.Name = "txtSearch";
        txtSearch.PlaceholderText = "Search by student ID or name";
        txtSearch.Size = new Size(300, 25);
        txtSearch.TabIndex = 0;
        txtSearch.TextChanged += txtSearch_TextChanged;
        //
        // lblCount
        //
        lblCount.AutoSize = true;
        lblCount.Location = new Point(332, 25);
        lblCount.Name = "lblCount";
        lblCount.Size = new Size(60, 15);
        lblCount.TabIndex = 1;
        lblCount.Text = "0 students";
        //
        // btnEdit
        //
        btnEdit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnEdit.Location = new Point(465, 18);
        btnEdit.Name = "btnEdit";
        btnEdit.Size = new Size(85, 30);
        btnEdit.TabIndex = 2;
        btnEdit.Text = "Edit";
        btnEdit.UseVisualStyleBackColor = true;
        btnEdit.Click += btnEdit_Click;
        //
        // btnDelete
        //
        btnDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnDelete.Location = new Point(560, 18);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(85, 30);
        btnDelete.TabIndex = 3;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        //
        // btnAdd
        //
        btnAdd.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAdd.Location = new Point(655, 18);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(130, 30);
        btnAdd.TabIndex = 4;
        btnAdd.Text = "+  Add Student";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        //
        // dgvStudents
        //
        dgvStudents.AllowUserToAddRows = false;
        dgvStudents.AllowUserToDeleteRows = false;
        dgvStudents.AllowUserToResizeRows = false;
        dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvStudents.Location = new Point(20, 70);
        dgvStudents.MultiSelect = false;
        dgvStudents.Name = "dgvStudents";
        dgvStudents.ReadOnly = true;
        dgvStudents.RowHeadersVisible = false;
        dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvStudents.Size = new Size(765, 375);
        dgvStudents.TabIndex = 5;
        dgvStudents.CellDoubleClick += dgvStudents_CellDoubleClick;
        //
        // StudentForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(805, 465);
        Controls.Add(dgvStudents);
        Controls.Add(btnAdd);
        Controls.Add(btnDelete);
        Controls.Add(btnEdit);
        Controls.Add(lblCount);
        Controls.Add(txtSearch);
        MinimumSize = new Size(821, 504);
        Name = "StudentForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Students";
        Load += StudentForm_Load;
        ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txtSearch;
    private Label lblCount;
    private Button btnEdit;
    private Button btnDelete;
    private Button btnAdd;
    private DataGridView dgvStudents;
}

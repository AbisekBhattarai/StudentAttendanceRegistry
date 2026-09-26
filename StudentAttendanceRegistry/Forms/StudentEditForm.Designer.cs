namespace StudentAttendanceRegistry.Forms;

partial class StudentEditForm
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
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblStudentId = new Label();
        txtStudentId = new TextBox();
        lblFirstName = new Label();
        txtFirstName = new TextBox();
        lblLastName = new Label();
        txtLastName = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblError = new Label();
        btnCancel = new Button();
        btnSave = new Button();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
        lblTitle.Location = new Point(26, 20);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(130, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Add Student";
        //
        // lblSubtitle
        //
        lblSubtitle.AutoSize = true;
        lblSubtitle.Location = new Point(29, 56);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(200, 15);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Fill in the student's details below.";
        //
        // lblStudentId
        //
        lblStudentId.AutoSize = true;
        lblStudentId.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblStudentId.Location = new Point(28, 96);
        lblStudentId.Name = "lblStudentId";
        lblStudentId.Size = new Size(66, 15);
        lblStudentId.TabIndex = 2;
        lblStudentId.Text = "Student ID";
        //
        // txtStudentId
        //
        txtStudentId.Font = new Font("Segoe UI", 10.5F);
        txtStudentId.Location = new Point(30, 118);
        txtStudentId.MaxLength = 8;
        txtStudentId.Name = "txtStudentId";
        txtStudentId.PlaceholderText = "e.g. S2500187";
        txtStudentId.Size = new Size(380, 26);
        txtStudentId.TabIndex = 3;
        //
        // lblFirstName
        //
        lblFirstName.AutoSize = true;
        lblFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblFirstName.Location = new Point(28, 164);
        lblFirstName.Name = "lblFirstName";
        lblFirstName.Size = new Size(67, 15);
        lblFirstName.TabIndex = 4;
        lblFirstName.Text = "First name";
        //
        // txtFirstName
        //
        txtFirstName.Font = new Font("Segoe UI", 10.5F);
        txtFirstName.Location = new Point(30, 186);
        txtFirstName.MaxLength = 50;
        txtFirstName.Name = "txtFirstName";
        txtFirstName.Size = new Size(184, 26);
        txtFirstName.TabIndex = 5;
        //
        // lblLastName
        //
        lblLastName.AutoSize = true;
        lblLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblLastName.Location = new Point(224, 164);
        lblLastName.Name = "lblLastName";
        lblLastName.Size = new Size(66, 15);
        lblLastName.TabIndex = 6;
        lblLastName.Text = "Last name";
        //
        // txtLastName
        //
        txtLastName.Font = new Font("Segoe UI", 10.5F);
        txtLastName.Location = new Point(226, 186);
        txtLastName.MaxLength = 50;
        txtLastName.Name = "txtLastName";
        txtLastName.Size = new Size(184, 26);
        txtLastName.TabIndex = 7;
        //
        // lblEmail
        //
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblEmail.Location = new Point(28, 232);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(95, 15);
        lblEmail.TabIndex = 8;
        lblEmail.Text = "Email (optional)";
        //
        // txtEmail
        //
        txtEmail.Font = new Font("Segoe UI", 10.5F);
        txtEmail.Location = new Point(30, 254);
        txtEmail.MaxLength = 100;
        txtEmail.Name = "txtEmail";
        txtEmail.PlaceholderText = "name@example.com";
        txtEmail.Size = new Size(380, 26);
        txtEmail.TabIndex = 9;
        //
        // lblError
        //
        lblError.Location = new Point(28, 296);
        lblError.Name = "lblError";
        lblError.Size = new Size(384, 34);
        lblError.TabIndex = 10;
        //
        // btnCancel
        //
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(214, 340);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(95, 34);
        btnCancel.TabIndex = 12;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        //
        // btnSave
        //
        btnSave.Location = new Point(315, 340);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(95, 34);
        btnSave.TabIndex = 11;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        //
        // StudentEditForm
        //
        AcceptButton = btnSave;
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(440, 396);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        Controls.Add(lblError);
        Controls.Add(txtEmail);
        Controls.Add(lblEmail);
        Controls.Add(txtLastName);
        Controls.Add(lblLastName);
        Controls.Add(txtFirstName);
        Controls.Add(lblFirstName);
        Controls.Add(txtStudentId);
        Controls.Add(lblStudentId);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "StudentEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Student";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblStudentId;
    private TextBox txtStudentId;
    private Label lblFirstName;
    private TextBox txtFirstName;
    private Label lblLastName;
    private TextBox txtLastName;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblError;
    private Button btnCancel;
    private Button btnSave;
}

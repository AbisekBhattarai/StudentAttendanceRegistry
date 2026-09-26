namespace StudentAttendanceRegistry.Forms;

partial class ClassEditForm
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
        lblClassCode = new Label();
        txtClassCode = new TextBox();
        lblClassName = new Label();
        txtClassName = new TextBox();
        lblTeacher = new Label();
        txtTeacher = new TextBox();
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
        lblTitle.Size = new Size(110, 28);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Add Class";
        //
        // lblSubtitle
        //
        lblSubtitle.AutoSize = true;
        lblSubtitle.Location = new Point(29, 56);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(200, 15);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Fill in the class details below.";
        //
        // lblClassCode
        //
        lblClassCode.AutoSize = true;
        lblClassCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblClassCode.Location = new Point(28, 96);
        lblClassCode.Name = "lblClassCode";
        lblClassCode.Size = new Size(67, 15);
        lblClassCode.TabIndex = 2;
        lblClassCode.Text = "Class code";
        //
        // txtClassCode
        //
        txtClassCode.CharacterCasing = CharacterCasing.Upper;
        txtClassCode.Font = new Font("Segoe UI", 10.5F);
        txtClassCode.Location = new Point(30, 118);
        txtClassCode.MaxLength = 20;
        txtClassCode.Name = "txtClassCode";
        txtClassCode.PlaceholderText = "e.g. ITS203";
        txtClassCode.Size = new Size(184, 26);
        txtClassCode.TabIndex = 3;
        //
        // lblClassName
        //
        lblClassName.AutoSize = true;
        lblClassName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblClassName.Location = new Point(28, 164);
        lblClassName.Name = "lblClassName";
        lblClassName.Size = new Size(70, 15);
        lblClassName.TabIndex = 4;
        lblClassName.Text = "Class name";
        //
        // txtClassName
        //
        txtClassName.Font = new Font("Segoe UI", 10.5F);
        txtClassName.Location = new Point(30, 186);
        txtClassName.MaxLength = 100;
        txtClassName.Name = "txtClassName";
        txtClassName.PlaceholderText = "e.g. Object-Oriented Design and Programming";
        txtClassName.Size = new Size(380, 26);
        txtClassName.TabIndex = 5;
        //
        // lblTeacher
        //
        lblTeacher.AutoSize = true;
        lblTeacher.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblTeacher.Location = new Point(28, 232);
        lblTeacher.Name = "lblTeacher";
        lblTeacher.Size = new Size(50, 15);
        lblTeacher.TabIndex = 6;
        lblTeacher.Text = "Teacher";
        //
        // txtTeacher
        //
        txtTeacher.Font = new Font("Segoe UI", 10.5F);
        txtTeacher.Location = new Point(30, 254);
        txtTeacher.MaxLength = 100;
        txtTeacher.Name = "txtTeacher";
        txtTeacher.Size = new Size(380, 26);
        txtTeacher.TabIndex = 7;
        //
        // lblError
        //
        lblError.Location = new Point(28, 296);
        lblError.Name = "lblError";
        lblError.Size = new Size(384, 34);
        lblError.TabIndex = 8;
        //
        // btnCancel
        //
        btnCancel.DialogResult = DialogResult.Cancel;
        btnCancel.Location = new Point(214, 340);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(95, 34);
        btnCancel.TabIndex = 10;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        //
        // btnSave
        //
        btnSave.Location = new Point(315, 340);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(95, 34);
        btnSave.TabIndex = 9;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = true;
        btnSave.Click += btnSave_Click;
        //
        // ClassEditForm
        //
        AcceptButton = btnSave;
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancel;
        ClientSize = new Size(440, 396);
        Controls.Add(btnSave);
        Controls.Add(btnCancel);
        Controls.Add(lblError);
        Controls.Add(txtTeacher);
        Controls.Add(lblTeacher);
        Controls.Add(txtClassName);
        Controls.Add(lblClassName);
        Controls.Add(txtClassCode);
        Controls.Add(lblClassCode);
        Controls.Add(lblSubtitle);
        Controls.Add(lblTitle);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "ClassEditForm";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Class";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblClassCode;
    private TextBox txtClassCode;
    private Label lblClassName;
    private TextBox txtClassName;
    private Label lblTeacher;
    private TextBox txtTeacher;
    private Label lblError;
    private Button btnCancel;
    private Button btnSave;
}

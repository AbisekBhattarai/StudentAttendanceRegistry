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
        lblTitle = new Label();
        btnManageStudents = new Button();
        SuspendLayout();
        //
        // lblTitle
        //
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTitle.Location = new Point(30, 30);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(288, 25);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Student Attendance Registry";
        //
        // btnManageStudents
        //
        btnManageStudents.Location = new Point(30, 90);
        btnManageStudents.Name = "btnManageStudents";
        btnManageStudents.Size = new Size(180, 35);
        btnManageStudents.TabIndex = 1;
        btnManageStudents.Text = "Manage Students";
        btnManageStudents.UseVisualStyleBackColor = true;
        btnManageStudents.Click += btnManageStudents_Click;
        //
        // MainForm
        //
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(btnManageStudents);
        Controls.Add(lblTitle);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Student Attendance Registry";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitle;
    private Button btnManageStudents;
}

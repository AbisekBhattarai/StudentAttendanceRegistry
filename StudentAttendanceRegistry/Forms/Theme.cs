namespace StudentAttendanceRegistry.Forms;

// Gives every form the same modern look
// Each page calls Theme.Apply in its constructor
public static class Theme
{
    public static readonly Color Background = Color.FromArgb(241, 245, 249);
    public static readonly Color Sidebar = Color.FromArgb(15, 23, 42);
    public static readonly Color SidebarHover = Color.FromArgb(30, 41, 59);
    public static readonly Color SidebarText = Color.FromArgb(148, 163, 184);
    public static readonly Color TextColor = Color.FromArgb(51, 65, 85);
    public static readonly Color MutedText = Color.FromArgb(100, 116, 139);
    public static readonly Color DarkText = Color.FromArgb(15, 23, 42);
    public static readonly Color BorderColor = Color.FromArgb(226, 232, 240);
    public static readonly Color Primary = Color.FromArgb(37, 99, 235);
    public static readonly Color PrimaryHover = Color.FromArgb(29, 78, 216);
    public static readonly Color Danger = Color.FromArgb(220, 38, 38);
    public static readonly Color DangerHover = Color.FromArgb(185, 28, 28);
    public static readonly Color Success = Color.FromArgb(22, 163, 74);
    public static readonly Color LightBlue = Color.FromArgb(219, 234, 254);
    public static readonly Color RowAlternate = Color.FromArgb(248, 250, 252);

    private const int HeaderHeight = 90;

    public static void Apply(Form form, string subtitle)
    {
        form.BackColor = Background;

        foreach (Control control in form.Controls)
        {
            StyleControl(control);
        }

        AddCard(form);
        AddHeader(form, subtitle);
    }

    // Style for the small add and edit windows
    public static void ApplyDialog(Form form)
    {
        form.BackColor = Color.White;

        foreach (Control control in form.Controls)
        {
            StyleControl(control);
        }
    }

    // Style for the links in the sidebar
    public static void StyleNavButton(Button button)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.UseVisualStyleBackColor = false;
        button.FlatAppearance.BorderSize = 0;
        button.FlatAppearance.MouseOverBackColor = SidebarHover;
        button.FlatAppearance.MouseDownBackColor = SidebarHover;
        button.BackColor = Sidebar;
        button.ForeColor = SidebarText;
        button.Font = new Font("Segoe UI", 10F);
        button.TextAlign = ContentAlignment.MiddleLeft;
        button.Padding = new Padding(22, 0, 0, 0);
        button.Cursor = Cursors.Hand;
    }

    // Highlights the page that is open
    public static void SetNavActive(Button button, bool active)
    {
        if (active)
        {
            button.BackColor = SidebarHover;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        }
        else
        {
            button.BackColor = Sidebar;
            button.ForeColor = SidebarText;
            button.Font = new Font("Segoe UI", 10F);
        }
    }

    private static void StyleControl(Control control)
    {
        if (control is Button)
        {
            StyleButton((Button)control);
        }
        else if (control is DataGridView)
        {
            StyleGrid((DataGridView)control);
        }
        else if (control is Label)
        {
            // keep labels that already have their own colour, like the report key
            if (control.ForeColor == SystemColors.ControlText)
            {
                control.ForeColor = TextColor;
            }
        }

        foreach (Control child in control.Controls)
        {
            StyleControl(child);
        }
    }

    private static void StyleButton(Button button)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.UseVisualStyleBackColor = false;
        button.Cursor = Cursors.Hand;
        button.FlatAppearance.BorderSize = 0;

        if (button.Name.Contains("Delete") || button.Name.Contains("Remove"))
        {
            button.BackColor = Danger;
            button.ForeColor = Color.White;
            button.FlatAppearance.MouseOverBackColor = DangerHover;
        }
        else if (IsSecondaryButton(button.Name))
        {
            button.BackColor = Color.White;
            button.ForeColor = TextColor;
            button.FlatAppearance.BorderSize = 1;
            button.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 245, 249);
        }
        else
        {
            button.BackColor = Primary;
            button.ForeColor = Color.White;
            button.FlatAppearance.MouseOverBackColor = PrimaryHover;
        }
    }

    // Buttons that are not the main action get a plain white style
    private static bool IsSecondaryButton(string name)
    {
        if (name == "btnClear" || name == "btnShowAll" || name == "btnAllPresent" || name == "btnAllAbsent"
            || name == "btnEdit" || name == "btnCancel")
        {
            return true;
        }
        return false;
    }

    public static void StyleGrid(DataGridView grid)
    {
        grid.BackgroundColor = Color.White;
        grid.BorderStyle = BorderStyle.None;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = BorderColor;
        grid.RowHeadersVisible = false;
        grid.RowTemplate.Height = 34;

        // header row
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.ColumnHeadersHeight = 40;
        grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = MutedText;
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
        grid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

        // normal rows
        grid.DefaultCellStyle.ForeColor = DarkText;
        grid.DefaultCellStyle.SelectionBackColor = LightBlue;
        grid.DefaultCellStyle.SelectionForeColor = DarkText;
        grid.DefaultCellStyle.Padding = new Padding(8, 0, 0, 0);
        grid.AlternatingRowsDefaultCellStyle.BackColor = RowAlternate;

        // tick box columns look better with the header in the middle
        foreach (DataGridViewColumn column in grid.Columns)
        {
            if (column is DataGridViewCheckBoxColumn)
            {
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Padding = new Padding(0);
            }
        }
    }

    // Puts the text boxes and buttons in a white card above the table
    private static void AddCard(Form form)
    {
        DataGridView? grid = null;
        List<Control> inputs = new List<Control>();
        foreach (Control control in form.Controls)
        {
            if (control is DataGridView)
            {
                grid = (DataGridView)control;
            }
            else
            {
                inputs.Add(control);
            }
        }

        if (grid == null || inputs.Count == 0)
        {
            return;
        }

        // find how tall the inputs area is
        int bottom = 0;
        foreach (Control control in inputs)
        {
            if (control.Bottom > bottom)
            {
                bottom = control.Bottom;
            }
        }

        // anchors are turned off while the form grows, otherwise things move or stretch
        AnchorStyles gridAnchor = grid.Anchor;
        grid.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        List<AnchorStyles> anchors = new List<AnchorStyles>();
        foreach (Control control in inputs)
        {
            anchors.Add(control.Anchor);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        // make the form a bit bigger so the card has space around it
        form.ClientSize = new Size(form.ClientSize.Width + 40, form.ClientSize.Height + 40);

        Panel card = new Panel();
        card.BackColor = Color.White;
        card.Location = new Point(20, 10);
        card.Size = new Size(form.ClientSize.Width - 40, bottom + 20);

        // move the inputs into the card, they keep the same spacing
        for (int i = 0; i < inputs.Count; i++)
        {
            form.Controls.Remove(inputs[i]);
            card.Controls.Add(inputs[i]);
            inputs[i].Anchor = anchors[i];
        }
        form.Controls.Add(card);
        card.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        // the table goes under the card and fills the rest of the page
        grid.Location = new Point(20, card.Bottom + 16);
        grid.Size = new Size(form.ClientSize.Width - 40, form.ClientSize.Height - grid.Top - 20);
        grid.Anchor = gridAnchor;
    }

    // Adds the page title and a short description at the top
    private static void AddHeader(Form form, string subtitle)
    {
        // anchors are turned off while the form grows, otherwise the grids stretch too
        List<Control> controls = new List<Control>();
        List<AnchorStyles> anchors = new List<AnchorStyles>();
        foreach (Control control in form.Controls)
        {
            controls.Add(control);
            anchors.Add(control.Anchor);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left;
        }

        form.ClientSize = new Size(form.ClientSize.Width, form.ClientSize.Height + HeaderHeight);

        // move everything down under the header and put the anchors back
        for (int i = 0; i < controls.Count; i++)
        {
            controls[i].Top += HeaderHeight;
            controls[i].Anchor = anchors[i];
        }

        Panel header = new Panel();
        header.Dock = DockStyle.Top;
        header.Height = HeaderHeight;
        header.BackColor = Background;

        Label title = new Label();
        title.AutoSize = true;
        title.Text = form.Text;
        title.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        title.ForeColor = DarkText;
        title.Location = new Point(16, 18);

        Label subtitleLabel = new Label();
        subtitleLabel.AutoSize = true;
        subtitleLabel.Text = subtitle;
        subtitleLabel.Font = new Font("Segoe UI", 9.5F);
        subtitleLabel.ForeColor = MutedText;
        subtitleLabel.Location = new Point(20, 60);

        header.Controls.Add(title);
        header.Controls.Add(subtitleLabel);
        form.Controls.Add(header);
    }
}

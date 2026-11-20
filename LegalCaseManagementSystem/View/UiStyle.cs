using System.Drawing.Drawing2D;

namespace LegalCaseManagementSystem.View
{
    internal static class UiStyle
    {
        internal static readonly Color Navy = Color.FromArgb(25, 45, 75);
        internal static readonly Color Gold = Color.FromArgb(184, 148, 88);
        internal static readonly Color Ivory = Color.FromArgb(245, 247, 250);
        internal static readonly Color Slate = Color.FromArgb(75, 86, 102);
        internal static readonly Color Border = Color.FromArgb(213, 220, 230);

        internal static void Maximize(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.WindowState = FormWindowState.Normal;
            form.Size = new Size(1100, 720);
            form.MinimumSize = new Size(900, 600);
            form.MaximizeBox = true;
            form.BackColor = Ivory;
        }

        internal static void ApplyAuthenticationTheme(Form form)
        {
            form.BackColor = Navy;
            form.ForeColor = Color.White;

            foreach (Control control in form.Controls)
            {
                if (control is Label label)
                {
                    label.ForeColor = label.ForeColor == Gold ? Gold : Color.White;
                }
                else if (control is TextBox textBox)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Navy;
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Navy;
                }
            }
        }

        internal static void ConfigureGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(225, 230, 238);
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 42;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Navy;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            grid.DefaultCellStyle.ForeColor = Color.FromArgb(40, 50, 65);
            grid.DefaultCellStyle.SelectionBackColor = Gold;
            grid.DefaultCellStyle.SelectionForeColor = Navy;
            grid.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            grid.RowTemplate.Height = 36;
        }

        internal static void ApplyProfessionalControls(Control root)
        {
            root.BackColor = Ivory;

            foreach (Control control in root.Controls)
            {
                if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    button.BackColor = Navy;
                    button.ForeColor = Color.White;
                    button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
                    button.Cursor = Cursors.Hand;
                    button.Padding = new Padding(8, 3, 8, 3);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.FromArgb(35, 45, 60);
                    textBox.Font = new Font("Segoe UI", 10F);
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Color.FromArgb(35, 45, 60);
                    comboBox.Font = new Font("Segoe UI", 10F);
                }
                else if (control is DateTimePicker datePicker)
                {
                    datePicker.CalendarTitleBackColor = Navy;
                    datePicker.CalendarTitleForeColor = Color.White;
                    datePicker.Font = new Font("Segoe UI", 10F);
                }
                else if (control is Label label && label.Font.Size < 12F && control.Parent?.BackColor != Navy)
                {
                    label.ForeColor = Slate;
                    label.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
                }

                if (control.HasChildren)
                    ApplyProfessionalControls(control);
            }
        }

        internal static Panel CreateLegalBanner(string title, string subtitle)
        {
            var banner = new Panel
            {
                Height = 108,
                Dock = DockStyle.Top,
                BackColor = Navy,
                Padding = new Padding(28, 18, 28, 14)
            };
            banner.Paint += (sender, e) =>
            {
                using var brush = new LinearGradientBrush(
                    banner.ClientRectangle,
                    Navy,
                    Color.FromArgb(47, 76, 115),
                    LinearGradientMode.Horizontal);
                e.Graphics.FillRectangle(brush, banner.ClientRectangle);
                using var pen = new Pen(Color.FromArgb(90, Gold), 2F);
                e.Graphics.DrawLine(pen, banner.Width - 180, 0, banner.Width - 45, banner.Height);
                e.Graphics.DrawLine(pen, banner.Width - 150, 0, banner.Width - 15, banner.Height);
            };

            var heading = new Label
            {
                Text = title,
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(28, 18),
                BackColor = Color.Transparent
            };
            var detail = new Label
            {
                Text = subtitle,
                AutoSize = true,
                ForeColor = Color.FromArgb(220, 228, 238),
                Font = new Font("Segoe UI", 10F),
                Location = new Point(31, 62),
                BackColor = Color.Transparent
            };
            banner.Controls.Add(detail);
            banner.Controls.Add(heading);
            return banner;
        }
    }
}

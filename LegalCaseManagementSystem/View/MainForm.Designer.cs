namespace LegalCaseManagementSystem.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblDesignerPreview = new Label();
            lblDesignerPreview.Visible = false;
            SuspendLayout();
            BackColor = Color.FromArgb(245, 247, 250);
            Font = new Font("Segoe UI", 10F);
            lblDesignerPreview.AutoSize = true;
            lblDesignerPreview.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblDesignerPreview.ForeColor = Color.FromArgb(25, 45, 75);
            lblDesignerPreview.Location = new Point(48, 80);
            lblDesignerPreview.Text = "Legal Case Management Dashboard";
            Controls.Add(lblDesignerPreview);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDesignerPreview;
    }
}
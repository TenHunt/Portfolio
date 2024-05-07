
namespace DeJager_Daniel_41669436
{
    partial class Form1
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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiQuotes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAdminPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.msMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiQuotes,
            this.tsmiWindow,
            this.tsmiExit});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(800, 24);
            this.msMenu.TabIndex = 1;
            this.msMenu.Text = "menuStrip1";
            // 
            // tsmiQuotes
            // 
            this.tsmiQuotes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiViewAll,
            this.tsmiAdminPanel});
            this.tsmiQuotes.Name = "tsmiQuotes";
            this.tsmiQuotes.Size = new System.Drawing.Size(57, 20);
            this.tsmiQuotes.Text = "Quotes";
            // 
            // tsmiViewAll
            // 
            this.tsmiViewAll.Name = "tsmiViewAll";
            this.tsmiViewAll.Size = new System.Drawing.Size(142, 22);
            this.tsmiViewAll.Text = "View All";
            this.tsmiViewAll.Click += new System.EventHandler(this.tsmiViewAll_Click);
            // 
            // tsmiAdminPanel
            // 
            this.tsmiAdminPanel.Name = "tsmiAdminPanel";
            this.tsmiAdminPanel.Size = new System.Drawing.Size(180, 22);
            this.tsmiAdminPanel.Text = "Admin Panel";
            this.tsmiAdminPanel.Click += new System.EventHandler(this.tsmiAdminPanel_Click);
            // 
            // tsmiWindow
            // 
            this.tsmiWindow.Name = "tsmiWindow";
            this.tsmiWindow.Size = new System.Drawing.Size(63, 20);
            this.tsmiWindow.Text = "Window";
            this.tsmiWindow.Click += new System.EventHandler(this.tsmiWindow_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(38, 20);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.msMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msMenu;
            this.Name = "Form1";
            this.Text = "Main Form";
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiQuotes;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiAdminPanel;
        private System.Windows.Forms.ToolStripMenuItem tsmiWindow;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
    }
}


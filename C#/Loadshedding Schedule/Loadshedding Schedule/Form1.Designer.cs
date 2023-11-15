
namespace Loadshedding_Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.radCurrent = new System.Windows.Forms.RadioButton();
            this.radFuture = new System.Windows.Forms.RadioButton();
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.grpNotifier = new System.Windows.Forms.GroupBox();
            this.txtStartTime = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.txtDuration = new System.Windows.Forms.TextBox();
            this.lblDuration = new System.Windows.Forms.Label();
            this.grpTest.SuspendLayout();
            this.grpNotifier.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(154, 178);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(128, 48);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check Now";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSchedule.Location = new System.Drawing.Point(6, 97);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(258, 55);
            this.btnSchedule.TabIndex = 6;
            this.btnSchedule.Text = "Schedule Reminder";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // radCurrent
            // 
            this.radCurrent.AutoSize = true;
            this.radCurrent.Location = new System.Drawing.Point(12, 19);
            this.radCurrent.Name = "radCurrent";
            this.radCurrent.Size = new System.Drawing.Size(59, 17);
            this.radCurrent.TabIndex = 0;
            this.radCurrent.TabStop = true;
            this.radCurrent.Text = "Current";
            this.radCurrent.UseVisualStyleBackColor = true;
            // 
            // radFuture
            // 
            this.radFuture.AutoSize = true;
            this.radFuture.Location = new System.Drawing.Point(77, 19);
            this.radFuture.Name = "radFuture";
            this.radFuture.Size = new System.Drawing.Size(55, 17);
            this.radFuture.TabIndex = 1;
            this.radFuture.TabStop = true;
            this.radFuture.Text = "Future";
            this.radFuture.UseVisualStyleBackColor = true;
            // 
            // grpTest
            // 
            this.grpTest.Controls.Add(this.radCurrent);
            this.grpTest.Controls.Add(this.radFuture);
            this.grpTest.Location = new System.Drawing.Point(12, 178);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(136, 48);
            this.grpTest.TabIndex = 1;
            this.grpTest.TabStop = false;
            this.grpTest.Text = "Test modes";
            // 
            // grpNotifier
            // 
            this.grpNotifier.Controls.Add(this.txtStartTime);
            this.grpNotifier.Controls.Add(this.lblStartTime);
            this.grpNotifier.Controls.Add(this.txtInterval);
            this.grpNotifier.Controls.Add(this.lblInterval);
            this.grpNotifier.Controls.Add(this.txtDuration);
            this.grpNotifier.Controls.Add(this.lblDuration);
            this.grpNotifier.Controls.Add(this.btnSchedule);
            this.grpNotifier.Location = new System.Drawing.Point(12, 12);
            this.grpNotifier.Name = "grpNotifier";
            this.grpNotifier.Size = new System.Drawing.Size(270, 160);
            this.grpNotifier.TabIndex = 0;
            this.grpNotifier.TabStop = false;
            this.grpNotifier.Text = "Daily Notification Scheduler";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(164, 19);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(100, 20);
            this.txtStartTime.TabIndex = 1;
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(6, 22);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(154, 13);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "Notification start time (HH:MM):";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(164, 71);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(100, 20);
            this.txtInterval.TabIndex = 5;
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(6, 74);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(140, 13);
            this.lblInterval.TabIndex = 4;
            this.lblInterval.Text = "Notification intervals (hours):";
            // 
            // txtDuration
            // 
            this.txtDuration.Location = new System.Drawing.Point(164, 45);
            this.txtDuration.Name = "txtDuration";
            this.txtDuration.Size = new System.Drawing.Size(100, 20);
            this.txtDuration.TabIndex = 3;
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(6, 48);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(139, 13);
            this.lblDuration.TabIndex = 2;
            this.lblDuration.Text = "Notification duration (hours):";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 236);
            this.Controls.Add(this.grpNotifier);
            this.Controls.Add(this.grpTest);
            this.Controls.Add(this.btnCheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Loadshedding Schedule";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpTest.ResumeLayout(false);
            this.grpTest.PerformLayout();
            this.grpNotifier.ResumeLayout(false);
            this.grpNotifier.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.RadioButton radCurrent;
        private System.Windows.Forms.RadioButton radFuture;
        private System.Windows.Forms.GroupBox grpTest;
        private System.Windows.Forms.GroupBox grpNotifier;
        private System.Windows.Forms.TextBox txtDuration;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.TextBox txtStartTime;
        private System.Windows.Forms.Label lblStartTime;
    }
}



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
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.lblAreaName = new System.Windows.Forms.Label();
            this.btnArea = new System.Windows.Forms.Button();
            this.lblAreaID = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.btnStatus = new System.Windows.Forms.Button();
            this.gbStages = new System.Windows.Forms.GroupBox();
            this.lblNextStageDate = new System.Windows.Forms.Label();
            this.lblNextStageTime = new System.Windows.Forms.Label();
            this.lblNextStage = new System.Windows.Forms.Label();
            this.lblCurrentStage = new System.Windows.Forms.Label();
            this.grpTest.SuspendLayout();
            this.grpNotifier.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.gbStages.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCheck.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(136, 95);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(128, 42);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Check Now";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSchedule.Location = new System.Drawing.Point(6, 97);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(258, 42);
            this.btnSchedule.TabIndex = 6;
            this.btnSchedule.Text = "Schedule Reminder";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // radCurrent
            // 
            this.radCurrent.AutoSize = true;
            this.radCurrent.Location = new System.Drawing.Point(12, 16);
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
            this.radFuture.Location = new System.Drawing.Point(12, 34);
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
            this.grpTest.Location = new System.Drawing.Point(181, 36);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(81, 56);
            this.grpTest.TabIndex = 4;
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
            this.grpNotifier.Location = new System.Drawing.Point(12, 286);
            this.grpNotifier.Name = "grpNotifier";
            this.grpNotifier.Size = new System.Drawing.Size(270, 148);
            this.grpNotifier.TabIndex = 2;
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
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.lblAreaName);
            this.grpDetails.Controls.Add(this.btnArea);
            this.grpDetails.Controls.Add(this.lblAreaID);
            this.grpDetails.Controls.Add(this.grpTest);
            this.grpDetails.Controls.Add(this.lblEnd);
            this.grpDetails.Controls.Add(this.btnCheck);
            this.grpDetails.Controls.Add(this.lblStart);
            this.grpDetails.Location = new System.Drawing.Point(12, 12);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(270, 145);
            this.grpDetails.TabIndex = 0;
            this.grpDetails.TabStop = false;
            this.grpDetails.Text = "Check Loadshedding";
            // 
            // lblAreaName
            // 
            this.lblAreaName.AutoSize = true;
            this.lblAreaName.Location = new System.Drawing.Point(9, 37);
            this.lblAreaName.Name = "lblAreaName";
            this.lblAreaName.Size = new System.Drawing.Size(90, 13);
            this.lblAreaName.TabIndex = 1;
            this.lblAreaName.Text = "Area name: None";
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(6, 95);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(128, 42);
            this.btnArea.TabIndex = 5;
            this.btnArea.Text = "Change area";
            this.btnArea.UseVisualStyleBackColor = true;
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // lblAreaID
            // 
            this.lblAreaID.AutoSize = true;
            this.lblAreaID.Location = new System.Drawing.Point(9, 18);
            this.lblAreaID.Name = "lblAreaID";
            this.lblAreaID.Size = new System.Drawing.Size(75, 13);
            this.lblAreaID.TabIndex = 0;
            this.lblAreaID.Text = "Area ID: None";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(9, 77);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(75, 13);
            this.lblEnd.TabIndex = 3;
            this.lblEnd.Text = "Next end time:";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(9, 56);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(77, 13);
            this.lblStart.TabIndex = 2;
            this.lblStart.Text = "Next start time:";
            // 
            // btnStatus
            // 
            this.btnStatus.Location = new System.Drawing.Point(6, 68);
            this.btnStatus.Name = "btnStatus";
            this.btnStatus.Size = new System.Drawing.Size(258, 42);
            this.btnStatus.TabIndex = 4;
            this.btnStatus.Text = "Check Stage Status";
            this.btnStatus.UseVisualStyleBackColor = true;
            this.btnStatus.Click += new System.EventHandler(this.btnStatus_Click);
            // 
            // gbStages
            // 
            this.gbStages.Controls.Add(this.lblNextStageDate);
            this.gbStages.Controls.Add(this.lblNextStageTime);
            this.gbStages.Controls.Add(this.lblNextStage);
            this.gbStages.Controls.Add(this.btnStatus);
            this.gbStages.Controls.Add(this.lblCurrentStage);
            this.gbStages.Location = new System.Drawing.Point(12, 163);
            this.gbStages.Name = "gbStages";
            this.gbStages.Size = new System.Drawing.Size(270, 117);
            this.gbStages.TabIndex = 1;
            this.gbStages.TabStop = false;
            this.gbStages.Text = "Stages";
            // 
            // lblNextStageDate
            // 
            this.lblNextStageDate.AutoSize = true;
            this.lblNextStageDate.Location = new System.Drawing.Point(107, 45);
            this.lblNextStageDate.Name = "lblNextStageDate";
            this.lblNextStageDate.Size = new System.Drawing.Size(85, 13);
            this.lblNextStageDate.TabIndex = 3;
            this.lblNextStageDate.Text = "Next stage date:";
            // 
            // lblNextStageTime
            // 
            this.lblNextStageTime.AutoSize = true;
            this.lblNextStageTime.Location = new System.Drawing.Point(107, 22);
            this.lblNextStageTime.Name = "lblNextStageTime";
            this.lblNextStageTime.Size = new System.Drawing.Size(83, 13);
            this.lblNextStageTime.TabIndex = 2;
            this.lblNextStageTime.Text = "Next stage time:";
            // 
            // lblNextStage
            // 
            this.lblNextStage.AutoSize = true;
            this.lblNextStage.Location = new System.Drawing.Point(9, 45);
            this.lblNextStage.Name = "lblNextStage";
            this.lblNextStage.Size = new System.Drawing.Size(61, 13);
            this.lblNextStage.TabIndex = 1;
            this.lblNextStage.Text = "Next stage:";
            // 
            // lblCurrentStage
            // 
            this.lblCurrentStage.AutoSize = true;
            this.lblCurrentStage.Location = new System.Drawing.Point(9, 22);
            this.lblCurrentStage.Name = "lblCurrentStage";
            this.lblCurrentStage.Size = new System.Drawing.Size(73, 13);
            this.lblCurrentStage.TabIndex = 0;
            this.lblCurrentStage.Text = "Current stage:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 449);
            this.Controls.Add(this.gbStages);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpNotifier);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Loadshedding Schedule";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpTest.ResumeLayout(false);
            this.grpTest.PerformLayout();
            this.grpNotifier.ResumeLayout(false);
            this.grpNotifier.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.gbStages.ResumeLayout(false);
            this.gbStages.PerformLayout();
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
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnStatus;
        private System.Windows.Forms.GroupBox gbStages;
        private System.Windows.Forms.Label lblNextStageTime;
        private System.Windows.Forms.Label lblNextStage;
        private System.Windows.Forms.Label lblCurrentStage;
        private System.Windows.Forms.Label lblNextStageDate;
        private System.Windows.Forms.Label lblAreaID;
        private System.Windows.Forms.Label lblAreaName;
    }
}


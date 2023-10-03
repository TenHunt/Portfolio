
namespace TitleCapitalizer
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.btnCapitalize = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lstPrevious = new System.Windows.Forms.ListBox();
            this.gbInput.SuspendLayout();
            this.gbResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(6, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(303, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.txtTitle);
            this.gbInput.Location = new System.Drawing.Point(12, 12);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(315, 47);
            this.gbInput.TabIndex = 1;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Enter your title/headline:";
            // 
            // btnCapitalize
            // 
            this.btnCapitalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapitalize.Location = new System.Drawing.Point(12, 118);
            this.btnCapitalize.Name = "btnCapitalize";
            this.btnCapitalize.Size = new System.Drawing.Size(155, 40);
            this.btnCapitalize.TabIndex = 2;
            this.btnCapitalize.Text = "&Capitalize";
            this.btnCapitalize.UseVisualStyleBackColor = true;
            this.btnCapitalize.Click += new System.EventHandler(this.btnCapitalize_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(174, 118);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 40);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clea&r";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gbResults
            // 
            this.gbResults.Controls.Add(this.lblOutput);
            this.gbResults.Location = new System.Drawing.Point(12, 65);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(315, 47);
            this.gbResults.TabIndex = 2;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results:";
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(6, 20);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(64, 13);
            this.lblOutput.TabIndex = 0;
            this.lblOutput.Text = "Output label";
            // 
            // lstPrevious
            // 
            this.lstPrevious.FormattingEnabled = true;
            this.lstPrevious.Location = new System.Drawing.Point(12, 164);
            this.lstPrevious.Name = "lstPrevious";
            this.lstPrevious.Size = new System.Drawing.Size(317, 160);
            this.lstPrevious.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 341);
            this.Controls.Add(this.lstPrevious);
            this.Controls.Add(this.gbResults);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCapitalize);
            this.Controls.Add(this.gbInput);
            this.Name = "Form1";
            this.Text = "Title Capitalizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbResults.ResumeLayout(false);
            this.gbResults.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Button btnCapitalize;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.ListBox lstPrevious;
    }
}



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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.btnCapitalize = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.gbResult = new System.Windows.Forms.GroupBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lstPrevious = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.gbInput.SuspendLayout();
            this.gbResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(6, 19);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(346, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.txtTitle);
            this.gbInput.Location = new System.Drawing.Point(12, 12);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(358, 47);
            this.gbInput.TabIndex = 0;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Enter your title/headline:";
            // 
            // btnCapitalize
            // 
            this.btnCapitalize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapitalize.Location = new System.Drawing.Point(12, 118);
            this.btnCapitalize.Name = "btnCapitalize";
            this.btnCapitalize.Size = new System.Drawing.Size(175, 40);
            this.btnCapitalize.TabIndex = 2;
            this.btnCapitalize.Text = "&Capitalize";
            this.btnCapitalize.UseVisualStyleBackColor = true;
            this.btnCapitalize.Click += new System.EventHandler(this.btnCapitalize_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(195, 118);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(175, 40);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // gbResult
            // 
            this.gbResult.Controls.Add(this.lblOutput);
            this.gbResult.Location = new System.Drawing.Point(12, 65);
            this.gbResult.Name = "gbResult";
            this.gbResult.Size = new System.Drawing.Size(358, 47);
            this.gbResult.TabIndex = 1;
            this.gbResult.TabStop = false;
            this.gbResult.Text = "Result:";
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
            this.lstPrevious.Size = new System.Drawing.Size(358, 160);
            this.lstPrevious.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(306, 289);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 26);
            this.button1.TabIndex = 5;
            this.button1.Text = "Clea&r";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 341);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lstPrevious);
            this.Controls.Add(this.gbResult);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCapitalize);
            this.Controls.Add(this.gbInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Title Capitalizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbResult.ResumeLayout(false);
            this.gbResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.Button btnCapitalize;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox gbResult;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.ListBox lstPrevious;
        private System.Windows.Forms.Button button1;
    }
}


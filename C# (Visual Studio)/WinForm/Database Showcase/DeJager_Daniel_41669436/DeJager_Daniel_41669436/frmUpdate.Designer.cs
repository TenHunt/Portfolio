
namespace DeJager_Daniel_41669436
{
    partial class frmUpdate
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
            this.lblID = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtUpdate = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(29, 23);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(53, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "Quote ID:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(29, 54);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(83, 13);
            this.lblUpdate.TabIndex = 2;
            this.lblUpdate.Text = "Updated Quote:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(121, 20);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(230, 20);
            this.txtID.TabIndex = 1;
            // 
            // txtUpdate
            // 
            this.txtUpdate.Location = new System.Drawing.Point(121, 51);
            this.txtUpdate.Multiline = true;
            this.txtUpdate.Name = "txtUpdate";
            this.txtUpdate.Size = new System.Drawing.Size(230, 44);
            this.txtUpdate.TabIndex = 3;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(367, 72);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // frmUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 115);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.txtUpdate);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.lblID);
            this.Name = "frmUpdate";
            this.Text = "frmUpdate";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtUpdate;
        private System.Windows.Forms.Button btnUpdate;
    }
}
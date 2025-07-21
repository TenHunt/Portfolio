
namespace DeJager_Daniel_41669436
{
    partial class ViewForm
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.lblRemoveFilter = new System.Windows.Forms.Label();
            this.lblCurrentYear = new System.Windows.Forms.Label();
            this.hsbYear = new System.Windows.Forms.HScrollBar();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.cbbName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.gbFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(1, 1);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(563, 184);
            this.dgvData.TabIndex = 0;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.lblRemoveFilter);
            this.gbFilter.Controls.Add(this.lblCurrentYear);
            this.gbFilter.Controls.Add(this.hsbYear);
            this.gbFilter.Controls.Add(this.lblYear);
            this.gbFilter.Controls.Add(this.lblName);
            this.gbFilter.Controls.Add(this.cbbName);
            this.gbFilter.Location = new System.Drawing.Point(1, 191);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(563, 100);
            this.gbFilter.TabIndex = 1;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter Quotes";
            // 
            // lblRemoveFilter
            // 
            this.lblRemoveFilter.AutoSize = true;
            this.lblRemoveFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemoveFilter.Location = new System.Drawing.Point(485, 79);
            this.lblRemoveFilter.Name = "lblRemoveFilter";
            this.lblRemoveFilter.Size = new System.Drawing.Size(72, 13);
            this.lblRemoveFilter.TabIndex = 5;
            this.lblRemoveFilter.Text = "Remove Filter";
            this.lblRemoveFilter.Click += new System.EventHandler(this.lblRemoveFilter_Click);
            // 
            // lblCurrentYear
            // 
            this.lblCurrentYear.AutoSize = true;
            this.lblCurrentYear.Location = new System.Drawing.Point(238, 65);
            this.lblCurrentYear.Name = "lblCurrentYear";
            this.lblCurrentYear.Size = new System.Drawing.Size(35, 13);
            this.lblCurrentYear.TabIndex = 4;
            this.lblCurrentYear.Text = "(Year)";
            // 
            // hsbYear
            // 
            this.hsbYear.LargeChange = 1;
            this.hsbYear.Location = new System.Drawing.Point(76, 61);
            this.hsbYear.Maximum = 2025;
            this.hsbYear.Name = "hsbYear";
            this.hsbYear.Size = new System.Drawing.Size(121, 22);
            this.hsbYear.TabIndex = 3;
            this.hsbYear.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbYear_Scroll);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(32, 65);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(32, 13);
            this.lblYear.TabIndex = 2;
            this.lblYear.Text = "Year:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(32, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(38, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // cbbName
            // 
            this.cbbName.FormattingEnabled = true;
            this.cbbName.Location = new System.Drawing.Point(76, 28);
            this.cbbName.Name = "cbbName";
            this.cbbName.Size = new System.Drawing.Size(121, 21);
            this.cbbName.TabIndex = 0;
            this.cbbName.SelectedIndexChanged += new System.EventHandler(this.cbbName_SelectedIndexChanged);
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 292);
            this.Controls.Add(this.gbFilter);
            this.Controls.Add(this.dgvData);
            this.Name = "ViewForm";
            this.Text = "ViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.GroupBox gbFilter;
        private System.Windows.Forms.Label lblRemoveFilter;
        private System.Windows.Forms.Label lblCurrentYear;
        private System.Windows.Forms.HScrollBar hsbYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cbbName;
    }
}
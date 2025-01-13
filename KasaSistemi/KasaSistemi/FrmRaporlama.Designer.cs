namespace KasaSistemi
{
    partial class FrmRaporlama
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRaporlama));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblToplamSatis = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.dataGridViewRapor = new System.Windows.Forms.DataGridView();
            this.dtpBaslangic = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpBitis = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnRaporuYenile = new Guna.UI2.WinForms.Guna2Button();
            this.btnPDFCikar = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.Panel1Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.FrmElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel2.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(25, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Başlangıç Tarihi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(25, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bitiş Tarihi:";
            // 
            // lblToplamSatis
            // 
            this.lblToplamSatis.AutoSize = true;
            this.lblToplamSatis.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.lblToplamSatis.Location = new System.Drawing.Point(10, 10);
            this.lblToplamSatis.Name = "lblToplamSatis";
            this.lblToplamSatis.Size = new System.Drawing.Size(117, 19);
            this.lblToplamSatis.TabIndex = 8;
            this.lblToplamSatis.Text = "Toplam Satış: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.panel2.Controls.Add(this.lblToplamSatis);
            this.panel2.Location = new System.Drawing.Point(12, 415);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(776, 50);
            this.panel2.TabIndex = 11;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 25;
            this.guna2CustomGradientPanel1.Controls.Add(this.dataGridViewRapor);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(12, 54);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(776, 232);
            this.guna2CustomGradientPanel1.TabIndex = 13;
            // 
            // dataGridViewRapor
            // 
            this.dataGridViewRapor.AllowUserToAddRows = false;
            this.dataGridViewRapor.AllowUserToDeleteRows = false;
            this.dataGridViewRapor.AllowUserToResizeColumns = false;
            this.dataGridViewRapor.AllowUserToResizeRows = false;
            this.dataGridViewRapor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.dataGridViewRapor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRapor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewRapor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRapor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRapor.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(143)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRapor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRapor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewRapor.EnableHeadersVisualStyles = false;
            this.dataGridViewRapor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewRapor.Location = new System.Drawing.Point(15, 12);
            this.dataGridViewRapor.MultiSelect = false;
            this.dataGridViewRapor.Name = "dataGridViewRapor";
            this.dataGridViewRapor.ReadOnly = true;
            this.dataGridViewRapor.RowHeadersVisible = false;
            this.dataGridViewRapor.RowHeadersWidth = 25;
            this.dataGridViewRapor.RowTemplate.DividerHeight = 2;
            this.dataGridViewRapor.RowTemplate.Height = 25;
            this.dataGridViewRapor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRapor.Size = new System.Drawing.Size(742, 197);
            this.dataGridViewRapor.TabIndex = 11;
            // 
            // dtpBaslangic
            // 
            this.dtpBaslangic.BorderRadius = 10;
            this.dtpBaslangic.Checked = true;
            this.dtpBaslangic.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBaslangic.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpBaslangic.Location = new System.Drawing.Point(188, 13);
            this.dtpBaslangic.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBaslangic.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBaslangic.Name = "dtpBaslangic";
            this.dtpBaslangic.Size = new System.Drawing.Size(181, 36);
            this.dtpBaslangic.TabIndex = 14;
            this.dtpBaslangic.Value = new System.DateTime(2024, 12, 20, 13, 57, 48, 723);
            // 
            // dtpBitis
            // 
            this.dtpBitis.BorderRadius = 10;
            this.dtpBitis.Checked = true;
            this.dtpBitis.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpBitis.Location = new System.Drawing.Point(188, 55);
            this.dtpBitis.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBitis.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(181, 36);
            this.dtpBitis.TabIndex = 15;
            this.dtpBitis.Value = new System.DateTime(2024, 12, 20, 13, 57, 48, 723);
            // 
            // btnRaporuYenile
            // 
            this.btnRaporuYenile.Animated = true;
            this.btnRaporuYenile.BorderRadius = 10;
            this.btnRaporuYenile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRaporuYenile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRaporuYenile.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRaporuYenile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRaporuYenile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRaporuYenile.ForeColor = System.Drawing.Color.White;
            this.btnRaporuYenile.Location = new System.Drawing.Point(386, 13);
            this.btnRaporuYenile.Name = "btnRaporuYenile";
            this.btnRaporuYenile.Size = new System.Drawing.Size(180, 36);
            this.btnRaporuYenile.TabIndex = 12;
            this.btnRaporuYenile.Text = "Raporu Yenile";
            this.btnRaporuYenile.Click += new System.EventHandler(this.btnRaporuYenile_Click);
            // 
            // btnPDFCikar
            // 
            this.btnPDFCikar.Animated = true;
            this.btnPDFCikar.BorderRadius = 10;
            this.btnPDFCikar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPDFCikar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPDFCikar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPDFCikar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPDFCikar.FillColor = System.Drawing.Color.LimeGreen;
            this.btnPDFCikar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPDFCikar.ForeColor = System.Drawing.SystemColors.Window;
            this.btnPDFCikar.Location = new System.Drawing.Point(386, 55);
            this.btnPDFCikar.Name = "btnPDFCikar";
            this.btnPDFCikar.Size = new System.Drawing.Size(180, 36);
            this.btnPDFCikar.TabIndex = 13;
            this.btnPDFCikar.Text = "PDF Çıkar";
            this.btnPDFCikar.Click += new System.EventHandler(this.btnPDFCikar_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2Panel1.Controls.Add(this.btnPDFCikar);
            this.guna2Panel1.Controls.Add(this.dtpBaslangic);
            this.guna2Panel1.Controls.Add(this.btnRaporuYenile);
            this.guna2Panel1.Controls.Add(this.dtpBitis);
            this.guna2Panel1.Controls.Add(this.label2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 301);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(597, 100);
            this.guna2Panel1.TabIndex = 16;
            // 
            // Panel1Elipse
            // 
            this.Panel1Elipse.BorderRadius = 20;
            this.Panel1Elipse.TargetControl = this.guna2Panel1;
            // 
            // panel2Elipse
            // 
            this.panel2Elipse.BorderRadius = 20;
            this.panel2Elipse.TargetControl = this.panel2;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(751, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 17;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 6);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(45, 42);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 20;
            this.guna2PictureBox1.TabStop = false;
            // 
            // FrmElipse
            // 
            this.FrmElipse.BorderRadius = 20;
            this.FrmElipse.TargetControl = this;
            // 
            // FrmRaporlama
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 477);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRaporlama";
            this.Text = "Raporlama";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmRaporlama_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmRaporlama_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmRaporlama_MouseUp);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblToplamSatis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.DataGridView dataGridViewRapor;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBaslangic;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBitis;
        private Guna.UI2.WinForms.Guna2Button btnRaporuYenile;
        private Guna.UI2.WinForms.Guna2Button btnPDFCikar;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Elipse Panel1Elipse;
        private Guna.UI2.WinForms.Guna2Elipse panel2Elipse;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse FrmElipse;
    }
}

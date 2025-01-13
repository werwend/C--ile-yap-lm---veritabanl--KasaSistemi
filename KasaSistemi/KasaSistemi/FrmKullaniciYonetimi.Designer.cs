namespace KasaSistemi
{
    partial class FrmKullaniciYonetimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKullaniciYonetimi));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbRol = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtSifre = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtKullaniciAdi = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnKullaniciSil = new Guna.UI2.WinForms.Guna2Button();
            this.btnKullaniciGuncelle = new Guna.UI2.WinForms.Guna2Button();
            this.btnKullaniciEkle = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.dataGridViewKullanicilar = new System.Windows.Forms.DataGridView();
            this.panel1Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.Panel2Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.FrmElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanicilar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.panel1.Controls.Add(this.cmbRol);
            this.panel1.Controls.Add(this.txtSifre);
            this.panel1.Controls.Add(this.txtKullaniciAdi);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(413, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 257);
            this.panel1.TabIndex = 1;
            // 
            // cmbRol
            // 
            this.cmbRol.BackColor = System.Drawing.Color.Transparent;
            this.cmbRol.BorderRadius = 10;
            this.cmbRol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRol.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbRol.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRol.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbRol.ItemHeight = 30;
            this.cmbRol.Items.AddRange(new object[] {
            "Admin",
            "Yönetici",
            "Kasiyer",
            "Garson"});
            this.cmbRol.Location = new System.Drawing.Point(37, 155);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(150, 36);
            this.cmbRol.TabIndex = 8;
            // 
            // txtSifre
            // 
            this.txtSifre.Animated = true;
            this.txtSifre.BorderRadius = 10;
            this.txtSifre.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSifre.DefaultText = "";
            this.txtSifre.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSifre.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSifre.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSifre.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSifre.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSifre.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSifre.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSifre.Location = new System.Drawing.Point(37, 103);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.PlaceholderText = "Şifre";
            this.txtSifre.SelectedText = "";
            this.txtSifre.Size = new System.Drawing.Size(200, 36);
            this.txtSifre.TabIndex = 7;
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Animated = true;
            this.txtKullaniciAdi.BorderRadius = 10;
            this.txtKullaniciAdi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtKullaniciAdi.DefaultText = "";
            this.txtKullaniciAdi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtKullaniciAdi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtKullaniciAdi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKullaniciAdi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtKullaniciAdi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtKullaniciAdi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtKullaniciAdi.Location = new System.Drawing.Point(37, 51);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.PasswordChar = '\0';
            this.txtKullaniciAdi.PlaceholderText = "Kullanıcı Adı";
            this.txtKullaniciAdi.SelectedText = "";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(200, 36);
            this.txtKullaniciAdi.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(30, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 37);
            this.label3.TabIndex = 0;
            this.label3.Text = "Kullanıcı Bilgileri";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.panel2.Controls.Add(this.btnKullaniciSil);
            this.panel2.Controls.Add(this.btnKullaniciGuncelle);
            this.panel2.Controls.Add(this.btnKullaniciEkle);
            this.panel2.Location = new System.Drawing.Point(12, 316);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 59);
            this.panel2.TabIndex = 2;
            // 
            // btnKullaniciSil
            // 
            this.btnKullaniciSil.BorderRadius = 10;
            this.btnKullaniciSil.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKullaniciSil.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKullaniciSil.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKullaniciSil.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKullaniciSil.FillColor = System.Drawing.Color.IndianRed;
            this.btnKullaniciSil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciSil.ForeColor = System.Drawing.Color.Black;
            this.btnKullaniciSil.Location = new System.Drawing.Point(564, 11);
            this.btnKullaniciSil.Name = "btnKullaniciSil";
            this.btnKullaniciSil.Size = new System.Drawing.Size(180, 36);
            this.btnKullaniciSil.TabIndex = 2;
            this.btnKullaniciSil.Text = "Kullanıcı Sil";
            this.btnKullaniciSil.Click += new System.EventHandler(this.btnKullaniciSil_Click);
            // 
            // btnKullaniciGuncelle
            // 
            this.btnKullaniciGuncelle.BorderRadius = 10;
            this.btnKullaniciGuncelle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKullaniciGuncelle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKullaniciGuncelle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKullaniciGuncelle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKullaniciGuncelle.FillColor = System.Drawing.Color.Gold;
            this.btnKullaniciGuncelle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnKullaniciGuncelle.Location = new System.Drawing.Point(296, 11);
            this.btnKullaniciGuncelle.Name = "btnKullaniciGuncelle";
            this.btnKullaniciGuncelle.Size = new System.Drawing.Size(180, 36);
            this.btnKullaniciGuncelle.TabIndex = 1;
            this.btnKullaniciGuncelle.Text = "Kullanıcı Güncelle";
            this.btnKullaniciGuncelle.Click += new System.EventHandler(this.btnKullaniciGuncelle_Click);
            // 
            // btnKullaniciEkle
            // 
            this.btnKullaniciEkle.BorderRadius = 10;
            this.btnKullaniciEkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnKullaniciEkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnKullaniciEkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnKullaniciEkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnKullaniciEkle.FillColor = System.Drawing.Color.LightGreen;
            this.btnKullaniciEkle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKullaniciEkle.ForeColor = System.Drawing.Color.Black;
            this.btnKullaniciEkle.Location = new System.Drawing.Point(37, 11);
            this.btnKullaniciEkle.Name = "btnKullaniciEkle";
            this.btnKullaniciEkle.Size = new System.Drawing.Size(180, 36);
            this.btnKullaniciEkle.TabIndex = 0;
            this.btnKullaniciEkle.Text = "Kullanıcı Ekle";
            this.btnKullaniciEkle.Click += new System.EventHandler(this.btnKullaniciEkle_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 25;
            this.guna2CustomGradientPanel1.Controls.Add(this.dataGridViewKullanicilar);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(12, 42);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(380, 257);
            this.guna2CustomGradientPanel1.TabIndex = 13;
            // 
            // dataGridViewKullanicilar
            // 
            this.dataGridViewKullanicilar.AllowUserToAddRows = false;
            this.dataGridViewKullanicilar.AllowUserToDeleteRows = false;
            this.dataGridViewKullanicilar.AllowUserToResizeColumns = false;
            this.dataGridViewKullanicilar.AllowUserToResizeRows = false;
            this.dataGridViewKullanicilar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.dataGridViewKullanicilar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewKullanicilar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewKullanicilar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewKullanicilar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewKullanicilar.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(143)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewKullanicilar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewKullanicilar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewKullanicilar.EnableHeadersVisualStyles = false;
            this.dataGridViewKullanicilar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewKullanicilar.Location = new System.Drawing.Point(15, 12);
            this.dataGridViewKullanicilar.MultiSelect = false;
            this.dataGridViewKullanicilar.Name = "dataGridViewKullanicilar";
            this.dataGridViewKullanicilar.ReadOnly = true;
            this.dataGridViewKullanicilar.RowHeadersVisible = false;
            this.dataGridViewKullanicilar.RowHeadersWidth = 25;
            this.dataGridViewKullanicilar.RowTemplate.DividerHeight = 2;
            this.dataGridViewKullanicilar.RowTemplate.Height = 25;
            this.dataGridViewKullanicilar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewKullanicilar.Size = new System.Drawing.Size(345, 232);
            this.dataGridViewKullanicilar.TabIndex = 11;
            // 
            // panel1Elipse
            // 
            this.panel1Elipse.BorderRadius = 10;
            this.panel1Elipse.TargetControl = this.panel1;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(727, 7);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 14;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(10, 0);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(45, 42);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 20;
            this.guna2PictureBox1.TabStop = false;
            // 
            // Panel2Elipse
            // 
            this.Panel2Elipse.BorderRadius = 10;
            this.Panel2Elipse.TargetControl = this.panel2;
            // 
            // FrmElipse
            // 
            this.FrmElipse.BorderRadius = 20;
            this.FrmElipse.TargetControl = this;
            // 
            // FrmKullaniciYonetimi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(784, 396);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmKullaniciYonetimi";
            this.Text = "Kullanıcı Yönetimi";
            this.Load += new System.EventHandler(this.FrmKullaniciYonetimi_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmKullaniciYonetimi_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmKullaniciYonetimi_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmKullaniciYonetimi_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKullanicilar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.DataGridView dataGridViewKullanicilar;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRol;
        private Guna.UI2.WinForms.Guna2TextBox txtSifre;
        private Guna.UI2.WinForms.Guna2TextBox txtKullaniciAdi;
        private Guna.UI2.WinForms.Guna2Button btnKullaniciSil;
        private Guna.UI2.WinForms.Guna2Button btnKullaniciGuncelle;
        private Guna.UI2.WinForms.Guna2Button btnKullaniciEkle;
        private Guna.UI2.WinForms.Guna2Elipse panel1Elipse;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse Panel2Elipse;
        private Guna.UI2.WinForms.Guna2Elipse FrmElipse;
    }
}

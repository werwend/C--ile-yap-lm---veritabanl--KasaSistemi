namespace KasaSistemi
{
    partial class FrmUrunYonetimi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUrunYonetimi));
            this.panelBilgi = new System.Windows.Forms.Panel();
            this.cmbKategori = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtFiyat = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtUrunAdi = new Guna.UI2.WinForms.Guna2TextBox();
            this.panelButonlar = new System.Windows.Forms.Panel();
            this.btnGuncelle = new Guna.UI2.WinForms.Guna2Button();
            this.btnSil = new Guna.UI2.WinForms.Guna2Button();
            this.btnEkle = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.dataGridViewUrunler = new System.Windows.Forms.DataGridView();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.PanelBilgiElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelButonlarElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.FrmElipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.panelBilgi.SuspendLayout();
            this.panelButonlar.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBilgi
            // 
            this.panelBilgi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.panelBilgi.Controls.Add(this.cmbKategori);
            this.panelBilgi.Controls.Add(this.txtFiyat);
            this.panelBilgi.Controls.Add(this.txtUrunAdi);
            this.panelBilgi.Location = new System.Drawing.Point(629, 49);
            this.panelBilgi.Name = "panelBilgi";
            this.panelBilgi.Size = new System.Drawing.Size(300, 180);
            this.panelBilgi.TabIndex = 1;
            // 
            // cmbKategori
            // 
            this.cmbKategori.BackColor = System.Drawing.Color.Transparent;
            this.cmbKategori.BorderRadius = 10;
            this.cmbKategori.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbKategori.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbKategori.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbKategori.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbKategori.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbKategori.ItemHeight = 30;
            this.cmbKategori.Location = new System.Drawing.Point(13, 117);
            this.cmbKategori.Name = "cmbKategori";
            this.cmbKategori.Size = new System.Drawing.Size(258, 36);
            this.cmbKategori.TabIndex = 2;
            // 
            // txtFiyat
            // 
            this.txtFiyat.BorderRadius = 10;
            this.txtFiyat.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFiyat.DefaultText = "";
            this.txtFiyat.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFiyat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFiyat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiyat.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFiyat.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiyat.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFiyat.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFiyat.Location = new System.Drawing.Point(13, 75);
            this.txtFiyat.Name = "txtFiyat";
            this.txtFiyat.PasswordChar = '\0';
            this.txtFiyat.PlaceholderText = "Fiyat";
            this.txtFiyat.SelectedText = "";
            this.txtFiyat.Size = new System.Drawing.Size(258, 36);
            this.txtFiyat.TabIndex = 1;
            // 
            // txtUrunAdi
            // 
            this.txtUrunAdi.BorderRadius = 10;
            this.txtUrunAdi.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUrunAdi.DefaultText = "";
            this.txtUrunAdi.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUrunAdi.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUrunAdi.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUrunAdi.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUrunAdi.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUrunAdi.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUrunAdi.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUrunAdi.Location = new System.Drawing.Point(13, 33);
            this.txtUrunAdi.Name = "txtUrunAdi";
            this.txtUrunAdi.PasswordChar = '\0';
            this.txtUrunAdi.PlaceholderText = "Ürün Adı";
            this.txtUrunAdi.SelectedText = "";
            this.txtUrunAdi.Size = new System.Drawing.Size(258, 36);
            this.txtUrunAdi.TabIndex = 0;
            // 
            // panelButonlar
            // 
            this.panelButonlar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.panelButonlar.Controls.Add(this.btnGuncelle);
            this.panelButonlar.Controls.Add(this.btnSil);
            this.panelButonlar.Controls.Add(this.btnEkle);
            this.panelButonlar.Location = new System.Drawing.Point(629, 237);
            this.panelButonlar.Name = "panelButonlar";
            this.panelButonlar.Size = new System.Drawing.Size(300, 120);
            this.panelButonlar.TabIndex = 2;
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BorderRadius = 10;
            this.btnGuncelle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGuncelle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGuncelle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGuncelle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGuncelle.FillColor = System.Drawing.Color.Gold;
            this.btnGuncelle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.btnGuncelle.ForeColor = System.Drawing.Color.Black;
            this.btnGuncelle.Location = new System.Drawing.Point(153, 17);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(120, 40);
            this.btnGuncelle.TabIndex = 2;
            this.btnGuncelle.Text = "Ürün Güncelle";
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BorderRadius = 10;
            this.btnSil.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSil.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSil.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSil.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSil.FillColor = System.Drawing.Color.IndianRed;
            this.btnSil.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSil.ForeColor = System.Drawing.Color.Black;
            this.btnSil.Location = new System.Drawing.Point(13, 63);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(260, 40);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Ürün Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.BorderRadius = 10;
            this.btnEkle.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEkle.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEkle.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEkle.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEkle.FillColor = System.Drawing.Color.LimeGreen;
            this.btnEkle.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEkle.ForeColor = System.Drawing.Color.Black;
            this.btnEkle.Location = new System.Drawing.Point(13, 17);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(120, 40);
            this.btnEkle.TabIndex = 0;
            this.btnEkle.Text = "Ürün Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BorderRadius = 25;
            this.guna2CustomGradientPanel1.Controls.Add(this.dataGridViewUrunler);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(12, 49);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(575, 416);
            this.guna2CustomGradientPanel1.TabIndex = 14;
            // 
            // dataGridViewUrunler
            // 
            this.dataGridViewUrunler.AllowUserToAddRows = false;
            this.dataGridViewUrunler.AllowUserToDeleteRows = false;
            this.dataGridViewUrunler.AllowUserToResizeColumns = false;
            this.dataGridViewUrunler.AllowUserToResizeRows = false;
            this.dataGridViewUrunler.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            this.dataGridViewUrunler.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUrunler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewUrunler.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(202)))), ((int)(((byte)(246)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewUrunler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewUrunler.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(143)))), ((int)(((byte)(242)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewUrunler.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewUrunler.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dataGridViewUrunler.EnableHeadersVisualStyles = false;
            this.dataGridViewUrunler.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridViewUrunler.Location = new System.Drawing.Point(15, 12);
            this.dataGridViewUrunler.MultiSelect = false;
            this.dataGridViewUrunler.Name = "dataGridViewUrunler";
            this.dataGridViewUrunler.ReadOnly = true;
            this.dataGridViewUrunler.RowHeadersVisible = false;
            this.dataGridViewUrunler.RowHeadersWidth = 25;
            this.dataGridViewUrunler.RowTemplate.DividerHeight = 2;
            this.dataGridViewUrunler.RowTemplate.Height = 25;
            this.dataGridViewUrunler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewUrunler.Size = new System.Drawing.Size(535, 388);
            this.dataGridViewUrunler.TabIndex = 11;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Black;
            this.guna2ControlBox1.Location = new System.Drawing.Point(902, 2);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(45, 29);
            this.guna2ControlBox1.TabIndex = 18;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 2);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(45, 42);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 19;
            this.guna2PictureBox1.TabStop = false;
            // 
            // PanelBilgiElipse
            // 
            this.PanelBilgiElipse.BorderRadius = 10;
            this.PanelBilgiElipse.TargetControl = this.panelBilgi;
            // 
            // panelButonlarElipse
            // 
            this.panelButonlarElipse.BorderRadius = 10;
            this.panelButonlarElipse.TargetControl = this.panelButonlar;
            // 
            // FrmElipse
            // 
            this.FrmElipse.BorderRadius = 20;
            this.FrmElipse.TargetControl = this;
            // 
            // FrmUrunYonetimi
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(950, 477);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Controls.Add(this.panelButonlar);
            this.Controls.Add(this.panelBilgi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmUrunYonetimi";
            this.Text = "Ürün Yönetimi";
            this.Load += new System.EventHandler(this.FrmUrunYonetimi_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmUrunYonetimi_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FrmUrunYonetimi_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FrmUrunYonetimi_MouseUp);
            this.panelBilgi.ResumeLayout(false);
            this.panelButonlar.ResumeLayout(false);
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUrunler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelBilgi;
        private System.Windows.Forms.Panel panelButonlar;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.DataGridView dataGridViewUrunler;
        private Guna.UI2.WinForms.Guna2Button btnGuncelle;
        private Guna.UI2.WinForms.Guna2Button btnSil;
        private Guna.UI2.WinForms.Guna2Button btnEkle;
        private Guna.UI2.WinForms.Guna2ComboBox cmbKategori;
        private Guna.UI2.WinForms.Guna2TextBox txtFiyat;
        private Guna.UI2.WinForms.Guna2TextBox txtUrunAdi;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Elipse PanelBilgiElipse;
        private Guna.UI2.WinForms.Guna2Elipse panelButonlarElipse;
        private Guna.UI2.WinForms.Guna2Elipse FrmElipse;
    }
}

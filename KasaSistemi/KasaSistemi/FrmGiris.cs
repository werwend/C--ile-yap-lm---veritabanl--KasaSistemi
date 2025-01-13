using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KasaSistemi
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        private bool Surukleme = false;
        private Point baslangicNoktasi = new Point(0, 0);




        void AlertBoxArtan(Color backColor, Color color, string title, string text, Image icon)
        {
            FrmAlertBox frm = new FrmAlertBox();
            frm.BackColor = backColor;
            frm.ColorAlertBox = color;
            frm.TitleAlertBox = title;
            frm.TextAlertBox = text;
            frm.IconeAlertBox = icon;
            frm.TopMost = true;

            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();
        }

        private void FrmGiris_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000);
        }

        #region Bağlantı
        private string Baglanti()
        {
            return ConfigurationManager.ConnectionStrings["KafeKasaSistemiDB"].ConnectionString;
        }
        #endregion


        #region Giriş Çıkış İşlemleri
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullaniciAdi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre))
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Kullanıcı adı ve şifre boş bırakılamaz!", Properties.Resources.Error);
                //MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Rol FROM Kullanicilar WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", sifre);

                    object rolObj = command.ExecuteScalar();
                    if (rolObj != null)
                    {
                        string rol = rolObj.ToString();
                        AlertBoxArtan(Color.LightGray, Color.SeaGreen, "Bilgi", $"Giriş Başarılı " +
                            $"Rol: {rol}", Properties.Resources.success);
                        //MessageBox.Show($"Giriş Başarılı " +
                            //$"Rol: {rol}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information); // Rol kontrolü

                        // Ana Formu aç ve KullaniciRol'ü ata
                        FrmAnaForm anaForm = new FrmAnaForm();
                        anaForm.KullaniciRol = rol; // Rolü FrmAnaForm'a aktarıyoruz
                        anaForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Geçersiz kullanıcı adı veya şifre!", Properties.Resources.Error);
                        MessageBox.Show("Geçersiz kullanıcı adı veya şifre!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Sürükleme İşlemleri
        private void guna2Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Surukleme = true;
                baslangicNoktasi = new Point(e.X, e.Y); // Tıklama konumunu kaydet
            }
        }

        private void guna2Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Surukleme)
            {
                // Formun yeni konumunu hesapla
                Point newPoint = this.Location;
                newPoint.X += e.X - baslangicNoktasi.X;
                newPoint.Y += e.Y - baslangicNoktasi.Y;
                this.Location = newPoint; // Formun konumunu güncelle
            }
        }

        private void guna2Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Surukleme = false; // Sürükleme işlemini durdur
        }

        #endregion
    }
}

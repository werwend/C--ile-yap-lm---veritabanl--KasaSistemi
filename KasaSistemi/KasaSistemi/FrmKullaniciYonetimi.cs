using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KasaSistemi
{
    public partial class FrmKullaniciYonetimi : Form
    {
        public FrmKullaniciYonetimi()
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


        private void FrmKullaniciYonetimi_Load(object sender, EventArgs e)
        {
            KullanicilariListele();
        }
        #region Bağlantı
        private string Baglanti()
        {
            return ConfigurationManager.ConnectionStrings["KafeKasaSistemiDB"].ConnectionString;
        }
        #endregion

        #region Metotlar
        private void KullanicilariListele()
        {
            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT KullaniciID, KullaniciAdi, Rol FROM Kullanicilar";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewKullanicilar.DataSource = dt;

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcılar listelenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Butonlar
        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciAdi = txtKullaniciAdi.Text.Trim();
                string sifre = txtSifre.Text.Trim();
                string rol = cmbRol.Text;

                if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(rol))
                {
                    AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen tüm alanları doldurun!", Properties.Resources.Error);
                    //MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Kullanicilar (KullaniciAdi, Sifre, Rol) VALUES (@KullaniciAdi, @Sifre, @Rol)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", sifre);
                    command.Parameters.AddWithValue("@Rol", rol);

                    command.ExecuteNonQuery();

                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Kullanıcı başarıyla eklendi.", Properties.Resources.information);
                    //MessageBox.Show("Kullanıcı başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    KullanicilariListele(); // Kullanıcıları yeniden listele

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı eklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKullaniciGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewKullanicilar.SelectedRows.Count == 0)
                {
                    AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen güncellenecek kullanıcıyı seçin!", Properties.Resources.Error);
                    //MessageBox.Show("Lütfen güncellenecek kullanıcıyı seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kullaniciID = Convert.ToInt32(dataGridViewKullanicilar.SelectedRows[0].Cells["KullaniciID"].Value);
                string kullaniciAdi = txtKullaniciAdi.Text.Trim();
                string sifre = txtSifre.Text.Trim();
                string rol = cmbRol.Text;

                if (string.IsNullOrEmpty(kullaniciAdi) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(rol))
                {
                    AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen tüm alanları doldurun!", Properties.Resources.Error);
                    //MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Kullanicilar SET KullaniciAdi = @KullaniciAdi, Sifre = @Sifre, Rol = @Rol WHERE KullaniciID = @KullaniciID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@Sifre", sifre);
                    command.Parameters.AddWithValue("@Rol", rol);
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                    command.ExecuteNonQuery();

                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Kullanıcı başarıyla güncellendi.", Properties.Resources.information);
                    //MessageBox.Show("Kullanıcı başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    KullanicilariListele(); // Kullanıcıları yeniden listele

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKullaniciSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewKullanicilar.SelectedRows.Count == 0)
                {
                    AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen silinecek kullanıcıyı seçin!", Properties.Resources.Error);
                    //MessageBox.Show("Lütfen silinecek kullanıcıyı seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int kullaniciID = Convert.ToInt32(dataGridViewKullanicilar.SelectedRows[0].Cells["KullaniciID"].Value);

                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Kullanicilar WHERE KullaniciID = @KullaniciID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@KullaniciID", kullaniciID);

                    command.ExecuteNonQuery();

                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Kullanıcı başarıyla silindi.", Properties.Resources.information);
                    //MessageBox.Show("Kullanıcı başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    KullanicilariListele(); // Kullanıcıları yeniden listele

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kullanıcı silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Sürükleme İşlemler
        private void FrmKullaniciYonetimi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Surukleme = true;
                baslangicNoktasi = new Point(e.X, e.Y); // Tıklama konumunu kaydet
            }
        }

        private void FrmKullaniciYonetimi_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmKullaniciYonetimi_MouseUp(object sender, MouseEventArgs e)
        {
            Surukleme = false; // Sürükleme işlemini durdur
        }
        #endregion

    }
}

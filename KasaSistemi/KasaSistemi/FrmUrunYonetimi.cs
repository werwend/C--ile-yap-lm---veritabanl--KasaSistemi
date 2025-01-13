using System.Data.SqlClient;
using System.Data;
using System;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;

namespace KasaSistemi
{
    public partial class FrmUrunYonetimi : Form
    {
        public FrmUrunYonetimi()
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

        


        private void FrmUrunYonetimi_Load(object sender, EventArgs e)
        {
            UrunleriListele();
            KategorileriYukle();
        }
        #region Bağlantı
        private string Baglanti()
        {
            return ConfigurationManager.ConnectionStrings["KafeKasaSistemiDB"].ConnectionString;
        }
        #endregion

        #region Metotlar

        private void UrunleriListele()
        {
            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT u.UrunID, u.UrunAdi, u.Fiyat, k.KategoriAdi " +
                                   "FROM Urunler u " +
                                   "INNER JOIN Kategoriler k ON u.KategoriID = k.KategoriID";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewUrunler.DataSource = dt;

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler listelenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void KategorileriYukle()
        {
            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT KategoriID, KategoriAdi FROM Kategoriler";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    cmbKategori.DataSource = dt;
                    cmbKategori.DisplayMember = "KategoriAdi";
                    cmbKategori.ValueMember = "KategoriID";

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kategoriler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Ürün Ekle , Ürün Güncelle, Ürün Sil
        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                string urunAdi = txtUrunAdi.Text.Trim();
                decimal fiyat = Convert.ToDecimal(txtFiyat.Text);
                int kategoriID = Convert.ToInt32(cmbKategori.SelectedValue);

                if (string.IsNullOrEmpty(urunAdi) || fiyat <= 0 || kategoriID <= 0)
                {
                    AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen tüm bilgileri eksiksiz ve doğru girin.", Properties.Resources.Error);
                    //MessageBox.Show("Lütfen tüm bilgileri eksiksiz ve doğru girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "INSERT INTO Urunler (UrunAdi, Fiyat, KategoriID) VALUES (@UrunAdi, @Fiyat, @KategoriID)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    command.Parameters.AddWithValue("@Fiyat", fiyat);
                    command.Parameters.AddWithValue("@KategoriID", kategoriID);

                    command.ExecuteNonQuery();
                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Ürün başarıyla eklendi.", Properties.Resources.information);
                    //MessageBox.Show("Ürün başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // FrmAnaForm'daki ürünleri yenile
                    FrmAnaForm.Instance.UrunleriYukle();

                    connection.Close();
                    connection.Dispose();
                }
                UrunleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün eklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridViewUrunler.SelectedRows.Count == 0)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen güncellemek istediğiniz ürünü seçin.", Properties.Resources.Error);
                //MessageBox.Show("Lütfen güncellemek istediğiniz ürünü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int urunID = Convert.ToInt32(dataGridViewUrunler.SelectedRows[0].Cells["UrunID"].Value);
                string urunAdi = txtUrunAdi.Text.Trim();
                decimal fiyat = Convert.ToDecimal(txtFiyat.Text);
                int kategoriID = Convert.ToInt32(cmbKategori.SelectedValue);

                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "UPDATE Urunler SET UrunAdi = @UrunAdi, Fiyat = @Fiyat, KategoriID = @KategoriID WHERE UrunID = @UrunID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunAdi", urunAdi);
                    command.Parameters.AddWithValue("@Fiyat", fiyat);
                    command.Parameters.AddWithValue("@KategoriID", kategoriID);
                    command.Parameters.AddWithValue("@UrunID", urunID);

                    command.ExecuteNonQuery();

                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Ürün başarıyla güncellendi.", Properties.Resources.information);
                    //MessageBox.Show("Ürün başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UrunleriListele();

                    connection.Close();
                    connection.Dispose();
                }
                UrunleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FrmAnaForm.Instance.UrunleriYukle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewUrunler.SelectedRows.Count == 0)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen silmek istediğiniz ürünü seçin.", Properties.Resources.Error);
                MessageBox.Show("Lütfen silmek istediğiniz ürünü seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int urunID = Convert.ToInt32(dataGridViewUrunler.SelectedRows[0].Cells["UrunID"].Value);

                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Urunler WHERE UrunID = @UrunID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UrunID", urunID);

                    command.ExecuteNonQuery();

                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Ürün başarıyla silindi.", Properties.Resources.information);
                    //MessageBox.Show("Ürün başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UrunleriListele();

                    connection.Close();
                    connection.Dispose();
                }
                UrunleriListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün silinirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FrmAnaForm.Instance.UrunleriYukle();
        }

        #endregion

        #region Sürükleme İşlemleri

        private void FrmUrunYonetimi_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Surukleme = true;
                baslangicNoktasi = new Point(e.X, e.Y); // Tıklama konumunu kaydet
            }
        }

        private void FrmUrunYonetimi_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmUrunYonetimi_MouseUp(object sender, MouseEventArgs e)
        {
            Surukleme = false; // Sürükleme işlemini durdur
        }

        #endregion

    }
}

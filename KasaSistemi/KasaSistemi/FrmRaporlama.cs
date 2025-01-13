using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
using DrawingImage = System.Drawing.Image;





namespace KasaSistemi
{
    public partial class FrmRaporlama : Form
    {
        public FrmRaporlama()
        {
            InitializeComponent();
        }

        private bool Surukleme = false;
        private Point baslangicNoktasi = new Point(0, 0);

        #region Bildirim
        void AlertBoxArtan(Color backColor, Color color, string title, string text, DrawingImage icon)
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
        #endregion

        #region Bağlantı
        private string Baglanti()
        {
            return ConfigurationManager.ConnectionStrings["KafeKasaSistemiDB"].ConnectionString;
        }
        #endregion

        #region Metotlar
        private void RaporuYenile()
        {
            DateTime baslangicTarihi = dtpBaslangic.Value.Date; // Başlangıç tarihi
            DateTime bitisTarihi = dtpBitis.Value.Date.AddDays(1).AddTicks(-1); // Bitiş tarihi

            string connectionString = Baglanti();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                SELECT 
                    s.SatisID AS [Satış No],
                    m.MasaAdi AS [Masa Adı],
                    s.Tarih AS [Tarih],
                    SUM(d.AraToplam) AS [Toplam Tutar],
                    o.OdemeYontemi AS [Ödeme Türü],
                    s.Durum AS [Durum]
                FROM Satislar s
                INNER JOIN Masalar m ON s.MasaID = m.MasaID
                INNER JOIN SatisDetaylari d ON s.SatisID = d.SatisID
                LEFT JOIN Odemeler o ON s.SatisID = o.SatisID
                WHERE s.Durum = 'Ödenmiş' AND s.Tarih BETWEEN @Baslangic AND @Bitis
                GROUP BY s.SatisID, m.MasaAdi, s.Tarih, o.OdemeYontemi, s.Durum
                ORDER BY s.Tarih;";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Baslangic", baslangicTarihi);
                command.Parameters.AddWithValue("@Bitis", bitisTarihi);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridViewRapor.DataSource = dt;

                connection.Close();
                connection.Dispose();
            }
        }




        private void ToplamSatisHesapla()
        {
            DateTime baslangicTarihi = dtpBaslangic.Value.Date;
            DateTime bitisTarihi = dtpBitis.Value.Date.AddDays(1).AddTicks(-1);

            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT 
                    SUM(d.AraToplam) AS [Toplam Tutar]
                FROM Satislar s
                INNER JOIN SatisDetaylari d ON s.SatisID = d.SatisID
                WHERE s.Durum = 'Ödenmiş' AND s.Tarih BETWEEN @Baslangic AND @Bitis";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Baslangic", baslangicTarihi);
                    command.Parameters.AddWithValue("@Bitis", bitisTarihi);

                    object result = command.ExecuteScalar();
                    decimal toplamTutar = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                    lblToplamSatis.Text = $"Toplam Satış: {toplamTutar:C2}";

                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Toplam satış hesaplanırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Butonlar
        private void btnRaporuYenile_Click(object sender, EventArgs e)
        {
            RaporuYenile();
            ToplamSatisHesapla();
        }

        private void btnPDFCikar_Click(object sender, EventArgs e)
        {
            // Kullanıcı dosya yolu seçsin
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files|*.pdf",
                Title = "PDF Dosyasını Kaydet"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string dosyaYolu = saveFileDialog.FileName;

                    // PDF oluşturma işlemi
                    using (var belge = new iTextSharp.text.Document())
                    {
                        PdfWriter.GetInstance(belge, new FileStream(dosyaYolu, FileMode.Create));
                        belge.Open();

                        // PDF başlığı ekleme
                        var baslikTipi = iTextSharp.text.FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                        belge.Add(new iTextSharp.text.Paragraph("Satis Raporu", baslikTipi));
                        belge.Add(new iTextSharp.text.Paragraph($"Tarih: {DateTime.Now:dd.MM.yyyy HH:mm}\n\n"));

                        // DataGridView'den PDF'e veri aktarma
                        var tablo = new iTextSharp.text.pdf.PdfPTable(dataGridViewRapor.ColumnCount);
                        foreach (DataGridViewColumn column in dataGridViewRapor.Columns)
                        {
                            tablo.AddCell(new Phrase(column.HeaderText));
                        }

                        foreach (DataGridViewRow satır in dataGridViewRapor.Rows)
                        {
                            if (!satır.IsNewRow) 
                            {
                                foreach (DataGridViewCell cell in satır.Cells)
                                {
                                    tablo.AddCell(cell.Value?.ToString() ?? "");
                                }
                            }
                        }

                        belge.Add(tablo);
                        belge.Close();
                    }

                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "PDF başarıyla oluşturuldu.", Properties.Resources.information);
                    //MessageBox.Show("PDF başarıyla oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"PDF oluşturulurken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Sürükleme İşlemleri
        private void FrmRaporlama_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Surukleme = true;
                baslangicNoktasi = new Point(e.X, e.Y); // Tıklama konumunu kaydet
            }
        }

        private void FrmRaporlama_MouseMove(object sender, MouseEventArgs e)
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

        private void FrmRaporlama_MouseUp(object sender, MouseEventArgs e)
        {
            Surukleme = false; // Sürükleme işlemini durdur
        }
        #endregion


    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using Guna.UI2.WinForms;



namespace KasaSistemi
{
    public partial class FrmAnaForm : Form
    {
        public static FrmAnaForm Instance { get; private set; }
        public FrmAnaForm()
        {
            InitializeComponent();
            Instance = this; // Bu formun referansını static olarak kayıt eder
        }

        #region Public, Private

        // Formun sürüklenip taşınmasını kontrol etmek için kullanılan bayrak
        private bool Surukleme = false;

        // Formun taşınmaya başladığı noktayı tutar
        private Point baslangicNoktasi = new Point(0, 0);

        // Kullanıcının rolünü tutar (örneğin, Admin, Yönetici, Kullanıcı)
        public string KullaniciRol { get; set; }

        // Hedef masa için ID değişkeni (varsayılan olarak -1, yani başlangıçta seçili masa yok)
        private int hedefMasaID = -1;

        // Seçilen masanın ID'sini tutar (varsayılan olarak -1, yani başlangıçta hiçbir masa seçilmemiş)
        private int selectedMasaID = -1;

        #endregion

        #region Bağlantı
        private string Baglanti()
        {
            return ConfigurationManager.ConnectionStrings["KafeKasaSistemiDB"].ConnectionString;
        }
        #endregion

        #region FrmAnaForm_Load
        private void FrmAnaForm_Load(object sender, EventArgs e)
        {
            // Masaları arayüze yükler
            MasalariYukle();

            // Raporlama Menüsü (Admin ve Yönetici için)
            if (KullaniciRol == "Admin" || KullaniciRol == "Yönetici")
            {
                // Raporlama menüsünü oluştur ve ana menüye ekle
                ToolStripMenuItem raporlamaMenu = new ToolStripMenuItem("Raporlama");
                raporlamaMenu.Click += BtnRaporlama_Click;
                raporlamaMenu.ShortcutKeys = Keys.Control | Keys.R;
                raporlamaMenu.Image = Properties.Resources.raporlama;
                raporlamaMenu.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                MTLSNovix.DropDownItems.Add(raporlamaMenu);
            }

            // Kullanıcı Yönetimi Menüsü (Sadece Admin için)
            if (KullaniciRol == "Admin")
            {
                // Kullanıcı Yönetimi menüsünü oluştur ve ana menüye ekler
                ToolStripMenuItem kullaniciYonetimiMenu = new ToolStripMenuItem("Kullanıcı Yönetimi");
                kullaniciYonetimiMenu.Click += BtnKullaniciYonetimi_Click;
                kullaniciYonetimiMenu.ShortcutKeys = Keys.Control | Keys.Y;
                kullaniciYonetimiMenu.Image = Properties.Resources.kullanici;
                kullaniciYonetimiMenu.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                MTLSNovix.DropDownItems.Add(kullaniciYonetimiMenu);
            }

            // Ürün Yönetimi Menüsü (Admin ve Yönetici için)
            if (KullaniciRol == "Admin" || KullaniciRol == "Yönetici")
            {
                // Ürün Yönetimi menüsünü oluştur ve ana menüye ekler
                ToolStripMenuItem urunYonetimiMenu = new ToolStripMenuItem("Ürün Yönetimi");
                urunYonetimiMenu.Click += btnUrunYonetimi_Click;
                urunYonetimiMenu.ShortcutKeys = Keys.Control | Keys.U;
                urunYonetimiMenu.Image = Properties.Resources.urun;
                urunYonetimiMenu.ImageScaling = ToolStripItemImageScaling.SizeToFit;
                MTLSNovix.DropDownItems.Add(urunYonetimiMenu);
            }


        }


        #endregion

        #region Metotlar

        #region Masa İşlemleri

        private void MasaDurumunuGuncelle(int masaID)
        {
            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Masadaki aktif siparişleri kontrol et
                    string kontrolQuery = @"
            SELECT COUNT(*) 
            FROM SatisDetaylari sd
            INNER JOIN Satislar s ON sd.SatisID = s.SatisID
            WHERE s.MasaID = @MasaID AND s.Durum = 'Aktif'";

                    SqlCommand kontrolCommand = new SqlCommand(kontrolQuery, connection);
                    kontrolCommand.Parameters.AddWithValue("@MasaID", masaID);

                    // Aktif sipariş sayısını al
                    int kalanSiparisSayisi = Convert.ToInt32(kontrolCommand.ExecuteScalar());

                    // Masa durumunu belirle ve güncelle
                    string durumGuncelleQuery = "UPDATE Masalar SET Durum = @Durum WHERE MasaID = @MasaID";
                    SqlCommand durumGuncelleCommand = new SqlCommand(durumGuncelleQuery, connection);
                    durumGuncelleCommand.Parameters.AddWithValue("@MasaID", masaID);

                    // Sipariş yoksa "Boş", varsa "Dolu" olarak ayarla
                    if (kalanSiparisSayisi == 0)
                    {
                        durumGuncelleCommand.Parameters.AddWithValue("@Durum", "Boş");
                    }
                    else
                    {
                        durumGuncelleCommand.Parameters.AddWithValue("@Durum", "Dolu");
                    }

                    durumGuncelleCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Hata oluştuğunda kullanıcıya bilgi ver
                MessageBox.Show($"Masa durumu güncellenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Sipariş İşlemleri

        private void SiparisleriListele(int masaID)
        {
            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Seçilen masanın aktif siparişlerini sorgular
                    string query = @"
                SELECT 
                d.SatisDetayID AS [SatisDetayID], 
                d.UrunID AS [UrunID],
                u.UrunAdi AS [Ürün Adı],
                d.Adet AS [Adet],
                d.BirimFiyat AS [Birim Fiyat],
                d.AraToplam AS [Ara Toplam]
                FROM SatisDetaylari d
                INNER JOIN Satislar s ON d.SatisID = s.SatisID
                INNER JOIN Urunler u ON d.UrunID = u.UrunID
                WHERE s.MasaID = @MasaID AND s.Durum = 'Aktif'";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MasaID", masaID);

                    // Sorgu sonucunu bir DataTable'a aktarır
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Siparişleri DataGridView'e yükler
                    dataGridViewSiparis.DataSource = dt;

                    // Görünmesini istemediğimiz sütunları gizler
                    dataGridViewSiparis.Columns["SatisDetayID"].Visible = false;
                    dataGridViewSiparis.Columns["UrunID"].Visible = false;

                    // Siparişlerin toplam tutarını hesaplar
                    decimal toplamTutar = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        toplamTutar += row["Ara Toplam"] != DBNull.Value ? Convert.ToDecimal(row["Ara Toplam"]) : 0;
                    }

                    // Toplam tutarı arayüzde gösterir
                    lblToplamTutar.Text = $"Toplam Tutar: {toplamTutar:C2}";
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi verir
                MessageBox.Show($"Siparişler listelenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void UrunleriGoster()
        {
            try
            {
                // Önceki içerikleri temizler
                flowLayoutPanelMasalar.Controls.Clear();

                string connectionString = Baglanti();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Ürünleri sorgular
                    string query = "SELECT UrunID, UrunAdi FROM Urunler";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Her ürün için bir buton oluştur ve ekle
                    while (reader.Read())
                    {
                        Guna2Button urunButonu = new Guna2Button
                        {
                            Name = "Urun" + reader["UrunID"].ToString(),
                            Text = reader["UrunAdi"].ToString(),
                            Width = 150,
                            Height = 50,
                            BorderRadius = 12,
                            FillColor = Color.LightBlue,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            ForeColor = Color.White
                        };

                        // Ürün butonuna tıklama olayını bağla
                        urunButonu.Click += UrunButonu_Click;

                        // Ürün butonunu arayüze ekle
                        flowLayoutPanelMasalar.Controls.Add(urunButonu);
                    }

                    reader.Close();
                }

                // Adet seçimi için bir NumericUpDown kontrolü ekler
                Guna2NumericUpDown nudAdet = new Guna2NumericUpDown
                {
                    Name = "nudAdet",
                    Minimum = 1,
                    Maximum = 100,
                    Value = 1,
                    Width = 150,
                    Height = 50,
                    BorderRadius = 10,
                    FillColor = Color.White,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.Black
                };
                flowLayoutPanelMasalar.Controls.Add(nudAdet);

                // Geri Dön butonu oluştur ve ekle
                Guna2Button geriDonButonu = new Guna2Button
                {
                    Text = "Geri Dön",
                    Width = 150,
                    Height = 50,
                    BorderRadius = 12,
                    FillColor = Color.OrangeRed,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White,
                    Tag = "GeriDon"
                };

                // Geri Dön butonuna tıklama olayını bağla
                geriDonButonu.Click += (s, e) => { MasalariYukle(); };

                // Geri Dön butonunu arayüze ekle
                flowLayoutPanelMasalar.Controls.Add(geriDonButonu);
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi verir
                MessageBox.Show($"Ürünler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UrunleriYukle()
        {
            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT UrunID, UrunAdi FROM Urunler";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);



                    if (dt.Rows.Count == 0)
                    {
                        AlertBoxArtan(Color.LightGoldenrodYellow, Color.Goldenrod, "Bilgi", "Henüz ürün bulunmamaktadır!", Properties.Resources.warning);
                        //MessageBox.Show("Henüz ürün bulunmamaktadır!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunuHedefMasayaAktar(int satisDetayID, int mevcutSatisID, int urunID, int hedefMasaID, int aktarimAdedi)
        {
            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Hedef masada aktif bir satış olup olmadığını kontrol et
                    string satisKontrolQuery = "SELECT SatisID FROM Satislar WHERE MasaID = @MasaID AND Durum = 'Aktif'";
                    SqlCommand satisKontrolCommand = new SqlCommand(satisKontrolQuery, connection);
                    satisKontrolCommand.Parameters.AddWithValue("@MasaID", hedefMasaID);
                    object satisIDObj = satisKontrolCommand.ExecuteScalar();

                    int hedefSatisID;

                    if (satisIDObj != null)
                    {
                        // Hedef masada zaten aktif bir satış varsa, onun ID'sini kullan
                        hedefSatisID = Convert.ToInt32(satisIDObj);
                    }
                    else
                    {
                        // Hedef masada aktif bir satış yoksa, yeni bir satış oluştur
                        string satisEkleQuery = "INSERT INTO Satislar (MasaID, Tarih, ToplamTutar, Durum) OUTPUT INSERTED.SatisID VALUES (@MasaID, GETDATE(), 0, 'Aktif')";
                        SqlCommand satisEkleCommand = new SqlCommand(satisEkleQuery, connection);
                        satisEkleCommand.Parameters.AddWithValue("@MasaID", hedefMasaID);
                        hedefSatisID = (int)satisEkleCommand.ExecuteScalar();
                    }

                    // Ürünü kaynak satıştan hedef satışa aktar
                    string urunAktarQuery = @"
            INSERT INTO SatisDetaylari (SatisID, UrunID, Adet, BirimFiyat, AraToplam)
            SELECT @HedefSatisID, UrunID, @Adet, BirimFiyat, @Adet * BirimFiyat
            FROM SatisDetaylari
            WHERE SatisDetayID = @SatisDetayID";

                    SqlCommand urunAktarCommand = new SqlCommand(urunAktarQuery, connection);
                    urunAktarCommand.Parameters.AddWithValue("@HedefSatisID", hedefSatisID);
                    urunAktarCommand.Parameters.AddWithValue("@SatisDetayID", satisDetayID);
                    urunAktarCommand.Parameters.AddWithValue("@Adet", aktarimAdedi);
                    urunAktarCommand.ExecuteNonQuery();

                    // Kaynak satıştan aktarımı yapılan ürün miktarını düş
                    string urunGuncelleQuery = @"
            UPDATE SatisDetaylari 
            SET Adet = Adet - @Adet, AraToplam = (Adet - @Adet) * BirimFiyat
            WHERE SatisDetayID = @SatisDetayID";

                    SqlCommand urunGuncelleCommand = new SqlCommand(urunGuncelleQuery, connection);
                    urunGuncelleCommand.Parameters.AddWithValue("@SatisDetayID", satisDetayID);
                    urunGuncelleCommand.Parameters.AddWithValue("@Adet", aktarimAdedi);
                    urunGuncelleCommand.ExecuteNonQuery();

                    // Eğer kaynak satıştaki ürün miktarı 0 ise, ilgili satırı sil
                    string urunSilQuery = "DELETE FROM SatisDetaylari WHERE SatisDetayID = @SatisDetayID AND Adet = 0";
                    SqlCommand urunSilCommand = new SqlCommand(urunSilQuery, connection);
                    urunSilCommand.Parameters.AddWithValue("@SatisDetayID", satisDetayID);
                    urunSilCommand.ExecuteNonQuery();

                    // Kaynak ve hedef masaların durumlarını güncelle
                    MasaDurumunuGuncelle(selectedMasaID);
                    MasaDurumunuGuncelle(hedefMasaID);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show($"Ürün aktarımı sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        #endregion

        #region Ödeme İşlemleri

        private void OdemeEkraniniGoster()
        {
            // Ödeme ekranı için FlowLayoutPanel'i temizle
            flowLayoutPanelMasalar.Controls.Clear();

            // Ödeme yöntemlerini tanımla
            string[] odemeYontemleri = { "Nakit", "Kredi Kartı", "Multinet", "Sodexo", "SetCard", "Metropol", "Banka Transferi" };

            foreach (string yontem in odemeYontemleri)
            {
                // Ödeme yöntemi için bir buton oluştur
                Guna2Button odemeButonu = new Guna2Button
                {
                    Text = yontem,
                    Width = 150,
                    Height = 50,
                    BorderRadius = 12,
                    FillColor = Color.LightBlue,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.White
                };

                // Ödeme butonuna tıklama olayını bağla
                odemeButonu.Click += (s, e) =>
                {
                    OdemeIsleminiTamamla(yontem); // Seçilen ödeme yöntemiyle işlemi tamamla
                };

                // Ödeme butonunu FlowLayoutPanel'e ekle
                flowLayoutPanelMasalar.Controls.Add(odemeButonu);
            }

            // Geri Dön butonunu oluştur
            Guna2Button geriDonButonu = new Guna2Button
            {
                Text = "Geri Dön",
                Width = 150,
                Height = 50,
                BorderRadius = 12,
                FillColor = Color.OrangeRed,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White
            };

            // Geri Dön butonuna tıklama olayını bağla
            geriDonButonu.Click += (s, e) =>
            {
                MasalariYukle(); // Masalar ekranını yeniden yükle
            };

            // Geri Dön butonunu FlowLayoutPanel'e ekle
            flowLayoutPanelMasalar.Controls.Add(geriDonButonu);
        }

        private void OdemeIsleminiTamamla(string odemeYontemi)
        {
            try
            {
                // Toplam tutarı metinden temizle ve doğrula
                string toplamTutarStr = lblToplamTutar.Text.Replace("Toplam Tutar:", "").Replace("₺", "").Trim();

                if (!decimal.TryParse(toplamTutarStr, out decimal toplamTutar))
                {
                    AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Toplam tutar geçersiz!", Properties.Resources.Error);
                    //MessageBox.Show("Toplam tutar geçersiz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Seçili masaya ait aktif satış ID'sini al
                    string satisIDQuery = "SELECT SatisID FROM Satislar WHERE MasaID = @MasaID AND Durum = 'Aktif'";
                    SqlCommand satisIDCommand = new SqlCommand(satisIDQuery, connection);
                    satisIDCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);

                    object satisIDObj = satisIDCommand.ExecuteScalar();
                    if (satisIDObj == null)
                    {
                        AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Bu masada ödeme yapılacak bir sipariş bulunamadı!", Properties.Resources.Error);
                        //MessageBox.Show("Bu masada ödeme yapılacak bir sipariş bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int satisID = Convert.ToInt32(satisIDObj);

                    // Ödemeyi veritabanına kaydet
                    string odemeEkleQuery = "INSERT INTO Odemeler (SatisID, Tarih, OdemeYontemi, Tutar) VALUES (@SatisID, GETDATE(), @OdemeYontemi, @Tutar)";
                    SqlCommand odemeEkleCommand = new SqlCommand(odemeEkleQuery, connection);
                    odemeEkleCommand.Parameters.AddWithValue("@SatisID", satisID);
                    odemeEkleCommand.Parameters.AddWithValue("@OdemeYontemi", odemeYontemi);
                    odemeEkleCommand.Parameters.AddWithValue("@Tutar", toplamTutar);
                    odemeEkleCommand.ExecuteNonQuery();

                    // Satış durumunu "Ödenmiş" olarak güncelle
                    string satisGuncelleQuery = "UPDATE Satislar SET Durum = 'Ödenmiş' WHERE SatisID = @SatisID";
                    SqlCommand satisGuncelleCommand = new SqlCommand(satisGuncelleQuery, connection);
                    satisGuncelleCommand.Parameters.AddWithValue("@SatisID", satisID);
                    satisGuncelleCommand.ExecuteNonQuery();

                    // Masanın durumunu "Boş" olarak güncelle
                    string masaDurumGuncelleQuery = "UPDATE Masalar SET Durum = 'Boş' WHERE MasaID = @MasaID";
                    SqlCommand masaDurumGuncelleCommand = new SqlCommand(masaDurumGuncelleQuery, connection);
                    masaDurumGuncelleCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);
                    masaDurumGuncelleCommand.ExecuteNonQuery();

                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", $"Ödeme başarıyla alındı! Ödeme yöntemi: {odemeYontemi}", Properties.Resources.information);
                    //MessageBox.Show($"Ödeme başarıyla alındı! Ödeme yöntemi: {odemeYontemi}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Masaları yeniden yükle
                    MasalariYukle();
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda kullanıcıya bilgi ver
                MessageBox.Show($"Ödeme işlemi sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Gerekli Metotlar

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

        private void MasalariYukle()
        {
            // Masalar için kullanılan FlowLayoutPanel'i temizler
            flowLayoutPanelMasalar.Controls.Clear();

            string connectionString = Baglanti();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Tüm masaları veritabanından çeker
                string query = "SELECT MasaID, MasaAdi, Durum FROM Masalar";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Her masa için bir buton oluşturur
                while (reader.Read())
                {
                    Button masa = new Button
                    {
                        Name = "Masa" + reader["MasaID"].ToString(),
                        Text = reader["MasaAdi"].ToString(),
                        Width = 100,
                        Height = 50,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        ForeColor = Color.White,
                        FlatStyle = FlatStyle.Flat
                    };

                    string durum = reader["Durum"].ToString();
                    masa.Tag = durum; // Masanın durumunu Tag özelliğinde saklar

                    // Masa durumuna göre görsel özellikler ayarlanır
                    switch (durum)
                    {
                        case "Boş":
                            masa.BackColor = Color.LightGray;
                            masa.FlatAppearance.BorderSize = 0; // Kenarlık
                            break;
                        case "Dolu":
                            masa.BackColor = Color.SeaGreen;
                            masa.FlatAppearance.BorderSize = 0;
                            masa.FlatAppearance.BorderColor = Color.DarkGreen;
                            break;
                        case "Rezerve":
                            masa.BackColor = Color.Firebrick;
                            masa.FlatAppearance.BorderSize = 2;
                            masa.FlatAppearance.BorderColor = Color.DarkRed;
                            break;
                        default:
                            masa.BackColor = Color.Gray;
                            masa.FlatAppearance.BorderSize = 0; // Kenarlık
                            break;
                    }

                    ElipseTool elipse = new ElipseTool
                    {
                        TargetControl = masa,
                        CornerRadius = 15
                    };

                    // Masa butonuna tıklama olayını bağlar
                    masa.Click += Masa_Click;

                    // Masayı FlowLayoutPanel'e ekler
                    flowLayoutPanelMasalar.Controls.Add(masa);
                }
            }
        }

        private int GetSelectedSatisID()
        {
            string connectionString = Baglanti();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Seçilen masaya ait aktif satış ID'sini sorgular
                string query = "SELECT SatisID FROM Satislar WHERE MasaID = @MasaID AND Durum = 'Aktif'";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MasaID", selectedMasaID);

                object satisIDObj = command.ExecuteScalar();

                if (satisIDObj != null)
                {
                    // Eğer satış ID'si varsa, döndür
                    return Convert.ToInt32(satisIDObj);
                }
                else
                {
                    // Satış ID'si yoksa hata fırlat
                    throw new Exception("Seçili masada aktif bir satış bulunamadı.");
                }
            }
        }


        #endregion

        #endregion

        #region Butonlar

        #region Sipariş İşlemleri

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            if (selectedMasaID == -1)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen önce bir masa seçin!", Properties.Resources.Error);
                //MessageBox.Show("Lütfen önce bir masa seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UrunleriGoster(); // Ürün ekleme arayüzünü göster
        }


        private void btnUrunCikar_Click(object sender, EventArgs e)
        {
            // DataGridView'den seçili satırı alın
            if (dataGridViewSiparis.CurrentRow == null)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen çıkarmak istediğiniz bir ürünü seçin!", Properties.Resources.Error);
                //MessageBox.Show("Lütfen çıkarmak istediğiniz bir ürünü seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int urunID = 0;
            if (!int.TryParse(dataGridViewSiparis.CurrentRow.Cells["UrunID"].Value.ToString(), out urunID))
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Geçerli bir ürün seçilemedi!", Properties.Resources.Error);
                //MessageBox.Show("Geçerli bir ürün seçilemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int mevcutAdet = Convert.ToInt32(dataGridViewSiparis.CurrentRow.Cells["Adet"].Value);

            if (mevcutAdet <= 0)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Bu ürünü çıkarmak için yeterli adet bulunmuyor!", Properties.Resources.Error);
                //MessageBox.Show("Bu ürünü çıkarmak için yeterli adet bulunmuyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // `nudAdetSecimi` kontrolünden aktarılacak miktarı alıyoruz
            nudAdetSecimi.Maximum = mevcutAdet; // Maksimum değer mevcut adet kadar olmalı
            nudAdetSecimi.Minimum = 1; // Minimum değer 1
            int cikarilacakAdet = (int)nudAdetSecimi.Value; // Seçili miktar

            if (cikarilacakAdet > mevcutAdet)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Aktarılacak miktar mevcut adetten fazla olamaz!", Properties.Resources.Error);
                //MessageBox.Show("Aktarılacak miktar mevcut adetten fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (cikarilacakAdet == mevcutAdet)
                    {
                        // Eğer tüm adet çıkarılıyorsa, ürünü tamamen sil
                        string silQuery = "DELETE FROM SatisDetaylari WHERE SatisID = @SatisID AND UrunID = @UrunID";
                        SqlCommand silCommand = new SqlCommand(silQuery, connection);
                        silCommand.Parameters.AddWithValue("@SatisID", GetSelectedSatisID());
                        silCommand.Parameters.AddWithValue("@UrunID", urunID);
                        silCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        // Eğer belirli bir miktar çıkarılıyorsa, miktarı azalt
                        string guncelleQuery = "UPDATE SatisDetaylari SET Adet = Adet - @CikarilacakAdet, AraToplam = AraToplam - (@CikarilacakAdet * BirimFiyat) WHERE SatisID = @SatisID AND UrunID = @UrunID";
                        SqlCommand guncelleCommand = new SqlCommand(guncelleQuery, connection);
                        guncelleCommand.Parameters.AddWithValue("@CikarilacakAdet", cikarilacakAdet);
                        guncelleCommand.Parameters.AddWithValue("@SatisID", GetSelectedSatisID());
                        guncelleCommand.Parameters.AddWithValue("@UrunID", urunID);
                        guncelleCommand.ExecuteNonQuery();
                    }

                    // Masadaki başka ürün olup olmadığını kontrol et
                    string kontrolQuery = "SELECT COUNT(*) FROM SatisDetaylari WHERE SatisID = @SatisID";
                    SqlCommand kontrolCommand = new SqlCommand(kontrolQuery, connection);
                    kontrolCommand.Parameters.AddWithValue("@SatisID", GetSelectedSatisID());
                    int kalanUrunSayisi = Convert.ToInt32(kontrolCommand.ExecuteScalar());

                    if (kalanUrunSayisi == 0)
                    {
                        // Eğer masada başka ürün yoksa masayı boş olarak işaretle
                        string masaDurumGuncelleQuery = "UPDATE Masalar SET Durum = 'Boş' WHERE MasaID = @MasaID";
                        SqlCommand masaDurumGuncelleCommand = new SqlCommand(masaDurumGuncelleQuery, connection);
                        masaDurumGuncelleCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);
                        masaDurumGuncelleCommand.ExecuteNonQuery();

                        AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Masanın tüm ürünleri silindi.", Properties.Resources.information);
                        //MessageBox.Show("Masanın tüm ürünleri silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    // Sipariş listesini yeniden yükle
                    SiparisleriListele(selectedMasaID);
                    // Masaları yeniden yükle
                    MasalariYukle();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürün çıkarma sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UrunButonu_Click(object sender, EventArgs e)
        {
            Guna2Button clickedUrun = sender as Guna2Button;
            int urunID = Convert.ToInt32(clickedUrun.Name.Replace("Urun", ""));

            // Adet sayısını al
            Guna2NumericUpDown nudAdet = (Guna2NumericUpDown)flowLayoutPanelMasalar.Controls["nudAdet"];
            int adet = (int)nudAdet.Value;

            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Ürünün birim fiyatını al
                    string urunFiyatQuery = "SELECT Fiyat FROM Urunler WHERE UrunID = @UrunID";
                    SqlCommand urunFiyatCommand = new SqlCommand(urunFiyatQuery, connection);
                    urunFiyatCommand.Parameters.AddWithValue("@UrunID", urunID);
                    decimal birimFiyat = Convert.ToDecimal(urunFiyatCommand.ExecuteScalar());

                    // Masanın aktif bir satışı var mı kontrol et
                    string satisKontrolQuery = "SELECT SatisID FROM Satislar WHERE MasaID = @MasaID AND Durum = 'Aktif'";
                    SqlCommand satisKontrolCommand = new SqlCommand(satisKontrolQuery, connection);
                    satisKontrolCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);

                    object satisIDObj = satisKontrolCommand.ExecuteScalar();
                    int satisID;

                    if (satisIDObj != null)
                    {
                        satisID = Convert.ToInt32(satisIDObj);
                    }
                    else
                    {
                        string satisEkleQuery = "INSERT INTO Satislar (MasaID, Tarih, ToplamTutar, Durum) OUTPUT INSERTED.SatisID VALUES (@MasaID, GETDATE(), 0, 'Aktif')";
                        SqlCommand satisEkleCommand = new SqlCommand(satisEkleQuery, connection);
                        satisEkleCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);
                        satisID = (int)satisEkleCommand.ExecuteScalar();
                    }

                    // SatisDetaylari tablosuna detay ekle
                    string detayEkleQuery = "INSERT INTO SatisDetaylari (SatisID, UrunID, Adet, BirimFiyat, AraToplam) VALUES (@SatisID, @UrunID, @Adet, @BirimFiyat, @AraToplam)";
                    SqlCommand detayEkleCommand = new SqlCommand(detayEkleQuery, connection);
                    detayEkleCommand.Parameters.AddWithValue("@SatisID", satisID);
                    detayEkleCommand.Parameters.AddWithValue("@UrunID", urunID);
                    detayEkleCommand.Parameters.AddWithValue("@Adet", adet);
                    detayEkleCommand.Parameters.AddWithValue("@BirimFiyat", birimFiyat);
                    detayEkleCommand.Parameters.AddWithValue("@AraToplam", adet * birimFiyat);
                    detayEkleCommand.ExecuteNonQuery();

                    // Masanın durumunu 'Dolu' olarak güncelle
                    string masaDurumGuncelleQuery = "UPDATE Masalar SET Durum = 'Dolu' WHERE MasaID = @MasaID";
                    SqlCommand masaDurumGuncelleCommand = new SqlCommand(masaDurumGuncelleQuery, connection);
                    masaDurumGuncelleCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);
                    masaDurumGuncelleCommand.ExecuteNonQuery();


                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Sipariş eklendi ve masa durumu güncellendi.", Properties.Resources.information);
                    //MessageBox.Show("Sipariş eklendi ve masa durumu güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



                    SiparisleriListele(selectedMasaID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sipariş eklenirken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUrunBol_Click(object sender, EventArgs e)
        {
            // Eğer DataGridView'de herhangi bir satır seçilmediyse kullanıcıya hata mesajı göster
            if (dataGridViewSiparis.CurrentRow == null)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen bölmek istediğiniz ürünü seçin!", Properties.Resources.Error);
                //MessageBox.Show("Lütfen bölmek istediğiniz ürünü seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçilen siparişin detay ID'sini al
            int satisDetayID = 0;
            if (!int.TryParse(dataGridViewSiparis.CurrentRow.Cells["SatisDetayID"].Value.ToString(), out satisDetayID))
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Geçerli bir satış detayı seçilemedi!", Properties.Resources.Error);
                //MessageBox.Show("Geçerli bir satış detayı seçilemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçilen ürünün ID'sini al
            int urunID = 0;
            if (!int.TryParse(dataGridViewSiparis.CurrentRow.Cells["UrunID"].Value.ToString(), out urunID))
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Geçerli bir ürün seçilemedi!", Properties.Resources.Error);
                //MessageBox.Show("Geçerli bir ürün seçilemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Seçilen ürünün mevcut adet bilgisini al
            int mevcutAdet = Convert.ToInt32(dataGridViewSiparis.CurrentRow.Cells["Adet"].Value);

            // Seçilen masaya ait aktif satış bilgilerini al
            int mevcutSatisID = GetSelectedSatisID();
            int mevcutMasaID = selectedMasaID;

            // Aktarılacak adet bilgisini kullanıcının seçimine göre belirle
            nudAdetSecimi.Maximum = mevcutAdet; // Kullanıcının seçebileceği maksimum değer
            nudAdetSecimi.Minimum = 1; // Minimum değer
            int aktarimAdedi = (int)nudAdetSecimi.Value;

            // Aktarılacak miktar mevcut adetten fazla ise hata mesajı göster
            if (aktarimAdedi > mevcutAdet)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Aktarılacak miktar mevcut adetten fazla olamaz!", Properties.Resources.Error);
                //MessageBox.Show("Aktarılacak miktar mevcut adetten fazla olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kullanıcıyı bilgilendir ve aktarılacak masayı seçmesini iste
            AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Lütfen ürünü aktarmak istediğiniz masayı seçin.", Properties.Resources.information);
            //MessageBox.Show("Lütfen ürünü aktarmak istediğiniz masayı seçin.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // FlowLayoutPanel'deki tüm masa butonlarını işlem için güncelle
            foreach (Control control in flowLayoutPanelMasalar.Controls)
            {
                if (control is Button btnMasa)
                {
                    btnMasa.Click -= Masa_Click; // Önceki olayları kaldır
                    btnMasa.Click += (s, args) =>
                    {
                        // Eğer geri dön butonuna tıklandıysa, masaları yükle ve işlemi iptal et
                        if (btnMasa.Tag != null && btnMasa.Tag.ToString() == "GeriDon")
                        {
                            MasalariYukle();
                            return;
                        }

                        // Tıklanan masa butonundan hedef masa ID'sini al
                        int hedefMasaID = -1;
                        if (!btnMasa.Name.StartsWith("Masa") || !int.TryParse(btnMasa.Name.Replace("Masa", ""), out hedefMasaID))
                        {
                            AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Geçersiz bir masa seçimi yapıldı!", Properties.Resources.Error);
                            //MessageBox.Show("Geçersiz bir masa seçimi yapıldı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Eğer hedef masa, mevcut masayla aynıysa hata mesajı göster
                        if (hedefMasaID == mevcutMasaID)
                        {
                            AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Aynı masaya ürün aktaramazsınız!", Properties.Resources.Error);
                            //MessageBox.Show("Aynı masaya ürün aktaramazsınız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Ürün aktarımı işlemini gerçekleştir
                        UrunuHedefMasayaAktar(satisDetayID, mevcutSatisID, urunID, hedefMasaID, aktarimAdedi);

                        // Masaları güncelle ve kullanıcıya işlem sonucunu bildir
                        MasalariYukle();
                        AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", $"Ürün ID: {urunID} başarıyla {aktarimAdedi} adet aktarıldı!", Properties.Resources.information);
                        //MessageBox.Show($"Ürün ID: {urunID} başarıyla {aktarimAdedi} adet aktarıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    };
                }
            }
        }


        private void btnUrunBolIptal_Click(object sender, EventArgs e)
        {
            // İşlemi iptal et ve masalar ekranını geri yükle
            AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Ürün bölme işlemi iptal edildi.", Properties.Resources.information);
            //MessageBox.Show("Ürün bölme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // FlowLayoutPanel'i temizle ve masaları yükle
            MasalariYukle();
        }

        #endregion

        #region Rezervasyon İşlemleri

        private void btnRezerveYap_Click(object sender, EventArgs e)
        {
            // Eğer bir masa seçilmemişse, kullanıcıya hata mesajı göster
            if (selectedMasaID == -1)
            {
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen bir masa seçin!", Properties.Resources.Error);
                //MessageBox.Show("Lütfen bir masa seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Veritabanında seçili masayı "Rezerve" durumuna güncelle
                    string masaRezerveQuery = "UPDATE Masalar SET Durum = 'Rezerve' WHERE MasaID = @MasaID";
                    SqlCommand masaRezerveCommand = new SqlCommand(masaRezerveQuery, connection);
                    masaRezerveCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);
                    masaRezerveCommand.ExecuteNonQuery();

                    // Kullanıcıya işlem sonucunu bildir
                    AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Masa rezerve olarak işaretlendi.", Properties.Resources.information);
                    //MessageBox.Show("Masa rezerve olarak işaretlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // FlowLayoutPanel içindeki masa butonunu bul ve rengini güncelle
                    foreach (Button btn in flowLayoutPanelMasalar.Controls)
                    {
                        // Seçili masanın butonunu kontrol et
                        if (btn.Name == "Masa" + selectedMasaID)
                        {
                            btn.BackColor = Color.Red; // Rezerve edilmiş masayı belirtmek için kırmızı renk
                            btn.Tag = "Rezerve"; // Durumunu güncelle
                            break; // Hedef masa bulunduğu için döngüden çık
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Bir hata oluşursa kullanıcıya hata mesajı göster
                MessageBox.Show($"Masa rezerve yapılırken hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnRezerveAc_Click(object sender, EventArgs e)
        {
            if (selectedMasaID == -1)
            {
                // Kullanıcıdan masa seçmesini isteyen hata mesajı
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen bir masa seçin!", Properties.Resources.Error);
                //MessageBox.Show("Lütfen bir masa seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Seçili masanın durumunu kontrol et
                    string query = "SELECT Durum FROM Masalar WHERE MasaID = @MasaID";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MasaID", selectedMasaID);

                    // Mevcut durumu veritabanından al
                    string durum = command.ExecuteScalar()?.ToString();

                    if (durum == "Rezerve")
                    {
                        // Eğer masa rezerve ise, durumunu "Dolu" olarak güncelle
                        string updateQuery = "UPDATE Masalar SET Durum = 'Dolu' WHERE MasaID = @MasaID";
                        SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);
                        updateCommand.ExecuteNonQuery();

                        // Başarılı işlem mesajı
                        AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Rezerve iptal edildi ve masa 'Dolu' olarak işaretlendi.", Properties.Resources.information);
                        //MessageBox.Show("Rezerve iptal edildi ve masa 'Dolu' olarak işaretlendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Kullanıcı arayüzünde ilgili masa butonunun rengini güncelle
                        foreach (Button btn in flowLayoutPanelMasalar.Controls)
                        {
                            if (btn.Name == "Masa" + selectedMasaID)
                            {
                                btn.BackColor = Color.Green; // Yeşil: "Dolu" durumu
                                btn.Tag = "Dolu"; // Masa durumunu belirt
                                break;
                            }
                        }
                    }
                    else
                    {
                        // Eğer masa zaten "Rezerve" değilse bilgilendirme mesajı
                        AlertBoxArtan(Color.LightSteelBlue, Color.DodgerBlue, "Bilgi", "Bu masa zaten rezerve değil!", Properties.Resources.information);
                        //MessageBox.Show("Bu masa zaten rezerve değil!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata mesajı
                MessageBox.Show($"Rezerve iptali sırasında hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        #region Ödeme İşlemleri

        private void btnOdemeAl_Click(object sender, EventArgs e)
        {
            if (selectedMasaID == -1)
            {
                // Kullanıcıdan bir masa seçmesini isteyen hata mesajı
                AlertBoxArtan(Color.LightPink, Color.DarkRed, "Hata", "Lütfen bir masa seçin!", Properties.Resources.Error);
                //MessageBox.Show("Lütfen bir masa seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string connectionString = Baglanti();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Masanın mevcut durumunu sorgula
                    string masaDurumuQuery = "SELECT Durum FROM Masalar WHERE MasaID = @MasaID";
                    SqlCommand masaDurumuCommand = new SqlCommand(masaDurumuQuery, connection);
                    masaDurumuCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);
                    string masaDurumu = masaDurumuCommand.ExecuteScalar()?.ToString();

                    // Eğer masa "Boş" ise, işlem sonlandırılır ve uyarı gösterilir
                    if (masaDurumu == "Boş")
                    {
                        AlertBoxArtan(Color.LightGoldenrodYellow, Color.Goldenrod, "Uyarı", "Bu masada ödeme yapılacak sipariş bulunamadı!", Properties.Resources.warning);
                        //MessageBox.Show("Bu masada ödeme yapılacak sipariş bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Masada aktif bir sipariş olup olmadığını kontrol et
                    string aktifSiparisQuery = "SELECT COUNT(*) FROM Satislar WHERE MasaID = @MasaID AND Durum = 'Aktif'";
                    SqlCommand aktifSiparisCommand = new SqlCommand(aktifSiparisQuery, connection);
                    aktifSiparisCommand.Parameters.AddWithValue("@MasaID", selectedMasaID);

                    int aktifSiparisSayisi = Convert.ToInt32(aktifSiparisCommand.ExecuteScalar());

                    // Eğer aktif bir sipariş yoksa, işlem sonlandırılır ve uyarı gösterilir
                    if (aktifSiparisSayisi == 0)
                    {
                        AlertBoxArtan(Color.LightGoldenrodYellow, Color.Goldenrod, "Uyarı", "Bu masada ödeme yapılacak sipariş bulunamadı!", Properties.Resources.warning);
                        //MessageBox.Show("Bu masada ödeme yapılacak sipariş bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Ödeme ekranını aç
                    OdemeEkraniniGoster();
                }
            }
            catch (Exception ex)
            {
                // Hata oluşursa kullanıcıya bilgi ver
                MessageBox.Show($"Ödeme kontrolü sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Yönetim İşlemleri

        private void btnUrunYonetimi_Click(object sender, EventArgs e)
        {
            FrmUrunYonetimi urunyonetimi = new FrmUrunYonetimi();
            urunyonetimi.ShowDialog();
        }

        private void BtnRaporlama_Click(object sender, EventArgs e)
        {
            FrmRaporlama raporlamaForm = new FrmRaporlama();
            raporlamaForm.ShowDialog();
        }

        private void BtnKullaniciYonetimi_Click(object sender, EventArgs e)
        {
            FrmKullaniciYonetimi kullaniciYonetimi = new FrmKullaniciYonetimi();
            kullaniciYonetimi.ShowDialog();
        }

        private void Masa_Click(object sender, EventArgs e)
        {
            Button clickedMasa = sender as Button;

            // Eğer buton "Geri Dön" ise işlem yapma
            if (clickedMasa.Tag != null && clickedMasa.Tag.ToString() == "GeriDon")
            {
                return;
            }

            selectedMasaID = Convert.ToInt32(clickedMasa.Name.Replace("Masa", ""));
            string masaDurumu = clickedMasa.Tag.ToString();

            // Eğer masa rezerve durumdaysa işlem yapılmasın
            if (masaDurumu == "Rezerve")
            {
                AlertBoxArtan(Color.LightGoldenrodYellow, Color.Goldenrod, "Uyarı", "Bu masa rezerve durumda, işlem yapılamaz!", Properties.Resources.warning);
                //MessageBox.Show("Bu masa rezerve durumda, işlem yapılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Eski masanın verilerini temizle
            dataGridViewSiparis.DataSource = null;
            lblToplamTutar.Text = "Toplam Tutar: 0₺";

            // Seçilen masanın siparişlerini listele
            SiparisleriListele(selectedMasaID);
        }

        #endregion

        #region Çıkış İşlemleri
        private void cntrlCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #endregion

        #region Sürükleme İşlemleri

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Surukleme = true;
                baslangicNoktasi = new Point(e.X, e.Y); // Tıklama konumunu kaydet
            }
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
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

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            Surukleme = false; // Sürükleme işlemini durdur
        }

        #endregion

    }
}

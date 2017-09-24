using System;
using System.Diagnostics;
using System.Windows.Forms;
using eksi_sozluk_debe.Siniflar;

namespace eksi_sozluk_debe
{
    public partial class FrmEksiSozlukDebe : Form
    {
        public FrmEksiSozlukDebe()
        {
            InitializeComponent();
        }

        // Sınıflar ve nesneler
        private readonly DebeXmlIndir _debeXmlIndir = new DebeXmlIndir();
        private readonly Guncelle _guncelle = new Guncelle();
        private readonly EntryKaydetYukle _entryKaydetYukle = new EntryKaydetYukle();
        private readonly GunKontrolu _gunKontrolu = new GunKontrolu();

        private void FrmEksiSozlukDebe_Load(object sender, EventArgs e)
        {
            // Entrylerin kaydedileceği dosyanın olup olmadığını kontrol et
            _entryKaydetYukle.XmlDosyasiniKontrolEt();
        }

        public void tsmiDebeYukle_Click(object sender, EventArgs e)
        {
            // ProgressBar'ı sıfırlayarak başla ve Kaydet butonunu aktif et
            tsProgressBar.Value = 0;
            tsmKaydet.Enabled = true;

            // Edward Zuckmeier'ın XML dosyasını al ve yükle
            _debeXmlIndir.XmlAl();
            _debeXmlIndir.DebeXmlWebBrowserYukle(webBrowser, tscEntryListesi);

            // Gün değerini alıp Debe'nin hangi güne dair olduğu konusunda durum çubuğunda bilgi yaz 
            _gunKontrolu.XmlYuklenmeZamani(_debeXmlIndir.GunDizi[0], tsslDurum);

            // ProgressBar'ı %100'e ulaştır ve 1 no'lu entryi göster
            tsProgressBar.Value = 100;
            _debeXmlIndir.EntryNo = 1;

            // Köşeli parantezin indeksini bul
            int koseliParantezYeri = _debeXmlIndir.BaslikDizi[1].IndexOf("]", StringComparison.Ordinal);

            // Her bir başlığı TscBox'a ekle ve köşeli parantezden sonraki kısımları yazdır
            foreach (var s in _debeXmlIndir.BaslikDizi)
            {
                tscEntryListesi.Items.Add(s.Substring(koseliParantezYeri + 2));
            }

            // En başta gelen, birinci satırdaki yazıyı sil ve ilk entryi seç
            tscEntryListesi.Items.RemoveAt(0);
            tscEntryListesi.SelectedIndex = 0;

            // Butonları ve tscBox'u aktif et
            btnSonraki.Enabled = true;
            btnOnceki.Enabled = true;
            tscEntryListesi.Enabled = true;
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            // tscEntryListesi aktif değilse kaydedilen entryleri göster
            if (tscEntryListesi.Enabled == false)
            {
                try
                {
                    // Yüklenen koleksiyonu arttır ve entryleri görüntüle
                    _entryKaydetYukle.Sayac++;
                    _entryKaydetYukle.EntryYukle(webBrowser, tscEntryListesi,tsslDurum);
                }
                catch (Exception)
                {
                    // Yüklenen koleksiyonun sınırlarını aşma ve hata verme
                    _entryKaydetYukle.Sayac = _entryKaydetYukle.IcerikDizi.Count-2;
                }
            }
            else
            {
                //   tsxBox'da entry başlığını göster
                tscEntryListesi.SelectedIndex = _debeXmlIndir.EntryNo - 1;
                
                //   Entry numarası diziden büyük değilse arttır
                if (_debeXmlIndir.EntryNo < _debeXmlIndir.BaslikDizi.Length - 1)
                {
                    _debeXmlIndir.EntryNo++;
                    _debeXmlIndir.DebeXmlWebBrowserYukle(webBrowser, tscEntryListesi);

                    // tsxBox'da entry başlığını göster
                    tscEntryListesi.SelectedIndex = _debeXmlIndir.EntryNo - 1;
                }
            }
        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            // tscEntryListesi aktif değilse kaydedilen entryleri göster
            if (tscEntryListesi.Enabled == false)
            {
                try
                {
                    _entryKaydetYukle.Sayac--;
                    _entryKaydetYukle.EntryYukle(webBrowser, tscEntryListesi, tsslDurum);
                }
                catch (Exception)
                {
                    _entryKaydetYukle.Sayac = 0;
                }
            }
            else
            {
                _debeXmlIndir.EntryNo--;

                // 0 no'lu entrye geçme ve WebBrowser'a yükle
                if (_debeXmlIndir.EntryNo == 0)
                    _debeXmlIndir.EntryNo = 1;

                _debeXmlIndir.DebeXmlWebBrowserYukle(webBrowser, tscEntryListesi);

                // tsxBox'da entry başlığını göster
                tscEntryListesi.SelectedIndex = _debeXmlIndir.EntryNo - 1;
            }
        }

        private void tsmGuncelle_Click(object sender, EventArgs e)
        {
            // Programın güncellemelerinin olup olmadığına bak
            _guncelle.GuncellemeKontroluYap();
        }

        private void tsmHakkinda_Click(object sender, EventArgs e)
        {
            // Programa dair gereksiz bilgiler ver
            MessageBox.Show(@"Bu program ile Kutsal Bilgi Kaynağı Ek$i Sözlük'teki Dünün En Beğenilen Entry'lerini (DEBE) görebilir ve okuyabilirsiniz. Ayrıca, istediğiniz entry'leri HTML biçiminde kaydedebilir, bunların çıktılarını alabilirsiniz." + Environment.NewLine + Environment.NewLine + @"Not: Bu programı anlamlı ve işe yarar hale getiren XML dosyasını oluşturan Ek$i Sözlük yazarı Edward Zuckmeier'a sonsuz teşekkürlerimi ve saygılarımı sunarım.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tsmYazdir_Click(object sender, EventArgs e)
        {
            // Entryi yazdırmak için webBrowser'ın gerekli yazdır fonksiyonunu çağır
            webBrowser.ShowPrintDialog();
        }

        private void tsmKaydet_Click(object sender, EventArgs e)
        {
            // WebBrowser'daki entryi kaydet
            _entryKaydetYukle.EntryKaydet(webBrowser);
        }

        private void tsmKaydedilenleriYukle_Click(object sender, EventArgs e)
        {
            // Daha önceden kaydedilen entryleri yükle
            _entryKaydetYukle.EntryYukle(webBrowser,tscEntryListesi, tsslDurum);

            // Butonları aktif et
            btnSonraki.Enabled = true;
            btnOnceki.Enabled = true;
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Mevcut linklere tıklandığı anda, bu program harici bir tarayıcıda linkleri aç
            if (!(e.Url.ToString().Equals("about:blank", StringComparison.CurrentCultureIgnoreCase)))
            {
                Process.Start(e.Url.ToString());
                e.Cancel = true;
            }            
        }

        private void tsmCikis_Click(object sender, EventArgs e)
        {
            // Programdan çık
            Application.Exit();
        }

        private void tscEntryListesi_DropDownClosed(object sender, EventArgs e)
        {
            // TscBox seçildiğinde Menu Strip'e odaklan (Fare ile üzerine gelince butonun renklenmesi için)
            menuStrip.Focus();

            // TscBox'tan entry seçildiğinde o entryi göster ve ilgili olayı yürüt
            _debeXmlIndir.EntryNo = (byte)tscEntryListesi.SelectedIndex;
            btnSonraki_Click(sender, e);
        }

        // ProcessCmdKey'i ezme sayesinde sağ ve sol oka basılarak entryler ileri-geri götürülebiliyor
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Sağ ya da sol oka tıklandığında ilgili olay yürütülüyor
            switch (keyData)
            {
                case Keys.Right:
                    btnSonraki_Click(null, null);
                    return true;
                case Keys.Left:
                    btnOnceki_Click(null, null);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
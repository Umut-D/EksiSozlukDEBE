using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using eksi_debe.Araclar;
using eksi_debe.Internet;
using eksi_debe.Islemler;

namespace eksi_debe
{
    public partial class FrmEksi : Form
    {
        public FrmEksi()
        {
            InitializeComponent();
            Butonlar = new Butonlar(this);
        }

        private readonly Debe _debe = new Debe();
        public Butonlar Butonlar { get; }
        private int _sayi;

        private void FrmEksi_Load(object sender, EventArgs e)
        {
            TarihAraliklari();

            tsslDurum.Text = Baglanti.Kontrol();
            tsslDurum.ForeColor = Baglanti.Renk(tsslDurum.Text);
        }

        private void tsmiDebeYukle_Click(object sender, EventArgs e)
        {
            tsProgressBar.Value = 0;

            try
            {
                DateTime tarih = Convert.ToDateTime(dtpTarihSec.Value.ToShortDateString());

                _debe.SecilenTarih = tarih;
                _debe.Indir(tscEntryListesi);
                _debe.Bilgilendirme(tsslDurum);

                Butonlar.AktifHaleGetir();
                webBrowser.DocumentText = _debe.Gezinti(0, tscEntryListesi);
            }
            catch (Exception)
            {
                MessageBox.Show(@"Günün seçilen entrylerinde bir sorun var. Muhtemelen DEBE'nin kayıtlara geçmediği bir gün seçtiniz. Lütfen başka bir gün seçiniz.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tsProgressBar.Value = 100;
        }

        // tsmiTarihSec_Click eyleminde tarih seçim kontrolünün çıkması için gerekli kodlar

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private const uint WM_SYSKEYDOWN = 0x104;

        private void tsmiTarihSec_Click(object sender, EventArgs e)
        {
            SendMessage(dtpTarihSec.Handle, WM_SYSKEYDOWN, (int) Keys.Down, 0);
        }

        private void dtpTarihSec_CloseUp(object sender, EventArgs e)
        {
            _debe.SecilenTarih = Convert.ToDateTime(dtpTarihSec.Value.ToShortDateString());

            // DateTimePicker'dan tarih seçildiğinde hemen DEBE'yi yükle
            tsmiDebeYukle_Click(this, e);
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            _sayi++;

            // Girilen sayı indirilen entry adedinden büyükse sayıyı düşür
            if (_sayi == _debe.Adet - 1)
                _sayi = _debe.Adet - 2;

            webBrowser.DocumentText = _debe.Gezinti(_sayi, tscEntryListesi);
        }

        private void btnOnceki_Click(object sender, EventArgs e)
        {
            _sayi--;

            // Girilen sayı 0'dan küçükse sayıyı 0'a sabitle
            if (_sayi < 0)
                _sayi = 0;

            webBrowser.DocumentText = _debe.Gezinti(_sayi, tscEntryListesi);
        }

        private void btnGit_Click(object sender, EventArgs e)
        {
            _debe.DebeSayfasinaGit(_sayi);
        }

        private void tscEntryListesi_DropDownClosed(object sender, EventArgs e)
        {
            // TscBox seçildiğinde Menu Strip'e odaklan (Fare ile üzerine gelince butonun renklenmesi için)
            menuStrip.Focus();

            // İlgili entry numarasına giderek mevcut entry numarasını değiştir
            webBrowser.DocumentText = _debe.Gezinti(tscEntryListesi.SelectedIndex, tscEntryListesi);
            _sayi = _debe.Sayi;
        }

        private void tsmGuncelle_Click(object sender, EventArgs e)
        {
            new Guncelle().Kontrol();
        }

        private void tsmiHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Kutsal Bilgi Kaynağı Ek$i Sözlük'teki Dünün En Beğenilen Entry'lerini (DEBE) kolayca okuyabilirsiniz.",
                @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void webBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Mevcut linklere tıklandığı anda, program harici bir tarayıcıda linkleri aç
            if (e.Url.ToString().Equals("about:blank", StringComparison.CurrentCultureIgnoreCase))
                return;
            
            // Gerekli düzenlemeyi alarak sorgu linkini hazırla (WebBrowser içindeki Bkz'leri tarayıcıda açmak için)
            Process.Start(@"http://eksisozluk.com" + e.Url.PathAndQuery);
            e.Cancel = true;
        }

        // Ekşi Sözlük haricindeki linkleri mevcut web tarayıcısında aç
        private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElementCollection linkElements = webBrowser.Document?.GetElementsByTagName("a");

            if (linkElements == null)
                return;

            foreach (HtmlElement link in linkElements)
                link.Click += (s, args) => { Process.Start(link.GetAttribute("href")); };
        }

        // ProcessCmdKey'i ezme sayesinde sağ ve sol oka basılarak entryler ileri-geri götürülebiliyor
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
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

        private void TarihAraliklari()
        {
            dtpTarihSec.MaxDate = DateTime.Today.Subtract(new TimeSpan(1));
            dtpTarihSec.MinDate = new DateTime(2015, 06, 04);
        }
    }
}
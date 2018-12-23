using System;
using System.Diagnostics;
using System.Windows.Forms;
using eksi_debe.Islemler;
using eksi_debe.Sistem;

namespace eksi_debe
{
    public partial class FrmEksi : Form
    {
        public FrmEksi()
        {
            InitializeComponent();
            Butonlar = new Butonlar(this);
        }

        readonly Debe _debe = new Debe();
        public Butonlar Butonlar { get; }
        private int _sayi;

        private void FrmEksi_Load(object sender, EventArgs e)
        {
            tsslDurum.Text = Baglanti.Kontrol();
            tsslDurum.ForeColor = Baglanti.Renk(tsslDurum.Text);
        }

        public void tsmiDebeYukle_Click(object sender, EventArgs e)
        {
            tsProgressBar.Value = 0;

            _debe.Indir(tscEntryListesi);
            _debe.Bilgilendirme(tsslDurum);

            Butonlar.Aktif();
            webBrowser.DocumentText = _debe.Gezinti(0, tscEntryListesi);

            tsProgressBar.Value = 100;
        }

        private void btnSonraki_Click(object sender, EventArgs e)
        {
            _sayi++;

            // Girilen sayı indirilen entry adedinden büyükse sayıyı düşür
            if (_sayi == _debe.EntryAdet - 1)
                _sayi = _debe.EntryAdet - 2;

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
            _debe.Git(_sayi);
        }

        private void tscEntryListesi_DropDownClosed(object sender, EventArgs e)
        {
            // TscBox seçildiğinde Menu Strip'e odaklan (Fare ile üzerine gelince butonun renklenmesi için)
            menuStrip.Focus();

            // İlgili entry numarasına giderek mevcut entry numarasını değiştir
            webBrowser.DocumentText = _debe.Gezinti(tscEntryListesi.SelectedIndex, tscEntryListesi);
            _sayi = _debe.EntrySayi;
        }

        private void tsmGuncelle_Click(object sender, EventArgs e)
        {
            new Guncelleme().Kontrol();
        }

        private void tsmHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Kutsal Bilgi Kaynağı Ek$i Sözlük'teki Dünün En Beğenilen Entry'lerini (DEBE) kolayca okuyabilirsiniz.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // ProcessCmdKey'i ezme sayesinde sağ ve sol oka basılarak entryler ileri-geri götürülebiliyor
        // Mecvut metodu ezmem gerekti. Sınıfa aktarım yapılamadı
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
    }
}
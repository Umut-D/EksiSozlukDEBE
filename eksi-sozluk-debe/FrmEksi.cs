using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using eksi_debe.Internet;

namespace eksi_debe
{
    public partial class FrmEksi : Form
    {
        public FrmEksi()
        {
            InitializeComponent();
        }

        private readonly Debe _debe = new Debe();

        private void FrmEksi_Load(object sender, EventArgs e)
        {
            dtpTarihSec.MaxDate = DateTime.Today.Subtract(new TimeSpan(1));
            dtpTarihSec.MinDate = new DateTime(2015, 06, 04);

            tsslDurum.Text = Baglanti.Kontrol();
        }

        private void TsmiDebeYukle_Click(object sender, EventArgs e)
        {
            tsProgressBar.Value = 0;
            tscEntryListesi.Items.Clear();

            try
            {
                _debe.SecilenTarih = Convert.ToDateTime(dtpTarihSec.Value.ToShortDateString());

                tscEntryListesi.Items.AddRange(_debe.Indir());

                AltBilgi();
                ButonlarAktif();

                webBrowser.DocumentText = _debe.Goruntule(0);
                tscEntryListesi.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Günün seçilen entrylerinde bir sorun var. Muhtemelen DEBE'nin kayıtlara geçmediği bir gün seçtiniz. Lütfen başka bir gün seçiniz.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tsProgressBar.Value = 100;
        }

        private void AltBilgi()
        {
            tsslDurum.Text = _debe.Gun().ToLongDateString() + @" DEBE'ler gösteriliyor";
            tsslDurum.ForeColor = Color.Green;
        }

        private void ButonlarAktif()
        {
            btnSonraki.Enabled = true;
            btnOnceki.Enabled = true;
            btnGit.Enabled = true;
            tscEntryListesi.Enabled = true;
        }

        // TsmiTarihSec_Click eyleminde tarih seçim kontrolünün çıkması için gerekli kodlar
        public const uint WM_SYSKEYDOWN = 0x104;

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private void TsmiTarihSec_Click(object sender, EventArgs e)
        {
            SendMessage(dtpTarihSec.Handle, WM_SYSKEYDOWN, (int) Keys.Down, 0);
        }

        private void DtpTarihSec_CloseUp(object sender, EventArgs e)
        {
            tscEntryListesi.Items.Clear();

            _debe.SecilenTarih = Convert.ToDateTime(dtpTarihSec.Value.ToShortDateString());

            TsmiDebeYukle_Click(this, e);
        }

        private void BtnSonraki_Click(object sender, EventArgs e)
        {
            if (tscEntryListesi.SelectedIndex == tscEntryListesi.Items.Count - 1)
                tscEntryListesi.SelectedIndex = tscEntryListesi.Items.Count - 2;

            webBrowser.DocumentText = _debe.Goruntule(tscEntryListesi.SelectedIndex + 1);
            tscEntryListesi.SelectedIndex += 1;
        }

        private void BtnOnceki_Click(object sender, EventArgs e)
        {
            if (tscEntryListesi.SelectedIndex == 0)
                tscEntryListesi.SelectedIndex = 1;

            webBrowser.DocumentText = _debe.Goruntule(tscEntryListesi.SelectedIndex - 1);
            tscEntryListesi.SelectedIndex -= 1;
        }

        private void BtnGit_Click(object sender, EventArgs e)
        {
            _debe.WebSayfasinaGit(tscEntryListesi.SelectedIndex);
        }

        private void TscEntryListesi_DropDownClosed(object sender, EventArgs e)
        {
            // TscBox seçildiğinde Menu Strip'e odaklan (Fare ile üzerine gelince butonun renklenmesi için)
            menuStrip.Focus();

            webBrowser.DocumentText = _debe.Goruntule(tscEntryListesi.SelectedIndex);
            tscEntryListesi.SelectedIndex = tscEntryListesi.SelectedIndex;
        }

        private void TsmGuncelle_Click(object sender, EventArgs e)
        {
            new Guncelle().Kontrol();
        }

        private void TsmiHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Kutsal Bilgi Kaynağı Ek$i Sözlük'teki Dünün En Beğenilen Entry'lerini (DEBE) kolayca okuyabilirsiniz.", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            // Mevcut linklere tıklandığı anda, program harici bir tarayıcıda linkleri aç
            if (e.Url.ToString().Equals("about:blank", StringComparison.CurrentCultureIgnoreCase))
                return;

            // Gerekli düzenlemeyi alarak sorgu linkini hazırla (WebBrowser içindeki Bkz'leri tarayıcıda açmak için)
            Process.Start(@"http://eksisozluk.com" + e.Url.PathAndQuery);
            e.Cancel = true;
        }

        // Ekşi Sözlük haricindeki linkleri mevcut web tarayıcısında aç
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
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
                    BtnSonraki_Click(null, null);
                    return true;
                case Keys.Left:
                    BtnOnceki_Click(null, null);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using eksi_debe.Internet;
using eksi_debe.Sozlock;
using eksi_debe.Sozluk;

namespace eksi_debe
{
    public partial class FrmEksi : Form
    {
        private readonly SozlockDebe _sozlockDebe;
        private SozlockTarih _tarih;
        private Goruntule _goruntule;

        public FrmEksi()
        {
            InitializeComponent();

            _sozlockDebe = new SozlockDebe();
        }

        private void FrmEksi_Load(object sender, EventArgs e)
        {
            BaglantiKontroluYap();

            TakvimdeGosterilecekGunleriBelirle();
        }

        private void BaglantiKontroluYap()
        {
            Baglanti baglanti = new Baglanti();
            baglanti.InternetVarMi();
        }

        private void TakvimdeGosterilecekGunleriBelirle()
        {
            dtpTarihSec.MaxDate = DateTime.Today.Subtract(new TimeSpan(1));
            dtpTarihSec.MinDate = new DateTime(2015, 06, 04);
        }

        private void TsmiDebeYukle_Click(object sender, EventArgs e)
        {
            tsProgressBar.Value = 0;
            tscEntryListesi.Items.Clear();

            try
            {
                SozlockIslemleri();

                tscEntryListesi.Items.AddRange(_sozlockDebe.Indir().ToArray());

                AltBilgi();

                ButonlariAktifHaleGetir();

                EntryleriGoster();

                tscEntryListesi.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Günün seçilen entrylerinde bir sorun var. Muhtemelen DEBE'nin kayıtlara geçmediği bir gün seçtiniz. Lütfen başka bir gün seçiniz.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tsProgressBar.Value = 100;
        }

        private void SozlockIslemleri()
        {
            _tarih = new SozlockTarih
            {
                Tarih = Convert.ToDateTime(dtpTarihSec.Value.ToShortDateString())
            };

            SozlockIndir indir = new SozlockIndir();
            indir.SayfayiIndir(_tarih);
        }

        private void AltBilgi()
        {
            tsslDurum.Text = _tarih.SecilenGun(_sozlockDebe) + @" DEBE'ler gösteriliyor";
            tsslDurum.ForeColor = Color.Green;
        }

        private void ButonlariAktifHaleGetir()
        {
            btnSonraki.Enabled = true;
            btnOnceki.Enabled = true;
            btnGit.Enabled = true;
            tscEntryListesi.Enabled = true;
        }

        private void EntryleriGoster()
        {
            _goruntule = new Goruntule(_sozlockDebe);
            webBrowser.DocumentText = _goruntule.Yazdir(0);
        }

        private void BtnSonraki_Click(object sender, EventArgs e)
        {
            if (tscEntryListesi.SelectedIndex == tscEntryListesi.Items.Count - 1)
                tscEntryListesi.SelectedIndex = tscEntryListesi.Items.Count - 2;

            webBrowser.DocumentText = _goruntule.Yazdir(tscEntryListesi.SelectedIndex + 1);
            tscEntryListesi.SelectedIndex += 1;
        }

        private void BtnOnceki_Click(object sender, EventArgs e)
        {
            if (tscEntryListesi.SelectedIndex == 0)
                tscEntryListesi.SelectedIndex = 1;

            webBrowser.DocumentText = _goruntule.Yazdir(tscEntryListesi.SelectedIndex - 1);
            tscEntryListesi.SelectedIndex -= 1;
        }

        private void BtnGit_Click(object sender, EventArgs e)
        {
            string link = _sozlockDebe.Entryler[tscEntryListesi.SelectedIndex].Link;
            Process.Start(link);
        }

        private void TscEntryListesi_DropDownClosed(object sender, EventArgs e)
        {
            menuStrip.Focus();

            webBrowser.DocumentText = _goruntule.Yazdir(tscEntryListesi.SelectedIndex);
            tscEntryListesi.SelectedIndex = tscEntryListesi.SelectedIndex;
        }

        private void TsmGuncelle_Click(object sender, EventArgs e)
        {
            Guncelle guncelle = new Guncelle();
            guncelle.VersiyonKontroluYap();
        }

        private void TsmiHakkinda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Bu program ile Kutsal Bilgi Kaynağı Ek$i Sözlük'ün Sozlock.com sitesinde paylaşılan Dünün En Beğenilen Entry'lerini (DEBE) kolayca okuyabilirsiniz. Ek$i Sözlük DEBE'leri olan versiyonsa yakında...", @"Hakkında", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WebBrowser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().Equals("about:blank", StringComparison.CurrentCultureIgnoreCase))
                return;

            Process.Start(@"http://eksisozluk.com" + e.Url.PathAndQuery);
            e.Cancel = true;
        }

        // Ekşi Sözlük haricindeki linkleri mevcut web tarayıcısında aç
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (webBrowser.Document?.GetElementsByTagName("a") == null)
                return;

            foreach (HtmlElement link in webBrowser.Document?.GetElementsByTagName("a"))
                link.Click += (s, args) => { Process.Start(link.GetAttribute("href")); };
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

            TsmiDebeYukle_Click(sender, e);
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
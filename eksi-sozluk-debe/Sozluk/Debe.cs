using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using eksi_debe.Araclar;
using eksi_debe.Internet;

namespace eksi_debe.Sozluk
{
    class Debe : HtmlIslemleri
    {
        private readonly List<Entry> _entryler = new List<Entry>();

        private string WebAdresiOlustur()
        {
            Uri sozlockAdres = new Uri("https://sozlock.com/");
            string secilenGun = "?date=" + SecilenTarih.ToString(@"yyyy-MM-dd");

            return sozlockAdres + secilenGun;
        }

        private void WebBaglanti()
        {
            WebClient webBaglanti = new WebClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            HtmlKaydet(webBaglanti);
        }

        private void HtmlKaydet(WebClient webBaglanti)
        {
            string kayitDizin = AppDomain.CurrentDomain.BaseDirectory + @"Entryler";
            webBaglanti.DownloadFile(WebAdresiOlustur(), kayitDizin);

            HtmlBelge.Load(kayitDizin, Encoding.UTF8);
        }

        private Entry EntryleriYukle(int sayac)
        {
            Entry entry = new Entry
            {
                Baslik = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Basliklar(sayac)).InnerText.Replace("&#39;", "'"),
                Icerik = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Icerikler(sayac)).InnerHtml,
                Yazar = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Yazarlar(sayac)).InnerHtml,
                Link = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Linkler(sayac)).Attributes["href"].Value,
                Zaman = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Zamanlar(sayac)).InnerText
            };
            _entryler.Add(entry);

            return entry;
        }

        private bool IcerikBosMu(int sayac)
        {
            bool durum = string.IsNullOrEmpty(HtmlBelge?.DocumentNode?.SelectSingleNode(Xpath.Basliklar(sayac))?.InnerText);
            return durum;
        }

        private void ListeTemizle(ToolStripComboBox tscListe)
        {
            tscListe.Items.Clear();
            _entryler.Clear();
        }

        public void Indir(ToolStripComboBox tscListe)
        {
            WebBaglanti();
            ListeTemizle(tscListe);

            int sayac = 1;
            while (true)
            {
                if (IcerikBosMu(sayac))
                    break;

                Entry entry = EntryleriYukle(sayac);
                tscListe.Items.Add(entry.Baslik);

                sayac++;
            }
        }

        public string Goruntule(int entryNo)
        {
            return "<html><body style='background-color:#cbcbcb;color: black;'><p style='font-size:26px;font-family:Cambria;font-weight:bold'>" + _entryler[entryNo].Baslik + "</p>" + "<font face='Calibri'>" + _entryler[entryNo].Icerik + "<br/><br/><strong>" + _entryler[entryNo].Yazar + "</strong><br/>" + _entryler[entryNo].Zaman + "</font></body></html>";
        }

        public string Gezinti(int sayi, ToolStripComboBox tscEntryListesi)
        {
            tscEntryListesi.SelectedIndex = sayi;
            return Goruntule(sayi);
        }

        public void Bilgilendirme(ToolStripStatusLabel tsslDurum)
        {
            // Değiştirilen entry saatleri tarih gösteriminde sorun yapmasın diye Zaman değişkenindeki Tarih alanı alınıyor 
            string[] zaman = _entryler[0].Zaman.Split(' ');
            DateTime gun = Convert.ToDateTime(zaman[0]);

            tsslDurum.Text = gun.ToLongDateString() + @" DEBE'ler gösteriliyor";
            tsslDurum.ForeColor = Color.Green;
        }

        public Process WebSayfasinaGit(int entryNo)
        {
            return Process.Start(_entryler[entryNo].Link);
        }
    }
}
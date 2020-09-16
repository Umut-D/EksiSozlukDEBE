using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using eksi_debe.Araclar;
using eksi_debe.Sozluk;

namespace eksi_debe.Internet
{
    class Debe : HtmlIslemleri
    {
        private readonly List<Entry> _entryler = new List<Entry>();

        private string WebAdres()
        {
            Uri sozlock = new Uri("https://sozlock.com/");
            string secilenGun = "?date=" + SecilenTarih.ToString(@"yyyy-MM-dd");

            return sozlock + secilenGun;
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
            webBaglanti.DownloadFile(WebAdres(), kayitDizin);

            HtmlBelge.Load(kayitDizin, Encoding.UTF8);
        }

        private Entry EntryleriYukle(int entryNo)
        {
            Entry entry = new Entry
            {
                Baslik = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Basliklar(entryNo)).InnerText.Replace("&#39;", "'"),
                Icerik = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Icerikler(entryNo)).InnerHtml,
                Yazar = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Yazarlar(entryNo)).InnerHtml,
                Link = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Linkler(entryNo)).Attributes["href"].Value,
                Zaman = HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Zamanlar(entryNo)).InnerText
            };
            _entryler.Add(entry);

            return entry;
        }

        private bool IcerikBosMu(int sayac)
        {
            return string.IsNullOrEmpty(HtmlBelge?.DocumentNode?.SelectSingleNode(Xpath.Basliklar(sayac))?.InnerText);
        }

        public object[] Indir()
        {
            WebBaglanti();
            _entryler.Clear();

            int sayac = 1;
            List<object> basliklar = new List<object>();
            while (true)
            {
                if (IcerikBosMu(sayac))
                    break;

                Entry entry = EntryleriYukle(sayac);
                basliklar.Add(entry.Baslik);

                sayac++;
            }

            return basliklar.ToArray();
        }

        public string Goruntule(int entryNo)
        {
            return "<html><body style='background-color:#cbcbcb;color: black;'><p style='font-size:26px;font-family:Cambria;font-weight:bold'>" + _entryler[entryNo].Baslik + "</p>" + "<font face='Calibri'>" + _entryler[entryNo].Icerik + "<br/><br/><strong>" + _entryler[entryNo].Yazar + "</strong><br/>" + _entryler[entryNo].Zaman + "</font></body></html>";
        }

        public DateTime Gun()
        {
            // Değiştirilen entry saatleri tarih gösteriminde sorun yapmasın diye Zaman değişkenindeki Tarih alanı alınıyor 
            string[] zaman = _entryler[0].Zaman.Split(' ');
            return Convert.ToDateTime(zaman[0]);
        }

        public Process WebSayfasinaGit(int entryNo)
        {
            return Process.Start(_entryler[entryNo].Link);
        }
    }
}
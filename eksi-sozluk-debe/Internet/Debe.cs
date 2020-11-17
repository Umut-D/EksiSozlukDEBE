using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using eksi_debe.Sozluk;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace eksi_debe.Internet
{
    public class Debe
    {
        private readonly List<Entry> _entryler;
        private readonly HtmlDocument _htmlBelge;
        private readonly Xpath _xpath;

        // DEBE'nin, kullanıcının tam olarak istediği tarih çıkması için gün arttırımı yap
        private DateTime _secilenTarih;
        public DateTime SecilenTarih
        {
            get => _secilenTarih;
            set => _secilenTarih = value.AddDays(1);
        }

        public Debe()
        {
            _entryler = new List<Entry>();
            _htmlBelge = new HtmlDocument();
            _xpath = new Xpath();
        }

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

            _htmlBelge.Load(kayitDizin, Encoding.UTF8);
        }

        private Entry EntryleriYukle(int entryNo)
        {
            Entry entry = new Entry
            {
                Baslik = _htmlBelge.DocumentNode.SelectSingleNode(_xpath.Basliklar(entryNo)).InnerText.Replace("&#39;", "'"),
                Icerik = _htmlBelge.DocumentNode.SelectSingleNode(_xpath.Icerikler(entryNo)).InnerHtml,
                Yazar = _htmlBelge.DocumentNode.SelectSingleNode(_xpath.Yazarlar(entryNo)).InnerHtml,
                Link = _htmlBelge.DocumentNode.SelectSingleNode(_xpath.Linkler(entryNo)).Attributes["href"].Value,
                Zaman = _htmlBelge.DocumentNode.SelectSingleNode(_xpath.Zamanlar(entryNo)).InnerText
            };
            _entryler.Add(entry);

            return entry;
        }

        private bool IcerikBosMu(int sayac)
        {
            string baslik = _htmlBelge?.DocumentNode?.SelectSingleNode(_xpath.Basliklar(sayac))?.InnerText;
            return string.IsNullOrEmpty(baslik);
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
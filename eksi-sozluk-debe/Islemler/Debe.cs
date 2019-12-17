using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace eksi_debe.Islemler
{
    class Debe : Entry
    {
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

            string dosya = AppDomain.CurrentDomain.BaseDirectory + @"Entryler";
            webBaglanti.DownloadFile(WebAdresiOlustur(), dosya);
            HtmlBelge.Load(dosya, Encoding.UTF8);
        }

        public void Indir(ToolStripComboBox tscListe)
        {
            WebBaglanti();
            EntryleriTemizle();

            int sayac = 1;
            try
            {
                for (sayac = 1; sayac < 52; sayac++)
                {
                    Baslik.Add(HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Basliklar(sayac)).InnerText.Replace("&#39;", "'"));
                    Icerik.Add(HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Icerikler(sayac)).InnerHtml);
                    Yazar.Add(HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Yazarlar(sayac)).InnerHtml);
                    Link.Add(HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Linkler(sayac)).Attributes["href"].Value);
                    Zaman.Add(HtmlBelge.DocumentNode.SelectSingleNode(Xpath.Zamanlar(sayac)).InnerText);
                }
            }
            catch (Exception)
            {
                Adet = sayac;
            }

            tscListe.Items.Clear();
            tscListe.Items.AddRange(Baslik.ToArray());
        }

        public string DebeGoruntule(int entryNo)
        {
            return
                "<html><body style='background-color:#cbcbcb;color: black;'><p style='font-size:26px;font-family:Cambria;font-weight:bold'>" +
                Baslik[entryNo] + "</p>" + "<font face='Calibri'>" + Icerik[entryNo] +
                "<br/><br/><strong>" + Yazar[entryNo] + "</strong><br/>" + Zaman[entryNo] +
                "</font></body></html>";
        }

        public string Gezinti(int sayi, ToolStripComboBox tscEntryListesi)
        {
            Sayi = sayi;
            tscEntryListesi.SelectedIndex = Sayi;

            return DebeGoruntule(Sayi);
        }

        public void Bilgilendirme(ToolStripStatusLabel tsslDurum)
        {
            // Değiştirilen entry saatleri tarih gösteriminde sorun yapmasın diye Zaman değişkenindeki Tarih alanı alınıyor 
            string[] zaman = Zaman[0].Split(' ');
            DateTime gun = Convert.ToDateTime(zaman[0]);

            tsslDurum.ForeColor = Color.Green;
            tsslDurum.Text = gun.ToLongDateString() + @" DEBE'ler gösteriliyor";
        }

        public Process DebeSayfasinaGit(int sayi)
        {
            return Process.Start(Link[sayi]);
        }

        public void EntryleriTemizle()
        {
            Baslik.Clear();
            Icerik.Clear();
            Yazar.Clear();
            Link.Clear();
            Zaman.Clear();
        }
    }
}
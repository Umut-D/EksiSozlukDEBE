using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eksi_sozluk_debe.Siniflar
{
    // Bu sınıf ile Edward Zuckmeier'ın sitesinden Debe, XML olarak çekilip gösteriliyor     
    public class DebeXmlIndir
    {
        // Ortak değişkenler
        public byte EntryNo = 1;
        public int TireKarakterNo, SlasKarakterNo;
        private const string DefaultDizin = @"eksi-sozluk-debe.xml";
        private readonly XNamespace _dc = "http://purl.org/dc/elements/1.1/";

        // Entry bileşenlerini oluştur (Yüklenen entryleri bu dizilere yükle)
        public string[] BaslikDizi, IcerikDizi, YazarDizi, GunDizi, EntryIdDizi = new string[50];

        public void XmlAl()
        {
            try
            {
                // Edward Zuckmeier'ın sitesinden web istemi yap ve geri bildirim al
                WebRequest webRequestIstemi = WebRequest.Create(new Uri(@"http://rss-lewstherin.rhcloud.com/static/eksideberss.xml"));
                WebResponse webResponseGeriBildirimi = webRequestIstemi.GetResponse();

                // Gelen bilgileri XML dosyasına yaz ve sonuna kadar okuma işlemi yap
                StreamReader akisOku = new StreamReader(webResponseGeriBildirimi.GetResponseStream());
                File.WriteAllText(DefaultDizin, akisOku.ReadToEnd());

                // Dizilere ilgili XML başlıklarını ayır
                BaslikDizi = XDocument.Load(DefaultDizin).Descendants("title").Select(element => element.Value).ToArray();
                IcerikDizi = XDocument.Load(DefaultDizin).Descendants("description").Select(element => element.Value).ToArray();
                YazarDizi = XDocument.Load(DefaultDizin).Descendants(_dc + "creator").Select(element => element.Value).ToArray();
                GunDizi = XDocument.Load(DefaultDizin).Descendants("pubDate").Select(element => element.Value).ToArray();
                EntryIdDizi = XDocument.Load(DefaultDizin).Descendants("guid").Select(element => element.Value).ToArray();

                // Başlık, içerik, yazar vs. konularda çeşitli kısaltmalar yapma gerek
                TireKarakterNo = GunDizi[EntryNo].LastIndexOf("-", StringComparison.Ordinal);
                SlasKarakterNo = EntryIdDizi[EntryNo].LastIndexOf("/", StringComparison.Ordinal);
            }
            catch (Exception)
            {
                MessageBox.Show(@"İstenmeyen bir hata meydana geldi. En iyisi çaktırmayın ve Debeoku.com'u deneyin.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void DebeXmlWebBrowserYukle(WebBrowser webBrowser, ToolStripComboBox tscBox)
        {
            // WebBrowser'a tüm bileşenleri yükle
                webBrowser.DocumentText = "<p style='font-size:24px;font-family:Cambria;font-weight:bold'>" + BaslikDizi[EntryNo].Substring(13) + "</p>" + "<font face='Calibri'>" + IcerikDizi[EntryNo] + "<br/>" + "<strong>" + YazarDizi[EntryNo - 1] + "</strong><br/>" + GunDizi[EntryNo - 1].Remove(TireKarakterNo).Substring(4) + "(#" + EntryIdDizi[EntryNo - 1].Substring(SlasKarakterNo + 1) + ")" + "</font>";

            // tscBox'u aktif et
            tscBox.Enabled = true;
        }
    }
}
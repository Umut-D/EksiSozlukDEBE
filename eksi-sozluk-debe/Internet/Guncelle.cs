using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace eksi_debe.Internet
{
    public class Guncelle
    {
        public void Kontrol()
        {
            try
            {
                XmlOku(webIstemcisi: WebIstemcisi());
            }
            catch (Exception)
            {
                MessageBox.Show(@"Bağlantı sağlanırken istenmeyen bir hata meydana geldi. İnternet bağlantınızı kontrol etseniz iyi olur.",
                    @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private WebClient WebIstemcisi()
        {
            // Web sitesine RSS okuyucu olarak istem yapmak gerek. Yoksa istek reddedilebilmekte
            WebClient webIstemcisi = new WebClient();
            webIstemcisi.Headers.Add("user-agent", "MyRSSReader/1.0");

            return webIstemcisi;
        }

        private void XmlOku(WebClient webIstemcisi)
        {
            string guncellemeLinki = @"http://www.umutd.com/wp-content/program-versions/eksi-sozluk-debe.xml";
            XmlReader xmlOku = XmlReader.Create(webIstemcisi.OpenRead(guncellemeLinki) ?? throw new InvalidOperationException());

            while (xmlOku.Read())
            {
                // XML dosyasında eksi kelimesiyle baslayan alan bulunmazsa okuma yapma
                if (xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "eksi" || !xmlOku.HasAttributes)
                    continue;

                VersiyonKarsilastir(xmlOku);
            }
        }

        private void VersiyonKarsilastir(XmlReader xmlOku)
        {
            // TODO Her yeni versiyonda bu alan ve sunucudaki XML dosyası güncellecek
            string versiyon = "1.22";
            string sunucudakiVersiyon = xmlOku.GetAttribute("version");

            if (sunucudakiVersiyon == versiyon)
                MessageBox.Show(@"Program günceldir. Yeni versiyon çıkana kadar şimdilik en iyisi bu.", @"Güncelle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult guncelleDiyalog = MessageBox.Show(@"Yeni bir güncelleme var. Programı " + sunucudakiVersiyon + @" versiyonuna yükselttim. Yenilikler var. Web sayfasına girip indirmek ister misiniz?",
                    @"Güncelle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (guncelleDiyalog == DialogResult.OK)
                    Process.Start("http://www.umutd.com/programlar/eksi-sozluk-debe");
            }
        }
    }
}
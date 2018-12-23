using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace eksi_debe.Sistem
{
    public class Guncelleme
    {
        private string GuncellemeLinki => @"http://www.umutd.com/wp-content/program-versions/eksi-sozluk-debe.xml";

        public void Kontrol()
        {
            try
            {
                // Web sitesine RSS okuyucu olarak istem yapmak gerek. Yoksa istek reddedilmekte
                WebClient webIstemcisi = new WebClient();
                webIstemcisi.Headers.Add("user-agent", "MyRSSReader/1.0");

                XmlReader xmlOku = XmlReader.Create(webIstemcisi.OpenRead(GuncellemeLinki));

                while (xmlOku.Read())
                {
                    // XML dosyasında eksi ile baslayan alan bulunmazsa okuma yapma
                    if (xmlOku.NodeType != XmlNodeType.Element || xmlOku.Name != "eksi" || !xmlOku.HasAttributes)
                        continue;

                    string versiyonNo = xmlOku.GetAttribute("version");

                    if (versiyonNo == "1.2")
                        MessageBox.Show(@"Program günceldir. Yeni versiyon çıkana kadar şimdilik en iyisi bu.", @"Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                    {
                        DialogResult guncelleDiyalog = MessageBox.Show(@"Yeni bir güncelleme var. Evet evet, programı " + versiyonNo + @" versiyonuna yükselttim. Yenilikler var. Web sayfasına girip indirmek ister misiniz?", @"Güncelle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                        if (guncelleDiyalog == DialogResult.OK)
                            Process.Start("http://www.umutd.com/programlar/eksi-sozluk-debe");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Bağlantı sağlanırken istenmeyen bir hata meydana geldi. İnternet bağlantınızı kontrol etseniz iyi olur.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
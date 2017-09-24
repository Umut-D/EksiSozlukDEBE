using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace eksi_sozluk_debe.Siniflar
{
    // Programa dair güncelleme olup olmadığını Umutd.com'dan bak 
    public class Guncelle
    {
        // Ortak değişkenler
        public string VersiyonNo;
        public string GuncellemeLinki = @"http://www.umutd.com/wp-content/program-versions/eksi-sozluk-debe.xml";

        // Programın güncelleme kontrolünü yap
        public void GuncellemeKontroluYap()
        {
            try
            {
                // Web sitesine RSS okuyucu olarak istem yapmak gerek. Yoksa istek reddediliyor
                WebClient webIstemcisi = new WebClient();
                webIstemcisi.Headers.Add("user-agent", "MyRSSReader/1.0");

                // Oluşturulan XML nesnesini okumaya başla
                XmlReader xmlOku = XmlReader.Create(webIstemcisi.OpenRead(GuncellemeLinki));

                while (xmlOku.Read())
                {
                    // XML dosyasında eksi ile baslayan etiket alanını oku
                    if ((xmlOku.NodeType == XmlNodeType.Element) && (xmlOku.Name == "eksi"))
                    {
                        if (xmlOku.HasAttributes)
                        {
                            VersiyonNo = xmlOku.GetAttribute("version");

                            //Versiyon güncellemelerinde bu alana dikkat!
                            if (VersiyonNo == "1.1")
                            {
                                MessageBox.Show(@"Program günceldir. Yeni versiyon çıkana kadar şimdilik en iyisi bu.", @"Güncelle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                DialogResult guncelleDialog = MessageBox.Show(@"Yeni bir güncelleme var. Evet evet, programı " + xmlOku.GetAttribute("version") + @" versiyonuna yükselttim. Yenilikler var. Web sayfasına girip indirmek ister misiniz?", @"Güncelle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                                // Eğer güncelleme yapılacaksa ilgili sayfayı tarayıcıda aç
                                if (guncelleDialog == DialogResult.OK)
                                {
                                    Process.Start("http://www.umutd.com/programlar/eksi-sozluk-debe");
                                }
                            }
                        }
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


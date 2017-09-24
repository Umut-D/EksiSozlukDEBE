using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace eksi_sozluk_debe.Siniflar
{
    public class EntryKaydetYukle
    {
        // Kaydedilme ve okuma yapılacak dizin
        private readonly string _dizin = AppDomain.CurrentDomain.BaseDirectory + @"\kaydedilen-entryler.xml";
        
        // Kaydedilip, daha sonra açılan entrylerin gösterim yapılırken atılacağı koleksiyon
        public ArrayList IcerikDizi = new ArrayList();
        public int Sayac = 0;

        // Değişken alanı
        private readonly XmlDocument _xmlOku = new XmlDocument();

        public void XmlDosyasiniKontrolEt()
        {
            // entrylerim.xml dosyası varsa yükle
            if (File.Exists(_dizin) && new FileInfo(_dizin).Length != 0)
            {
                _xmlOku.Load(_dizin);
            }
            // entrylerim.xml dosyası yoksa sıfırdan oluştur ve günün tarihini at
            else
            {
                File.Create(_dizin).Close();

                // Girintili XML dosyası oluştur
                XmlTextWriter xmlYaz = new XmlTextWriter(_dizin, Encoding.UTF8)
                {
                    Formatting = Formatting.Indented
                };

                // Dış dizinden içe doğru başla ve iç dizinden dışa doğru devam et
                xmlYaz.WriteStartElement("kaydedilenEntryler"); // Dış kabuk aç
                xmlYaz.WriteStartElement("entryler"); // orta kabuk aç
                xmlYaz.WriteStartElement("kayit"); // İç kısım aç
                xmlYaz.WriteString("Lütfen bu dosyayı silmeyiniz."); // Etiketin içine yaz
                xmlYaz.WriteEndElement(); // İç kısım kapat
                xmlYaz.WriteEndElement(); // orta kabuk kapat
                xmlYaz.WriteEndElement(); // Dış kabuk kapat

                xmlYaz.Close();
            }
        }

        public void EntryKaydet(WebBrowser webBrowser)
        {
            // Dizini yükle
            _xmlOku.Load(_dizin);

            // XML dosyasına düğüm düğüm yazmaya başla ve kaydet
            XmlNode kaydedilenEntryler = _xmlOku.CreateElement("entryler");
            XmlNode entryler = _xmlOku.CreateElement("kayit");
            entryler.InnerText = webBrowser.DocumentText;
            kaydedilenEntryler.AppendChild(entryler);
            _xmlOku.DocumentElement?.AppendChild(kaydedilenEntryler);
            _xmlOku.Save(_dizin);

            MessageBox.Show(@"Entry başarıyla kaydedildi.", @"Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void EntryYukle(WebBrowser webBrowser, ToolStripComboBox tscBox, ToolStripLabel tsslDurum)
        {
            XmlDosyasiniKontrolEt();

            // XML dosyasını yükle
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(_dizin);
            
            // Entry içeriklerini tek tek koleksiyona yükle
            foreach (XmlNode node in xdoc.SelectNodes("kaydedilenEntryler/entryler"))
            {
                IcerikDizi.Add(node.SelectSingleNode("kayit").InnerText);
            }

            IcerikDizi.Remove("Lütfen bu dosyayı silmeyiniz.");

            // Kaydedilen entryler varsa yükle, yoksa yükleme yapmayıp uyarı ver
            if (IcerikDizi.Count != 0)
            {
                // Koleksiyonda yer alan tüm bileşenleri WebBrowser'a yükle
                webBrowser.DocumentText = "<p style='font-size:24px;font-family:Cambria;font-weight:bold'>" + IcerikDizi[Sayac] + "</p>";

                // Daha önceden kaydedilen entryleri yükle
                tsslDurum.Text = @"Kaydedilen entryler başarıyla yüklendi.";
                tsslDurum.ForeColor = Color.BlueViolet;
            }
            else
            {
                webBrowser.DocumentText = "";
                MessageBox.Show(@"Kaydedilen entry bulunamadı. Beğendiğiniz entryler yok anlaşılan.", @"Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // tscBox'u bloke et ve içeriği varsa temizle
            tscBox.Enabled = false;
            tscBox.Items.Clear();            

            // Koleksiyon başını alıp gitmesin diye diziyi sıfırla
            IcerikDizi.Clear();
        }
    }
}
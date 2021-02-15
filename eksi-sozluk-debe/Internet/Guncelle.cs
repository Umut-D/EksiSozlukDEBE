using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace eksi_debe.Internet
{
    public class Guncelle
    {
        private XmlReader _xmlOku;

        public void VersiyonKontroluYap()
        {
            Baglanti baglanti = new Baglanti();
            if (baglanti.InternetVarMi())
                WebXmlBaglanti();
        }

        private void WebXmlBaglanti()
        {
            string guncellemeLinki = @"https://raw.githubusercontent.com/Umut-D/umutd.com/master/assets/program-versions/eksi-sozluk-debe.xml";

            WebClient webIstemcisi = new WebClient();
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            _xmlOku = XmlReader.Create(webIstemcisi.OpenRead(guncellemeLinki) ?? throw new InvalidOperationException());

            WebXmlOku();
        }

        private void WebXmlOku()
        {
            while (_xmlOku.Read())
            {
                if (_xmlOku.NodeType != XmlNodeType.Element || _xmlOku.Name != "eksi" || !_xmlOku.HasAttributes)
                    continue;

                VersiyonlariKarsilastir();
            }
        }

        private void VersiyonlariKarsilastir()
        {
            if (MevcutVersiyon() == SunucudakiVersiyon())
                MessageBox.Show(@"Program günceldir. Yenisi çıkana kadar şimdilik en iyisi bu.", @"Güncelle",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                DialogResult diyalog = MessageBox.Show($@"Yeni bir güncelleme var. Programı {SunucudakiVersiyon()} versiyonuna yükselttim. Web sayfasına girip indirmek ister misiniz?", @"Güncelle", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (diyalog == DialogResult.OK)
                    Process.Start("http://www.umutd.com/programlar/eksi-sozluk-debe");
            }
        }

        private string MevcutVersiyon()
        {
            return "1.26";
        }

        private string SunucudakiVersiyon()
        {
            return _xmlOku.GetAttribute("version");
        }
    }
}
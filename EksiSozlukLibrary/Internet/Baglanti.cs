using System;
using System.Net;
using System.Windows.Forms;

namespace EksiSozlukLibrary.Internet
{
    public class Baglanti
    {
        public bool InternetVarMi()
        {
            try
            {
                using (WebClient webBaglanti = new WebClient())
                {
                    using (webBaglanti.OpenRead("http://google.com/"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                MessageBox.Show(@"Maalesef internet bağlantınız aktif değil. Programı çalıştıramazsınız.", @"Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Environment.Exit(0);

                return false;
            }
        }
    }
}
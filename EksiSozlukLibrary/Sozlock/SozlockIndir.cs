using System;
using System.Net;

namespace EksiSozlukLibrary.Sozlock
{
    public class SozlockIndir
    {
        public string Dizin => AppDomain.CurrentDomain.BaseDirectory + @"Entryler";

        public void SayfayiIndir(SozlockTarih tarih)
        {
            GuvenlikProtokoluEkle();

            WebClient webIstem = new WebClient();
            webIstem.DownloadFile(Adres(tarih), Dizin);
        }

        private string Adres(SozlockTarih tarih)
        {
            Uri adres = new Uri("https://sozlock.com/");
            string secilenDebeGunu = "?date=" + tarih.DuzenliTarih;

            return adres + secilenDebeGunu;
        }

        private void GuvenlikProtokoluEkle()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
        }
    }
}
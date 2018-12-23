﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace eksi_debe.Islemler
{
    class Debe : Degiskenler
    {
        public void WebBaglanti()
        {
            WebClient webBaglanti = new WebClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            webBaglanti.DownloadFile(Sozlock, Dosya);
            HtmlBelge.Load(Dosya, Encoding.UTF8);
        }

        public void Indir(ToolStripComboBox tscListe)
        {
            WebBaglanti();

            Degiskenler degiskenler = new Degiskenler();
            
            // Tüm entryleri indirerek Generic Listelere ekle (Tuple kullanıp kullanmama arasında çok kararsız kaldım)
            int sayac = 1;
            try
            {
                for (sayac = 1; sayac < 52; sayac++)
                {
                    Baslik.Add(HtmlBelge.DocumentNode.SelectSingleNode(degiskenler.Basliklar(sayac)).InnerText.Replace("&#39;","'"));
                    Icerik.Add(HtmlBelge.DocumentNode.SelectSingleNode(degiskenler.Icerikler(sayac)).InnerHtml);
                    Yazar.Add(HtmlBelge.DocumentNode.SelectSingleNode(degiskenler.Yazarlar(sayac)).InnerHtml);
                    Link.Add(HtmlBelge.DocumentNode.SelectSingleNode(degiskenler.Linkler(sayac)).Attributes["href"].Value);
                    Zaman.Add(HtmlBelge.DocumentNode.SelectSingleNode(degiskenler.Zamanlar(sayac)).InnerText);               
                }
            }
            catch (Exception)
            {
                EntryAdet = sayac;
            }

            // Başlıkları tek seferde ToolStripComboBox'a aktar
            tscListe.Items.AddRange(Baslik.ToArray());
        }

        public string DebeGoruntule(int entryNo)
        {
            return "<html><body style='background-color:#cbcbcb;color: black;'><p style='font-size:26px;font-family:Cambria;font-weight:bold'>" + Baslik[entryNo] + "</p>" + "<font face='Calibri'>" + Icerik[entryNo] + "<br/><br/><strong>" + Yazar[entryNo] + "</strong><br/>" + Zaman[entryNo] + "</font></body></html>";
        }

        public string Gezinti(int sayi, ToolStripComboBox tscEntryListesi)
        {
            EntrySayi = sayi;
            tscEntryListesi.SelectedIndex = EntrySayi;

            return DebeGoruntule(EntrySayi);
        }

        public Process Git(int sayi)
        {
            return Process.Start(Link[sayi]);
        }

        public void Bilgilendirme(ToolStripStatusLabel tsslDurum)
        {
            DateTime gun = Convert.ToDateTime(Zaman[0]);
         
            tsslDurum.ForeColor = Color.Green;
            tsslDurum.Text = gun.ToLongDateString() + @" tarihli DEBE'ler gösteriliyor";
        }
    }
}
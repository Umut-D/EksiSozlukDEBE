using System.Collections.Generic;
using System.Text;
using EksiSozlukLibrary.Sozluk;
using EksiSozlukLibrary.XPath;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace EksiSozlukLibrary.Sozlock
{
    public class SozlockDebe
    {
        public List<Entry> Entryler { get; private set; }
        private readonly SozlockXpath _xpath;
        private HtmlDocument _html;

        public SozlockDebe()
        {
            _xpath = new SozlockXpath();
        }

        public List<string> Indir()
        {
            HtmlYukle();

            Entryler = new List<Entry>();
            Entryler.Clear();

            return BasliklariEkle();
        }

        private void HtmlYukle()
        {
            SozlockIndir indir = new SozlockIndir();
            
            _html = new HtmlDocument();
            _html.Load(indir.Dizin, Encoding.UTF8);
        }

        private List<string> BasliklariEkle()
        {
            int sayac = 1;
            List<string> basliklar = new List<string>();
            while (true)
            {
                if (IcerikBosMu(sayac))
                    break;

                Entry entry = EntryleriYukle(sayac);
                basliklar.Add(entry.Baslik);

                sayac++;
            }

            return basliklar;
        }

        private bool IcerikBosMu(int sayac)
        {
            string baslik = _html?.DocumentNode?.SelectSingleNode(_xpath.Baslik(sayac))?.InnerText;
            return string.IsNullOrEmpty(baslik);
        }

        private Entry EntryleriYukle(int entryNo)
        {
            Entry entry = new Entry
            {
                Baslik = _html.DocumentNode.SelectSingleNode(_xpath.Baslik(entryNo)).InnerText.Replace("&#39;", "'"),
                Icerik = _html.DocumentNode.SelectSingleNode(_xpath.Icerik(entryNo)).InnerHtml,
                Yazar = _html.DocumentNode.SelectSingleNode(_xpath.Yazar(entryNo)).InnerHtml,
                Link = _html.DocumentNode.SelectSingleNode(_xpath.Link(entryNo)).Attributes["href"].Value,
                Tarih = _html.DocumentNode.SelectSingleNode(_xpath.Tarih(entryNo)).InnerText
            };
            Entryler.Add(entry);

            return entry;
        }
    }
}
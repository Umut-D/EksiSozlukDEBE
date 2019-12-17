using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace eksi_debe.Islemler
{
    class Entry
    {
        public List<string> Baslik { get; set; } = new List<string>();
        public List<string> Icerik { get; set; } = new List<string>();
        public List<string> Yazar { get; set; } = new List<string>();
        public List<string> Link { get; set; } = new List<string>();
        public List<string> Zaman { get; set; } = new List<string>();

        public int Sayi { get; set; }
        public int Adet { get; set; }

        public HtmlDocument HtmlBelge { get; set; } = new HtmlDocument();
        public Xpath Xpath { get; } = new Xpath();

        private DateTime _secilenTarih;
        public DateTime SecilenTarih
        {
            get => _secilenTarih;
            set => _secilenTarih =
                value.AddDays(1); // DEBE'nin, kullanıcının tam olarak istediği tarih çıkması için gün arttırımı yap
        }
    }
}
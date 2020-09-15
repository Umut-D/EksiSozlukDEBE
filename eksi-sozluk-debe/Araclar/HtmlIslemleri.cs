using System;
using HtmlAgilityPack;

namespace eksi_debe.Araclar
{
    class HtmlIslemleri
    {
        public HtmlDocument HtmlBelge { set; get; } = new HtmlDocument();

        // DEBE'nin, kullanıcının tam olarak istediği tarih çıkması için gün arttırımı yap
        private DateTime _secilenTarih;
        public DateTime SecilenTarih
        {
            get => _secilenTarih;
            set => _secilenTarih = value.AddDays(1);
        }
    }
}
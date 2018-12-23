using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace eksi_debe.Islemler
{
    class Degiskenler
    {
        public List<string> Baslik { get; set; } = new List<string>();
        public List<string> Icerik { get; set; } = new List<string>();
        public List<string> Yazar { get; set; } = new List<string>();
        public List<string> Link { get; set; } = new List<string>();
        public List<string> Zaman { get; set; } = new List<string>();

        public int EntrySayi { get; set; }
        public int EntryAdet { get; set; }
        public HtmlDocument HtmlBelge { get; set; } = new HtmlDocument();
        public Uri Sozlock => new Uri("http://www.sozlock.com/");
        public string Dosya => AppDomain.CurrentDomain.BaseDirectory + @"Entryler";

        #region Html Agility Pack ile çekilen XPATH kodları

        public string Basliklar(int sayi)
        {
            return @"/html/body/main/div/div[2]/ul/li[" + sayi + "]/h3";
        }

        public string Icerikler(int sayi)
        {
            return @"/html/body/main/div/div[2]/ul/li[" + sayi + "]/div[1]/div/p";
        }

        public string Yazarlar(int sayi)
        {
            return @"/html/body/main/div/div[2]/ul/li[" + sayi + "]/div[1]/div/div/div[2]/a";
        }

        public string Linkler(int sayi)
        {
            return "/html/body/main/div/div[2]/ul/li[" + sayi + "]/div[2]/a";
        }

        public string Zamanlar(int sayi)
        {
            return @"/html/body/main/div/div[2]/ul/li[" + sayi + "]/div[1]/div/div/div[2]/span";
        }

        #endregion
    }
}
namespace eksi_debe.XPath
{
    public class SozlockXpath
    {
        public string Baslik(int sayi)
        {
            return $"/html/body/main/div/div[2]/div[2]/ul/li[{sayi}]/h3";
        }

        public string Icerik(int sayi)
        {
            return $"/html/body/main/div//div[2]/div[2]/ul/li[{sayi}]/div[1]/div/p";
        }

        public string Yazar(int sayi)
        {
            return $"/html/body/main/div/div[2]/div[2]/ul/li[{sayi}]/div[1]/div/div/div[2]/a";
        }

        public string Link(int sayi)
        {
            return $"/html/body/main/div//div[2]/div[2]/ul/li[{sayi}]/div[2]/a";
        }

        public string Tarih(int sayi)
        {
            return $"/html/body/main/div//div[2]/div[2]/ul/li[{sayi}]/div[1]/div/div/div[2]/span";
        }
    }
}
namespace eksi_debe.Islemler
{
    class Xpath
    {
        public string Basliklar(int sayi)
        {
            return @"/html/body/main/div/div[2]/div[2]/ul/li[" + sayi + "]/h3";
        }

        public string Icerikler(int sayi)
        {
            return @"/html/body/main/div//div[2]/div[2]/ul/li[" + sayi + "]/div[1]/div/p";
        }

        public string Yazarlar(int sayi)
        {
            return @"/html/body/main/div/div[2]/div[2]/ul/li[" + sayi + "]/div[1]/div/div/div[2]/a";
        }

        public string Linkler(int sayi)
        {
            return "/html/body/main/div//div[2]/div[2]/ul/li[" + sayi + "]/div[2]/a";
        }

        public string Zamanlar(int sayi)
        {
            return @"/html/body/main/div//div[2]/div[2]/ul/li[" + sayi + "]/div[1]/div/div/div[2]/span";
        }
    }
}
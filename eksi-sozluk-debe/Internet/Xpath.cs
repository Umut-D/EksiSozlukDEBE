namespace eksi_debe.Internet
{
    class Xpath
    {
        public static string Basliklar(int sayi)
        {
            return @"/html/body/main/div/div[2]/div[2]/ul/li[" + sayi + "]/h3";
        }

        public static string Icerikler(int sayi)
        {
            return @"/html/body/main/div//div[2]/div[2]/ul/li[" + sayi + "]/div[1]/div/p";
        }

        public static string Yazarlar(int sayi)
        {
            return @"/html/body/main/div/div[2]/div[2]/ul/li[" + sayi + "]/div[1]/div/div/div[2]/a";
        }

        public static string Linkler(int sayi)
        {
            return "/html/body/main/div//div[2]/div[2]/ul/li[" + sayi + "]/div[2]/a";
        }

        public static string Zamanlar(int sayi)
        {
            return @"/html/body/main/div//div[2]/div[2]/ul/li[" + sayi + "]/div[1]/div/div/div[2]/span";
        }
    }
}
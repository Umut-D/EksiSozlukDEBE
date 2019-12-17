using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace eksi_debe.Internet
{
    public class Baglanti
    {
        // İnternet bağlatısını kontrol etmek için wininet.dll'yi kullanıp işletim sistemi kaynaklarına eriş
        [DllImport("wininet.dll", CharSet = CharSet.Auto)]
        private static extern bool InternetGetConnectedState(ref InternetConnectionStateFlags lpdwFlags, int dwReserved);

        [Flags]
        private enum InternetConnectionStateFlags
        {
            INTERNET_CONNECTION_MODEM = 0x01,
            INTERNET_CONNECTION_LAN = 0x02,
            INTERNET_CONNECTION_PROXY = 0x04,
            INTERNET_RAS_INSTALLED = 0x10,
            INTERNET_CONNECTION_OFFLINE = 0x20,
            INTERNET_CONNECTION_CONFIGURED = 0x40
        }

        public static string Kontrol()
        {
            InternetConnectionStateFlags flags = 0;
            bool baglantiDurumu = InternetGetConnectedState(ref flags, 0);

            if (baglantiDurumu)
                return @"İnternet bağlantınız var ve bu iyi bir şey.";

            return @"İnternet bağlantınız maalesef yok. Modemi bir kapatıp açın derim.";
        }

        public static Color Renk(string durumYazisi)
        {
            if (durumYazisi.Contains("var"))
                return Color.Green;
        
            return Color.MediumVioletRed;
        }
    }
}
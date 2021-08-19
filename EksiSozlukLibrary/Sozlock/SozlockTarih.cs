using System;

namespace EksiSozlukLibrary.Sozlock
{
    public class SozlockTarih
    {
        public string DuzenliTarih => _tarih.ToString(@"yyyy-MM-dd");
        private DateTime _tarih;

        public DateTime Tarih
        {
            get => _tarih;
            set => _tarih = value.AddDays(1);
        }

        public string SecilenGun(SozlockDebe debe)
        {
            string[] zaman = debe.Entryler[0].Tarih.Split(' ');
            return Convert.ToDateTime(zaman[0]).ToLongDateString();
        }
    }
}
using EksiSozlukLibrary.Sozlock;

namespace EksiSozlukLibrary.Sozluk
{
    public class Goruntule
    {
        private readonly SozlockDebe _sozlockDebe;

        public Goruntule(SozlockDebe sozlockDebe)
        {
            _sozlockDebe = sozlockDebe;
        }

        public string Yazdir(int entryNo)
        {
            return "<html><body style='background-color:#cbcbcb;color: black;'><p style='font-size:26px;font-family:Cambria;font-weight:bold'>" + _sozlockDebe.Entryler[entryNo].Baslik + "</p>" + "<font face='Calibri'>" + _sozlockDebe.Entryler[entryNo].Icerik + "<br/><br/><strong>" + _sozlockDebe.Entryler[entryNo].Yazar + "</strong><br/>" + _sozlockDebe.Entryler[entryNo].Tarih + "</font></body></html>";
        }
    }
}
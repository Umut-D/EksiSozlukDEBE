using System;
using System.Drawing;
using System.Windows.Forms;

namespace eksi_sozluk_debe.Siniflar
{
    // Yüklenen entrynin bir önceki Debe listesine ait olup olmadığını kontrol et ve kullanıcıyı bilgilendir
    public class GunKontrolu
    {
        // Mevcut günün tarihini al
        readonly int _gun = DateTime.Today.Day - 1;
        int _ilkBosluk, _ikinciBosluk;
        string _mevcutGun;

        // XML dosyasının yüklenme zamanını bul
        public void XmlYuklenmeZamani(string gelenGunDegeri, ToolStripStatusLabel tsslDurum)
        {
            // Gelen uzun tarihten gün değerini al ve sayıya dönüştür
            _ilkBosluk = gelenGunDegeri.IndexOf(" ", StringComparison.Ordinal);
            _ikinciBosluk = gelenGunDegeri.LastIndexOf(" ", _ilkBosluk, StringComparison.Ordinal);
            _mevcutGun = gelenGunDegeri.Substring(_ilkBosluk, _ikinciBosluk);
            int oncekiGun = Convert.ToInt32(_mevcutGun);

            // bir önceki gün, entry girilme günü ile eşitse
            if (_gun == oncekiGun)
            {
                tsslDurum.Text = @"Bir önceki günün (" + DateTime.Today.AddDays(-1).ToLongDateString() + @") entryleri başarıyla yüklendi.";
                tsslDurum.ForeColor = Color.ForestGreen;
            }
            // bir önceki gün, entry girilme günü ile eşit değilse
            else
            {
                tsslDurum.Text = @"Yüklenen entryler bir önceki güne ait değil! Lütfen diğer site seçeneğini deneyiniz.";
                tsslDurum.ForeColor = Color.OrangeRed;
            }
        }
    }
}

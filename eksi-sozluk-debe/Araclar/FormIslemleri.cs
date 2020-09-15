using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace eksi_debe.Araclar
{
    public class FormIslemleri
    {
        // TsmiTarihSec_Click eyleminde tarih seçim kontrolünün çıkması için gerekli kodlar
        public const uint WM_SYSKEYDOWN = 0x104;
        
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        private readonly FrmEksi _frmEksi;

        public FormIslemleri(FrmEksi frmEksi)
        {
            _frmEksi = frmEksi;
        }

        public void Aktif()
        {
            _frmEksi.btnSonraki.Enabled = true;
            _frmEksi.btnOnceki.Enabled = true;
            _frmEksi.btnGit.Enabled = true;

            _frmEksi.tscEntryListesi.Enabled = true;
        }

        public void TarihAraliklari(DateTimePicker dtpTarihSec)
        {
            dtpTarihSec.MaxDate = DateTime.Today.Subtract(new TimeSpan(1));
            dtpTarihSec.MinDate = new DateTime(2015, 06, 04);
        }
    }
}
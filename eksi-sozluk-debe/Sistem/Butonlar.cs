namespace eksi_debe.Sistem
{
    public class Butonlar
    {
        private readonly FrmEksi _frmEksi;

        public Butonlar(FrmEksi frmEksi)
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
    }
}
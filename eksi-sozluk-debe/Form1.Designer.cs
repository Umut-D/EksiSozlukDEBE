namespace eksi_sozluk_debe
{
    partial class FrmEksiSozlukDebe
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEksiSozlukDebe));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiDosya = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKaydet = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmKaydedilenleriYukle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmYazdir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmCikis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDebeYukle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBilgi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGuncelle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.tscEntryListesi = new System.Windows.Forms.ToolStripComboBox();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelUst = new System.Windows.Forms.Panel();
            this.btnSonraki = new System.Windows.Forms.Button();
            this.btnOnceki = new System.Windows.Forms.Button();
            this.ssButonlar = new System.Windows.Forms.StatusStrip();
            this.tsProgressBar = new System.Windows.Forms.ProgressBar();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelUst.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDosya,
            this.tsmiDebeYukle,
            this.tsmiBilgi,
            this.tscEntryListesi});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(942, 34);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiDosya
            // 
            this.tsmiDosya.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmKaydet,
            this.tsmKaydedilenleriYukle,
            this.toolStripSeparator1,
            this.tsmYazdir,
            this.toolStripSeparator2,
            this.tsmCikis});
            this.tsmiDosya.Name = "tsmiDosya";
            this.tsmiDosya.Size = new System.Drawing.Size(65, 30);
            this.tsmiDosya.Text = "Dosya";
            // 
            // tsmKaydet
            // 
            this.tsmKaydet.Enabled = false;
            this.tsmKaydet.Name = "tsmKaydet";
            this.tsmKaydet.Size = new System.Drawing.Size(229, 28);
            this.tsmKaydet.Text = "Kaydet";
            this.tsmKaydet.Click += new System.EventHandler(this.tsmKaydet_Click);
            // 
            // tsmKaydedilenleriYukle
            // 
            this.tsmKaydedilenleriYukle.Name = "tsmKaydedilenleriYukle";
            this.tsmKaydedilenleriYukle.Size = new System.Drawing.Size(229, 28);
            this.tsmKaydedilenleriYukle.Text = "Kaydedilenleri Yükle";
            this.tsmKaydedilenleriYukle.Click += new System.EventHandler(this.tsmKaydedilenleriYukle_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // tsmYazdir
            // 
            this.tsmYazdir.Name = "tsmYazdir";
            this.tsmYazdir.Size = new System.Drawing.Size(229, 28);
            this.tsmYazdir.Text = "Yazdır";
            this.tsmYazdir.Click += new System.EventHandler(this.tsmYazdir_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // tsmCikis
            // 
            this.tsmCikis.Name = "tsmCikis";
            this.tsmCikis.Size = new System.Drawing.Size(229, 28);
            this.tsmCikis.Text = "Çıkış";
            this.tsmCikis.Click += new System.EventHandler(this.tsmCikis_Click);
            // 
            // tsmiDebeYukle
            // 
            this.tsmiDebeYukle.Name = "tsmiDebeYukle";
            this.tsmiDebeYukle.Size = new System.Drawing.Size(100, 30);
            this.tsmiDebeYukle.Text = "Debe Yükle";
            this.tsmiDebeYukle.Click += new System.EventHandler(this.tsmiDebeYukle_Click);
            // 
            // tsmiBilgi
            // 
            this.tsmiBilgi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGuncelle,
            this.tsmHakkinda});
            this.tsmiBilgi.Name = "tsmiBilgi";
            this.tsmiBilgi.Size = new System.Drawing.Size(52, 30);
            this.tsmiBilgi.Text = "Bilgi";
            // 
            // tsmGuncelle
            // 
            this.tsmGuncelle.Name = "tsmGuncelle";
            this.tsmGuncelle.Size = new System.Drawing.Size(154, 28);
            this.tsmGuncelle.Text = "Güncelle";
            this.tsmGuncelle.Click += new System.EventHandler(this.tsmGuncelle_Click);
            // 
            // tsmHakkinda
            // 
            this.tsmHakkinda.Name = "tsmHakkinda";
            this.tsmHakkinda.Size = new System.Drawing.Size(154, 28);
            this.tsmHakkinda.Text = "Hakkında";
            this.tsmHakkinda.Click += new System.EventHandler(this.tsmHakkinda_Click);
            // 
            // tscEntryListesi
            // 
            this.tscEntryListesi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscEntryListesi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tscEntryListesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscEntryListesi.Enabled = false;
            this.tscEntryListesi.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tscEntryListesi.Name = "tscEntryListesi";
            this.tscEntryListesi.Size = new System.Drawing.Size(415, 30);
            this.tscEntryListesi.Tag = "";
            this.tscEntryListesi.DropDownClosed += new System.EventHandler(this.tscEntryListesi_DropDownClosed);
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(2, 2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(937, 560);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.webBrowser_Navigating);
            // 
            // statusStrip
            // 
            this.statusStrip.AutoSize = false;
            this.statusStrip.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslDurum});
            this.statusStrip.Location = new System.Drawing.Point(0, 639);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(942, 32);
            this.statusStrip.TabIndex = 2;
            // 
            // tsslDurum
            // 
            this.tsslDurum.Name = "tsslDurum";
            this.tsslDurum.Size = new System.Drawing.Size(47, 27);
            this.tsslDurum.Text = "Hazır";
            // 
            // panelUst
            // 
            this.panelUst.Controls.Add(this.btnSonraki);
            this.panelUst.Controls.Add(this.btnOnceki);
            this.panelUst.Controls.Add(this.ssButonlar);
            this.panelUst.Controls.Add(this.webBrowser);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUst.Location = new System.Drawing.Point(0, 34);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(942, 605);
            this.panelUst.TabIndex = 3;
            // 
            // btnSonraki
            // 
            this.btnSonraki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSonraki.Enabled = false;
            this.btnSonraki.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSonraki.Location = new System.Drawing.Point(839, 565);
            this.btnSonraki.Name = "btnSonraki";
            this.btnSonraki.Size = new System.Drawing.Size(100, 37);
            this.btnSonraki.TabIndex = 4;
            this.btnSonraki.Text = "Sonraki >>";
            this.btnSonraki.UseVisualStyleBackColor = true;
            this.btnSonraki.Click += new System.EventHandler(this.btnSonraki_Click);
            // 
            // btnOnceki
            // 
            this.btnOnceki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOnceki.Enabled = false;
            this.btnOnceki.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOnceki.Location = new System.Drawing.Point(3, 565);
            this.btnOnceki.Name = "btnOnceki";
            this.btnOnceki.Size = new System.Drawing.Size(100, 37);
            this.btnOnceki.TabIndex = 3;
            this.btnOnceki.Text = "<< Önceki";
            this.btnOnceki.UseVisualStyleBackColor = true;
            this.btnOnceki.Click += new System.EventHandler(this.btnOnceki_Click);
            // 
            // ssButonlar
            // 
            this.ssButonlar.AutoSize = false;
            this.ssButonlar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.ssButonlar.Location = new System.Drawing.Point(0, 563);
            this.ssButonlar.Name = "ssButonlar";
            this.ssButonlar.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ssButonlar.Size = new System.Drawing.Size(942, 42);
            this.ssButonlar.SizingGrip = false;
            this.ssButonlar.Stretch = false;
            this.ssButonlar.TabIndex = 2;
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tsProgressBar.Location = new System.Drawing.Point(781, 639);
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(161, 32);
            this.tsProgressBar.TabIndex = 5;
            // 
            // FrmEksiSozlukDebe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 671);
            this.Controls.Add(this.tsProgressBar);
            this.Controls.Add(this.panelUst);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(960, 720);
            this.Name = "FrmEksiSozlukDebe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekşi Sözlük Debe";
            this.Load += new System.EventHandler(this.FrmEksiSozlukDebe_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelUst.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsmiDosya;
        private System.Windows.Forms.ToolStripMenuItem tsmKaydet;
        private System.Windows.Forms.ToolStripMenuItem tsmKaydedilenleriYukle;
        private System.Windows.Forms.ToolStripMenuItem tsmCikis;
        private System.Windows.Forms.ToolStripMenuItem tsmiDebeYukle;
        private System.Windows.Forms.ToolStripMenuItem tsmiBilgi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmGuncelle;
        private System.Windows.Forms.ToolStripMenuItem tsmHakkinda;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslDurum;
        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.ToolStripComboBox tscEntryListesi;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmYazdir;
        private System.Windows.Forms.StatusStrip ssButonlar;
        private System.Windows.Forms.Button btnSonraki;
        private System.Windows.Forms.Button btnOnceki;
        private System.Windows.Forms.ProgressBar tsProgressBar;
        public System.Windows.Forms.WebBrowser webBrowser;
    }
}


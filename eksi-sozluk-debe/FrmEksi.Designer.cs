namespace eksi_debe
{
    partial class FrmEksi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEksi));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiDebeYukle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTarihSec = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBilgi = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmGuncelle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHakkinda = new System.Windows.Forms.ToolStripMenuItem();
            this.tscEntryListesi = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslDurum = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelUst = new System.Windows.Forms.Panel();
            this.btnGit = new System.Windows.Forms.Button();
            this.btnSonraki = new System.Windows.Forms.Button();
            this.btnOnceki = new System.Windows.Forms.Button();
            this.ssButonlar = new System.Windows.Forms.StatusStrip();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.tsProgressBar = new System.Windows.Forms.ProgressBar();
            this.dtpTarihSec = new System.Windows.Forms.DateTimePicker();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelUst.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDebeYukle,
            this.tsmiTarihSec,
            this.tsmiBilgi,
            this.tscEntryListesi});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(942, 35);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // tsmiDebeYukle
            // 
            this.tsmiDebeYukle.Name = "tsmiDebeYukle";
            this.tsmiDebeYukle.Size = new System.Drawing.Size(107, 31);
            this.tsmiDebeYukle.Text = "Debe Yükle";
            this.tsmiDebeYukle.Click += new System.EventHandler(this.TsmiDebeYukle_Click);
            // 
            // tsmiTarihSec
            // 
            this.tsmiTarihSec.Name = "tsmiTarihSec";
            this.tsmiTarihSec.Size = new System.Drawing.Size(89, 31);
            this.tsmiTarihSec.Text = "Tarih Seç";
            this.tsmiTarihSec.Click += new System.EventHandler(this.TsmiTarihSec_Click);
            // 
            // tsmiBilgi
            // 
            this.tsmiBilgi.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmGuncelle,
            this.tsmHakkinda});
            this.tsmiBilgi.Name = "tsmiBilgi";
            this.tsmiBilgi.Size = new System.Drawing.Size(54, 31);
            this.tsmiBilgi.Text = "Bilgi";
            // 
            // tsmGuncelle
            // 
            this.tsmGuncelle.Name = "tsmGuncelle";
            this.tsmGuncelle.Size = new System.Drawing.Size(160, 28);
            this.tsmGuncelle.Text = "Güncelle";
            this.tsmGuncelle.Click += new System.EventHandler(this.TsmGuncelle_Click);
            // 
            // tsmHakkinda
            // 
            this.tsmHakkinda.Name = "tsmHakkinda";
            this.tsmHakkinda.Size = new System.Drawing.Size(160, 28);
            this.tsmHakkinda.Text = "Hakkında";
            this.tsmHakkinda.Click += new System.EventHandler(this.TsmiHakkinda_Click);
            // 
            // tscEntryListesi
            // 
            this.tscEntryListesi.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tscEntryListesi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.tscEntryListesi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscEntryListesi.Enabled = false;
            this.tscEntryListesi.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tscEntryListesi.Name = "tscEntryListesi";
            this.tscEntryListesi.Size = new System.Drawing.Size(415, 31);
            this.tscEntryListesi.Tag = "";
            this.tscEntryListesi.DropDownClosed += new System.EventHandler(this.TscEntryListesi_DropDownClosed);
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
            this.tsslDurum.Size = new System.Drawing.Size(50, 27);
            this.tsslDurum.Text = "Hazır";
            // 
            // panelUst
            // 
            this.panelUst.Controls.Add(this.btnGit);
            this.panelUst.Controls.Add(this.btnSonraki);
            this.panelUst.Controls.Add(this.btnOnceki);
            this.panelUst.Controls.Add(this.ssButonlar);
            this.panelUst.Controls.Add(this.webBrowser);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUst.Location = new System.Drawing.Point(0, 35);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(942, 604);
            this.panelUst.TabIndex = 3;
            // 
            // btnGit
            // 
            this.btnGit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGit.Enabled = false;
            this.btnGit.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGit.Location = new System.Drawing.Point(420, 564);
            this.btnGit.Name = "btnGit";
            this.btnGit.Size = new System.Drawing.Size(100, 37);
            this.btnGit.TabIndex = 5;
            this.btnGit.Text = "< Git >";
            this.btnGit.UseVisualStyleBackColor = true;
            this.btnGit.Click += new System.EventHandler(this.BtnGit_Click);
            // 
            // btnSonraki
            // 
            this.btnSonraki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSonraki.Enabled = false;
            this.btnSonraki.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSonraki.Location = new System.Drawing.Point(839, 564);
            this.btnSonraki.Name = "btnSonraki";
            this.btnSonraki.Size = new System.Drawing.Size(100, 37);
            this.btnSonraki.TabIndex = 4;
            this.btnSonraki.Text = "Sonraki >>";
            this.btnSonraki.UseVisualStyleBackColor = true;
            this.btnSonraki.Click += new System.EventHandler(this.BtnSonraki_Click);
            // 
            // btnOnceki
            // 
            this.btnOnceki.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOnceki.Enabled = false;
            this.btnOnceki.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOnceki.Location = new System.Drawing.Point(3, 564);
            this.btnOnceki.Name = "btnOnceki";
            this.btnOnceki.Size = new System.Drawing.Size(100, 37);
            this.btnOnceki.TabIndex = 3;
            this.btnOnceki.Text = "<< Önceki";
            this.btnOnceki.UseVisualStyleBackColor = true;
            this.btnOnceki.Click += new System.EventHandler(this.BtnOnceki_Click);
            // 
            // ssButonlar
            // 
            this.ssButonlar.AutoSize = false;
            this.ssButonlar.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.ssButonlar.Location = new System.Drawing.Point(0, 562);
            this.ssButonlar.Name = "ssButonlar";
            this.ssButonlar.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.ssButonlar.Size = new System.Drawing.Size(942, 42);
            this.ssButonlar.SizingGrip = false;
            this.ssButonlar.Stretch = false;
            this.ssButonlar.TabIndex = 2;
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(2, 2);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(937, 559);
            this.webBrowser.TabIndex = 1;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_DocumentCompleted);
            this.webBrowser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowser_Navigating);
            // 
            // tsProgressBar
            // 
            this.tsProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tsProgressBar.Location = new System.Drawing.Point(781, 639);
            this.tsProgressBar.Name = "tsProgressBar";
            this.tsProgressBar.Size = new System.Drawing.Size(161, 32);
            this.tsProgressBar.TabIndex = 5;
            // 
            // dtpTarihSec
            // 
            this.dtpTarihSec.Location = new System.Drawing.Point(114, 2);
            this.dtpTarihSec.Name = "dtpTarihSec";
            this.dtpTarihSec.Size = new System.Drawing.Size(20, 30);
            this.dtpTarihSec.TabIndex = 6;
            this.dtpTarihSec.Visible = false;
            this.dtpTarihSec.CloseUp += new System.EventHandler(this.DtpTarihSec_CloseUp);
            // 
            // FrmEksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 671);
            this.Controls.Add(this.dtpTarihSec);
            this.Controls.Add(this.tsProgressBar);
            this.Controls.Add(this.panelUst);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Calibri", 9.969231F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(960, 720);
            this.Name = "FrmEksi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekşi Sözlük Debe";
            this.Load += new System.EventHandler(this.FrmEksi_Load);
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
        private System.Windows.Forms.ToolStripMenuItem tsmiDebeYukle;
        private System.Windows.Forms.ToolStripMenuItem tsmiBilgi;
        private System.Windows.Forms.ToolStripMenuItem tsmGuncelle;
        private System.Windows.Forms.ToolStripMenuItem tsmHakkinda;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslDurum;
        private System.Windows.Forms.Panel panelUst;
        public System.Windows.Forms.ToolStripComboBox tscEntryListesi;
        public System.Windows.Forms.Button btnSonraki;
        public System.Windows.Forms.Button btnOnceki;
        private System.Windows.Forms.ProgressBar tsProgressBar;
        public System.Windows.Forms.Button btnGit;
        private System.Windows.Forms.StatusStrip ssButonlar;
        public System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ToolStripMenuItem tsmiTarihSec;
        private System.Windows.Forms.DateTimePicker dtpTarihSec;
    }
}


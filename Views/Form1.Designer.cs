namespace CanadaHousing
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.btnSettings = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.btnFolder = new System.Windows.Forms.RibbonButton();
            this.ribbonButton1 = new System.Windows.Forms.RibbonButton();
            this.btnDbInitialize = new System.Windows.Forms.RibbonButton();
            this.btnCloud = new System.Windows.Forms.RibbonButton();
            this.btnStartCrawling = new System.Windows.Forms.RibbonButton();
            this.btnUpdateIndex = new System.Windows.Forms.RibbonButton();
            this.ribbonButton3 = new System.Windows.Forms.RibbonButton();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbImage = null;
            this.ribbon1.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(1276, 146);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Panels.Add(this.ribbonPanel1);
            this.ribbonTab1.Panels.Add(this.ribbonPanel2);
            this.ribbonTab1.Panels.Add(this.ribbonPanel3);
            this.ribbonTab1.Text = "Home";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.btnSettings);
            this.ribbonPanel1.Items.Add(this.ribbonButton2);
            this.ribbonPanel1.Items.Add(this.btnFolder);
            this.ribbonPanel1.Items.Add(this.ribbonButton1);
            this.ribbonPanel1.Text = "Metadata";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.btnDbInitialize);
            this.ribbonPanel2.Items.Add(this.btnCloud);
            this.ribbonPanel2.Text = "Database";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.btnStartCrawling);
            this.ribbonPanel3.Items.Add(this.btnUpdateIndex);
            this.ribbonPanel3.Items.Add(this.ribbonButton3);
            this.ribbonPanel3.Text = "Crawling";
            // 
            // btnSettings
            // 
            this.btnSettings.Image = global::CanadaHousing.Properties.Resources.icons8_automatic_40;
            this.btnSettings.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnSettings.SmallImage")));
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = global::CanadaHousing.Properties.Resources.icons8_database_administrator_40;
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "Database";
            // 
            // btnFolder
            // 
            this.btnFolder.Image = global::CanadaHousing.Properties.Resources.icons8_folder_40;
            this.btnFolder.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnFolder.SmallImage")));
            this.btnFolder.Text = "Folder";
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // ribbonButton1
            // 
            this.ribbonButton1.Enabled = false;
            this.ribbonButton1.Image = global::CanadaHousing.Properties.Resources.icons8_edit_property_40;
            this.ribbonButton1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton1.SmallImage")));
            this.ribbonButton1.Text = "Log";
            // 
            // btnDbInitialize
            // 
            this.btnDbInitialize.Image = global::CanadaHousing.Properties.Resources.icons8_database_export_40;
            this.btnDbInitialize.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnDbInitialize.SmallImage")));
            this.btnDbInitialize.Text = "Initialize";
            // 
            // btnCloud
            // 
            this.btnCloud.Enabled = false;
            this.btnCloud.Image = global::CanadaHousing.Properties.Resources.icons8_cloud_40;
            this.btnCloud.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnCloud.SmallImage")));
            this.btnCloud.Text = "Cloud";
            // 
            // btnStartCrawling
            // 
            this.btnStartCrawling.Image = global::CanadaHousing.Properties.Resources.icons8_play_40;
            this.btnStartCrawling.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnStartCrawling.SmallImage")));
            this.btnStartCrawling.Text = "Run";
            this.btnStartCrawling.Click += new System.EventHandler(this.btnStartCrawling_Click);
            // 
            // btnUpdateIndex
            // 
            this.btnUpdateIndex.Image = global::CanadaHousing.Properties.Resources.icons8_index_40;
            this.btnUpdateIndex.SmallImage = ((System.Drawing.Image)(resources.GetObject("btnUpdateIndex.SmallImage")));
            this.btnUpdateIndex.Text = "Index";
            this.btnUpdateIndex.Click += new System.EventHandler(this.btnUpdateIndex_Click);
            // 
            // ribbonButton3
            // 
            this.ribbonButton3.Image = global::CanadaHousing.Properties.Resources.icons8_database_view_40;
            this.ribbonButton3.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton3.SmallImage")));
            this.ribbonButton3.Text = "DbSync";
            this.ribbonButton3.Click += new System.EventHandler(this.ribbonButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 740);
            this.Controls.Add(this.ribbon1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canada Realstate Database Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton btnSettings;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonButton btnFolder;
        private System.Windows.Forms.RibbonButton ribbonButton1;
        private System.Windows.Forms.RibbonButton btnDbInitialize;
        private System.Windows.Forms.RibbonButton btnStartCrawling;
        private System.Windows.Forms.RibbonButton btnCloud;
        private System.Windows.Forms.RibbonButton btnUpdateIndex;
        private System.Windows.Forms.RibbonButton ribbonButton3;
    }
}


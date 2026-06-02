namespace Squelette_M3
{
    partial class UserControlHistorique
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitre = new System.Windows.Forms.Label();
            this.panelRecherche = new System.Windows.Forms.Panel();
            this.lblRecherche = new System.Windows.Forms.Label();
            this.txtRecherche = new System.Windows.Forms.TextBox();
            this.btnRechercher = new System.Windows.Forms.Button();
            this.btnRafraichir = new System.Windows.Forms.Button();
            this.btnExporter = new System.Windows.Forms.Button();
            this.dgvHistorique = new System.Windows.Forms.DataGridView();
            this.txtDetail = new System.Windows.Forms.TextBox();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.lblDetail = new System.Windows.Forms.Label();
            this.panelHeader = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblResultats = new System.Windows.Forms.Label();
            this.panelSeparator = new System.Windows.Forms.Panel();  // ✅ NOUVEAU
            this.panelSeparator2 = new System.Windows.Forms.Panel(); // ✅ NOUVEAU

            ((System.ComponentModel.ISupportInitialize)this.dgvHistorique).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picIcon).BeginInit();
            this.SuspendLayout();

            // ─── PANEL HEADER ─────────────────────────────────────────────
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.panelHeader.Controls.Add(this.picIcon);
            this.panelHeader.Controls.Add(this.lblTitre);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1000, 70);
            this.panelHeader.TabIndex = 0;

            // picIcon
            this.picIcon.Location = new System.Drawing.Point(15, 17);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(40, 40);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;

            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(63, 18);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(340, 37);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "📊 Historique des Lots";

            // ─── PANEL SEPARATOR 1 ────────────────────────────────────────
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Height = 3;
            this.panelSeparator.Location = new System.Drawing.Point(0, 70);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.Size = new System.Drawing.Size(1000, 3);

            // ─── PANEL RECHERCHE ──────────────────────────────────────────
            this.panelRecherche.BackColor = System.Drawing.Color.FromArgb(240, 245, 250);
            this.panelRecherche.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRecherche.Location = new System.Drawing.Point(0, 73);
            this.panelRecherche.Name = "panelRecherche";
            this.panelRecherche.Padding = new System.Windows.Forms.Padding(15, 12, 15, 12);
            this.panelRecherche.Size = new System.Drawing.Size(1000, 90);
            this.panelRecherche.TabIndex = 1;

            // lblRecherche
            this.lblRecherche.AutoSize = true;
            this.lblRecherche.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblRecherche.ForeColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.lblRecherche.Location = new System.Drawing.Point(15, 15);
            this.lblRecherche.Name = "lblRecherche";
            this.lblRecherche.Size = new System.Drawing.Size(85, 17);
            this.lblRecherche.TabIndex = 0;
            this.lblRecherche.Text = "🔍 Rechercher";

            // txtRecherche
            this.txtRecherche.BackColor = System.Drawing.Color.White;
            this.txtRecherche.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecherche.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtRecherche.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.txtRecherche.Location = new System.Drawing.Point(15, 35);
            this.txtRecherche.Name = "txtRecherche";
            this.txtRecherche.PlaceholderText = "Nom du lot, recette, ID, état...";
            this.txtRecherche.Size = new System.Drawing.Size(380, 28);
            this.txtRecherche.TabIndex = 1;

            // btnRechercher
            this.btnRechercher.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnRechercher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRechercher.FlatAppearance.BorderSize = 0;
            this.btnRechercher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRechercher.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRechercher.ForeColor = System.Drawing.Color.White;
            this.btnRechercher.Location = new System.Drawing.Point(405, 35);
            this.btnRechercher.Name = "btnRechercher";
            this.btnRechercher.Size = new System.Drawing.Size(125, 35);
            this.btnRechercher.TabIndex = 2;
            this.btnRechercher.Text = "🔎 Chercher";
            this.btnRechercher.UseVisualStyleBackColor = false;
            this.btnRechercher.Click += new System.EventHandler(this.BtnRechercher_Click);

            // btnRafraichir
            this.btnRafraichir.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnRafraichir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRafraichir.FlatAppearance.BorderSize = 0;
            this.btnRafraichir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnRafraichir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRafraichir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRafraichir.ForeColor = System.Drawing.Color.White;
            this.btnRafraichir.Location = new System.Drawing.Point(540, 35);
            this.btnRafraichir.Name = "btnRafraichir";
            this.btnRafraichir.Size = new System.Drawing.Size(125, 35);
            this.btnRafraichir.TabIndex = 3;
            this.btnRafraichir.Text = "🔄 Rafraîchir";
            this.btnRafraichir.UseVisualStyleBackColor = false;
            this.btnRafraichir.Click += new System.EventHandler(this.BtnRafraichir_Click);

            // btnExporter
            this.btnExporter.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnExporter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExporter.FlatAppearance.BorderSize = 0;
            this.btnExporter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(211, 84, 0);
            this.btnExporter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExporter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnExporter.ForeColor = System.Drawing.Color.White;
            this.btnExporter.Location = new System.Drawing.Point(675, 35);
            this.btnExporter.Name = "btnExporter";
            this.btnExporter.Size = new System.Drawing.Size(125, 35);
            this.btnExporter.TabIndex = 4;
            this.btnExporter.Text = "📥 Exporter";
            this.btnExporter.UseVisualStyleBackColor = false;
            this.btnExporter.Click += new System.EventHandler(this.BtnExporter_Click);

            // lblResultats
            this.lblResultats.AutoSize = true;
            this.lblResultats.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblResultats.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblResultats.Location = new System.Drawing.Point(15, 70);
            this.lblResultats.Name = "lblResultats";
            this.lblResultats.Size = new System.Drawing.Size(220, 15);
            this.lblResultats.TabIndex = 5;
            this.lblResultats.Text = "⏳ Chargement en cours...";

            // ─── DATAGRIDVIEW ─────────────────────────────────────────────
            this.dgvHistorique.AllowUserToAddRows = false;
            this.dgvHistorique.AllowUserToDeleteRows = false;
            this.dgvHistorique.AllowUserToResizeRows = false;
            this.dgvHistorique.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvHistorique.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistorique.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistorique.ColumnHeadersHeight = 38;
            this.dgvHistorique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistorique.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvHistorique.Location = new System.Drawing.Point(0, 163);
            this.dgvHistorique.Name = "dgvHistorique";
            this.dgvHistorique.ReadOnly = true;
            this.dgvHistorique.RowHeadersVisible = false;
            this.dgvHistorique.RowTemplate.Height = 30;
            this.dgvHistorique.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorique.Size = new System.Drawing.Size(1000, 290);
            this.dgvHistorique.TabIndex = 2;
            this.dgvHistorique.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvHistorique_CellDoubleClick);

            // Style en-têtes
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvHistorique.ColumnHeadersDefaultCellStyle = headerStyle;

            // Style alternance de lignes
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            altStyle.BackColor = System.Drawing.Color.FromArgb(245, 248, 250);
            altStyle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvHistorique.AlternatingRowsDefaultCellStyle = altStyle;

            // ─── PANEL SEPARATOR 2 ────────────────────────────────────────
            this.panelSeparator2.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.panelSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator2.Height = 1;
            this.panelSeparator2.Location = new System.Drawing.Point(0, 453);
            this.panelSeparator2.Name = "panelSeparator2";
            this.panelSeparator2.Size = new System.Drawing.Size(1000, 1);

            // ─── PANEL DETAIL ─────────────────────────────────────────────
            this.panelDetail.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            this.panelDetail.Controls.Add(this.txtDetail);
            this.panelDetail.Controls.Add(this.lblDetail);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetail.Location = new System.Drawing.Point(0, 454);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Padding = new System.Windows.Forms.Padding(15, 10, 15, 15);
            this.panelDetail.Size = new System.Drawing.Size(1000, 216);
            this.panelDetail.TabIndex = 3;

            // lblDetail
            this.lblDetail.AutoSize = true;
            this.lblDetail.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblDetail.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblDetail.Location = new System.Drawing.Point(15, 10);
            this.lblDetail.Name = "lblDetail";
            this.lblDetail.Size = new System.Drawing.Size(160, 20);
            this.lblDetail.TabIndex = 1;
            this.lblDetail.Text = "📋 Détail du Lot";

            // txtDetail
            this.txtDetail.BackColor = System.Drawing.Color.FromArgb(20, 20, 25);
            this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDetail.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(0, 255, 136);
            this.txtDetail.Location = new System.Drawing.Point(15, 35);
            this.txtDetail.Multiline = true;
            this.txtDetail.Name = "txtDetail";
            this.txtDetail.ReadOnly = true;
            this.txtDetail.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDetail.Size = new System.Drawing.Size(970, 166);
            this.txtDetail.TabIndex = 0;
            this.txtDetail.WordWrap = false;

            // ─── USER CONTROL ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.panelSeparator2);
            this.Controls.Add(this.dgvHistorique);
            this.Controls.Add(this.panelRecherche);
            this.Controls.Add(this.panelSeparator);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "UserControlHistorique";
            this.Size = new System.Drawing.Size(1000, 670);

            ((System.ComponentModel.ISupportInitialize)this.dgvHistorique).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picIcon).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel panelRecherche;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panelSeparator2;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnRechercher;
        private System.Windows.Forms.Button btnRafraichir;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.DataGridView dgvHistorique;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblResultats;
    }
}

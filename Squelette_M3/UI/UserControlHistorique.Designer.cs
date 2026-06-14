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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            picIcon = new PictureBox();
            lblTitre = new Label();
            panelSeparator = new Panel();
            panelRecherche = new Panel();
            lblRecherche = new Label();
            txtRecherche = new TextBox();
            btnRafraichir = new Button();
            btnExporter = new Button();
            lblResultats = new Label();
            dgvHistorique = new DataGridView();
            panelSeparator2 = new Panel();
            panelDetail = new Panel();
            txtDetail = new TextBox();
            lblDetail = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            panelRecherche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorique).BeginInit();
            panelDetail.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(41, 128, 185);
            panelHeader.Controls.Add(picIcon);
            panelHeader.Controls.Add(lblTitre);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1000, 70);
            panelHeader.TabIndex = 0;
            // 
            // picIcon
            // 
            picIcon.Location = new Point(15, 17);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(36, 36);
            picIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            picIcon.TabIndex = 1;
            picIcon.TabStop = false;
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(60, 18);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(310, 37);
            lblTitre.TabIndex = 2;
            lblTitre.Text = "📊 Historique des Lots";
            // 
            // panelSeparator
            // 
            panelSeparator.BackColor = Color.FromArgb(41, 128, 185);
            panelSeparator.Dock = DockStyle.Top;
            panelSeparator.Location = new Point(0, 70);
            panelSeparator.Name = "panelSeparator";
            panelSeparator.Size = new Size(1000, 3);
            panelSeparator.TabIndex = 1;
            // 
            // panelRecherche
            // 
            panelRecherche.BackColor = Color.White;
            panelRecherche.BorderStyle = BorderStyle.FixedSingle;
            panelRecherche.Controls.Add(lblRecherche);
            panelRecherche.Controls.Add(txtRecherche);
            panelRecherche.Controls.Add(btnRafraichir);
            panelRecherche.Controls.Add(btnExporter);
            panelRecherche.Controls.Add(lblResultats);
            panelRecherche.Dock = DockStyle.Top;
            panelRecherche.Location = new Point(0, 73);
            panelRecherche.Name = "panelRecherche";
            panelRecherche.Padding = new Padding(20);
            panelRecherche.Size = new Size(1000, 70);
            panelRecherche.TabIndex = 2;
            // 
            // lblRecherche
            // 
            lblRecherche.AutoSize = true;
            lblRecherche.Font = new Font("Segoe UI", 9F);
            lblRecherche.ForeColor = Color.FromArgb(52, 73, 94);
            lblRecherche.Location = new Point(14, 20);
            lblRecherche.Name = "lblRecherche";
            lblRecherche.Size = new Size(72, 15);
            lblRecherche.TabIndex = 1;
            lblRecherche.Text = "Rechercher :";
            // 
            // txtRecherche
            // 
            txtRecherche.BorderStyle = BorderStyle.FixedSingle;
            txtRecherche.Font = new Font("Segoe UI", 9F);
            txtRecherche.Location = new Point(94, 18);
            txtRecherche.Name = "txtRecherche";
            txtRecherche.PlaceholderText = "Nom du lot, recette, ID, état...";
            txtRecherche.Size = new Size(240, 23);
            txtRecherche.TabIndex = 2;
            // 
            // btnRafraichir
            // 
            btnRafraichir.BackColor = Color.FromArgb(46, 204, 113);
            btnRafraichir.Cursor = Cursors.Hand;
            btnRafraichir.FlatAppearance.BorderSize = 0;
            btnRafraichir.FlatAppearance.MouseDownBackColor = Color.FromArgb(70, 170, 119);
            btnRafraichir.FlatAppearance.MouseOverBackColor = Color.FromArgb(88, 214, 141);
            btnRafraichir.FlatStyle = FlatStyle.Flat;
            btnRafraichir.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRafraichir.ForeColor = Color.White;
            btnRafraichir.Location = new Point(351, 14);
            btnRafraichir.Name = "btnRafraichir";
            btnRafraichir.Size = new Size(144, 31);
            btnRafraichir.TabIndex = 4;
            btnRafraichir.Text = "🔄 Rafraîchir";
            btnRafraichir.UseVisualStyleBackColor = false;
            btnRafraichir.Click += BtnRafraichir_Click;
            // 
            // btnExporter
            // 
            btnExporter.BackColor = Color.FromArgb(230, 126, 34);
            btnExporter.Cursor = Cursors.Hand;
            btnExporter.FlatAppearance.BorderSize = 0;
            btnExporter.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 136, 80);
            btnExporter.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 176, 65);
            btnExporter.FlatStyle = FlatStyle.Flat;
            btnExporter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExporter.ForeColor = Color.White;
            btnExporter.Location = new Point(513, 14);
            btnExporter.Name = "btnExporter";
            btnExporter.Size = new Size(144, 31);
            btnExporter.TabIndex = 5;
            btnExporter.Text = "📥 Exporter";
            btnExporter.UseVisualStyleBackColor = false;
            btnExporter.Click += BtnExporter_Click;
            // 
            // lblResultats
            // 
            lblResultats.AutoSize = true;
            lblResultats.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblResultats.ForeColor = Color.FromArgb(127, 140, 141);
            lblResultats.Location = new Point(94, 48);
            lblResultats.Name = "lblResultats";
            lblResultats.Size = new Size(143, 15);
            lblResultats.TabIndex = 6;
            lblResultats.Text = "⏳ Chargement en cours...";
            // 
            // dgvHistorique
            // 
            dgvHistorique.AllowUserToAddRows = false;
            dgvHistorique.AllowUserToDeleteRows = false;
            dgvHistorique.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 246, 247);
            dgvHistorique.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistorique.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvHistorique.BackgroundColor = Color.FromArgb(236, 240, 241);
            dgvHistorique.BorderStyle = BorderStyle.None;
            dgvHistorique.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvHistorique.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistorique.ColumnHeadersHeight = 38;
            dgvHistorique.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHistorique.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHistorique.Dock = DockStyle.Top;
            dgvHistorique.Location = new Point(0, 143);
            dgvHistorique.Name = "dgvHistorique";
            dgvHistorique.ReadOnly = true;
            dgvHistorique.RowHeadersVisible = false;
            dgvHistorique.RowTemplate.Height = 30;
            dgvHistorique.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorique.Size = new Size(1000, 220);
            dgvHistorique.TabIndex = 3;
            dgvHistorique.CellDoubleClick += DgvHistorique_CellDoubleClick;
            // 
            // panelSeparator2
            // 
            panelSeparator2.BackColor = Color.FromArgb(189, 195, 199);
            panelSeparator2.Dock = DockStyle.Top;
            panelSeparator2.Location = new Point(0, 363);
            panelSeparator2.Name = "panelSeparator2";
            panelSeparator2.Size = new Size(1000, 1);
            panelSeparator2.TabIndex = 4;
            // 
            // panelDetail
            // 
            panelDetail.BackColor = Color.FromArgb(250, 250, 250);
            panelDetail.Controls.Add(txtDetail);
            panelDetail.Controls.Add(lblDetail);
            panelDetail.Dock = DockStyle.Fill;
            panelDetail.Location = new Point(0, 364);
            panelDetail.Name = "panelDetail";
            panelDetail.Padding = new Padding(15, 10, 15, 15);
            panelDetail.Size = new Size(1000, 306);
            panelDetail.TabIndex = 5;
            // 
            // txtDetail
            // 
            txtDetail.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDetail.BackColor = Color.FromArgb(20, 20, 25);
            txtDetail.BorderStyle = BorderStyle.FixedSingle;
            txtDetail.Font = new Font("Consolas", 9F);
            txtDetail.ForeColor = Color.FromArgb(0, 255, 136);
            txtDetail.Location = new Point(15, 38);
            txtDetail.Multiline = true;
            txtDetail.Name = "txtDetail";
            txtDetail.ReadOnly = true;
            txtDetail.ScrollBars = ScrollBars.Both;
            txtDetail.Size = new Size(970, 253);
            txtDetail.TabIndex = 1;
            txtDetail.WordWrap = false;
            // 
            // lblDetail
            // 
            lblDetail.AutoSize = true;
            lblDetail.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblDetail.ForeColor = Color.FromArgb(41, 128, 185);
            lblDetail.Location = new Point(15, 10);
            lblDetail.Name = "lblDetail";
            lblDetail.Size = new Size(125, 20);
            lblDetail.TabIndex = 0;
            lblDetail.Text = "📋 Détail du Lot";
            // 
            // UserControlHistorique
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(panelDetail);
            Controls.Add(panelSeparator2);
            Controls.Add(dgvHistorique);
            Controls.Add(panelRecherche);
            Controls.Add(panelSeparator);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "UserControlHistorique";
            Size = new Size(1000, 670);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            panelRecherche.ResumeLayout(false);
            panelRecherche.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorique).EndInit();
            panelDetail.ResumeLayout(false);
            panelDetail.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel panelRecherche;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panelSeparator2;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblRecherche;
        private System.Windows.Forms.TextBox txtRecherche;
        private System.Windows.Forms.Button btnRafraichir;
        private System.Windows.Forms.Button btnExporter;
        private System.Windows.Forms.DataGridView dgvHistorique;
        private System.Windows.Forms.TextBox txtDetail;
        private System.Windows.Forms.Panel panelDetail;
        private System.Windows.Forms.Label lblDetail;
        private System.Windows.Forms.Label lblResultats;
    }
}

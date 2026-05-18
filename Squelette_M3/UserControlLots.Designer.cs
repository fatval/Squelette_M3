namespace Squelette_M3
{
    partial class UserControlLots
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
            this.panelHeader = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblTitre = new System.Windows.Forms.Label();
            this.panelSeparator = new System.Windows.Forms.Panel();

            this.panelCreation = new System.Windows.Forms.Panel();
            this.lblCreation = new System.Windows.Forms.Label();
            this.lblNomLot = new System.Windows.Forms.Label();
            this.txtNomLot = new System.Windows.Forms.TextBox();
            this.lblRecette = new System.Windows.Forms.Label();
            this.cmbRecettes = new System.Windows.Forms.ComboBox();
            this.lblQuantite = new System.Windows.Forms.Label();
            this.nudQuantite = new System.Windows.Forms.NumericUpDown();
            this.btnCreerLot = new System.Windows.Forms.Button();
            this.panelSeparator2 = new System.Windows.Forms.Panel();

            this.dgvLots = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRecette = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEtat = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblResultats = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)this.picIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudQuantite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvLots).BeginInit();
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
            this.picIcon.Size = new System.Drawing.Size(36, 36);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;

            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(60, 18);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(230, 37);
            this.lblTitre.TabIndex = 2;
            this.lblTitre.Text = "📦 Gestion des Lots";

            // ─── PANEL SEPARATOR 1 ────────────────────────────────────────
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Height = 3;
            this.panelSeparator.Location = new System.Drawing.Point(0, 70);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.TabIndex = 1;

            // ─── PANEL CREATION ────────────────────────────────────────────
            this.panelCreation.BackColor = System.Drawing.Color.White;
            this.panelCreation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCreation.Controls.Add(this.lblCreation);
            this.panelCreation.Controls.Add(this.lblNomLot);
            this.panelCreation.Controls.Add(this.txtNomLot);
            this.panelCreation.Controls.Add(this.lblRecette);
            this.panelCreation.Controls.Add(this.cmbRecettes);
            this.panelCreation.Controls.Add(this.lblQuantite);
            this.panelCreation.Controls.Add(this.nudQuantite);
            this.panelCreation.Controls.Add(this.btnCreerLot);
            this.panelCreation.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCreation.Location = new System.Drawing.Point(0, 73);
            this.panelCreation.Name = "panelCreation";
            this.panelCreation.Padding = new System.Windows.Forms.Padding(20);
            this.panelCreation.Size = new System.Drawing.Size(1000, 150);
            this.panelCreation.TabIndex = 2;

            // lblCreation
            this.lblCreation.AutoSize = true;
            this.lblCreation.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCreation.ForeColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.lblCreation.Location = new System.Drawing.Point(20, 8);
            this.lblCreation.Name = "lblCreation";
            this.lblCreation.Size = new System.Drawing.Size(170, 20);
            this.lblCreation.TabIndex = 0;
            this.lblCreation.Text = "➕ Créer un nouveau lot";

            // lblNomLot
            this.lblNomLot.AutoSize = true;
            this.lblNomLot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNomLot.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblNomLot.Location = new System.Drawing.Point(20, 40);
            this.lblNomLot.Name = "lblNomLot";
            this.lblNomLot.Size = new System.Drawing.Size(75, 15);
            this.lblNomLot.TabIndex = 1;
            this.lblNomLot.Text = "Nom du lot :";

            // txtNomLot
            this.txtNomLot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomLot.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNomLot.Location = new System.Drawing.Point(120, 37);
            this.txtNomLot.Name = "txtNomLot";
            this.txtNomLot.Size = new System.Drawing.Size(200, 23);
            this.txtNomLot.TabIndex = 2;

            // lblRecette
            this.lblRecette.AutoSize = true;
            this.lblRecette.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRecette.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblRecette.Location = new System.Drawing.Point(340, 40);
            this.lblRecette.Name = "lblRecette";
            this.lblRecette.Size = new System.Drawing.Size(60, 15);
            this.lblRecette.TabIndex = 3;
            this.lblRecette.Text = "Recette :";

            // cmbRecettes
            this.cmbRecettes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecettes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbRecettes.FormattingEnabled = true;
            this.cmbRecettes.Location = new System.Drawing.Point(420, 37);
            this.cmbRecettes.Name = "cmbRecettes";
            this.cmbRecettes.Size = new System.Drawing.Size(200, 23);
            this.cmbRecettes.TabIndex = 4;

            // lblQuantite
            this.lblQuantite.AutoSize = true;
            this.lblQuantite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuantite.ForeColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.lblQuantite.Location = new System.Drawing.Point(640, 40);
            this.lblQuantite.Name = "lblQuantite";
            this.lblQuantite.Size = new System.Drawing.Size(68, 15);
            this.lblQuantite.TabIndex = 5;
            this.lblQuantite.Text = "Quantité :";

            // nudQuantite
            this.nudQuantite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nudQuantite.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nudQuantite.Location = new System.Drawing.Point(720, 37);
            this.nudQuantite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudQuantite.Name = "nudQuantite";
            this.nudQuantite.Size = new System.Drawing.Size(100, 23);
            this.nudQuantite.TabIndex = 6;
            this.nudQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });

            // btnCreerLot
            this.btnCreerLot.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnCreerLot.FlatAppearance.BorderSize = 0;
            this.btnCreerLot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreerLot.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnCreerLot.ForeColor = System.Drawing.Color.White;
            this.btnCreerLot.Location = new System.Drawing.Point(850, 37);
            this.btnCreerLot.Name = "btnCreerLot";
            this.btnCreerLot.Size = new System.Drawing.Size(120, 35);
            this.btnCreerLot.TabIndex = 7;
            this.btnCreerLot.Text = "✓ Créer";
            this.btnCreerLot.UseVisualStyleBackColor = false;
            this.btnCreerLot.Click += new System.EventHandler(this.btnCreerLot_Click);

            // Effet Hover
            this.btnCreerLot.MouseEnter += (s, e) => this.btnCreerLot.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnCreerLot.MouseLeave += (s, e) => this.btnCreerLot.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);

            // ─── PANEL SEPARATOR 2 ────────────────────────────────────────
            this.panelSeparator2.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.panelSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator2.Height = 1;
            this.panelSeparator2.Location = new System.Drawing.Point(0, 223);
            this.panelSeparator2.Name = "panelSeparator2";
            this.panelSeparator2.TabIndex = 3;

            // ─── DATAGRIDVIEW LOTS ────────────────────────────────────────
            this.dgvLots.AllowUserToAddRows = false;
            this.dgvLots.AllowUserToDeleteRows = false;
            this.dgvLots.BackgroundColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.dgvLots.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvLots.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLots.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colId,
                this.colNom,
                this.colQuantite,
                this.colRecette,
                this.colDate,
                this.colEtat
            });
            this.dgvLots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLots.Location = new System.Drawing.Point(0, 224);
            this.dgvLots.Name = "dgvLots";
            this.dgvLots.ReadOnly = true;
            this.dgvLots.RowHeadersVisible = false;
            this.dgvLots.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLots.Size = new System.Drawing.Size(1000, 446);
            this.dgvLots.TabIndex = 4;

            // Style en-têtes
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvLots.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvLots.ColumnHeadersHeight = 35;

            // Style alternance
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            altStyle.BackColor = System.Drawing.Color.FromArgb(245, 246, 247);
            this.dgvLots.AlternatingRowsDefaultCellStyle = altStyle;

            // Style sélection
            System.Windows.Forms.DataGridViewCellStyle selectStyle = new System.Windows.Forms.DataGridViewCellStyle();
            selectStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            selectStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLots.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle()
            {
                Padding = new System.Windows.Forms.Padding(5)
            };

            // Colonnes
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Width = 50;

            this.colNom.DataPropertyName = "Nom";
            this.colNom.HeaderText = "Nom du Lot";
            this.colNom.Name = "colNom";
            this.colNom.Width = 130;

            this.colQuantite.DataPropertyName = "Quantite";
            this.colQuantite.HeaderText = "Quantité";
            this.colQuantite.Name = "colQuantite";
            this.colQuantite.Width = 80;

            this.colRecette.DataPropertyName = "Recette";
            this.colRecette.HeaderText = "Recette";
            this.colRecette.Name = "colRecette";
            this.colRecette.Width = 120;

            this.colDate.DataPropertyName = "Date";
            this.colDate.HeaderText = "Date de Création";
            this.colDate.Name = "colDate";
            this.colDate.Width = 140;

            this.colEtat.DataPropertyName = "Etat";
            this.colEtat.HeaderText = "État";
            this.colEtat.Name = "colEtat";
            this.colEtat.Width = 100;

            // lblResultats
            this.lblResultats.AutoSize = true;
            this.lblResultats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResultats.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblResultats.Location = new System.Drawing.Point(15, 230);
            this.lblResultats.Name = "lblResultats";
            this.lblResultats.Size = new System.Drawing.Size(0, 15);
            this.lblResultats.TabIndex = 5;

            // ─── USER CONTROL ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.Controls.Add(this.lblResultats);
            this.Controls.Add(this.dgvLots);
            this.Controls.Add(this.panelSeparator2);
            this.Controls.Add(this.panelCreation);
            this.Controls.Add(this.panelSeparator);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "UserControlLots";
            this.Size = new System.Drawing.Size(1000, 670);

            ((System.ComponentModel.ISupportInitialize)this.picIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudQuantite).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvLots).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panelCreation;
        private System.Windows.Forms.Label lblCreation;
        private System.Windows.Forms.Label lblNomLot;
        private System.Windows.Forms.TextBox txtNomLot;
        private System.Windows.Forms.Label lblRecette;
        private System.Windows.Forms.ComboBox cmbRecettes;
        private System.Windows.Forms.Label lblQuantite;
        private System.Windows.Forms.NumericUpDown nudQuantite;
        private System.Windows.Forms.Button btnCreerLot;
        private System.Windows.Forms.Panel panelSeparator2;
        private System.Windows.Forms.DataGridView dgvLots;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantite;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecette;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEtat;
        private System.Windows.Forms.Label lblResultats;
    }
}

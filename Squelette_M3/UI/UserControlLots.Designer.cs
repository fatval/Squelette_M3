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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            picIcon = new PictureBox();
            lblTitre = new Label();
            panelSeparator = new Panel();
            panelCreation = new Panel();
            lblNomLot = new Label();
            txtNomLot = new TextBox();
            lblRecette = new Label();
            cmbRecettes = new ComboBox();
            lblQuantite = new Label();
            nudQuantite = new NumericUpDown();
            btnCreerLot = new Button();
            panelSeparator2 = new Panel();
            dgvLots = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            colQuantite = new DataGridViewTextBoxColumn();
            colRecette = new DataGridViewTextBoxColumn();
            colDate = new DataGridViewTextBoxColumn();
            colEtat = new DataGridViewTextBoxColumn();
            lblResultats = new Label();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            panelCreation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLots).BeginInit();
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
            lblTitre.Size = new Size(272, 37);
            lblTitre.TabIndex = 2;
            lblTitre.Text = "📦 Gestion des Lots";
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
            // panelCreation
            // 
            panelCreation.BackColor = Color.White;
            panelCreation.BorderStyle = BorderStyle.FixedSingle;
            panelCreation.Controls.Add(lblNomLot);
            panelCreation.Controls.Add(txtNomLot);
            panelCreation.Controls.Add(lblRecette);
            panelCreation.Controls.Add(cmbRecettes);
            panelCreation.Controls.Add(lblQuantite);
            panelCreation.Controls.Add(nudQuantite);
            panelCreation.Controls.Add(btnCreerLot);
            panelCreation.Dock = DockStyle.Top;
            panelCreation.Location = new Point(0, 73);
            panelCreation.Name = "panelCreation";
            panelCreation.Padding = new Padding(20);
            panelCreation.Size = new Size(1000, 150);
            panelCreation.TabIndex = 2;
            // 
            // lblNomLot
            // 
            lblNomLot.AutoSize = true;
            lblNomLot.Font = new Font("Segoe UI", 9F);
            lblNomLot.ForeColor = Color.FromArgb(52, 73, 94);
            lblNomLot.Location = new Point(14, 42);
            lblNomLot.Name = "lblNomLot";
            lblNomLot.Size = new Size(74, 15);
            lblNomLot.TabIndex = 1;
            lblNomLot.Text = "Nom du lot :";
            // 
            // txtNomLot
            // 
            txtNomLot.BorderStyle = BorderStyle.FixedSingle;
            txtNomLot.Font = new Font("Segoe UI", 9F);
            txtNomLot.Location = new Point(94, 37);
            txtNomLot.Name = "txtNomLot";
            txtNomLot.Size = new Size(200, 23);
            txtNomLot.TabIndex = 2;
            // 
            // lblRecette
            // 
            lblRecette.AutoSize = true;
            lblRecette.Font = new Font("Segoe UI", 9F);
            lblRecette.ForeColor = Color.FromArgb(52, 73, 94);
            lblRecette.Location = new Point(324, 42);
            lblRecette.Name = "lblRecette";
            lblRecette.Size = new Size(52, 15);
            lblRecette.TabIndex = 3;
            lblRecette.Text = "Recette :";
            // 
            // cmbRecettes
            // 
            cmbRecettes.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRecettes.Font = new Font("Segoe UI", 9F);
            cmbRecettes.FormattingEnabled = true;
            cmbRecettes.Location = new Point(384, 37);
            cmbRecettes.Name = "cmbRecettes";
            cmbRecettes.Size = new Size(200, 23);
            cmbRecettes.TabIndex = 4;
            // 
            // lblQuantite
            // 
            lblQuantite.AutoSize = true;
            lblQuantite.Font = new Font("Segoe UI", 9F);
            lblQuantite.ForeColor = Color.FromArgb(52, 73, 94);
            lblQuantite.Location = new Point(613, 41);
            lblQuantite.Name = "lblQuantite";
            lblQuantite.Size = new Size(59, 15);
            lblQuantite.TabIndex = 5;
            lblQuantite.Text = "Quantité :";
            // 
            // nudQuantite
            // 
            nudQuantite.BorderStyle = BorderStyle.FixedSingle;
            nudQuantite.Font = new Font("Segoe UI", 9F);
            nudQuantite.Location = new Point(673, 37);
            nudQuantite.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantite.Name = "nudQuantite";
            nudQuantite.Size = new Size(100, 23);
            nudQuantite.TabIndex = 6;
            nudQuantite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
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
            // 
            lblResultats.AutoSize = true;
            lblResultats.Font = new Font("Segoe UI", 9F);
            lblResultats.ForeColor = Color.FromArgb(127, 140, 141);
            lblResultats.Location = new Point(15, 230);
            lblResultats.Name = "lblResultats";
            lblResultats.Size = new Size(0, 15);
            lblResultats.TabIndex = 5;
            // 
            // UserControlLots
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(lblResultats);
            Controls.Add(dgvLots);
            Controls.Add(panelSeparator2);
            Controls.Add(panelCreation);
            Controls.Add(panelSeparator);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "UserControlLots";
            Size = new Size(1000, 670);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            panelCreation.ResumeLayout(false);
            panelCreation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantite).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLots).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panelCreation;
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

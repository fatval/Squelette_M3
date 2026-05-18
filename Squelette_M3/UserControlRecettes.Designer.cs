namespace Squelette_M3
{
    partial class UserControlRecettes
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

            this.panelBoutons = new System.Windows.Forms.Panel();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.panelSeparator2 = new System.Windows.Forms.Panel();

            this.dgvRecettes = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNbOp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateCreation = new System.Windows.Forms.DataGridViewTextBoxColumn();

            this.lblResultats = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)this.picIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecettes).BeginInit();
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
            this.picIcon.Location = new System.Drawing.Point(15, 17);  // ✅ CHANGÉ : 5 → 15
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(36, 36);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;

            // lblTitre
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Location = new System.Drawing.Point(15, 18);  // ✅ CHANGÉ : 50 → 15
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(280, 37);
            this.lblTitre.TabIndex = 2;
            this.lblTitre.Text = "📋 Gestion des Recettes";



            // ─── PANEL SEPARATOR 1 ────────────────────────────────────────
            this.panelSeparator.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.panelSeparator.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator.Height = 3;
            this.panelSeparator.Location = new System.Drawing.Point(0, 70);
            this.panelSeparator.Name = "panelSeparator";
            this.panelSeparator.TabIndex = 1;

            // ─── PANEL BOUTONS ────────────────────────────────────────────
            this.panelBoutons.BackColor = System.Drawing.Color.White;
            this.panelBoutons.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBoutons.Controls.Add(this.btnAjouter);
            this.panelBoutons.Controls.Add(this.btnModifier);
            this.panelBoutons.Controls.Add(this.btnSupprimer);
            this.panelBoutons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBoutons.Location = new System.Drawing.Point(0, 73);
            this.panelBoutons.Name = "panelBoutons";
            this.panelBoutons.Padding = new System.Windows.Forms.Padding(20, 12, 20, 12);
            this.panelBoutons.Size = new System.Drawing.Size(1000, 55);
            this.panelBoutons.TabIndex = 2;

            // btnAjouter
            this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnAjouter.FlatAppearance.BorderSize = 0;
            this.btnAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAjouter.ForeColor = System.Drawing.Color.White;
            this.btnAjouter.Location = new System.Drawing.Point(20, 12);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(130, 32);
            this.btnAjouter.TabIndex = 0;
            this.btnAjouter.Text = "➕ Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = false;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            this.btnAjouter.MouseEnter += (s, e) => this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(30, 100, 150);
            this.btnAjouter.MouseLeave += (s, e) => this.btnAjouter.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);

            // btnModifier
            this.btnModifier.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnModifier.FlatAppearance.BorderSize = 0;
            this.btnModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModifier.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnModifier.ForeColor = System.Drawing.Color.White;
            this.btnModifier.Location = new System.Drawing.Point(165, 12);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(130, 32);
            this.btnModifier.TabIndex = 1;
            this.btnModifier.Text = "✏️ Modifier";
            this.btnModifier.UseVisualStyleBackColor = false;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            this.btnModifier.MouseEnter += (s, e) => this.btnModifier.BackColor = System.Drawing.Color.FromArgb(210, 100, 10);
            this.btnModifier.MouseLeave += (s, e) => this.btnModifier.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);

            // btnSupprimer
            this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSupprimer.ForeColor = System.Drawing.Color.White;
            this.btnSupprimer.Location = new System.Drawing.Point(310, 12);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(130, 32);
            this.btnSupprimer.TabIndex = 2;
            this.btnSupprimer.Text = "🗑️ Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = false;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            this.btnSupprimer.MouseEnter += (s, e) => this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(210, 50, 30);
            this.btnSupprimer.MouseLeave += (s, e) => this.btnSupprimer.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);

            // ─── PANEL SEPARATOR 2 ────────────────────────────────────────
            this.panelSeparator2.BackColor = System.Drawing.Color.FromArgb(189, 195, 199);
            this.panelSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSeparator2.Height = 1;
            this.panelSeparator2.Location = new System.Drawing.Point(0, 128);
            this.panelSeparator2.Name = "panelSeparator2";
            this.panelSeparator2.TabIndex = 3;

            // ─── DATAGRIDVIEW RECETTES ────────────────────────────────────
            this.dgvRecettes.AllowUserToAddRows = false;
            this.dgvRecettes.AllowUserToDeleteRows = false;
            this.dgvRecettes.BackgroundColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.dgvRecettes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRecettes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvRecettes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecettes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[]
            {
                this.colId,
                this.colNom,
                this.colNbOp,
                this.colDateCreation
            });
            this.dgvRecettes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRecettes.Location = new System.Drawing.Point(0, 129);
            this.dgvRecettes.Name = "dgvRecettes";
            this.dgvRecettes.ReadOnly = true;
            this.dgvRecettes.RowHeadersVisible = false;
            this.dgvRecettes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecettes.Size = new System.Drawing.Size(1000, 541);
            this.dgvRecettes.TabIndex = 4;

            // Style en-têtes
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            headerStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvRecettes.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvRecettes.ColumnHeadersHeight = 35;

            // Style alternance
            System.Windows.Forms.DataGridViewCellStyle altStyle = new System.Windows.Forms.DataGridViewCellStyle();
            altStyle.BackColor = System.Drawing.Color.FromArgb(245, 246, 247);
            this.dgvRecettes.AlternatingRowsDefaultCellStyle = altStyle;

            // Style sélection
            System.Windows.Forms.DataGridViewCellStyle selectStyle = new System.Windows.Forms.DataGridViewCellStyle();
            selectStyle.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            selectStyle.ForeColor = System.Drawing.Color.White;
            this.dgvRecettes.DefaultCellStyle = new System.Windows.Forms.DataGridViewCellStyle()
            {
                Padding = new System.Windows.Forms.Padding(5)
            };

            // Colonnes
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.Width = 50;

            this.colNom.DataPropertyName = "Nom";
            this.colNom.HeaderText = "Nom de la Recette";
            this.colNom.Name = "colNom";
            this.colNom.Width = 250;

            this.colNbOp.DataPropertyName = "NbOperations";
            this.colNbOp.HeaderText = "Nb Opérations";
            this.colNbOp.Name = "colNbOp";
            this.colNbOp.Width = 120;

            this.colDateCreation.DataPropertyName = "DateCreation";
            this.colDateCreation.HeaderText = "Date de Création";
            this.colDateCreation.Name = "colDateCreation";
            this.colDateCreation.Width = 150;

            // lblResultats
            this.lblResultats.AutoSize = true;
            this.lblResultats.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResultats.ForeColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.lblResultats.Location = new System.Drawing.Point(15, 135);
            this.lblResultats.Name = "lblResultats";
            this.lblResultats.Size = new System.Drawing.Size(0, 15);
            this.lblResultats.TabIndex = 5;

            // ─── USER CONTROL ─────────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.Controls.Add(this.lblResultats);
            this.Controls.Add(this.dgvRecettes);
            this.Controls.Add(this.panelSeparator2);
            this.Controls.Add(this.panelBoutons);
            this.Controls.Add(this.panelSeparator);
            this.Controls.Add(this.panelHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "UserControlRecettes";
            this.Size = new System.Drawing.Size(1000, 670);

            ((System.ComponentModel.ISupportInitialize)this.picIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.dgvRecettes).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panelBoutons;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Panel panelSeparator2;
        private System.Windows.Forms.DataGridView dgvRecettes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNom;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNbOp;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDateCreation;
        private System.Windows.Forms.Label lblResultats;
    }
}

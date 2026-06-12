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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panelHeader = new Panel();
            picIcon = new PictureBox();
            lblTitre = new Label();
            panelSeparator = new Panel();
            panelSeparator2 = new Panel();
            dgvRecettes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNom = new DataGridViewTextBoxColumn();
            colNbOp = new DataGridViewTextBoxColumn();
            colDateCreation = new DataGridViewTextBoxColumn();
            lblResultats = new Label();
            btnSupprimer = new Button();
            btnModifier = new Button();
            btnAjouter = new Button();
            panelBoutons = new Panel();
            panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecettes).BeginInit();
            panelBoutons.SuspendLayout();
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
            lblTitre.Size = new Size(327, 37);
            lblTitre.TabIndex = 2;
            lblTitre.Text = "📋 Gestion des Recettes";
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
            // panelSeparator2
            // 
            panelSeparator2.BackColor = Color.FromArgb(189, 195, 199);
            panelSeparator2.Dock = DockStyle.Top;
            panelSeparator2.Location = new Point(0, 128);
            panelSeparator2.Name = "panelSeparator2";
            panelSeparator2.Size = new Size(1000, 1);
            panelSeparator2.TabIndex = 3;
            // 
            // dgvRecettes
            // 
            dgvRecettes.AllowUserToAddRows = false;
            dgvRecettes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(245, 246, 247);
            dgvRecettes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvRecettes.BackgroundColor = Color.FromArgb(236, 240, 241);
            dgvRecettes.BorderStyle = BorderStyle.None;
            dgvRecettes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dgvRecettes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvRecettes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecettes.Columns.AddRange(new DataGridViewColumn[] { colId, colNom, colNbOp, colDateCreation });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvRecettes.DefaultCellStyle = dataGridViewCellStyle3;
            dgvRecettes.Dock = DockStyle.Fill;
            dgvRecettes.Location = new Point(0, 129);
            dgvRecettes.Name = "dgvRecettes";
            dgvRecettes.ReadOnly = true;
            dgvRecettes.RowHeadersVisible = false;
            dgvRecettes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecettes.Size = new Size(1000, 541);
            dgvRecettes.TabIndex = 4;
            // 
            // colId
            // 
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colId.DataPropertyName = "Id";
            colId.HeaderText = "ID";
            colId.Name = "colId";
            colId.ReadOnly = true;
            colId.Resizable = DataGridViewTriState.False;
            colId.Width = 48;
            // 
            // colNom
            // 
            colNom.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colNom.DataPropertyName = "Nom";
            colNom.HeaderText = "Nom de la Recette";
            colNom.Name = "colNom";
            colNom.ReadOnly = true;
            colNom.Resizable = DataGridViewTriState.False;
            colNom.Width = 158;
            // 
            // colNbOp
            // 
            colNbOp.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colNbOp.DataPropertyName = "NbOperations";
            colNbOp.HeaderText = "Nb Opérations";
            colNbOp.Name = "colNbOp";
            colNbOp.ReadOnly = true;
            colNbOp.Resizable = DataGridViewTriState.False;
            colNbOp.Width = 132;
            // 
            // colDateCreation
            // 
            colDateCreation.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colDateCreation.DataPropertyName = "DateCreation";
            colDateCreation.HeaderText = "Date de Création";
            colDateCreation.Name = "colDateCreation";
            colDateCreation.ReadOnly = true;
            colDateCreation.Resizable = DataGridViewTriState.False;
            colDateCreation.Width = 147;
            // 
            // lblResultats
            // 
            lblResultats.AutoSize = true;
            lblResultats.Font = new Font("Segoe UI", 9F);
            lblResultats.ForeColor = Color.FromArgb(127, 140, 141);
            lblResultats.Location = new Point(15, 135);
            lblResultats.Name = "lblResultats";
            lblResultats.Size = new Size(0, 15);
            lblResultats.TabIndex = 5;
            // 
            // btnSupprimer
            // 
            btnSupprimer.BackColor = Color.FromArgb(231, 76, 60);
            btnSupprimer.Cursor = Cursors.Hand;
            btnSupprimer.FlatAppearance.BorderSize = 0;
            btnSupprimer.FlatAppearance.MouseOverBackColor = Color.FromArgb(241, 148, 138);
            btnSupprimer.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 110, 100);
            btnSupprimer.FlatStyle = FlatStyle.Flat;
            btnSupprimer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSupprimer.ForeColor = Color.White;
            btnSupprimer.Location = new Point(310, 12);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(130, 32);
            btnSupprimer.TabIndex = 2;
            btnSupprimer.Text = "🗑️ Supprimer";
            btnSupprimer.UseVisualStyleBackColor = false;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnModifier
            // 
            btnModifier.BackColor = Color.FromArgb(230, 126, 34);
            btnModifier.Cursor = Cursors.Hand;
            btnModifier.FlatAppearance.BorderSize = 0;
            btnModifier.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 176, 65);
            btnModifier.FlatAppearance.MouseDownBackColor = Color.FromArgb(190, 136, 80);
            btnModifier.FlatStyle = FlatStyle.Flat;
            btnModifier.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModifier.ForeColor = Color.White;
            btnModifier.Location = new Point(165, 12);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(130, 32);
            btnModifier.TabIndex = 1;
            btnModifier.Text = "✏️ Modifier";
            btnModifier.UseVisualStyleBackColor = false;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.BackColor = Color.FromArgb(41, 128, 185);
            btnAjouter.Cursor = Cursors.Hand;
            btnAjouter.FlatAppearance.BorderSize = 0;
            btnAjouter.FlatAppearance.MouseOverBackColor = Color.FromArgb(93, 173, 226);
            btnAjouter.FlatAppearance.MouseDownBackColor = Color.FromArgb(74, 137, 180);
            btnAjouter.FlatStyle = FlatStyle.Flat;
            btnAjouter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAjouter.ForeColor = Color.White;
            btnAjouter.Location = new Point(20, 12);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(130, 32);
            btnAjouter.TabIndex = 0;
            btnAjouter.Text = "➕ Ajouter";
            btnAjouter.UseVisualStyleBackColor = false;
            btnAjouter.Click += btnAjouter_Click;
            // 
            // panelBoutons
            // 
            panelBoutons.BackColor = Color.White;
            panelBoutons.BorderStyle = BorderStyle.FixedSingle;
            panelBoutons.Controls.Add(btnAjouter);
            panelBoutons.Controls.Add(btnModifier);
            panelBoutons.Controls.Add(btnSupprimer);
            panelBoutons.Dock = DockStyle.Top;
            panelBoutons.Location = new Point(0, 73);
            panelBoutons.Name = "panelBoutons";
            panelBoutons.Padding = new Padding(20, 12, 20, 12);
            panelBoutons.Size = new Size(1000, 55);
            panelBoutons.TabIndex = 2;
            // 
            // UserControlRecettes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(236, 240, 241);
            Controls.Add(lblResultats);
            Controls.Add(dgvRecettes);
            Controls.Add(panelSeparator2);
            Controls.Add(panelBoutons);
            Controls.Add(panelSeparator);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            Name = "UserControlRecettes";
            Size = new Size(1000, 670);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRecettes).EndInit();
            panelBoutons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.PictureBox picIcon;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Panel panelSeparator;
        private System.Windows.Forms.Panel panelSeparator2;
        private System.Windows.Forms.DataGridView dgvRecettes;
        private System.Windows.Forms.Label lblResultats;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNom;
        private DataGridViewTextBoxColumn colNbOp;
        private DataGridViewTextBoxColumn colDateCreation;
        private Button btnSupprimer;
        private Button btnModifier;
        private Button btnAjouter;
        private Panel panelBoutons;
    }
}

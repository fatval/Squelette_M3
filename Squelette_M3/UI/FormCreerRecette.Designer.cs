using System;
using System.Windows.Forms;

namespace M3
{
    partial class FormCreerRecette
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
<<<<<<< HEAD
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
=======
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreerRecette));
>>>>>>> a799a05ab1e8e3ebef2af8db350d44285257f8a5
            lblTitre = new Label();
            lblNomRecette = new Label();
            txtNomRecette = new TextBox();
            lblOperations = new Label();
            dgvOperations = new DataGridView();
            colPosition = new DataGridViewComboBoxColumn();
            colTempsArret = new DataGridViewTextBoxColumn();
            colQuittance = new DataGridViewCheckBoxColumn();
            btnAjouterOperation = new Button();
            btnSupprimerOperation = new Button();
            btnEnregistrer = new Button();
            btnAnnuler = new Button();
            panelTitre = new Panel();
            panelBoutons = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvOperations).BeginInit();
            panelTitre.SuspendLayout();
            panelBoutons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitre.ForeColor = Color.White;
            lblTitre.Location = new Point(15, 15);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(246, 25);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Créer une nouvelle recette";
            // 
            // lblNomRecette
            // 
            lblNomRecette.AutoSize = true;
            lblNomRecette.Font = new Font("Segoe UI", 10F);
            lblNomRecette.Location = new Point(20, 80);
            lblNomRecette.Name = "lblNomRecette";
            lblNomRecette.Size = new Size(125, 19);
            lblNomRecette.TabIndex = 1;
            lblNomRecette.Text = "Nom de la recette :";
            // 
            // txtNomRecette
            // 
            txtNomRecette.Font = new Font("Segoe UI", 10F);
            txtNomRecette.Location = new Point(309, 80);
            txtNomRecette.MaxLength = 50;
            txtNomRecette.Name = "txtNomRecette";
            txtNomRecette.Size = new Size(334, 25);
            txtNomRecette.TabIndex = 0;
            // 
            // lblOperations
            // 
            lblOperations.AutoSize = true;
            lblOperations.Font = new Font("Segoe UI", 10F);
            lblOperations.Location = new Point(671, 86);
            lblOperations.Name = "lblOperations";
            lblOperations.Size = new Size(144, 19);
            lblOperations.TabIndex = 2;
            lblOperations.Text = "Opérations (max. 10) :";
            // 
            // dgvOperations
            // 
            dgvOperations.AllowUserToAddRows = false;
            dgvOperations.AllowUserToDeleteRows = false;
            dgvOperations.AllowUserToResizeColumns = false;
            dgvOperations.AllowUserToResizeRows = false;
            dgvOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperations.BackgroundColor = Color.White;
<<<<<<< HEAD
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvOperations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
=======
            dgvOperations.BorderStyle = BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOperations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
>>>>>>> a799a05ab1e8e3ebef2af8db350d44285257f8a5
            dgvOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperations.Columns.AddRange(new DataGridViewColumn[] { colPosition, colTempsArret, colQuittance });
            dgvOperations.Font = new Font("Segoe UI", 9F);
            dgvOperations.GridColor = SystemColors.HotTrack;
            dgvOperations.Location = new Point(33, 194);
            dgvOperations.Name = "dgvOperations";
            dgvOperations.RowHeadersVisible = false;
            dgvOperations.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvOperations.RowTemplate.Height = 28;
            dgvOperations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperations.Size = new Size(810, 661);
            dgvOperations.TabIndex = 1;
            // 
            // colPosition
            // 
            colPosition.AutoComplete = false;
            colPosition.DisplayStyleForCurrentCellOnly = true;
            colPosition.HeaderText = "Position moteur";
            colPosition.Items.AddRange(new object[] { "12", "3", "6", "9" });
            colPosition.MinimumWidth = 10;
            colPosition.Name = "colPosition";
<<<<<<< HEAD
            colPosition.Width = 150;
=======
>>>>>>> a799a05ab1e8e3ebef2af8db350d44285257f8a5
            // 
            // colTempsArret
            // 
            colTempsArret.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colTempsArret.HeaderText = "Temps d'arrêt (s)";
            colTempsArret.MinimumWidth = 10;
            colTempsArret.Name = "colTempsArret";
<<<<<<< HEAD
            colTempsArret.Width = 104;
=======
            colTempsArret.Width = 205;
>>>>>>> a799a05ab1e8e3ebef2af8db350d44285257f8a5
            // 
            // colQuittance
            // 
            colQuittance.HeaderText = "Quittance manuelle";
            colQuittance.MinimumWidth = 10;
            colQuittance.Name = "colQuittance";
<<<<<<< HEAD
            colQuittance.Width = 150;
=======
>>>>>>> a799a05ab1e8e3ebef2af8db350d44285257f8a5
            // 
            // btnAjouterOperation
            // 
            btnAjouterOperation.BackColor = Color.FromArgb(0, 122, 204);
            btnAjouterOperation.Cursor = Cursors.Hand;
            btnAjouterOperation.FlatAppearance.BorderSize = 0;
            btnAjouterOperation.FlatStyle = FlatStyle.Flat;
            btnAjouterOperation.Font = new Font("Segoe UI", 9F);
            btnAjouterOperation.ForeColor = Color.White;
            btnAjouterOperation.Location = new Point(909, 194);
            btnAjouterOperation.Name = "btnAjouterOperation";
            btnAjouterOperation.Size = new Size(242, 95);
            btnAjouterOperation.TabIndex = 2;
            btnAjouterOperation.Text = "+ Ajouter opération";
            btnAjouterOperation.UseVisualStyleBackColor = false;
            btnAjouterOperation.Click += btnAjouterOp_Click;
            // 
            // btnSupprimerOperation
            // 
            btnSupprimerOperation.BackColor = Color.FromArgb(200, 50, 50);
            btnSupprimerOperation.Cursor = Cursors.Hand;
            btnSupprimerOperation.FlatAppearance.BorderSize = 0;
            btnSupprimerOperation.FlatStyle = FlatStyle.Flat;
            btnSupprimerOperation.Font = new Font("Segoe UI", 9F);
            btnSupprimerOperation.ForeColor = Color.White;
            btnSupprimerOperation.Location = new Point(1388, 194);
            btnSupprimerOperation.Name = "btnSupprimerOperation";
            btnSupprimerOperation.Size = new Size(284, 95);
            btnSupprimerOperation.TabIndex = 3;
            btnSupprimerOperation.Text = "- Supprimer opération";
            btnSupprimerOperation.UseVisualStyleBackColor = false;
            btnSupprimerOperation.Click += btnSupprimerOp_Click;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.BackColor = Color.FromArgb(40, 167, 69);
            btnEnregistrer.Cursor = Cursors.Hand;
            btnEnregistrer.FlatAppearance.BorderSize = 0;
            btnEnregistrer.FlatStyle = FlatStyle.Flat;
            btnEnregistrer.Font = new Font("Segoe UI", 10F);
            btnEnregistrer.ForeColor = Color.White;
            btnEnregistrer.Location = new Point(68, 7);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(171, 87);
            btnEnregistrer.TabIndex = 4;
            btnEnregistrer.Text = "✔ Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = false;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.BackColor = Color.FromArgb(108, 117, 125);
            btnAnnuler.Cursor = Cursors.Hand;
            btnAnnuler.DialogResult = DialogResult.Cancel;
            btnAnnuler.FlatAppearance.BorderSize = 0;
            btnAnnuler.FlatStyle = FlatStyle.Flat;
            btnAnnuler.Font = new Font("Segoe UI", 10F);
            btnAnnuler.ForeColor = Color.White;
            btnAnnuler.Location = new Point(1525, 7);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(158, 87);
            btnAnnuler.TabIndex = 5;
            btnAnnuler.Text = "✖ Annuler";
            btnAnnuler.UseVisualStyleBackColor = false;
            // 
            // panelTitre
            // 
            panelTitre.BackColor = Color.FromArgb(40, 40, 40);
            panelTitre.Controls.Add(lblTitre);
            panelTitre.Dock = DockStyle.Top;
            panelTitre.Location = new Point(0, 0);
            panelTitre.Name = "panelTitre";
            panelTitre.Size = new Size(1754, 60);
            panelTitre.TabIndex = 0;
            // 
            // panelBoutons
            // 
            panelBoutons.BackColor = Color.FromArgb(245, 245, 245);
            panelBoutons.Controls.Add(btnEnregistrer);
            panelBoutons.Controls.Add(btnAnnuler);
            panelBoutons.Dock = DockStyle.Bottom;
            panelBoutons.Location = new Point(0, 955);
            panelBoutons.Name = "panelBoutons";
            panelBoutons.Size = new Size(1754, 106);
            panelBoutons.TabIndex = 4;
            // 
            // FormCreerRecette
            // 
            AcceptButton = btnEnregistrer;
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            BackColor = Color.White;
            CancelButton = btnAnnuler;
            ClientSize = new Size(1754, 1061);
            Controls.Add(panelTitre);
            Controls.Add(lblNomRecette);
            Controls.Add(txtNomRecette);
            Controls.Add(lblOperations);
            Controls.Add(dgvOperations);
            Controls.Add(btnAjouterOperation);
            Controls.Add(btnSupprimerOperation);
            Controls.Add(panelBoutons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCreerRecette";
            Text = "Nouvelle Recette";
            ((System.ComponentModel.ISupportInitialize)dgvOperations).EndInit();
            panelTitre.ResumeLayout(false);
            panelTitre.PerformLayout();
            panelBoutons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelTitre;
        private System.Windows.Forms.Panel panelBoutons;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblNomRecette;
        private System.Windows.Forms.TextBox txtNomRecette;
        private System.Windows.Forms.Label lblOperations;
        private System.Windows.Forms.DataGridView dgvOperations;
        private System.Windows.Forms.Button btnAjouterOperation;
        private System.Windows.Forms.Button btnSupprimerOperation;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private DataGridViewComboBoxColumn colPosition;
        private DataGridViewTextBoxColumn colTempsArret;
        private DataGridViewCheckBoxColumn colQuittance;
    }
}

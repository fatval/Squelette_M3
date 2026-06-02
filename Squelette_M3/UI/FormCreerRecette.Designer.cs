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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblTitre = new Label();
            lblNomRecette = new Label();
            txtNomRecette = new TextBox();
            lblOperations = new Label();
            dgvOperations = new DataGridView();
            colOrdre = new DataGridViewTextBoxColumn();
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
            txtNomRecette.Location = new Point(180, 77);
            txtNomRecette.MaxLength = 50;
            txtNomRecette.Name = "txtNomRecette";
            txtNomRecette.Size = new Size(250, 25);
            txtNomRecette.TabIndex = 0;
            // 
            // lblOperations
            // 
            lblOperations.AutoSize = true;
            lblOperations.Font = new Font("Segoe UI", 10F);
            lblOperations.Location = new Point(20, 125);
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
            dgvOperations.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvOperations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvOperations.ColumnHeadersHeight = 30;
            dgvOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvOperations.Columns.AddRange(new DataGridViewColumn[] { colOrdre, colPosition, colTempsArret, colQuittance });
            dgvOperations.Font = new Font("Segoe UI", 9F);
            dgvOperations.Location = new Point(20, 150);
            dgvOperations.Name = "dgvOperations";
            dgvOperations.RowHeadersVisible = false;
            dgvOperations.RowTemplate.Height = 28;
            dgvOperations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperations.Size = new Size(555, 250);
            dgvOperations.TabIndex = 1;
            // 
            // colOrdre
            // 
            colOrdre.HeaderText = "Ordre";
            colOrdre.Name = "colOrdre";
            colOrdre.ReadOnly = true;
            colOrdre.Width = 60;
            // 
            // colPosition
            // 
            colPosition.DisplayStyleForCurrentCellOnly = true;
            colPosition.HeaderText = "Position moteur";
            colPosition.Items.AddRange(new object[] { "3", "6", "9", "12" });
            colPosition.Name = "colPosition";
            colPosition.Width = 150;
            // 
            // colTempsArret
            // 
            colTempsArret.HeaderText = "Temps d'arrêt (s)";
            colTempsArret.Name = "colTempsArret";
            colTempsArret.Width = 140;
            // 
            // colQuittance
            // 
            colQuittance.HeaderText = "Quittance manuelle";
            colQuittance.Name = "colQuittance";
            colQuittance.Width = 150;
            // 
            // btnAjouterOperation
            // 
            btnAjouterOperation.BackColor = Color.FromArgb(0, 122, 204);
            btnAjouterOperation.Cursor = Cursors.Hand;
            btnAjouterOperation.FlatAppearance.BorderSize = 0;
            btnAjouterOperation.FlatStyle = FlatStyle.Flat;
            btnAjouterOperation.Font = new Font("Segoe UI", 9F);
            btnAjouterOperation.ForeColor = Color.White;
            btnAjouterOperation.Location = new Point(20, 415);
            btnAjouterOperation.Name = "btnAjouterOperation";
            btnAjouterOperation.Size = new Size(160, 35);
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
            btnSupprimerOperation.Location = new Point(195, 415);
            btnSupprimerOperation.Name = "btnSupprimerOperation";
            btnSupprimerOperation.Size = new Size(165, 35);
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
            btnEnregistrer.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnEnregistrer.ForeColor = Color.White;
            btnEnregistrer.Location = new Point(370, 12);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(130, 36);
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
            btnAnnuler.Location = new Point(510, 12);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(75, 36);
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
            panelTitre.Size = new Size(600, 60);
            panelTitre.TabIndex = 0;
            // 
            // panelBoutons
            // 
            panelBoutons.BackColor = Color.FromArgb(245, 245, 245);
            panelBoutons.Controls.Add(btnEnregistrer);
            panelBoutons.Controls.Add(btnAnnuler);
            panelBoutons.Dock = DockStyle.Bottom;
            panelBoutons.Location = new Point(0, 475);
            panelBoutons.Name = "panelBoutons";
            panelBoutons.Size = new Size(600, 60);
            panelBoutons.TabIndex = 4;
            // 
            // FormCreerRecette
            // 
            AcceptButton = btnEnregistrer;
            BackColor = Color.White;
            CancelButton = btnAnnuler;
            ClientSize = new Size(600, 535);
            Controls.Add(panelTitre);
            Controls.Add(lblNomRecette);
            Controls.Add(txtNomRecette);
            Controls.Add(lblOperations);
            Controls.Add(dgvOperations);
            Controls.Add(btnAjouterOperation);
            Controls.Add(btnSupprimerOperation);
            Controls.Add(panelBoutons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCreerRecette";
            StartPosition = FormStartPosition.CenterParent;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn colOrdre;
        private System.Windows.Forms.DataGridViewComboBoxColumn colPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTempsArret;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colQuittance;
        private System.Windows.Forms.Button btnAjouterOperation;
        private System.Windows.Forms.Button btnSupprimerOperation;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
    }
}

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
            btnAjouterOperation = new Button();
            btnSupprimerOperation = new Button();
            btnEnregistrer = new Button();
            btnAnnuler = new Button();
            panelTitre = new Panel();
            panelBoutons = new Panel();
            colPosition = new DataGridViewComboBoxColumn();
            colTempsArret = new DataGridViewTextBoxColumn();
            colQuittance = new DataGridViewCheckBoxColumn();
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
            lblTitre.Size = new Size(495, 51);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Créer une nouvelle recette";
            // 
            // lblNomRecette
            // 
            lblNomRecette.AutoSize = true;
            lblNomRecette.Font = new Font("Segoe UI", 10F);
            lblNomRecette.Location = new Point(20, 80);
            lblNomRecette.Name = "lblNomRecette";
            lblNomRecette.Size = new Size(242, 37);
            lblNomRecette.TabIndex = 1;
            lblNomRecette.Text = "Nom de la recette :";
            // 
            // txtNomRecette
            // 
            txtNomRecette.Font = new Font("Segoe UI", 10F);
            txtNomRecette.Location = new Point(309, 80);
            txtNomRecette.MaxLength = 50;
            txtNomRecette.Name = "txtNomRecette";
            txtNomRecette.Size = new Size(334, 43);
            txtNomRecette.TabIndex = 0;
            // 
            // lblOperations
            // 
            lblOperations.AutoSize = true;
            lblOperations.Font = new Font("Segoe UI", 10F);
            lblOperations.Location = new Point(671, 86);
            lblOperations.Name = "lblOperations";
            lblOperations.Size = new Size(276, 37);
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
            dgvOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperations.Columns.AddRange(new DataGridViewColumn[] { colPosition, colTempsArret, colQuittance });
            dgvOperations.Font = new Font("Segoe UI", 9F);
            dgvOperations.Location = new Point(33, 194);
            dgvOperations.Name = "dgvOperations";
            dgvOperations.RowHeadersVisible = false;
            dgvOperations.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dgvOperations.RowTemplate.Height = 28;
            dgvOperations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperations.Size = new Size(786, 435);
            dgvOperations.TabIndex = 1;
            // 
            // btnAjouterOperation
            // 
            btnAjouterOperation.BackColor = Color.FromArgb(0, 122, 204);
            btnAjouterOperation.Cursor = Cursors.Hand;
            btnAjouterOperation.FlatAppearance.BorderSize = 0;
            btnAjouterOperation.FlatStyle = FlatStyle.Flat;
            btnAjouterOperation.Font = new Font("Segoe UI", 9F);
            btnAjouterOperation.ForeColor = Color.White;
            btnAjouterOperation.Location = new Point(61, 811);
            btnAjouterOperation.Name = "btnAjouterOperation";
            btnAjouterOperation.Size = new Size(174, 107);
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
            btnSupprimerOperation.Location = new Point(637, 823);
            btnSupprimerOperation.Name = "btnSupprimerOperation";
            btnSupprimerOperation.Size = new Size(188, 95);
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
            btnEnregistrer.Location = new Point(61, 22);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(130, 58);
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
            btnAnnuler.Location = new Point(1525, 22);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(99, 68);
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
            panelBoutons.Location = new Point(0, 1038);
            panelBoutons.Name = "panelBoutons";
            panelBoutons.Size = new Size(1754, 106);
            panelBoutons.TabIndex = 4;
            // 
            // colPosition
            // 
            colPosition.AutoComplete = false;
            colPosition.DisplayStyleForCurrentCellOnly = true;
            colPosition.HeaderText = "Position moteur";
            colPosition.Items.AddRange(new object[] { "12", "3", "6", "9" });
            colPosition.MinimumWidth = 10;
            colPosition.Name = "colPosition";
            colPosition.Width = 150;
            // 
            // colTempsArret
            // 
            colTempsArret.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            colTempsArret.HeaderText = "Temps d'arrêt (s)";
            colTempsArret.MinimumWidth = 10;
            colTempsArret.Name = "colTempsArret";
            colTempsArret.Width = 205;
            // 
            // colQuittance
            // 
            colQuittance.HeaderText = "Quittance manuelle";
            colQuittance.MinimumWidth = 10;
            colQuittance.Name = "colQuittance";
            colQuittance.Width = 150;
            // 
            // FormCreerRecette
            // 
            AcceptButton = btnEnregistrer;
            BackColor = Color.White;
            CancelButton = btnAnnuler;
            ClientSize = new Size(1754, 1144);
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
        private System.Windows.Forms.Button btnAjouterOperation;
        private System.Windows.Forms.Button btnSupprimerOperation;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Button btnAnnuler;
        private DataGridViewComboBoxColumn colPosition;
        private DataGridViewTextBoxColumn colTempsArret;
        private DataGridViewCheckBoxColumn colQuittance;
    }
}

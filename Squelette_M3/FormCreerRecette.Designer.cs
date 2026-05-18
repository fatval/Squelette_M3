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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblNomRecette = new System.Windows.Forms.Label();
            this.txtNomRecette = new System.Windows.Forms.TextBox();
            this.lblOperations = new System.Windows.Forms.Label();
            this.dgvOperations = new System.Windows.Forms.DataGridView();
            this.colOrdre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPosition = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colTempsArret = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuittance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnAjouterOperation = new System.Windows.Forms.Button();
            this.btnSupprimerOperation = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.panelTitre = new System.Windows.Forms.Panel();
            this.panelBoutons = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            this.panelTitre.SuspendLayout();
            this.panelBoutons.SuspendLayout();
            this.SuspendLayout();

            // ── panelTitre ──────────────────────────────────────────
            this.panelTitre.BackColor = System.Drawing.Color.FromArgb(40, 40, 40);
            this.panelTitre.Controls.Add(this.lblTitre);
            this.panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitre.Location = new System.Drawing.Point(0, 0);
            this.panelTitre.Size = new System.Drawing.Size(600, 60);

            // ── lblTitre ────────────────────────────────────────────
            this.lblTitre.Text = "Créer une nouvelle recette";
            this.lblTitre.ForeColor = System.Drawing.Color.White;
            this.lblTitre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitre.AutoSize = true;
            this.lblTitre.Location = new System.Drawing.Point(15, 15);

            // ── lblNomRecette ───────────────────────────────────────
            this.lblNomRecette.Text = "Nom de la recette :";
            this.lblNomRecette.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNomRecette.Location = new System.Drawing.Point(20, 80);
            this.lblNomRecette.AutoSize = true;

            // ── txtNomRecette ───────────────────────────────────────
            this.txtNomRecette.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNomRecette.Location = new System.Drawing.Point(180, 77);
            this.txtNomRecette.Size = new System.Drawing.Size(250, 27);
            this.txtNomRecette.MaxLength = 50;
            this.txtNomRecette.Name = "txtNomRecette";
            this.txtNomRecette.TabIndex = 0;

            // ── lblOperations ───────────────────────────────────────
            this.lblOperations.Text = "Opérations (max. 10) :";
            this.lblOperations.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOperations.Location = new System.Drawing.Point(20, 125);
            this.lblOperations.AutoSize = true;

            // ── dgvOperations ───────────────────────────────────────
            this.dgvOperations.Location = new System.Drawing.Point(20, 150);
            this.dgvOperations.Size = new System.Drawing.Size(555, 250);
            this.dgvOperations.AllowUserToAddRows = false;
            this.dgvOperations.AllowUserToDeleteRows = false;
            this.dgvOperations.RowHeadersVisible = false;
            this.dgvOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperations.BackgroundColor = System.Drawing.Color.White;
            this.dgvOperations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvOperations.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvOperations.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.dgvOperations.ColumnHeadersHeight = 30;
            this.dgvOperations.RowTemplate.Height = 28;
            this.dgvOperations.Name = "dgvOperations";
            this.dgvOperations.TabIndex = 1;

            // ── colOrdre ────────────────────────────────────────────
            this.colOrdre.HeaderText = "Ordre";
            this.colOrdre.Name = "colOrdre";
            this.colOrdre.Width = 60;
            this.colOrdre.ReadOnly = true;

            // ── colPosition ─────────────────────────────────────────
            this.colPosition.HeaderText = "Position moteur";
            this.colPosition.Name = "colPosition";
            this.colPosition.Width = 150;
            this.colPosition.Items.AddRange(new object[] { "3h", "6h", "9h", "12h" });
            this.colPosition.DisplayStyleForCurrentCellOnly = true;

            // ── colTempsArret ───────────────────────────────────────
            this.colTempsArret.HeaderText = "Temps d'arrêt (s)";
            this.colTempsArret.Name = "colTempsArret";
            this.colTempsArret.Width = 140;

            // ── colQuittance ────────────────────────────────────────
            this.colQuittance.HeaderText = "Quittance manuelle";
            this.colQuittance.Name = "colQuittance";
            this.colQuittance.Width = 150;

            this.dgvOperations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colOrdre,
                this.colPosition,
                this.colTempsArret,
                this.colQuittance
            });

            // ── btnAjouterOperation ─────────────────────────────────
            this.btnAjouterOperation.Text = "+ Ajouter opération";
            this.btnAjouterOperation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAjouterOperation.Location = new System.Drawing.Point(20, 415);
            this.btnAjouterOperation.Size = new System.Drawing.Size(160, 35);
            this.btnAjouterOperation.BackColor = System.Drawing.Color.FromArgb(0, 122, 204);
            this.btnAjouterOperation.ForeColor = System.Drawing.Color.White;
            this.btnAjouterOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAjouterOperation.FlatAppearance.BorderSize = 0;
            this.btnAjouterOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAjouterOperation.Name = "btnAjouterOperation";
            this.btnAjouterOperation.TabIndex = 2;
            this.btnAjouterOperation.UseVisualStyleBackColor = false;
            this.btnAjouterOperation.Click += new System.EventHandler(this.btnAjouterOp_Click);

            // ── btnSupprimerOperation ───────────────────────────────
            this.btnSupprimerOperation.Text = "- Supprimer opération";
            this.btnSupprimerOperation.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSupprimerOperation.Location = new System.Drawing.Point(195, 415);
            this.btnSupprimerOperation.Size = new System.Drawing.Size(165, 35);
            this.btnSupprimerOperation.BackColor = System.Drawing.Color.FromArgb(200, 50, 50);
            this.btnSupprimerOperation.ForeColor = System.Drawing.Color.White;
            this.btnSupprimerOperation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimerOperation.FlatAppearance.BorderSize = 0;
            this.btnSupprimerOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSupprimerOperation.Name = "btnSupprimerOperation";
            this.btnSupprimerOperation.TabIndex = 3;
            this.btnSupprimerOperation.UseVisualStyleBackColor = false;
            this.btnSupprimerOperation.Click += new System.EventHandler(this.btnSupprimerOp_Click);

            // ── panelBoutons ────────────────────────────────────────
            this.panelBoutons.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.panelBoutons.Controls.Add(this.btnEnregistrer);
            this.panelBoutons.Controls.Add(this.btnAnnuler);
            this.panelBoutons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBoutons.Location = new System.Drawing.Point(0, 475);
            this.panelBoutons.Size = new System.Drawing.Size(600, 60);

            // ── btnEnregistrer ──────────────────────────────────────
            this.btnEnregistrer.Text = "✔ Enregistrer";
            this.btnEnregistrer.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEnregistrer.Location = new System.Drawing.Point(370, 12);
            this.btnEnregistrer.Size = new System.Drawing.Size(130, 36);
            this.btnEnregistrer.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnEnregistrer.ForeColor = System.Drawing.Color.White;
            this.btnEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnregistrer.FlatAppearance.BorderSize = 0;
            this.btnEnregistrer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.TabIndex = 4;
            this.btnEnregistrer.UseVisualStyleBackColor = false;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);

            // ── btnAnnuler ──────────────────────────────────────────
            this.btnAnnuler.Text = "✖ Annuler";
            this.btnAnnuler.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAnnuler.Location = new System.Drawing.Point(510, 12);
            this.btnAnnuler.Size = new System.Drawing.Size(75, 36);
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnnuler.FlatAppearance.BorderSize = 0;
            this.btnAnnuler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.TabIndex = 5;
            this.btnAnnuler.UseVisualStyleBackColor = false;

            // ── FormCreerRecette ────────────────────────────────────
            this.Text = "Nouvelle Recette";  // ← Sera changé au runtime si modification
            this.ClientSize = new System.Drawing.Size(600, 535);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.BackColor = System.Drawing.Color.White;
            this.Name = "FormCreerRecette";
            this.CancelButton = this.btnAnnuler;
            this.AcceptButton = this.btnEnregistrer;

            this.Controls.Add(this.panelTitre);
            this.Controls.Add(this.lblNomRecette);
            this.Controls.Add(this.txtNomRecette);
            this.Controls.Add(this.lblOperations);
            this.Controls.Add(this.dgvOperations);
            this.Controls.Add(this.btnAjouterOperation);
            this.Controls.Add(this.btnSupprimerOperation);
            this.Controls.Add(this.panelBoutons);

            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            this.panelTitre.ResumeLayout(false);
            this.panelTitre.PerformLayout();
            this.panelBoutons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
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

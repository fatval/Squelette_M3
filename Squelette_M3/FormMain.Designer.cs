using System.Drawing;

namespace Squelette_M3
{
    partial class FormMain
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
            btnRecettes = new Button();
            btnLots = new Button();
            btnHistorique = new Button();
            panelContenu = new Panel();
            panelSidebar = new Panel();
            lblTitre = new Label();
            SuspendLayout();

            // ─── SIDEBAR ───────────────────────────────────────────────────
            panelSidebar.BackColor = Color.FromArgb(45, 45, 48);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.Name = "panelSidebar";
            panelSidebar.Size = new Size(220, 600);
            panelSidebar.TabIndex = 10;

            // ─── TITRE SIDEBAR ─────────────────────────────────────────────
            lblTitre.AutoSize = false;
            lblTitre.BackColor = Color.FromArgb(45, 45, 48);
            lblTitre.ForeColor = Color.White;
            lblTitre.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitre.Location = new Point(15, 20);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(190, 35);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "NewIndustry 4.0";
            panelSidebar.Controls.Add(lblTitre);

            // ─── BOUTON RECETTES ───────────────────────────────────────────
            btnRecettes.BackColor = Color.FromArgb(45, 45, 48);
            btnRecettes.FlatStyle = FlatStyle.Flat;
            btnRecettes.FlatAppearance.BorderSize = 0;
            btnRecettes.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 76);
            btnRecettes.UseVisualStyleBackColor = false; // ← IMPORTANT !
            btnRecettes.ForeColor = Color.White;
            btnRecettes.Font = new Font("Segoe UI", 11F);
            btnRecettes.Location = new Point(10, 80);
            btnRecettes.Name = "btnRecettes";
            btnRecettes.Size = new Size(200, 50);
            btnRecettes.TabIndex = 1;
            btnRecettes.Text = "📋 Recettes";
            btnRecettes.TextAlign = ContentAlignment.MiddleLeft;
            btnRecettes.Padding = new Padding(15, 0, 0, 0);
            btnRecettes.Cursor = Cursors.Hand;
            btnRecettes.Click += btnRecettes_Click;
            panelSidebar.Controls.Add(btnRecettes);

            // ─── BOUTON LOTS ───────────────────────────────────────────────
            btnLots.BackColor = Color.FromArgb(45, 45, 48);
            btnLots.FlatStyle = FlatStyle.Flat;
            btnLots.FlatAppearance.BorderSize = 0;
            btnLots.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 76);
            btnLots.UseVisualStyleBackColor = false; // ← IMPORTANT !
            btnLots.ForeColor = Color.White;
            btnLots.Font = new Font("Segoe UI", 11F);
            btnLots.Location = new Point(10, 140);
            btnLots.Name = "btnLots";
            btnLots.Size = new Size(200, 50);
            btnLots.TabIndex = 2;
            btnLots.Text = "📦 Lots";
            btnLots.TextAlign = ContentAlignment.MiddleLeft;
            btnLots.Padding = new Padding(15, 0, 0, 0);
            btnLots.Cursor = Cursors.Hand;
            btnLots.Click += btnLots_Click;
            panelSidebar.Controls.Add(btnLots);

            // ─── BOUTON HISTORIQUE ─────────────────────────────────────────
            btnHistorique.BackColor = Color.FromArgb(45, 45, 48);
            btnHistorique.FlatStyle = FlatStyle.Flat;
            btnHistorique.FlatAppearance.BorderSize = 0;
            btnHistorique.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 76);
            btnHistorique.UseVisualStyleBackColor = false; // ← IMPORTANT !
            btnHistorique.ForeColor = Color.White;
            btnHistorique.Font = new Font("Segoe UI", 11F);
            btnHistorique.Location = new Point(10, 200);
            btnHistorique.Name = "btnHistorique";
            btnHistorique.Size = new Size(200, 50);
            btnHistorique.TabIndex = 3;
            btnHistorique.Text = "📊 Traçabilité";
            btnHistorique.TextAlign = ContentAlignment.MiddleLeft;
            btnHistorique.Padding = new Padding(15, 0, 0, 0);
            btnHistorique.Cursor = Cursors.Hand;
            btnHistorique.Click += btnHistorique_Click;
            panelSidebar.Controls.Add(btnHistorique);

            // ─── PANEL CONTENU ─────────────────────────────────────────────
            panelContenu.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelContenu.BackColor = Color.FromArgb(240, 240, 240);
            panelContenu.Location = new Point(220, 0);
            panelContenu.Name = "panelContenu";
            panelContenu.Size = new Size(780, 600);
            panelContenu.TabIndex = 0;

            // ─── FORM MAIN ─────────────────────────────────────────────────
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 240);
            ClientSize = new Size(1000, 600);
            Controls.Add(panelContenu);
            Controls.Add(panelSidebar);
            Name = "FormMain";
            Text = "NewIndustry 4.0 - Gestion de Production";
            Font = new Font("Segoe UI", 9F);
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
        }

        private Button btnRecettes;
        private Button btnLots;
        private Button btnHistorique;
        private Panel panelContenu;
        private Panel panelSidebar;
        private Label lblTitre;
    }
}

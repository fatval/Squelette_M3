using System;
using System.Windows.Forms;
using System.Drawing;

namespace Squelette_M3
{
    public partial class FormMain : Form
    {
        private Color colorActif = Color.FromArgb(0, 120, 215);
        private Color colorInactif = Color.FromArgb(45, 45, 48);

        public FormMain()
        {
            InitializeComponent();
            btnRecettes.BackColor = colorActif; // Premier bouton actif par défaut
            AfficherPage(new UserControlRecettes());
        }

        private void AfficherPage(UserControl uc)
        {
            panelContenu.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContenu.Controls.Add(uc);
        }

        private void DesactiverTousBoutons()
        {
            btnRecettes.BackColor = colorInactif;
            btnLots.BackColor = colorInactif;
            btnHistorique.BackColor = colorInactif;
        }

        private void btnRecettes_Click(object sender, EventArgs e)
        {
            DesactiverTousBoutons();
            btnRecettes.BackColor = colorActif;
            AfficherPage(new UserControlRecettes());
        }

        private void btnLots_Click(object sender, EventArgs e)
        {
            DesactiverTousBoutons();
            btnLots.BackColor = colorActif;
            AfficherPage(new UserControlLots());
        }

        private void btnHistorique_Click(object sender, EventArgs e)
        {
            DesactiverTousBoutons();
            btnHistorique.BackColor = colorActif;
            AfficherPage(new UserControlHistorique());
        }

        private void panelContenu_Paint(object sender, PaintEventArgs e)
        {
            // Vide
        }
    }
}

// ============================================================================
// Fichier     : FormMain.cs
// Auteurs     : Noé A-Hadi, Valentin Boegli
// Date        : Juin 2026
// Description : Fenêtre principale de l'application (Menu de navigation).
//               Gère l'affichage dynamique des différentes sections (Recettes,
//               Lots, Historique) sous forme de UserControls dans un panneau 
//               central, offrant une navigation de type "Single Page".
//
// Méthodes :
// - AfficherPage() : Charge et adapte un UserControl dans le panneau principal.
// - DesactiverTousBoutons() : Réinitialise l'apparence visuelle du menu.
// - btnXXX_Click() : Gestionnaires d'événements pour la navigation.
// ============================================================================

namespace Squelette_M3
{
    public partial class FormMain : Form
    {
        private Color colorActif = Color.FromArgb(0, 120, 215);
        private Color colorInactif = Color.FromArgb(45, 45, 48);

        // ─── CONSTRUCTEUR ──────────────────────────────────────────
        /// <summary>
        /// Constructeur par défaut. Initialise la fenêtre principale, 
        /// active le bouton "Recettes" et charge la page correspondante par défaut.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
            btnRecettes.BackColor = colorActif; // Premier bouton actif par défaut
            AfficherPage(new UserControlRecettes());
        }

        // ─── GESTION DE L'AFFICHAGE (SINGLE PAGE) ──────────────────
        /// <summary>
        /// Charge un UserControl spécifié et l'adapte pour qu'il remplisse le panneau central.
        /// </summary>
        /// <param name="uc">Le UserControl (page) à afficher dans le panneau principal.</param>
        private void AfficherPage(UserControl uc)
        {
            panelContenu.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContenu.Controls.Add(uc);
        }

        /// <summary>
        /// Réinitialise l'apparence (couleur) de tous les boutons du menu de navigation
        /// pour indiquer qu'ils sont inactifs.
        /// </summary>
        private void DesactiverTousBoutons()
        {
            btnRecettes.BackColor = colorInactif;
            btnLots.BackColor = colorInactif;
            btnHistorique.BackColor = colorInactif;
        }

        // ─── ÉVÉNEMENTS DE NAVIGATION ──────────────────────────────
        /// <summary>
        /// Gère le clic sur le bouton "Recettes". Active le bouton et affiche le UserControl des recettes.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnRecettes_Click(object sender, EventArgs e)
        {
            DesactiverTousBoutons();
            btnRecettes.BackColor = colorActif;
            AfficherPage(new UserControlRecettes());
        }

        /// <summary>
        /// Gère le clic sur le bouton "Lots". Active le bouton et affiche le UserControl des lots.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnLots_Click(object sender, EventArgs e)
        {
            DesactiverTousBoutons();
            btnLots.BackColor = colorActif;
            AfficherPage(new UserControlLots());
        }

        /// <summary>
        /// Gère le clic sur le bouton "Historique". Active le bouton et affiche le UserControl de l'historique.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnHistorique_Click(object sender, EventArgs e)
        {
            DesactiverTousBoutons();
            btnHistorique.BackColor = colorActif;
            AfficherPage(new UserControlHistorique());
        }

    }
}

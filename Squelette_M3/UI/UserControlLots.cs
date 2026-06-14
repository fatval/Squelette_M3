// ============================================================================
// Fichier     : UserControlLots.cs
// Auteurs     : Noé A-Hadi, Valentin Boegli
// Date        : Juin 2026
// Description : Interface de gestion des lots de production. Permet de créer
//               de nouveaux lots en les associant à une recette existante
//               et de visualiser la liste des lots actuels.
//               Aucun appel SQL direct ici, tout passe par Lot.cs et Recette.cs.
//
// Méthodes principales :
// - ChargerRecettes() : Remplit le ComboBox avec les recettes disponibles.
// - ChargerLots() : Récupère et affiche la liste de tous les lots.
// - btnCreerLot_Click() : Valide les saisies et crée un nouveau lot en BDD.
// ============================================================================

namespace Squelette_M3
{
    public partial class UserControlLots : UserControl
    {
        // ─── CONSTRUCTEUR ─────────────────────────────────────────────────────
        /// <summary>
        /// Constructeur par défaut. Initialise le composant, configure le DataGridView, 
        /// puis charge les recettes (pour la liste déroulante) et les lots existants.
        /// </summary>
        public UserControlLots()
        {
            InitializeComponent();
            dgvLots.AllowUserToResizeRows = false;
            ChargerRecettes();
            ChargerLots();
        }

        // ─── CHARGER LES RECETTES DANS LE COMBOBOX ────────────────────────────
        /// <summary>
        /// Récupère toutes les recettes depuis la base de données via la classe métier 
        /// et les lie au ComboBox pour permettre à l'utilisateur d'en sélectionner une.
        /// </summary>
        private void ChargerRecettes()
        {
            try
            {
                cmbRecettes.DataSource = Recette.GetAll();
                cmbRecettes.DisplayMember = "REC_Nom";     // texte affiché
                cmbRecettes.ValueMember = "Id_Recette";    // valeur interne
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de charger les recettes.\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ─── CHARGER LES LOTS DANS LE DATAGRIDVIEW ────────────────────────────
        /// <summary>
        /// Récupère la liste de tous les lots depuis la base de données via la classe métier 
        /// et met à jour l'affichage du DataGridView ligne par ligne.
        /// </summary>
        private void ChargerLots()
        {
            try
            {
                dgvLots.Rows.Clear();

                foreach (Lot lot in Lot.GetAll())
                {
                    dgvLots.Rows.Add(
                        lot.Id_Lot,
                        lot.LOT_Nom,
                        lot.LOT_Quantite,
                        lot.REC_Nom,
                        lot.LOT_DateHeureCreation.ToString("dd/MM/yyyy HH:mm"),
                        lot.ETA_Libelle
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de charger les lots.\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // ─── CRÉER UN LOT ─────────────────────────────────────────────────────
        /// <summary>
        /// Événement déclenché lors du clic sur le bouton de création d'un lot. 
        /// Valide les entrées de l'utilisateur (nom, sélection d'une recette), 
        /// puis demande l'insertion du lot en base de données.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnCreerLot_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNomLot.Text))
            {
                MessageBox.Show("Veuillez saisir un nom pour le lot.",
                    "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRecettes.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une recette.",
                    "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Recette recetteSelectionnee = (Recette)cmbRecettes.SelectedItem;

                Lot.AjouterLot(
                    txtNomLot.Text.Trim(),
                    (int)nudQuantite.Value,
                    recetteSelectionnee.Id_Recette
                );

                MessageBox.Show("Lot créé avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Réinitialisation des champs après succès
                txtNomLot.Text = "";
                nudQuantite.Value = 1000;
                ChargerLots();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossible de créer le lot.\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

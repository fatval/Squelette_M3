// ============================================================================
// Fichier     : UserControlRecettes.cs
// Auteurs     : Noé A-Hadi, Valentin Boegli
// Date        : Juin 2026
// Description : Interface de gestion des recettes de production. Permet de 
//               visualiser l'ensemble des recettes, d'en ajouter de nouvelles, 
//               ainsi que de les modifier ou de les supprimer. 
//               Toute la logique métier et SQL est déléguée à la classe Recette.
//
// Méthodes principales :
// - ChargerRecettesDGV() : Récupère et affiche les recettes dans le tableau.
// - btnAjouter_Click() : Ouvre le formulaire de création d'une nouvelle recette.
// - btnModifier_Click() : Ouvre le formulaire pour modifier la recette sélectionnée.
// - btnSupprimer_Click() : Supprime la recette sélectionnée après confirmation.
// ============================================================================

using M3;
namespace Squelette_M3
{
    public partial class UserControlRecettes : UserControl
    {
        // ─── CONSTRUCTEUR ─────────────────────────────────────────────────────
        /// <summary>
        /// Constructeur par défaut. Initialise le composant, bloque le redimensionnement
        /// des lignes du tableau et charge la liste des recettes existantes.
        /// </summary>
        public UserControlRecettes()
        {
            InitializeComponent();
            dgvRecettes.AllowUserToResizeRows = false;      //Empêcher le redimensionnement des lignes
            ChargerRecettesDGV();
        }

        // ─── CHARGER LES RECETTES ─────────────────────────────────────────────
        /// <summary>
        /// Vide le DataGridView puis le remplit avec les données de toutes les recettes 
        /// présentes dans la base de données, y compris le nombre d'opérations associées.
        /// </summary>
        private void ChargerRecettesDGV()
        {
            try
            {   //S'assurer que les lignes et colonnes sont vidées avant de remplir des nouvelles
                dgvRecettes.Rows.Clear();

                //Remplir la dgv avec les données de la base de données
                List<Recette> recettes = Recette.GetAll();
                foreach (Recette r in recettes)
                {
                    dgvRecettes.Rows.Add(
                        r.Id_Recette,
                        r.REC_Nom,
                        Recette.CompterOperations(r.Id_Recette),      //Compte via table contenir
                        r.REC_DateHeureCreation.ToString("dd.MM.yyyy HH:mm")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erreur lors du chargement des recettes.\n\nDétails : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── AJOUTER UNE RECETTE ──────────────────────────────────────────────
        /// <summary>
        /// Gère le clic sur le bouton "Ajouter". Ouvre le formulaire de création 
        /// d'une recette et rafraîchit la liste si la création a été validée.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FormCreerRecette form = new FormCreerRecette();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ChargerRecettesDGV();
            }
        }

        // ─── MODIFIER UNE RECETTE ─────────────────────────────────────────────
        /// <summary>
        /// Gère le clic sur le bouton "Modifier". Vérifie qu'une recette est sélectionnée, 
        /// charge ses informations depuis la base de données, puis ouvre le formulaire 
        /// de création/modification en lui passant l'objet à éditer.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                //Vérifier qu'une recette est sélectionnée
                if (dgvRecettes.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Veuillez sélectionner une recette à modifier.",
                        "Attention",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                // Récupérer l'ID de la recette sélectionnée
                int recetteId = Convert.ToInt32(dgvRecettes.SelectedRows[0].Cells["colId"].Value);

                // Charger l'objet Recette complet depuis la DB
                Recette recetteAModifier = Recette.GetById(recetteId);

                // Ouvrir le formulaire de modification
                using (FormCreerRecette formEditor = new FormCreerRecette(recetteAModifier))
                {
                    if (formEditor.ShowDialog(this) == DialogResult.OK)
                    {
                        ChargerRecettesDGV();
                    }
                }

            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "❌ Erreur : ID de recette invalide.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"❌ Erreur lors de la modification :\n{ex.Message}",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // ─── SUPPRIMER UNE RECETTE ────────────────────────────────────────────
        /// <summary>
        /// Gère le clic sur le bouton "Supprimer". Demande une confirmation à l'utilisateur, 
        /// puis supprime la recette sélectionnée (et ses dépendances) de la base de données.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvRecettes.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Sélectionnez une recette à supprimer.");
                    return;
                }

                DataGridViewRow row = dgvRecettes.SelectedRows[0];
                int idRecette = Convert.ToInt32(row.Cells[0].Value);
                string nomRecette = row.Cells[1].Value.ToString();

                DialogResult confirm = MessageBox.Show(
                    $"Êtes-vous sûr de vouloir supprimer la recette \"{nomRecette}\" ?\n\n" +
                    $"⚠️ Tous les lots associés seront aussi supprimés.",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    // ✅ Appel direct à Recette.cs — plus de SQL ici
                    Recette.SupprimerRecette(idRecette);
                    ChargerRecettesDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

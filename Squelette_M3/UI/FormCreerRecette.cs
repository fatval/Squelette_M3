// ============================================================================
// Fichier     : FormCreerRecette.cs
// Auteurs     : Noé A-Hadi, Valentin Boegli
// Date        : Juin 2026
// Description : Formulaire permettant la création et la modification d'une 
//               recette de production. Il permet de définir le nom de la 
//               recette et de gérer sa séquence d'opérations (entre 1 et 10).
//
// Méthodes principales :
// - FormCreerRecette() : Constructeur par défaut (Mode création).
// - FormCreerRecette(Recette) : Constructeur surchargé (Mode modification).
// - RafraichirGrille() : Met à jour l'affichage du DataGridView avec la liste.
// - btnEnregistrer_Click() : Valide les données (nom, nb d'opérations) 
//                            puis appelle AjouterRecette ou ModifierRecette.
// ============================================================================
using Squelette_M3;
namespace M3
{
    public partial class FormCreerRecette : Form
    {
        private List<Operation> operationsEnCours = new List<Operation>();
        private int recetteIdAModifier = -1;

        // ─── CONSTRUCTEUR : Nouvelle recette ───────────────────────
        /// <summary>
        /// Constructeur par défaut. Initialise le formulaire en mode "Création d'une nouvelle recette".
        /// </summary>
        public FormCreerRecette()
        {
            InitializeComponent();
            dgvOperations.DataError += (s, e) => { e.Cancel = true; };
        }

        // ─── CONSTRUCTEUR : Modifier une recette existante ─────────
        /// <summary>
        /// Constructeur surchargé. Initialise le formulaire en mode "Modification d'une recette existante".
        /// </summary>
        /// <param name="recetteAModifier">L'objet Recette contenant les données à modifier.</param>
        public FormCreerRecette(Recette recetteAModifier)
        {
            InitializeComponent();
            recetteIdAModifier = recetteAModifier.Id_Recette;
            this.Text = "Modifier Recette";
            lblTitre.Text = "Modifier une recette";
            txtNomRecette.Text = recetteAModifier.REC_Nom;

            operationsEnCours = new List<Operation>(recetteAModifier.Operations);
            RafraichirGrille();
        }

        // ─── RAFRAÎCHIR LA GRILLE ──────────────────────────────────
        /// <summary>
        /// Met à jour le contenu de la grille d'opérations pour refléter l'état actuel de la liste en mémoire.
        /// </summary>
        /// <remarks>
        /// Efface les lignes existantes puis ajoute une ligne pour chaque opération de la liste.
        /// Garantit que l'affichage reste synchronisé avec les données sous-jacentes.
        /// </remarks>
        private void RafraichirGrille()
        {
            dgvOperations.Rows.Clear();

            foreach (Operation op in operationsEnCours)
            {
                int rowIndex = dgvOperations.Rows.Add();
                dgvOperations.Rows[rowIndex].Cells["colPosition"].Value = op.OPE_PositionMoteur.ToString();
                dgvOperations.Rows[rowIndex].Cells["colSensMoteur"].Value = op.OPE_SensMoteur;
                dgvOperations.Rows[rowIndex].Cells["colTempsArret"].Value = op.OPE_TempsAttente;
                dgvOperations.Rows[rowIndex].Cells["colQuittance"].Value = op.OPE_Quittance;
                dgvOperations.Rows[rowIndex].Cells["colCycleVerin"].Value = op.OPE_CycleVerin;
            }
        }

        // ─── AJOUTER OPÉRATION ──────────────────────────────────────
        /// <summary>
        /// Ajoute une nouvelle opération avec des valeurs par défaut à la liste en cours (limite de 10 max).
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnAjouterOp_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ 1. SAUVEGARDER les saisies actuelles AVANT d'ajouter
                if (!SynchroniserDepuisGrille()) return;

                // 2. Limite à 10 opérations
                if (operationsEnCours.Count >= 10)
                {
                    MessageBox.Show("❌ Maximum 10 opérations atteint !",
                        "Limite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 3. Créer la nouvelle opération
                Operation nouvelleOp = new Operation
                {
                    Id_Operation = operationsEnCours.Count + 1,
                    OPE_PositionMoteur = 12,
                    OPE_SensMoteur = false,
                    OPE_TempsAttente = 0,
                    OPE_Quittance = false,
                    OPE_CycleVerin = false,
                };

                operationsEnCours.Add(nouvelleOp);
                RafraichirGrille();

                int derniereLigne = dgvOperations.Rows.Count - 1;
                dgvOperations.CurrentCell = dgvOperations.Rows[derniereLigne].Cells["colPosition"];
                dgvOperations.BeginEdit(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── SUPPRIMER OPÉRATION ────────────────────────────────────
        /// <summary>
        /// Supprime l'opération actuellement sélectionnée dans la grille et réorganise les IDs.
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnSupprimerOp_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvOperations.SelectedRows.Count == 0)
                {
                    MessageBox.Show("❌ Veuillez sélectionner une opération à supprimer !",
                        "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Sauvegarder les saisies AVANT de supprimer
                if (!SynchroniserDepuisGrille()) return;

                int rowIndex = dgvOperations.SelectedRows[0].Index;
                operationsEnCours.RemoveAt(rowIndex);

                for (int i = 0; i < operationsEnCours.Count; i++)
                    operationsEnCours[i].Id_Operation = i + 1;

                RafraichirGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── SYNCHRONISER GRILLE → LISTE ───────────────────────────
        /// <summary>
        /// Lit les données saisies par l'utilisateur dans la grille et met à jour la liste des opérations en mémoire.
        /// </summary>
        /// <returns>True si la synchronisation a réussi, False en cas d'erreur de lecture.</returns>
        private bool SynchroniserDepuisGrille()
        {
            try
            {
                dgvOperations.EndEdit();
                operationsEnCours.Clear();

                for (int i = 0; i < dgvOperations.Rows.Count; i++)
                {
                    DataGridViewRow row = dgvOperations.Rows[i];

                    // Position moteur (3, 6, 9, 12)
                    int positionMoteur = 12;
                    if (row.Cells["colPosition"].Value != null)
                        int.TryParse(row.Cells["colPosition"].Value.ToString(), out positionMoteur);

                    // Temps d'attente
                    int tempsAttente = 0;
                    if (row.Cells["colTempsArret"].Value != null)
                        int.TryParse(row.Cells["colTempsArret"].Value.ToString(), out tempsAttente);

                    // Quittance
                    bool quittance = false;
                    if (row.Cells["colQuittance"].Value != null)
                        quittance = Convert.ToBoolean(row.Cells["colQuittance"].Value);

                    //Cycle vérin
                    bool cycleVerin = false;
                    if (row.Cells["colCycleVerin"].Value != null)
                        cycleVerin = Convert.ToBoolean(row.Cells["colCycleVerin"].Value);

                    //Sens moteur (true = horaire, false = antihoraire)
                    bool sensMoteur = false;
                    if (row.Cells["colSensMoteur"].Value != null)
                        sensMoteur = Convert.ToBoolean(row.Cells["colSensMoteur"].Value);

                    operationsEnCours.Add(new Operation
                    {
                        OPE_PositionMoteur = positionMoteur,
                        OPE_TempsAttente = tempsAttente,
                        OPE_Quittance = quittance,
                        OPE_CycleVerin = cycleVerin,
                        OPE_SensMoteur = sensMoteur
                    });
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lecture grille : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ─── ENREGISTRER ───────────────────────────────────────────
        /// <summary>
        /// Valide les saisies (nom, nb opérations), synchronise la grille puis enregistre 
        /// la recette en base de données (Ajout ou Modification).
        /// </summary>
        /// <param name="sender">L'objet déclenchant l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                //Gestion de l'erreur nom de recette vide
                if (string.IsNullOrWhiteSpace(txtNomRecette.Text))
                {
                    MessageBox.Show("❌ Le nom de la recette ne peut pas être vide !",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;//Sortir de la fonction en cas d'erreur
                }

                if (!SynchroniserDepuisGrille()) return;

                //Gestion d'erreur : 
                if (operationsEnCours.Count == 0)
                {
                    MessageBox.Show("❌ Vous devez ajouter au moins une opération !",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;//Sortir de la fonction en cas d'erreur
                }

                Recette recette = new Recette
                {
                    REC_Nom = txtNomRecette.Text.Trim(),
                    REC_DateHeureCreation = DateTime.Now,
                    Operations = new List<Operation>(operationsEnCours)
                };

                //Si recetteIdAModifier = -1 --> Nouvelle recette, sinon, modification d'une recette existante
                if (recetteIdAModifier == -1)
                {
                    Recette.AjouterRecette(recette.REC_Nom, recette.Operations);
                    MessageBox.Show($"✅ Recette '{recette.REC_Nom}' créée avec succès !",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Recette.ModifierRecette(recetteIdAModifier, recette.REC_Nom, recette.Operations);
                    MessageBox.Show($"✅ Recette '{recette.REC_Nom}' modifiée avec succès !",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                string message = "";
                Exception current = ex;
                int niveau = 0;

                while (current != null)
                {
                    message += $"[Niveau {niveau}] {current.GetType().Name}\n{current.Message}\n\n";
                    current = current.InnerException;
                    niveau++;
                }

                MessageBox.Show($"❌ Détail complet :\n\n{message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

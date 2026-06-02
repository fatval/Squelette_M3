using M3.Models;
using Squelette_M3;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace M3
{
    public partial class FormCreerRecette : Form
    {
        private List<Operation> operationsEnCours = new List<Operation>();
        private int recetteIdAModifier = -1;

        // ─── CONSTRUCTEUR : Nouvelle recette ───────────────────────
        public FormCreerRecette()
        {
            InitializeComponent();
            dgvOperations.DataError += (s, e) => { e.Cancel = true; };
        }

        // ─── CONSTRUCTEUR : Modifier une recette existante ─────────
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


        /// <summary>
        /// Met à jour le contenu de la grille d'opérations pour refléter l'état actuel de la liste des opérations en
        /// cours.
        /// </summary>
        /// <remarks>Cette méthode efface toutes les lignes existantes dans la grille, puis ajoute une
        /// ligne pour chaque opération en cours. Elle doit être appelée chaque fois que la liste des opérations change
        /// afin de garantir que l'affichage reste synchronisé avec les données sous-jacentes.</remarks>
        private void RafraichirGrille()
        {
            dgvOperations.Rows.Clear();

            foreach (Operation op in operationsEnCours)
            {
                int rowIndex = dgvOperations.Rows.Add();
                dgvOperations.Rows[rowIndex].Cells["colOrdre"].Value = op.OPE_Ordre;
                dgvOperations.Rows[rowIndex].Cells["colPosition"].Value = op.OPE_PositionMoteur.ToString();
                dgvOperations.Rows[rowIndex].Cells["colTempsArret"].Value = op.OPE_TempsAttente;
                dgvOperations.Rows[rowIndex].Cells["colQuittance"].Value = op.OPE_Quittance;
            }
        }

        // ─── AJOUTER OPÉRATION ──────────────────────────────────────
        private void btnAjouterOp_Click(object sender, EventArgs e)
        {
            try
            {//Limite à 10 opérations
                if (operationsEnCours.Count >= 10)
                {
                    MessageBox.Show("❌ Maximum 10 opérations atteint !",
                        "Limite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //
                Operation nouvelleOp = new Operation
                {
                    OPE_Ordre = operationsEnCours.Count + 1,
                    OPE_PositionMoteur = 3,
                    OPE_TempsAttente = 0,
                    OPE_Quittance = false
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

                int rowIndex = dgvOperations.SelectedRows[0].Index;
                operationsEnCours.RemoveAt(rowIndex);

                for (int i = 0; i < operationsEnCours.Count; i++)
                    operationsEnCours[i].OPE_Ordre = i + 1;

                RafraichirGrille();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── SYNCHRONISER GRILLE → LISTE ───────────────────────────
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
                    int positionMoteur = 3;
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

                    operationsEnCours.Add(new Operation
                    {
                        OPE_Ordre = i + 1, //ne pas utiliser i++ sinon ça saute la ligne 1
                        OPE_PositionMoteur = positionMoteur,
                        OPE_TempsAttente = tempsAttente,
                        OPE_Quittance = quittance
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
                MessageBox.Show($"❌ Erreur lors de l'enregistrement :\n{ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
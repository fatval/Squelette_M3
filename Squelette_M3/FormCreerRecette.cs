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

        // ─── RAFRAICHIR LA GRILLE ───────────────────────────────────
        private void RafraichirGrille()
        {
            dgvOperations.Rows.Clear();

            foreach (Operation op in operationsEnCours)
            {
                int rowIndex = dgvOperations.Rows.Add();
                dgvOperations.Rows[rowIndex].Cells["colOrdre"].Value = op.OPE_Ordre;
                dgvOperations.Rows[rowIndex].Cells["colPosition"].Value = op.OPE_PositionMoteur;
                dgvOperations.Rows[rowIndex].Cells["colTempsArret"].Value = op.OPE_TempsAttente;
                dgvOperations.Rows[rowIndex].Cells["colQuittance"].Value = op.OPE_Quittance;
            }
        }

        // ─── AJOUTER OPÉRATION ──────────────────────────────────────
        private void btnAjouterOp_Click(object sender, EventArgs e)
        {
            try
            {
                if (operationsEnCours.Count >= 10)
                {
                    MessageBox.Show("❌ Maximum 10 opérations atteint !",
                        "Limite", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
                        OPE_Ordre = i + 1,
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
                if (string.IsNullOrWhiteSpace(txtNomRecette.Text))
                {
                    MessageBox.Show("❌ Le nom de la recette ne peut pas être vide !",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!SynchroniserDepuisGrille()) return;

                if (operationsEnCours.Count == 0)
                {
                    MessageBox.Show("❌ Vous devez ajouter au moins une opération !",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Recette recette = new Recette
                {
                    REC_Nom = txtNomRecette.Text.Trim(),
                    REC_DateHeureCreation = DateTime.Now,
                    Operations = new List<Operation>(operationsEnCours)
                };

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

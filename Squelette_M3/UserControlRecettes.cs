using M3;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Squelette_M3
{
    public partial class UserControlRecettes : UserControl
    {
        public UserControlRecettes()
        {
            InitializeComponent();
            ChargerRecettes();
        }

        private void ChargerRecettes()
        {
            try
            {
                dgvRecettes.Rows.Clear();
                dgvRecettes.Columns.Clear();

                dgvRecettes.Columns.Add("Id_Recette", "ID");
                dgvRecettes.Columns.Add("REC_Nom", "Nom de la recette");
                dgvRecettes.Columns.Add("REC_DateHeureCreation", "Date de création");

                List<Recette> recettes = Recette.GetAll();
                foreach (Recette r in recettes)
                {
                    dgvRecettes.Rows.Add(
                        r.Id_Recette,
                        r.REC_Nom,
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

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            FormCreerRecette form = new FormCreerRecette();

            if (form.ShowDialog() == DialogResult.OK)
            {
                ChargerRecettes();
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            try
            {
                // ✅ Vérifier qu'une recette est sélectionnée
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
                int recetteId = Convert.ToInt32(dgvRecettes.SelectedRows[0].Cells["Id_Recette"].Value);

                // Charger l'objet Recette complet depuis la DB
                Recette recetteAModifier = Recette.GetById(recetteId);

                // Ouvrir le formulaire de modification
                using (FormCreerRecette formEditor = new FormCreerRecette(recetteAModifier))
                {
                    if (formEditor.ShowDialog(this) == DialogResult.OK)
                    {
                        ChargerRecettes();
                        MessageBox.Show("✅ Recette modifiée avec succès !",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    SupprimerRecetteAvecLots(idRecette);
                    MessageBox.Show("Recette et ses lots supprimés avec succès !");
                    ChargerRecettes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Compter les Lots associés à une Recette ───────────────────────
        private int CompterLotsAssocies(int idRecette)
        {
            try
            {
                using (MySqlConnection connection = DBManager.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM lot WHERE Id_Recette = @idRecette";

                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idRecette", idRecette);
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch
            {
                return 0; // En cas d'erreur, retourner 0
            }
        }

        // ─── Supprimer la Recette et ses Lots associés ─────────────────────
        private void SupprimerRecetteAvecLots(int idRecette)
        {
            using (MySqlConnection connection = DBManager.GetConnection())
            {
                connection.Open();
                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1️⃣ RÉCUPÉRER TOUS LES LOTS LIÉS À CETTE RECETTE
                        List<int> lotsASupprimer = new List<int>();
                        string getLotsQuery = "SELECT Id_Lot FROM lot WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(getLotsQuery, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            using (MySqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    lotsASupprimer.Add(Convert.ToInt32(reader["Id_Lot"]));
                                }
                            }
                        }

                        // 2️⃣ SUPPRIMER LES ÉVÉNEMENTS DE CES LOTS
                        if (lotsASupprimer.Count > 0)
                        {
                            string lotsIn = string.Join(",", lotsASupprimer);
                            string deleteEvenements = $"DELETE FROM evenement WHERE Id_Lot IN ({lotsIn})";
                            using (MySqlCommand cmd = new MySqlCommand(deleteEvenements, connection, transaction))
                            {
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // 3️⃣ SUPPRIMER LES LOTS
                        string deleteLots = "DELETE FROM lot WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteLots, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 4️⃣ SUPPRIMER DANS LA TABLE ASSOCIATIVE Contenir
                        string deleteContenir = "DELETE FROM Contenir WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteContenir, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        // 5️⃣ SUPPRIMER LA RECETTE
                        string deleteRecette = "DELETE FROM recette WHERE Id_Recette = @id";
                        using (MySqlCommand cmd = new MySqlCommand(deleteRecette, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@id", idRecette);
                            cmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("✅ Recette et ses lots supprimés avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (MySqlException mex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"❌ Erreur SQL : {mex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"❌ Erreur : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}

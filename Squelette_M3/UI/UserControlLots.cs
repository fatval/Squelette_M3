using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Squelette_M3
{
    public partial class UserControlLots : UserControl
    {
        public UserControlLots()
        {
            InitializeComponent();
            dgvLots.AllowUserToResizeRows = false;      //Empêcher le redimensionnement des lignes
            ChargerRecettes();
            ChargerLots();
        }

        // ─── Charger les recettes dans le ComboBox ───────────────────────────
        private void ChargerRecettes()
        {
            try
            {
                cmbRecettes.Items.Clear();

                using (MySqlConnection connection = DBManager.GetConnection())
                {
                    connection.Open();

                    string query = "SELECT Id_Recette, REC_Nom FROM recette";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmbRecettes.Items.Add(new RecetteItem
                            {
                                Id_Recette = Convert.ToInt32(reader["Id_Recette"]),
                                REC_Nom = reader["REC_Nom"].ToString()
                            });
                        }
                    }
                }

                if (cmbRecettes.Items.Count > 0)
                    cmbRecettes.SelectedIndex = 0;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Impossible de charger les recettes.\nErreur MySQL : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur inattendue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Charger les lots dans le DataGridView ───────────────────────────
        private void ChargerLots()
        {
            try
            {
                dgvLots.Rows.Clear();

                using (MySqlConnection connection = DBManager.GetConnection())
                {
                    connection.Open();

                    string query = @"SELECT l.Id_Lot, l.LOT_Nom, l.LOT_Quantite, 
                                            r.REC_Nom, l.LOT_DateHeureCreation, e.ETA_Libelle
                                     FROM lot l
                                     JOIN recette r ON l.Id_Recette = r.Id_Recette
                                     JOIN etat e ON l.Id_Etat = e.Id_Etat
                                     ORDER BY l.LOT_DateHeureCreation DESC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvLots.Rows.Add(
                                reader["Id_Lot"].ToString(),
                                reader["LOT_Nom"].ToString(),
                                reader["LOT_Quantite"].ToString(),
                                reader["REC_Nom"].ToString(),
                                Convert.ToDateTime(reader["LOT_DateHeureCreation"]).ToString("dd/MM/yyyy HH:mm"),
                                reader["ETA_Libelle"].ToString()
                            );
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Impossible de charger les lots.\nErreur MySQL : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur inattendue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── Créer un lot ────────────────────────────────────────────────────
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
                RecetteItem recetteSelectionnee = (RecetteItem)cmbRecettes.SelectedItem;

                using (MySqlConnection connection = DBManager.GetConnection())
                {
                    connection.Open();

                    // Récupérer l'état "En attente"
                    int idEtatEnAttente = 1;
                    string queryEtat = "SELECT Id_Etat FROM etat WHERE ETA_Libelle = 'En attente' LIMIT 1";

                    using (MySqlCommand cmdEtat = new MySqlCommand(queryEtat, connection))
                    {
                        object result = cmdEtat.ExecuteScalar();
                        if (result != null)
                            idEtatEnAttente = Convert.ToInt32(result);
                    }

                    // Insérer le lot
                    string query = @"INSERT INTO lot 
                                     (LOT_Nom, LOT_Quantite, LOT_DateHeureCreation, Id_Etat, Id_Recette) 
                                     VALUES 
                                     (@nom, @quantite, @date, @etat, @recette)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nom", txtNomLot.Text.Trim());
                        command.Parameters.AddWithValue("@quantite", (int)nudQuantite.Value);
                        command.Parameters.AddWithValue("@date", DateTime.Now);
                        command.Parameters.AddWithValue("@etat", idEtatEnAttente);
                        command.Parameters.AddWithValue("@recette", recetteSelectionnee.Id_Recette);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Lot créé avec succès !", "Succès",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtNomLot.Text = "";
                nudQuantite.Value = 1;
                ChargerLots();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Impossible de créer le lot.\nErreur MySQL : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur inattendue : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

    // ─── Classe helper pour le ComboBox ──────────────────────────────────────
    public class RecetteItem
    {
        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; }

        public override string ToString()
        {
            return REC_Nom;
        }
    }
}

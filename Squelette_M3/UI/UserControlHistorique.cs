using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Squelette_M3
{
    public partial class UserControlHistorique : UserControl
    {
        private string connectionString = "Server=localhost;Database=m3;Uid=root;Pwd=;";
        private DataTable donneesCompletes; // Stockage des données complètes

        public UserControlHistorique()
        {
            InitializeComponent();
            ChargerHistorique();

            // ✅ AJOUTER L'ÉVÉNEMENT TEXTCHANGED POUR RECHERCHE TEMPS RÉEL
            txtRecherche.TextChanged += TxtRecherche_TextChanged;
        }

        // ─── CHARGER L'HISTORIQUE COMPLET ──────────────────────────────────
        private void ChargerHistorique()
        {
            try
            {
                donneesCompletes = ObtenirHistoriqueLots();
                AfficherDonnees(donneesCompletes);
                txtDetail.Text = "📋 Sélectionnez un lot pour voir son historique détaillé...";
                MettreAJourLblResultats(donneesCompletes.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors du chargement : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── AFFICHER LES DONNÉES DANS LE DATAGRIDVIEW ─────────────────────
        private void AfficherDonnees(DataTable dt)
        {
            dgvHistorique.DataSource = null;
            dgvHistorique.DataSource = dt;

            // Ajuster les colonnes
            AjusterColonnes();
        }

        // ─── AJUSTER LA LARGEUR DES COLONNES ───────────────────────────────
        private void AjusterColonnes()
        {
            if (dgvHistorique.Columns.Count > 0)
            {
                dgvHistorique.Columns["ID"].Width = 50;
                dgvHistorique.Columns["Nom du lot"].Width = 120;
                dgvHistorique.Columns["Recette"].Width = 120;
                dgvHistorique.Columns["Quantité"].Width = 80;
                dgvHistorique.Columns["État"].Width = 100;
                dgvHistorique.Columns["Date Création"].Width = 140;
            }
        }

        // ─── METTRE À JOUR LE LABEL RÉSULTATS ──────────────────────────────
        private void MettreAJourLblResultats(int nombre)
        {
            if (nombre == 0)
                lblResultats.Text = "❌ Aucun résultat trouvé";
            else if (nombre == 1)
                lblResultats.Text = $"✅ 1 lot trouvé";
            else
                lblResultats.Text = $"✅ {nombre} lots trouvés";
        }

        // ─── OBTENIR LES DONNÉES DE L'HISTORIQUE ───────────────────────────
        private DataTable ObtenirHistoriqueLots()
        {
            DataTable dt = new DataTable();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            L.Id_Lot,
                            L.LOT_Nom,
                            L.Id_Recette,
                            L.LOT_Quantite,
                            E.ETA_Libelle AS Etat,
                            L.LOT_DateHeureCreation,
                            R.REC_Nom
                        FROM Lot L
                        LEFT JOIN Etat E ON L.Id_Etat = E.Id_Etat
                        LEFT JOIN Recette R ON L.Id_Recette = R.Id_Recette
                        ORDER BY L.LOT_DateHeureCreation DESC
                    ";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        adapter.Fill(dt);
                    }
                }

                RenommerColonnes(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors de la récupération de l'historique : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        // ─── RENOMMER LES COLONNES ────────────────────────────────────────
        private void RenommerColonnes(DataTable dt)
        {
            if (dt.Columns.Contains("Id_Lot"))
                dt.Columns["Id_Lot"].ColumnName = "ID";
            if (dt.Columns.Contains("LOT_Nom"))
                dt.Columns["LOT_Nom"].ColumnName = "Nom du lot";
            if (dt.Columns.Contains("REC_Nom"))
                dt.Columns["REC_Nom"].ColumnName = "Recette";
            if (dt.Columns.Contains("LOT_Quantite"))
                dt.Columns["LOT_Quantite"].ColumnName = "Quantité";
            if (dt.Columns.Contains("Etat"))
                dt.Columns["Etat"].ColumnName = "État";
            if (dt.Columns.Contains("LOT_DateHeureCreation"))
                dt.Columns["LOT_DateHeureCreation"].ColumnName = "Date Création";

            // Supprimer les colonnes inutiles
            if (dt.Columns.Contains("Id_Recette"))
                dt.Columns.Remove("Id_Recette");
        }

        // ✅ ÉVÉNEMENT TEXTCHANGED POUR RECHERCHE EN TEMPS RÉEL ──────────────
        private void TxtRecherche_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string recherche = txtRecherche.Text.Trim();

                if (string.IsNullOrEmpty(recherche))
                {
                    // Si vide, afficher tous les lots
                    AfficherDonnees(donneesCompletes);
                    MettreAJourLblResultats(donneesCompletes.Rows.Count);
                }
                else
                {
                    // Sinon, filtrer en mémoire (plus rapide)
                    DataTable dtFiltre = FiltrerDonnees(recherche);
                    AfficherDonnees(dtFiltre);
                    MettreAJourLblResultats(dtFiltre.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors de la recherche : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── FILTRER LES DONNÉES EN MÉMOIRE ───────────────────────────────
        private DataTable FiltrerDonnees(string recherche)
        {
            DataTable dtFiltre = donneesCompletes.Clone();
            recherche = recherche.ToLower();

            foreach (DataRow row in donneesCompletes.Rows)
            {
                string id = row["ID"].ToString().ToLower();
                string nom = row["Nom du lot"].ToString().ToLower();
                string recette = row["Recette"]?.ToString().ToLower() ?? "";

                if (id.Contains(recherche) || nom.Contains(recherche) || recette.Contains(recherche))
                {
                    dtFiltre.ImportRow(row);
                }
            }

            return dtFiltre;
        }

        // ─── BOUTON RECHERCHER ─────────────────────────────────────────────
        private void BtnRechercher_Click(object sender, EventArgs e)
        {
            TxtRecherche_TextChanged(null, null);
        }

        // ─── BOUTON RAFRAÎCHIR ─────────────────────────────────────────────
        private void BtnRafraichir_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            ChargerHistorique();
        }

        // ─── BOUTON EXPORTER ───────────────────────────────────────────────
        private void BtnExporter_Click(object sender, EventArgs e)
        {
            if (dgvHistorique.Rows.Count == 0)
            {
                MessageBox.Show("❌ Aucun lot à exporter", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Fichiers XML|*.xml|Fichiers CSV|*.csv|Tous les fichiers|*.*";
                sfd.FileName = $"Historique_Lots_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (sfd.FileName.EndsWith(".xml"))
                            ExporterXML(sfd.FileName);
                        else if (sfd.FileName.EndsWith(".csv"))
                            ExporterCSV(sfd.FileName);

                        MessageBox.Show("✅ Export réussi !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Erreur lors de l'export : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ─── EXPORTER EN XML ────────────────────────────────────────────────
        private void ExporterXML(string chemin)
        {
            DataTable dt = (DataTable)dgvHistorique.DataSource;
            dt.TableName = "Lots";
            dt.WriteXml(chemin);
        }

        // ─── EXPORTER EN CSV ────────────────────────────────────────────────
        private void ExporterCSV(string chemin)
        {
            using (var writer = new System.IO.StreamWriter(chemin, false, System.Text.Encoding.UTF8))
            {
                // En-têtes
                for (int i = 0; i < dgvHistorique.Columns.Count; i++)
                {
                    writer.Write(dgvHistorique.Columns[i].HeaderText);
                    if (i < dgvHistorique.Columns.Count - 1)
                        writer.Write(",");
                }
                writer.WriteLine();

                // Données
                foreach (DataGridViewRow row in dgvHistorique.Rows)
                {
                    for (int i = 0; i < dgvHistorique.Columns.Count; i++)
                    {
                        writer.Write(row.Cells[i].Value?.ToString() ?? "");
                        if (i < dgvHistorique.Columns.Count - 1)
                            writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }
        }

        // ─── DOUBLE CLIC SUR UNE LIGNE ────────────────────────────────────
        private void DgvHistorique_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idLot = (int)dgvHistorique.Rows[e.RowIndex].Cells["ID"].Value;
                AfficherDetailLot(idLot);
            }
        }

        // ─── OBTENIR LE DÉTAIL COMPLET D'UN LOT ────────────────────────────
        private void AfficherDetailLot(int idLot)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    // Récupérer infos lot
                    string queryLot = @"
                        SELECT 
                            L.LOT_Nom,
                            L.LOT_Quantite,
                            E.ETA_Libelle,
                            L.LOT_DateHeureCreation,
                            R.REC_Nom
                        FROM Lot L
                        LEFT JOIN Etat E ON L.Id_Etat = E.Id_Etat
                        LEFT JOIN Recette R ON L.Id_Recette = R.Id_Recette
                        WHERE L.Id_Lot = @id
                    ";

                    DataRow lotInfo = null;
                    using (MySqlCommand cmd = new MySqlCommand(queryLot, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idLot);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                                lotInfo = dt.Rows[0];
                        }
                    }

                    // Vérifier si lotInfo est null
                    if (lotInfo == null)
                    {
                        txtDetail.Text = "❌ Lot non trouvé dans la base de données.";
                        return;
                    }

                    // Récupérer historique événements
                    string queryEvenements = @"
                        SELECT 
                            EVE_Message,
                            DATE_FORMAT(EVE_DateHeure, '%d.%m.%Y %H:%i:%s') as EVE_DateHeure
                        FROM Evenement
                        WHERE Id_Lot = @id
                        ORDER BY EVE_DateHeure ASC
                    ";

                    List<string> evenements = new List<string>();
                    using (MySqlCommand cmd = new MySqlCommand(queryEvenements, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idLot);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string message = reader["EVE_Message"].ToString();
                                string horo = reader["EVE_DateHeure"] != DBNull.Value ? reader["EVE_DateHeure"].ToString() : "N/A";
                                evenements.Add($"  ⏱️  [{horo}] {message}");
                            }
                        }
                    }

                    // Construire le texte détaillé
                    string nomRecette = lotInfo["REC_Nom"] != DBNull.Value ? lotInfo["REC_Nom"].ToString() : "N/A";
                    string dateCreation = lotInfo["LOT_DateHeureCreation"] != DBNull.Value ? lotInfo["LOT_DateHeureCreation"].ToString() : "N/A";
                    string etat = lotInfo["ETA_Libelle"] != DBNull.Value ? lotInfo["ETA_Libelle"].ToString() : "N/A";

                    string detailComplet = $@"
╔═══════════════════════════════════════════════════════════════╗
║  📋 DÉTAIL DU LOT {idLot}
╚═══════════════════════════════════════════════════════════════╝

🏷️ ID Lot             : {idLot}
📦 Nom                : {lotInfo["LOT_Nom"]}
🔧 Recette            : {nomRecette}
📊 Quantité           : {lotInfo["LOT_Quantite"]} pièces
⚡ État               : {etat}
📅 Créé le            : {dateCreation}

╔═══════════════════════════════════════════════════════════════╗
║  📊 HISTORIQUE DES ÉVÉNEMENTS ({evenements.Count})
╚═══════════════════════════════════════════════════════════════╝
";

                    if (evenements.Count > 0)
                    {
                        foreach (string evt in evenements)
                        {
                            detailComplet += evt + Environment.NewLine;
                        }
                    }
                    else
                    {
                        detailComplet += "  ⓘ Aucun événement enregistré.";
                    }

                    txtDetail.Text = detailComplet;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors du chargement du détail : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

// ============================================================================
// Fichier     : UserControlHistorique.cs
// Auteurs     : Noé A-Hadi, Valentin Boegli
// Date        : Juin 2026
// Description : Interface d'affichage, de recherche et d'export de l'historique
//               des lots de production. Permet de consulter la traçabilité 
//               complète (détails et événements) d'un lot spécifique.
//
// Méthodes principales :
// - ChargerHistorique() : Récupère tous les lots depuis la BDD (DataTable).
// - FiltrerDonnees() : Effectue une recherche dynamique en mémoire.
// - ExporterXML() / ExporterCSV() : Exporte les données du DataGridView vers un fichier.
// - AfficherDetailLot() : Génère et affiche la traçabilité détaillée (événements) 
//                         d'un lot sélectionné par double-clic.
// ============================================================================

using System.Data;
namespace Squelette_M3
{
    public partial class UserControlHistorique : UserControl
    {
        private DataTable _donneesCompletes;

        /// <summary>
        /// Constructeur par défaut. Initialise le composant, charge l'historique 
        /// depuis la base de données et s'abonne à l'événement de recherche.
        /// </summary>
        public UserControlHistorique()
        {
            InitializeComponent();
            ChargerHistorique();
            txtRecherche.TextChanged += TxtRecherche_TextChanged;
        }

        // ─── CHARGER L'HISTORIQUE COMPLET ──────────────────────────────────
        /// <summary>
        /// Charge l'historique complet des lots depuis la base de données vers une DataTable en mémoire, 
        /// puis met à jour l'affichage dans le DataGridView.
        /// </summary>
        private void ChargerHistorique()
        {
            try
            {
                _donneesCompletes = Lot.GetAllAsDataTable();
                AfficherDonnees(_donneesCompletes);
                txtDetail.Text = "📋 Sélectionnez un lot pour voir son historique détaillé...";
                MettreAJourLblResultats(_donneesCompletes.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors du chargement : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── AFFICHER LES DONNÉES DANS LE DATAGRIDVIEW ─────────────────────
        /// <summary>
        /// Lie une DataTable au DataGridView pour afficher les données.
        /// </summary>
        /// <param name="dt">La DataTable contenant les données à afficher.</param>
        private void AfficherDonnees(DataTable dt)
        {
            dgvHistorique.DataSource = null;
            dgvHistorique.DataSource = dt;
            AjusterColonnes();
        }

        // ─── AJUSTER LA LARGEUR DES COLONNES ───────────────────────────────
        /// <summary>
        /// Ajuste la largeur des colonnes du DataGridView selon un dictionnaire prédéfini 
        /// pour optimiser la lisibilité des informations.
        /// </summary>
        private void AjusterColonnes()
        {
            if (dgvHistorique.Columns.Count == 0) return;

            Dictionary<string, int> largeurs = new Dictionary<string, int>
            {
                { "Id_Lot",                  50  },
                { "LOT_Nom",                 120 },
                { "REC_Nom",                 120 },
                { "LOT_Quantite",            80  },
                { "Etat",                    100 },
                { "LOT_DateHeureCreation",   140 }
            };

            foreach (var col in largeurs)
            {
                if (dgvHistorique.Columns.Contains(col.Key))
                    dgvHistorique.Columns[col.Key].Width = col.Value;
            }
        }

        // ─── METTRE À JOUR LE LABEL RÉSULTATS ──────────────────────────────
        /// <summary>
        /// Met à jour le texte du label affichant le nombre de résultats obtenus.
        /// </summary>
        /// <param name="nombre">Le nombre de lignes actuellement affichées.</param>
        private void MettreAJourLblResultats(int nombre)
        {
            lblResultats.Text = nombre == 0 ? "❌ Aucun résultat trouvé"
                              : nombre == 1 ? "✅ 1 lot trouvé"
                              : $"✅ {nombre} lots trouvés";
        }

        // ─── RECHERCHE EN TEMPS RÉEL ────────────────────────────────────────
        /// <summary>
        /// Événement déclenché à chaque modification du texte de recherche. 
        /// Filtre dynamiquement les données affichées.
        /// </summary>
        /// <param name="sender">L'objet ayant déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void TxtRecherche_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string recherche = txtRecherche.Text.Trim();

                if (string.IsNullOrEmpty(recherche))
                {
                    AfficherDonnees(_donneesCompletes);
                    MettreAJourLblResultats(_donneesCompletes.Rows.Count);
                }
                else
                {
                    DataTable dtFiltre = FiltrerDonnees(recherche);
                    AfficherDonnees(dtFiltre);
                    MettreAJourLblResultats(dtFiltre.Rows.Count);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors de la recherche : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── FILTRER LES DONNÉES EN MÉMOIRE ───────────────────────────────
        /// <summary>
        /// Filtre les données de l'historique en mémoire en fonction d'un texte de recherche.
        /// </summary>
        /// <param name="recherche">Le texte à rechercher (ID, Nom du lot ou Recette).</param>
        /// <returns>Une DataTable clonée contenant uniquement les lignes correspondant à la recherche.</returns>
        private DataTable FiltrerDonnees(string recherche)
        {
            DataTable dtFiltre = _donneesCompletes.Clone();// Crée une copie de la structure du DataTable complet
            recherche = recherche.ToLower();

            foreach (DataRow row in _donneesCompletes.Rows)
            {
                string id = row["Id_Lot"].ToString().ToLower();
                string nom = row["LOT_Nom"].ToString().ToLower();
                string recette = row["REC_Nom"]?.ToString().ToLower() ?? "";

                if (id.Contains(recherche) || nom.Contains(recherche) || recette.Contains(recherche))
                    dtFiltre.ImportRow(row);
            }

            return dtFiltre;
        }

        // ─── BOUTON RECHERCHER ─────────────────────────────────────────────
        /// <summary>
        /// Déclenche manuellement la recherche (identique au changement de texte).
        /// </summary>
        /// <param name="sender">L'objet ayant déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void BtnRechercher_Click(object sender, EventArgs e)
        {
            TxtRecherche_TextChanged(sender, e);
        }

        // ─── BOUTON RAFRAÎCHIR ─────────────────────────────────────────────
        /// <summary>
        /// Efface le champ de recherche et recharge complètement les données depuis la base de données.
        /// </summary>
        /// <param name="sender">L'objet ayant déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void BtnRafraichir_Click(object sender, EventArgs e)
        {
            txtRecherche.Clear();
            ChargerHistorique();
        }

        // ─── BOUTON EXPORTER ───────────────────────────────────────────────
        /// <summary>
        /// Ouvre une boîte de dialogue pour permettre à l'utilisateur d'exporter 
        /// les données actuellement affichées au format XML ou CSV.
        /// </summary>
        /// <param name="sender">L'objet ayant déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void BtnExporter_Click(object sender, EventArgs e)
        {
            if (dgvHistorique.Rows.Count == 0)
            {
                MessageBox.Show("❌ Aucun lot à exporter", "Attention",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                        MessageBox.Show("✅ Export réussi !", "Succès",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"❌ Erreur lors de l'export : {ex.Message}",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // ─── EXPORTER EN XML ────────────────────────────────────────────────
        /// <summary>
        /// Exporte la DataTable sous-jacente du DataGridView dans un fichier XML.
        /// </summary>
        /// <param name="chemin">Le chemin complet du fichier de destination.</param>
        private void ExporterXML(string chemin)
        {
            DataTable dt = dgvHistorique.DataSource as DataTable;
            if (dt == null) return;

            dt.TableName = "Lots";
            dt.WriteXml(chemin);
        }

        // ─── EXPORTER EN CSV ────────────────────────────────────────────────
        /// <summary>
        /// Parcourt les lignes du DataGridView et les exporte dans un fichier CSV.
        /// </summary>
        /// <param name="chemin">Le chemin complet du fichier de destination.</param>
        private void ExporterCSV(string chemin)
        {
            using (var writer = new System.IO.StreamWriter(chemin, false, System.Text.Encoding.UTF8))
            {
                // En-têtes
                for (int i = 0; i < dgvHistorique.Columns.Count; i++)
                {
                    writer.Write(dgvHistorique.Columns[i].HeaderText);
                    if (i < dgvHistorique.Columns.Count - 1) writer.Write(",");
                }
                writer.WriteLine();

                // Données
                foreach (DataGridViewRow row in dgvHistorique.Rows)
                {
                    for (int i = 0; i < dgvHistorique.Columns.Count; i++)
                    {
                        writer.Write(row.Cells[i].Value?.ToString() ?? "");
                        if (i < dgvHistorique.Columns.Count - 1) writer.Write(",");
                    }
                    writer.WriteLine();
                }
            }
        }

        // ─── DOUBLE CLIC SUR UNE LIGNE ────────────────────────────────────
        /// <summary>
        /// Récupère l'ID du lot de la ligne sélectionnée (par double-clic) 
        /// et affiche ses détails et son historique d'événements.
        /// </summary>
        /// <param name="sender">L'objet ayant déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement (contenant l'index de la ligne).</param>
        private void DgvHistorique_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            object cellValue = dgvHistorique.Rows[e.RowIndex].Cells["Id_Lot"].Value;
            if (cellValue == null || cellValue == DBNull.Value) return;

            int idLot = Convert.ToInt32(cellValue);
            AfficherDetailLot(idLot);
        }

        // ─── AFFICHER LE DÉTAIL COMPLET D'UN LOT ───────────────────────────
        /// <summary>
        /// Interroge la base de données pour récupérer les informations générales d'un lot 
        /// ainsi que la liste de tous ses événements (traçabilité), et formate l'affichage dans la zone de texte.
        /// </summary>
        /// <param name="idLot">L'identifiant unique du lot à afficher.</param>
        private void AfficherDetailLot(int idLot)
        {
            try
            {
                DataRow lotInfo = Lot.GetById(idLot);
                List<Evenement> evts = Evenement.GetByLotId(idLot);

                if (lotInfo == null)
                {
                    txtDetail.Text = "❌ Lot non trouvé dans la base de données.";
                    return;
                }

                string nomRecette = lotInfo["REC_Nom"] != DBNull.Value ? lotInfo["REC_Nom"].ToString() : "N/A";
                string dateCreation = lotInfo["LOT_DateHeureCreation"] != DBNull.Value ? lotInfo["LOT_DateHeureCreation"].ToString() : "N/A";
                string etat = lotInfo["ETA_Libelle"] != DBNull.Value ? lotInfo["ETA_Libelle"].ToString() : "N/A";

                string detail = $@"
╔═══════════════════════════════════════════════════════════════╗
║  📋 DÉTAIL DU LOT {idLot}
╚═══════════════════════════════════════════════════════════════╝

🏷️  Nom      : {lotInfo["LOT_Nom"]}
🔧  Recette  : {nomRecette}
📊  Quantité : {lotInfo["LOT_Quantite"]} pièces
⚡  État     : {etat}
📅  Créé le  : {dateCreation}

╔═══════════════════════════════════════════════════════════════╗
║  📊 HISTORIQUE DES ÉVÉNEMENTS ({evts.Count})
╚═══════════════════════════════════════════════════════════════╝
";
                if (evts.Count > 0)
                    foreach (Evenement evt in evts)
                        detail += $"  ⏱️  [{evt.EVE_DateHeure:dd.MM.yyyy HH:mm:ss}] {evt.EVE_Message}{Environment.NewLine}";
                else
                    detail += "  ⓘ Aucun événement enregistré.";

                txtDetail.Text = detail;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Erreur lors du chargement du détail : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

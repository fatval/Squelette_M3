/*
 * Auteurs : Noé A-Hadi, Valentin Boegli
 * Date    : 2026
 * Description : Classe Contenir - Table de liaison entre Operation et Recette.
 *               Associe une opération à une recette et définit son ordre d'exécution.
 *
 * Propriétés :
 * - Id_Operation_est_contenu_dans : Identifiant de l'opération (FK → Operation).
 * - Id_Recette                    : Identifiant de la recette (FK → Recette).
 * - CON_NoOperation               : Ordre de l'opération dans la recette (1 à 10).
 *
 * Remarque :
 * - La clé primaire de cette table est composée : Id_Operation_est_contenu_dans + Id_Recette.
 * - Utilisation : Cette classe a été modélisée pour refléter fidèlement la structure 
 *   de la base de données. Cependant, dans la logique applicative (WinForms), 
 *   ces getters/setters ne sont pas directement utilisés car l'affichage des opérations 
 *   d'une recette est géré de manière plus optimisée via des requêtes SQL (JOIN), ce qui 
 *   facilite grandement le DataBinding avec les DataGridViews.
 */

namespace Squelette_M3
{
    internal class Contenir
    {
        // ─── Propriétés ──────────────────────────────────────────────────────
        public int Id_Operation_est_contenu_dans { get; set; }  // FK → Operation (PK composée)
        public int Id_Recette { get; set; }                     // FK → Recette   (PK composée)
        public int CON_NoOperation { get; set; }                // Ordre dans la recette (1 à 10)
    }
}

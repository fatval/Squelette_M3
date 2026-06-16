/*
 * Auteurs : Noé A-Hadi, Valentin Boegli
 * Date    : 12.06.2026
 * Description : Classe Etat - Représente la table de référence des états d'un lot.
 *               Définit le statut actuel (Ex: En attente, En production, Terminé, En erreur).
 *
 * Propriétés :
 * - Id_Etat      : Identifiant unique de l'état (PK).
 * - ETA_Libelle  : Libellé de l'état.
 *
 * Remarques :
 * - Cette classe a été créée pour maintenir une cohérence stricte avec la structure 
 *   de la base de données (MLD). 
 * - Dans la pratique (WinForms), les getters/setters de cette classe ne sont pas 
 *   explicitement appelés. Le libellé de l'état (ETA_Libelle) est récupéré directement 
 *   via une jointure SQL (JOIN) dans la classe Lot (qui agit comme DTO). Cela évite 
 *   de complexifier inutilement le code et facilite le DataBinding dans l'interface.
 */

namespace Squelette_M3
{
    internal class Etat
    {
        // ─── Propriétés ──────────────────────────────────────────────────────
        public int Id_Etat { get; set; }         // PK
        public string ETA_Libelle { get; set; }  // Ex: "En attente", "En production", "Terminé", "En erreur"
    }
}

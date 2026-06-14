/*
 * Auteur  : Noé A-Hadi, Valentin Boegli
 * Date    : 12.06.2026
 * Description : Classe Operation - Représente une opération (pas) d'une recette de production.
 *
 * Propriétés :
 * - Id_Operation       : Identifiant unique de l'opération.
 * - OPE_Nom            : Nom de l'opération.
 * - OPE_PositionMoteur : Position du moteur (3h, 6h, 9h, 12h).
 * - OPE_TempsAttente   : Temps d'arrêt en secondes.
 * - OPE_CycleVerin     : Indique si un cycle vérin est requis.
 * - OPE_Quittance      : Indique si une quittance manuelle est requise.
 * - OPE_SensMoteur     : Sens de rotation du moteur.
 */

namespace Squelette_M3
{
    public class Operation
    {
        public int Id_Operation { get; set; }           // PK
        public string OPE_Nom { get; set; } = "";       // Nom de l'opération
        public int OPE_PositionMoteur { get; set; }     // Position du moteur : 3, 6, 9, 12h
        public int OPE_TempsAttente { get; set; }       // Temps d'arrêt en secondes
        public bool OPE_CycleVerin { get; set; }        // Cycle vérin requis
        public bool OPE_Quittance { get; set; }         // Quittance manuelle requise
        public bool OPE_SensMoteur { get; set; }        // Sens de rotation du moteur
    }
}

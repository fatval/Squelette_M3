namespace M3.Models
{
    public class Operation
    {
        public int Id_Operation { get; set; }
        public int OPE_Ordre { get; set; }           // CON_NoOperation dans contenir table associative
        public string OPE_Nom { get; set; } = "";
        public int OPE_PositionMoteur { get; set; }  // 3, 6, 9, 12
        public int OPE_TempsAttente { get; set; }    // En secondes
        public bool OPE_CycleVerin { get; set; }
        public bool OPE_Quittance { get; set; }
        public bool OPE_SensMoteur { get; set; }


        public string OPE_Description
        {
            get
            {
                return $"Opération {OPE_Ordre}: {OPE_Nom}, Position Moteur: {OPE_PositionMoteur}h, Temps d'attente: {OPE_TempsAttente}s, Cycle Vérin: {(OPE_CycleVerin ? "Oui" : "Non")}, Quittance: {(OPE_Quittance ? "Oui" : "Non")}, Sens Moteur: {(OPE_SensMoteur ? "Horaire" : "Anti-horaire")}";
            }
        }
        /// <summary>
        /// Méthode de création d'une opération avec tous les paramètres requis
        /// </summary>
        /// <param name="id">L'identifiant de l'opération</param>
        /// <param name="ordre">L'ordre de l'opération</param>
        /// <param name="nom">Le nom de l'opération</param>
        /// <param name="positionMoteur">La position du moteur</param>
        /// <param name="tempsAttente">Le temps d'attente en secondes</param>
        /// <param name="cycleVerin">Indique si l'opération implique un cycle de vérin</param>
        /// <param name="quittance">Indique si l'opération implique une quittance</param>
        /// <param name="sensMoteur">Indique le sens du moteur</param>
        /// <returns></returns>
        public static Operation Create(int id, int ordre, string nom, int positionMoteur, int tempsAttente, bool cycleVerin, bool quittance, bool sensMoteur)
        {
            return new Operation
            {
                Id_Operation = id,
                OPE_Ordre = ordre,
                OPE_Nom = nom,
                OPE_PositionMoteur = positionMoteur,
                OPE_TempsAttente = tempsAttente,
                OPE_CycleVerin = cycleVerin,
                OPE_Quittance = quittance,
                OPE_SensMoteur = sensMoteur
            };
        }
    }
}

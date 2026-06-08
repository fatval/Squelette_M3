using MySql.Data.MySqlClient;

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
    }
}
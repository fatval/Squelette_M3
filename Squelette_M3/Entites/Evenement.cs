using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace M3.Models
{
    internal class Evenement
    {
        public int Id_Evenement {  get; set; }
        public string EVE_Message {  get; set; }
        public DateTime EVE_DateHeure { get; set; }
        public int Id_Lot {  get; set; }
    
    }

    

}


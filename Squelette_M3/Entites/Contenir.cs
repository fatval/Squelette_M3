using System;
using System.Collections.Generic;
using System.Text;

namespace Squelette_M3.Entites
{
    internal class Contenir
    {
        //primary key ==  Id_Operation_est_contenu_dans + Id_Recette

        // CON_NoOperation int
        //getter et setter de l'ordre de l'opération dans la recette

        public int ID_Operation { get; set; }
        public int ID_Recette { get; set; }

        public int CON_NoOperation { get; set; } // Ordre de l'opération dans la recette
    }
}

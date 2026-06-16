// ============================================================================
// Fichier     : Program.cs
// Auteurs     : Noé A-Hadi, Valentin Boegli
// Date        : Juin 2026
// Description : Point d'entrée principal de l'application. Initialise les
//               paramètres d'affichage, établit la connexion à la base de
//               données et lance le formulaire principal.
// ============================================================================

using System;
using System.Windows.Forms;

namespace Squelette_M3
{
    internal static class Program
    {
        // ─── POINT D'ENTRÉE PRINCIPAL ─────────────────────────────────────────
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Permet à l'application de s'adapter à la résolution de l'écran et ne pas tenir compte du scaling windows
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            ApplicationConfiguration.Initialize();

            DBManager.ConnectToDB("m3", "root", "");
            Application.Run(new FormMain());

            // Initialisation de la connexion à la base de données MySQL (ici projet scolaire avec DB en local, mais en réalité on aurait gérer le MDP différemment, avec un USER SECRET)
            DBManager.ConnectToDB("m3", "root", "");

        }
    }
}

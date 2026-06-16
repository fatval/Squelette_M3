namespace Squelette_M3
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.SetHighDpiMode(HighDpiMode.SystemAware); //Permet à l'application de s'adapter à la résolution de l'écran et ne pas tenir compte du scaling windows
            ApplicationConfiguration.Initialize();
            Application.Run(new FormMain());

            // Initialisation de la connexion à la base de données MySQL (ici projet scolaire avec DB en local, mais en réalité on aurait gérer le MDP différemment, avec un USER SECRET)
            DBManager.ConnectToDB("m3", "root", "");

        }
    }
}
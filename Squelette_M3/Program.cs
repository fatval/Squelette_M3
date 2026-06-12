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
            DBManager.ConnectToDB("m3", "root", "");
            Application.Run(new FormMain());


        }
    }
}
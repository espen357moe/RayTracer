namespace RayTracer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();            
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new();
            
            Application.Run(form);            
        }
    }
}
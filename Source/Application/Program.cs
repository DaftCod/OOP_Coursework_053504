using System;
using System.Windows.Forms;
using MVC;

namespace Laba2
{
    static class Program
    {
        public static Controller Controller = null;
        public static ViewModel ViewModel = null;
        public static DomainModel.DomainModel DomainModel = null;
        public static MVC.View View = null;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            InitializeMVC();
            Application.Run(View.GetMainForm());
        }

        private static void InitializeMVC()
        {
            // Creating Model, View, Controller
            ViewModel = new ViewModel();
            DomainModel = new DomainModel.DomainModel();
            View = new MVC.View();
            Controller = new Controller(ViewModel, DomainModel, View);

            // Initializing Model, View, Controller
            Controller.Initialize();
            View.Initialize(ViewModel);
            DomainModel.Initialize(View.Graphics);

            // Start application with initial commands
            Controller.StartUp();
        }
    }
}
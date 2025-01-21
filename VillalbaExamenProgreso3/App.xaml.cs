using System;
using System.IO;

namespace VillalbaExamenProgreso3
{
    public partial class App : Application
    {
        public static string DatabasePath { get; private set; }

        public App()
        {
            InitializeComponent();

            
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            DatabasePath = Path.Combine(folderPath, "VillalbaExamenProgreso3.db3");

            MainPage = new AppShell();
        }
    }
}

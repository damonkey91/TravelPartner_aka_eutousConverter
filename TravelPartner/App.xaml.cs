using System;
using System.IO;
using TravelPartner.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TravelPartner
{
    public partial class App : Application
    {
        private static SQLiteHelper database;

        public static SQLiteHelper Database
        {
            get
            {
                if (database == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Currency.db3");
                    database = new SQLiteHelper(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomeTabbedPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

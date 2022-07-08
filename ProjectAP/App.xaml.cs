using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ProjectAP.Sources;
using ProjectAP.Sources.Accounts;

namespace ProjectAP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            DataManager.Save();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DataManager.Load();
            //DataManager.AddAccount(new Admin("name", "name", "Admin@gmail.com", "09385017532", "Admin1234"));
        }
    }
}

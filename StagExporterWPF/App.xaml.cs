using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace TakholtasponWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string TokenName = "token.json";

        /// <summary>
        /// odebrani Google tokenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            try
            {
                var dir = new DirectoryInfo(System.AppDomain.CurrentDomain.BaseDirectory + TokenName);
                if (dir.Exists) dir.Delete(true);
            }
            catch
            {

            }
        }
    }
}

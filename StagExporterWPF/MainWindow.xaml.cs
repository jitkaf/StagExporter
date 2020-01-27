using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ConsoleApp1.Export;
using App1;
using ConsoleApp1.Stag;
using Properties.Settings.Default;
using ConsoleApp1.DataAcces.StagWS;
using Properties.Settings.Default;

namespace TakholtasponWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Current;

        public MainWindow()
        {
            VydolovavacUniverzit vydolovavac = new VydolovavacUniverzit();
            if (vydolovavac.NactiXMLZeStagu(Stringy.urlZakaznici))
                 vydolovavac.ZiskejData();

            InitializeComponent();
            Current = this;
            mainFrame.Navigate(new MainPage());
        }
    }
}

using System;

using ConsoleApp1.Stag;
using ConsoleApp1.Export;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows;
using System.Collections.Generic;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
 
    public sealed partial class DruhaStrana : Page
    {
        
        public DruhaStrana()
        {
            this.InitializeComponent();

            rozvrhoveAkceLV.ItemsSource = Uzivatel.RozvrhoveAkce;
        }

        private async void export_Click(object sender, RoutedEventArgs e)
        {
            export.IsEnabled = false;
            pbStatus.Visibility = Visibility.Visible;
            tbStatus.Text = "Tvoření záznamů pro kalendář.";

            await Task.Run(() => new TvoricZaznamuProGoogleKalendar().VytvorZaznamyProGoogleKalendar());

            tbStatus.Text = "Záznamy pro kalendář byly vytvořeny.";
            tbStatus.Text = "Export záznamů do google kalendáře.";

            await Task.Run(() => new Exporter().SpustExport());

            tbStatus.Text = "Záznamy byly exportovány.";
            pbStatus.Visibility = Visibility.Hidden;
            export.IsEnabled = true;
        }
    }
}

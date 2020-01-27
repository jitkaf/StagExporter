using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ConsoleApp1.Stag;
using Properties.Settings.Default;
using System.Windows.Controls;
using System.Windows;
using TakholtasponWPF;
using ConsoleApp1.Stag.Harmonogram;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
using TakholtasponWPF.Managers;
namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            osobniCisloTB.Text = Uzivatel.OsobniCislo;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            Uzivatel.OsobniCislo = textbox.Text;
            Uzivatel.UdajeSpravne = true;
        }

        /// <summary>
        /// V pripade pozadavku na harmonogram zavola metody pro jeho tvoreni. V pripade absence osobniho cisla, upozorni uzivatele.
        /// Zavola dolovani rozvrhovych akci.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Uzivatel.Vycistit();
            if ((Uzivatel.ChceIHarmonogram == true) && (!Uzivatel.HarmonogramVygenerovan))
            {
                TvoricHarmonogramu tvoricH = new TvoricHarmonogramu();
            }

            TvoricRozvrhu tvoricR = new TvoricRozvrhu();
            if (Uzivatel.UdajeSpravne)
            {
                this.chyba.Text = "";
                MainWindow.Current.mainFrame.Navigate(new DruhaStrana());
            }
            else
            {
                this.chyba.Text = Uzivatel.ChybovaHlaska;            
            }
        }

        private void chbHarmonogram_Checked(object sender, RoutedEventArgs e)
        {
            Uzivatel.ChceIHarmonogram = true;
        }

        private void chbHarmonogram_Unchecked(object sender, RoutedEventArgs e)
        {
            Uzivatel.ChceIHarmonogram = false;
        }

        /// <summary>
        /// Stara se o vyber univerzity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void university_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            var pom = combobox.SelectedValue;
            foreach (var value in Uzivatel.Zakaznici)
            {
                if (value.Equals(pom))
                {
                    Uzivatel.UrlSkoly = value.UrlSkoly;
                    Uzivatel.UdajeSpravne = true;
                    break;
                }
            }
           
        }

        private void kalendarTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            Uzivatel.Kalendar = textbox.Text;
        }

        private void kalendarTB_Loaded(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;
            textbox.Text = Uzivatel.Kalendar;
        }

        /// <summary>
        /// Unicializuje univerzity.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void university_Initialized(object sender, EventArgs e)
        {
            var comboBox = sender as ComboBox;
            comboBox.ItemsSource = Uzivatel.Zakaznici;
            comboBox.SelectedIndex = Uzivatel.Zakaznici.Count - 1;
        }
    }
}

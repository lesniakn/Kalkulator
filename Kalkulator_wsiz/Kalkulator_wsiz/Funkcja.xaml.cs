using System;
using System.Windows;
using System.Windows.Controls;

namespace Kalkulator_wsiz
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Funkcja : Page
    {
        public Funkcja()
        {
            InitializeComponent();
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {

            (sender as TextBox).Clear();

        }
    }
}
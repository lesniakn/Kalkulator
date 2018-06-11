using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private void Delete_btn_Click(object senders, RoutedEventArgs e)
        {

            wyczysc_btn.Visibility = Visibility.Hidden;
            tb_a.Text = string.Empty;
            tb_b.Text = string.Empty;
            tb_c.Text = string.Empty;
            tb_result.Text = string.Empty;
            tb_result2.Text = string.Empty;
            tb_result3.Text = string.Empty;
            tb_result4.Text = string.Empty;
            tb_result5.Text = string.Empty;
            tb_result6.Text = string.Empty;
            tb_result7.Text = string.Empty;
            tb_a.IsEnabled = true;
            tb_b.IsEnabled = true;
            tb_c.IsEnabled = true;
            tb_a.Text = "a";
            tb_b.Text = "b";
            tb_c.Text = "c";
            oblicz_btn.IsEnabled = true;
            this.Width = 400;
            //wykres
            wykres_btn.IsEnabled = false;
            wykres_btn.Visibility = Visibility.Hidden;
            wykres1.Visibility = Visibility.Hidden;
            wykres2.Visibility = Visibility.Hidden;
            wykres3.Visibility = Visibility.Hidden;
            wykres4.Visibility = Visibility.Hidden;
            tb_result8.Visibility = Visibility.Hidden;
            tb_result9.Visibility = Visibility.Hidden;
            tb_result10.Visibility = Visibility.Hidden;
            tb_result11.Visibility = Visibility.Hidden;


        }
        private void wykres_btn_Click(object sender, RoutedEventArgs e)
        {

            double a = Convert.ToDouble(tb_a.Text);
            double b = Convert.ToDouble(tb_b.Text);
            double c = Convert.ToDouble(tb_c.Text);
            double obl_delta;//delta

            double x1;//miejsce zerowe1
            double x2;//miejsce zerowe2
            double p;//wierzchołek funkcji
            double q;//wierzchołek funkcji
            obl_delta = (b * b) - 4 * a * c;
            p = ((-b) / (2 * a));
            q = ((-obl_delta) / (4 * a));
            x1 = (-b - Math.Sqrt(obl_delta)) / (2 * a);
            x2 = (-b + Math.Sqrt(obl_delta)) / (2 * a);


            if (a > 0 & obl_delta > 0)
            {
                wykres1.Visibility = Visibility;
                tb_result8.Visibility = Visibility;
                tb_result9.Visibility = Visibility;
                tb_result10.Visibility = Visibility;
                tb_result10.Text = "(" + Math.Round(p, 2) + ";" + Math.Round(q, 2) + ")";
                tb_result8.Text = "(" + Math.Round(x1, 2) + ";" + "0)";
                tb_result9.Text = "(" + Math.Round(x2, 2) + ";" + "0)";
            }
            if (a < 0 & obl_delta > 0)
            {
                wykres2.Visibility = Visibility;
                tb_result11.Visibility = Visibility;
                tb_result8.Visibility = Visibility;
                tb_result9.Visibility = Visibility;
                tb_result11.Text = "(" + Math.Round(p, 2) + ";" + Math.Round(q, 2) + ")";
                tb_result8.Text = "(" + Math.Round(x1, 2) + ";" + "0)";
                tb_result9.Text = "(" + Math.Round(x2, 2) + ";" + "0)";
            }
            if (a < 0 & obl_delta < 0)
            {
                wykres3.Visibility = Visibility;
                tb_result11.Visibility = Visibility;
                tb_result11.Text = "(" + Math.Round(p, 2) + ";" + Math.Round(q, 2) + ")";
            }
            if (a > 0 & obl_delta < 0)
            {
                wykres4.Visibility = Visibility;
                tb_result10.Visibility = Visibility;
                tb_result10.Text = "(" + Math.Round(p, 2) + ";" + Math.Round(q, 2) + ")";
            }

            wykres_btn.IsEnabled = false;

        }

        private void draw_btn_Click(object sender, RoutedEventArgs e)
        {
            if (tb_a.Text == "a" | tb_b.Text == "b" | tb_c.Text == "c")
            {
                tb_a.Text = string.Empty;
                tb_b.Text = string.Empty;
                tb_c.Text = string.Empty;
                tb_a.Text = "a";
                tb_b.Text = "b";
                tb_c.Text = "c";
                MessageBox.Show("Brak danych !");
                return;
            }

            else if (tb_a.Text == string.Empty & tb_a.Text == string.Empty & tb_a.Text == string.Empty)
            {
                tb_a.Text = string.Empty;
                tb_b.Text = string.Empty;
                tb_c.Text = string.Empty;
                tb_a.Text = "a";
                tb_b.Text = "b";
                tb_c.Text = "c";
                MessageBox.Show("Brak danych !");
                return;
            }


            wyczysc_btn.Visibility = Visibility;
            double a = Convert.ToDouble(tb_a.Text);
            double b = Convert.ToDouble(tb_b.Text);
            double c = Convert.ToDouble(tb_c.Text);
            double obl_delta;//delta
            double x1;//miejsce zerowe1
            double x2;//miejsce zerowe2
            double p;//wierzchołek funkcji
            double q;//wierzchołek funkcji
            double zw1;//zbiór wartości, delta > 0
            double zw2;//zbiór wartości, delta < 0

            tb_result.Text = string.Empty;
            tb_result2.Text = string.Empty;
            tb_result3.Text = string.Empty;
            tb_result4.Text = string.Empty;
            tb_result5.Text = string.Empty;
            tb_result6.Text = string.Empty;
            tb_result7.Text = string.Empty;
            tb_a.IsEnabled = false;
            tb_b.IsEnabled = false;
            tb_c.IsEnabled = false;
            oblicz_btn.IsEnabled = false;

            wykres_btn.Visibility = Visibility;
            wykres_btn.IsEnabled = true;


            //Warunek dla istnienia funkcji kwadratowej
            if (a != 0)
            {
                obl_delta = (b * b) - 4 * a * c;

                tb_result.Text = "Δ = " + Math.Round(obl_delta, 2).ToString();
                //Delta = 0
                if (obl_delta == 0)
                {
                    x1 = x2 = -b / (2 * a);
                    tb_result2.Text = "Δ równa 0: \nx1 wynosi : " + Math.Round(x1, 2);

                }
                //Delta > 0
                else if (obl_delta > 0)
                {
                    x1 = (-b - Math.Sqrt(obl_delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(obl_delta)) / (2 * a);
                    tb_result2.Text = "Δ większa od 0: \nx1: " + Math.Round(x1, 2) + "\nx2: " + Math.Round(x2, 2);

                }
                //Delta < 0
                else if (obl_delta < 0)
                {
                    tb_result2.Text = "Brak rozwiązań. Δ ujemna!";
                }
                //Zbiór wartości
                {
                    if (a > 0)
                    {
                        zw1 = (-obl_delta / 4 * a);
                        tb_result3.Text = "Zbiór wartości funkcji:" + "\n(" + Math.Round(zw1, 2) + " ,+ ∞ )";
                    }
                    else if (a < 0)
                    {
                        zw2 = (-obl_delta / 4 * a);
                        tb_result3.Text = "Zbiór wartości funkcji:" + "\n(- ∞, " + Math.Round(zw2, 2) + ")";
                    }
                }

                // Wierzchołek paraboli
                p = ((-b) / (2 * a));
                q = ((-obl_delta) / (4 * a));
                tb_result4.Text = "p = " + Math.Round(p, 2) + " , q = " + Math.Round(q, 2) + ", W = (" + Math.Round(p, 2) + ";" + Math.Round(q, 2) + ")";

                // Monotoniczność funkcji
                {
                    if (a > 0)
                    {
                        tb_result5.Text = "Funkcja jest malejąca w przedziale: " + "(- ∞ ," + Math.Round(p, 2) + ")"
                        + "\nFunkcja jest rosnąca w przedziale: " + "( " + Math.Round(p, 2) + ", + ∞)";

                    }
                    else
                    {
                        tb_result5.Text = "Funkcja jest rosnąca w przedziale: " + "(-∞ ," + Math.Round(p, 2) + ")"
                        + "\nFunkcja jest malejąca w przedziale: " + "( " + Math.Round(p, 2) + ", + ∞)";


                    }
                }

                //Dziedzina Funkcji
                {
                    if (a > 0)
                    {
                        tb_result6.Text = "Dziedzina funkcji: " + "\n( " + Math.Round(q, 2) + ", + ∞)";
                    }
                    else
                    {
                        tb_result6.Text = "Dziedzina funkcji: " + "\n(- ∞ ," + Math.Round(q, 2) + ")";

                    }
                }


                //Postacie funkcji dla delty równej 0
                if (obl_delta == 0)
                {

                    if ((x1 = x2 = -b / (2 * a)) < 0)
                    {

                        tb_result7.Text = "Postać iloczynowa: " + a + "(x + " + (-1) * x1 + ")^2" + "\nPostać kanoniczna: " + a + "(x " + p + ") + " + q +
                             "\nPostać ogólna: " + a + "x^2 + " + b + "x + " + c;

                    }
                    else
                    {

                        tb_result7.Text = "Postać iloczynowa: " + a + "(x " + (-1) * x1 + ")^2" + "\nPostać kanoniczna: " + a + "(x + " + p + ") + " + q +
                             "\nPostać ogólna: " + a + "x^2 + " + b + "x + " + c;

                    }
                }
                //Postacie funckji dla dlety większej od 0
                if (obl_delta > 0)
                {
                    x1 = (-b - Math.Sqrt(obl_delta)) / (2 * a);
                    x2 = (-b + Math.Sqrt(obl_delta)) / (2 * a);

                    if (x1 > 0 & x2 > 0 & p >= 0 & q >= 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(a, 2) + "(x -" + Math.Round(x1, 2) + ")*(x - " + Math.Round(x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(a, 2) + "(x " + Math.Round(p, 2) + ") + " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 + " + Math.Round(b, 2) + "x + " + Math.Round(c, 2);
                    }
                    if (x1 < 0 & x2 < 0 & p < 0 & q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(a, 2) + "(x " + Math.Round(-x1, 2) + ")*(x + " + Math.Round(-x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(a, 2) + "(x + " + Math.Round(-p, 2) + ")  " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 + " + Math.Round(b, 2) + "x + " + Math.Round(c, 2);
                    }
                    if (x1 > 0 & x2 < 0 & p < 0 & q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(a, 2) + "(x " + Math.Round(-x1, 2) + ")*(x + " + Math.Round(-x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(a, 2) + "(x + " + Math.Round(-p, 2) + ")  " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 + " + Math.Round(b, 2) + "x + " + Math.Round(c, 2);
                    }
                    if (x1 < 0 & x2 > 0 & p < 0 & q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(a, 2) + "(x +" + Math.Round(-x1, 2) + ")*(x " + Math.Round(-x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(a, 2) + "(x + " + Math.Round(-p, 2) + ")  " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 + " + Math.Round(b, 2) + "x " + Math.Round(c, 2);
                    }
                    if (x1 > 0 & x2 < 0 & p > 0 & q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(a, 2) + "(x " + Math.Round(-x1, 2) + ")*(x " + Math.Round(-x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(a, 2) + "(x + " + Math.Round(-p, 2) + ")  " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 + " + Math.Round(b, 2) + "x " + Math.Round(c, 2);
                    }
                    if (x1 > 0 & x2 < 0 & p > 0 & q > 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(a, 2) + "(x " + Math.Round(-x1, 2) + ")*(x + " + Math.Round(-x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(a, 2) + "(x " + Math.Round(-p, 2) + ") + " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 + " + Math.Round(b, 2) + "x + " + Math.Round(c, 2);
                    }


                }
                // postacie funkcji dla delty mniejszej od 0
                else if (obl_delta < 0)// brak postaci iloczynowej
                {
                    if (p < 0 & b >= 0)
                    {
                        tb_result7.Text = "Brak postaci iloczynowej" + "\nPostać kanoniczna: " + a + "(x " + Math.Round(p, 2) + ") + " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 +" + Math.Round(b, 2) + "x + " + Math.Round(c, 2);
                    }
                    if (p > 0)
                    {
                        tb_result7.Text = "Brak postaci iloczynowej" + "\nPostać kanoniczna: " + a + "(x +" + Math.Round(p, 2) + ") " + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 +" + Math.Round(b, 2) + "x " + Math.Round(c, 2);
                    }
                    if (p > 0 & b < 0)
                    {
                        tb_result7.Text = "Brak postaci iloczynowej" + "\nPostać kanoniczna: " + a + "(x +" + Math.Round(p, 2) + ") +" + Math.Round(q, 2) +
                             "\nPostać ogólna: " + Math.Round(a, 2) + "x^2 " + Math.Round(b, 2) + "x +" + Math.Round(c, 2);
                    }

                }


            }
            else
            {
                wyczysc_btn.Visibility = Visibility.Hidden;
                MessageBox.Show("To nie jest funkcja kwadratowa! \nZmienna a musi być różna od 0.");
                tb_a.Text = string.Empty;
                tb_b.Text = string.Empty;
                tb_c.Text = string.Empty;
                tb_a.Text = "a";
                tb_b.Text = "b";
                tb_c.Text = "c";
                tb_result.Text = string.Empty;
                tb_result2.Text = string.Empty;
                tb_result3.Text = string.Empty;
                tb_result4.Text = string.Empty;
                tb_result5.Text = string.Empty;
                tb_result6.Text = string.Empty;
                tb_result7.Text = string.Empty;
                oblicz_btn.IsEnabled = true;
                tb_a.IsEnabled = true;
                tb_b.IsEnabled = true;
                tb_c.IsEnabled = true;


            }


        }
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {

                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.Subtract:
                case Key.OemMinus:

                    break;


                default:

                    e.Handled = true;


                    break;
            }
        }

       
    }
}
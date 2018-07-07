using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kalkulator_wsiz
{
    /**
* <p>
* Klasa Funckej przechowujaca zmienne 
* </p>
* <param name="a">Zmienna a przechowujaca wspolczynnik kierunkowy funkcji kwadratowej</param>
* <param name="b">Zmienna b przechowujaca parametr b </param>
* <param name="c">Zmienna c przechowujaca wyraz wolny</param>
* <param name="obl_delta">Zmienna przechowujaca obliczona delte</param>
* <param name="x1">Zmienna przechowujaca wartosc miejsca zerowego x1</param>
* <param name="x2">Zmienna przechowujaca wartosc miejsca zerowego x1</param>
* <param name="p">Zmienna przechowujaca wspolrzedne X wierzcholka funkcji</param>
* <param name="q">Zmienna przechowujaca wspolrzedne Y wierzcholka funkcji</param>
* <param name="zw1">Zmienna przechowujaca zbior wartosci funkcji dla delty wiekszej od 0</param>
* <param name="zw2">Zmienna przechowujaca zbior wartosci funkcji dla delty mniejszej od 0</param>
* @return Wszystkie pola puste 
*/

    class Funkcje
    {
        public double a;
        public double b;
        public double c;
        public double obl_delta;
        public double x1;//miejsce zerowe1
        public double x2;//miejsce zerowe2
        public double p;//wierzchołek funkcji
        public double q;//wierzchołek funkcji
        public double zw1;//zbiór wartości, delta > 0
        public double zw2;//zbiór wartości, delta < 0
    }

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
        /**
 * <p>
 * Funkcja obslugujaca przycisk usuwania wszystkich danych z interfejsu 
 * </p>
 * <param name="tb_a.Text">Pole tekstowe a</param>
 * <param name="tb_b.Text">Pole tekstowe b</param>
 * <param name="tb_c.Text">Pole tekstowe c</param>
 * <param name="tb_result.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result1.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result2.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result3.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result4.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result5.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result6.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * @return Wszystkie pola puste 
*/
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
        /**
 * <p>
 * Funkcja obslugujaca przycisk obliczający wszystkie dane i generujacy wykres
 * </p>
 * <param name="wykres.a">Zmienna a</param>
 * <param name="wykres.b">Zmienna b</param>
 * <param name="wykres.c">Zmienna c</param>
 * <param name="wykres.obl_delta">Zmienna zachowujaca obliczona delte</param>
 * <param name="wykres.p">Zmienna przechowujaca wspolrzedna X wierzcholka </param>
 * <param name="wykres.p">Zmienna przechowujaca wspolrzedna Y wierzcholka</param>
 * <param name="wykres.x1">Zmienna w ktorej znajduje sie obliczone miejsce zerowe x1</param>
 * <param name="wykres.x2t">Zmienna w ktorej znajduje sie obliczone miejsce zerowe x2</param>
 * <param name="tb_result5.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result6.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * @return Wyswietla pogladowy wykres i obliczone wierzcholki i miejsca zerowe 
*/

        private void wykres_btn_Click(object sender, RoutedEventArgs e)
        {
            Funkcje wykres = new Funkcje();
            wykres.a = Convert.ToDouble(tb_a.Text);
            wykres.b = Convert.ToDouble(tb_b.Text);
            wykres.c = Convert.ToDouble(tb_c.Text);
           ///Obliczanie delty i miejsc zerowych funkcji 

            wykres.obl_delta = (wykres.b * wykres.b) - 4 * wykres.a * wykres.c;
            wykres.p = ((-wykres.b) / (2 * wykres.a));
            wykres.q = ((-wykres.obl_delta) / (4 * wykres.a));
            wykres.x1 = (-wykres.b - Math.Sqrt(wykres.obl_delta)) / (2 * wykres.a);
            wykres.x2 = (-wykres.b + Math.Sqrt(wykres.obl_delta)) / (2 * wykres.a);

            ///warunek jezeleli wspolczynnik a jest wieksz niz 0 i delta jest dodatnia to wypisuje miejsca zerowe i wierzcholek

            if (wykres.a > 0 & wykres.obl_delta > 0)
            {
                wykres1.Visibility = Visibility;
                tb_result8.Visibility = Visibility;
                tb_result9.Visibility = Visibility;
                tb_result10.Visibility = Visibility;
                tb_result10.Text = "(" + Math.Round(wykres.p, 2) + ";" + Math.Round(wykres.q, 2) + ")";
                tb_result8.Text = "(" + Math.Round(wykres.x1, 2) + ";" + "0)";
                tb_result9.Text = "(" + Math.Round(wykres.x2, 2) + ";" + "0)";
            }
            ///warunek jezeleli wspolczynnik a jest mniejszy od 0 i delta jest dodatnia to wypisuje miejsca zerowe i wierzcholek
            if (wykres.a < 0 & wykres.obl_delta > 0)
            {
                wykres2.Visibility = Visibility;
                tb_result11.Visibility = Visibility;
                tb_result8.Visibility = Visibility;
                tb_result9.Visibility = Visibility;
                tb_result11.Text = "(" + Math.Round(wykres.p, 2) + ";" + Math.Round(wykres.q, 2) + ")";
                tb_result8.Text = "(" + Math.Round(wykres.x1, 2) + ";" + "0)";
                tb_result9.Text = "(" + Math.Round(wykres.x2, 2) + ";" + "0)";
            }
            ///warunek Jezeli a jest ujemne i delta mniejsza od zero to wyswietla wierzcholek
            if (wykres.a < 0 & wykres.obl_delta < 0)
            {
                wykres3.Visibility = Visibility;
                tb_result11.Visibility = Visibility;
                tb_result11.Text = "(" + Math.Round(wykres.p, 2) + ";" + Math.Round(wykres.q, 2) + ")";
            }
            ///warunek jezeli a jest wieksze niz 0 i delta mniejsza od zero to wyswietla wierzcholek
            if (wykres.a > 0 & wykres.obl_delta < 0)
            {
                wykres4.Visibility = Visibility;
                tb_result10.Visibility = Visibility;
                tb_result10.Text = "(" + Math.Round(wykres.p, 2) + ";" + Math.Round(wykres.q, 2) + ")";
            }

            wykres_btn.IsEnabled = false;

        }

        /**
* <p>
* Funkcja obslugujaca przycisk OBLICZ 
* </p>
* <param name="a">Zmienna a</param>
* <param name=".b">Zmienna b</param>
* <param name="c">Zmienna c</param>
* <param name="obl_delta">Zmienna zachowujaca obliczona delte</param>
* <param name="p">Zmienna przechowujaca wspolrzedna X wierzcholka </param>
* <param name=".p">Zmienna przechowujaca wspolrzedna Y wierzcholka</param>
* <param name=x1">Zmienna w ktorej znajduje sie obliczone miejsce zerowe x1</param>
* <param name="x2t">Zmienna w ktorej znajduje sie obliczone miejsce zerowe x2</param>
 * <param name="tb_result.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result1.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result2.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result3.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result4.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result5.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
 * <param name="tb_result6.Text">Pole tekstowe wyswietlajace rezultat obliczen</param>
* @return Delta, miejsca zerowe, dziedzina, wierzcholek, zbior wartosci funkcji, monotonicznosc i postacie funkcji 
*/

        private void draw_btn_Click(object sender, RoutedEventArgs e)
        {
            Funkcje obiekt2 = new Funkcje();
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
            obiekt2.a = Convert.ToDouble(tb_a.Text);
            obiekt2.b = Convert.ToDouble(tb_b.Text);
            obiekt2.c = Convert.ToDouble(tb_c.Text);
          

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
            if (obiekt2.a != 0)
            {
                obiekt2.obl_delta = (obiekt2.b * obiekt2.b) - 4 * obiekt2.a * obiekt2.c;

                tb_result.Text = "Δ = " + Math.Round(obiekt2.obl_delta, 2).ToString();
                //Delta = 0
                if (obiekt2.obl_delta == 0)
                {
                    obiekt2.x1 = obiekt2.x2 = -obiekt2.b / (2 * obiekt2.a);
                    tb_result2.Text = "Δ równa 0: \nx1 wynosi : " + Math.Round(obiekt2.x1, 2);

                }
                //Delta > 0
                else if (obiekt2.obl_delta > 0)
                {
                    obiekt2.x1 = (-obiekt2.b - Math.Sqrt(obiekt2.obl_delta)) / (2 * obiekt2.a);
                    obiekt2.x2 = (-obiekt2.b + Math.Sqrt(obiekt2.obl_delta)) / (2 * obiekt2.a);
                    tb_result2.Text = "Δ większa od 0: \nx1: " + Math.Round(obiekt2.x1, 2) + "\nx2: " + Math.Round(obiekt2.x2, 2);

                }
                //Delta < 0
                else if (obiekt2.obl_delta < 0)
                {
                    tb_result2.Text = "Brak rozwiązań. Δ ujemna!";
                }
                //Zbiór wartości
                {
                    if (obiekt2.a > 0)
                    {
                        obiekt2.zw1 = (-obiekt2.obl_delta / 4 * obiekt2.a);
                        tb_result3.Text = "Zbiór wartości funkcji:" + "\n(" + Math.Round(obiekt2.zw1, 2) + " ,+ ∞ )";
                    }
                    else if (obiekt2.a < 0)
                    {
                        obiekt2.zw2 = (-obiekt2.obl_delta / 4 * obiekt2.a);
                        tb_result3.Text = "Zbiór wartości funkcji:" + "\n(- ∞, " + Math.Round(obiekt2.zw2, 2) + ")";
                    }
                }

                // Wierzchołek paraboli
                obiekt2.p = ((-obiekt2.b) / (2 * obiekt2.a));
                obiekt2.q = ((-obiekt2.obl_delta) / (4 * obiekt2.a));
                tb_result4.Text = "p = " + Math.Round(obiekt2.p, 2) + " , q = " + Math.Round(obiekt2.q, 2) + ", W = (" + Math.Round(obiekt2.p, 2) + ";" + Math.Round(obiekt2.q, 2) + ")";

                // Monotoniczność funkcji
                {
                    if (obiekt2.a > 0)
                    {
                        tb_result5.Text = "Funkcja jest malejąca w przedziale: " + "(- ∞ ," + Math.Round(obiekt2.p, 2) + ")"
                        + "\nFunkcja jest rosnąca w przedziale: " + "( " + Math.Round(obiekt2.p, 2) + ", + ∞)";

                    }
                    else
                    {
                        tb_result5.Text = "Funkcja jest rosnąca w przedziale: " + "(-∞ ," + Math.Round(obiekt2.p, 2) + ")"
                        + "\nFunkcja jest malejąca w przedziale: " + "( " + Math.Round(obiekt2.p, 2) + ", + ∞)";


                    }
                }

                //Dziedzina Funkcji
                {
                    if (obiekt2.a > 0)
                    {
                        tb_result6.Text = "Dziedzina funkcji: " + "\n( " + Math.Round(obiekt2.q, 2) + ", + ∞)";
                    }
                    else
                    {
                        tb_result6.Text = "Dziedzina funkcji: " + "\n(- ∞ ," + Math.Round(obiekt2.q, 2) + ")";

                    }
                }


                //Postacie funkcji dla delty równej 0
                if (obiekt2.obl_delta == 0)
                {

                    if ((obiekt2.x1 = obiekt2.x2 = -obiekt2.b / (2 * obiekt2.a)) < 0)
                    {

                        tb_result7.Text = "Postać iloczynowa: " + obiekt2.a + "(x + " + (-1) * obiekt2.x1 + ")^2" + "\nPostać kanoniczna: " + obiekt2.a + "(x " + obiekt2.p + ") + " + obiekt2.q +
                             "\nPostać ogólna: " + obiekt2.a + "x^2 + " + obiekt2.b + "x + " + obiekt2.c;

                    }
                    else
                    {

                        tb_result7.Text = "Postać iloczynowa: " + obiekt2.a + "(x " + (-1) * obiekt2.x1 + ")^2" + "\nPostać kanoniczna: " + obiekt2.a + "(x + " + obiekt2.p + ") + " + obiekt2.q +
                             "\nPostać ogólna: " + obiekt2.a + "x^2 + " + obiekt2.b + "x + " + obiekt2.c;

                    }
                }
                //Postacie funckji dla dlety większej od 0
                if (obiekt2.obl_delta > 0)
                {
                    obiekt2.x1 = (-obiekt2.b - Math.Sqrt(obiekt2.obl_delta)) / (2 * obiekt2.a);
                    obiekt2.x2 = (-obiekt2.b + Math.Sqrt(obiekt2.obl_delta)) / (2 * obiekt2.a);

                    if (obiekt2.x1 > 0 & obiekt2.x2 > 0 & obiekt2.p >= 0 & obiekt2.q >= 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(obiekt2.a, 2) + "(x -" + Math.Round(obiekt2.x1, 2) + ")*(x - " + Math.Round(obiekt2.x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(obiekt2.a, 2) + "(x " + Math.Round(obiekt2.p, 2) + ") + " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 + " + Math.Round(obiekt2.b, 2) + "x + " + Math.Round(obiekt2.c, 2);
                    }
                    if (obiekt2.x1 < 0 & obiekt2.x2 < 0 & obiekt2.p < 0 & obiekt2.q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(obiekt2.a, 2) + "(x " + Math.Round(-obiekt2.x1, 2) + ")*(x + " + Math.Round(-obiekt2.x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(obiekt2.a, 2) + "(x + " + Math.Round(-obiekt2.p, 2) + ")  " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 + " + Math.Round(obiekt2.b, 2) + "x + " + Math.Round(obiekt2.c, 2);
                    }
                    if (obiekt2.x1 > 0 & obiekt2.x2 < 0 & obiekt2.p < 0 & obiekt2.q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(obiekt2.a, 2) + "(x " + Math.Round(-obiekt2.x1, 2) + ")*(x + " + Math.Round(-obiekt2.x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(obiekt2.a, 2) + "(x + " + Math.Round(-obiekt2.p, 2) + ")  " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 + " + Math.Round(obiekt2.b, 2) + "x + " + Math.Round(obiekt2.c, 2);
                    }
                    if (obiekt2.x1 < 0 & obiekt2.x2 > 0 & obiekt2.p < 0 & obiekt2.q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(obiekt2.a, 2) + "(x +" + Math.Round(-obiekt2.x1, 2) + ")*(x " + Math.Round(-obiekt2.x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(obiekt2.a, 2) + "(x + " + Math.Round(-obiekt2.p, 2) + ")  " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 + " + Math.Round(obiekt2.b, 2) + "x " + Math.Round(obiekt2.c, 2);
                    }
                    if (obiekt2.x1 > 0 & obiekt2.x2 < 0 & obiekt2.p > 0 & obiekt2.q < 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(obiekt2.a, 2) + "(x " + Math.Round(-obiekt2.x1, 2) + ")*(x " + Math.Round(-obiekt2.x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(obiekt2.a, 2) + "(x + " + Math.Round(-obiekt2.p, 2) + ")  " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 + " + Math.Round(obiekt2.b, 2) + "x " + Math.Round(obiekt2.c, 2);
                    }
                    if (obiekt2.x1 > 0 & obiekt2.x2 < 0 & obiekt2.p > 0 & obiekt2.q > 0)
                    {
                        tb_result7.Text = "Postać iloczynowa: " + Math.Round(obiekt2.a, 2) + "(x " + Math.Round(-obiekt2.x1, 2) + ")*(x + " + Math.Round(-obiekt2.x2, 2) + ")" + "\nPostać kanoniczna: " + Math.Round(obiekt2.a, 2) + "(x " + Math.Round(-obiekt2.p, 2) + ") + " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 + " + Math.Round(obiekt2.b, 2) + "x + " + Math.Round(obiekt2.c, 2);
                    }


                }
                // postacie funkcji dla delty mniejszej od 0
                else if (obiekt2.obl_delta < 0)// brak postaci iloczynowej
                {
                    if (obiekt2.p < 0 & obiekt2.b >= 0)
                    {
                        tb_result7.Text = "Brak postaci iloczynowej" + "\nPostać kanoniczna: " + obiekt2.a + "(x " + Math.Round(obiekt2.p, 2) + ") + " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 +" + Math.Round(obiekt2.b, 2) + "x + " + Math.Round(obiekt2.c, 2);
                    }
                    if (obiekt2.p > 0)
                    {
                        tb_result7.Text = "Brak postaci iloczynowej" + "\nPostać kanoniczna: " + obiekt2.a + "(x +" + Math.Round(obiekt2.p, 2) + ") " + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 +" + Math.Round(obiekt2.b, 2) + "x " + Math.Round(obiekt2.c, 2);
                    }
                    if (obiekt2.p > 0 & obiekt2.b < 0)
                    {
                        tb_result7.Text = "Brak postaci iloczynowej" + "\nPostać kanoniczna: " + obiekt2.a + "(x +" + Math.Round(obiekt2.p, 2) + ") +" + Math.Round(obiekt2.q, 2) +
                             "\nPostać ogólna: " + Math.Round(obiekt2.a, 2) + "x^2 " + Math.Round(obiekt2.b, 2) + "x +" + Math.Round(obiekt2.c, 2);
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
                case Key.OemComma:

                    break;


                default:

                    e.Handled = true;


                    break;
            }
        }

       
    }
}
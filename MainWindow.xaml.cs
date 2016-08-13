using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace products
{
    public partial class MainWindow : Window
    {

        Produkt Produkty = new Produkt();

        public MainWindow()
        {
            InitializeComponent();

            Produkty.Create();
            ShowItemsInTable();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tabelka.Items.Clear();
            ShowItemsInTable(IloscKalorii.Text, grupa.Text);
        }

        private void ShowItemsInTable(string kalorie = null, string grupa = null)
        {

            if (kalorie == null && grupa == null)
            {
                foreach (var item in Produkty.getProd())
                {
                    Tabelka.Items.Add(item);
                }
            }
            else
            {
                int k;
                bool boolKalorie = int.TryParse(kalorie, out k);

                if (boolKalorie)
                {
                    foreach (var item in Produkty.getProd())
                    {
                        if (grupa == item.grupa)
                        {
                            float ka = 20 / item.kalorie;
                            item.waga = k / item.kalorie;
                            Tabelka.Items.Add(item);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Podaj prawidłową wartość kalorii");
                }
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            //Kalorie2.TekstWindow TextWindow = new Kalorie2.TekstWindow();
            //TextWindow.Show();
        }
    }
}

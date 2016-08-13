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
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;

namespace products
{
    class Produkt
    {
        List<Prod> produkty = new List<Prod>();
        private const string FILE_NAME = "produkty.data";
        private string[] tabProduct;
        private bool istniejePlik;

        public void Create()
        {
            _getFile();

            if(istniejePlik == true) { 
                foreach (var prod in tabProduct)
                {
                    string[] split = prod.Split("|".ToCharArray());

                    int k = Int32.Parse(split[1]);

                    produkty.Add(new Prod() { nazwa = split[0], kalorie = k, grupa = split[2], polecany = split[3] });
                }
            }
        }
        public List<Prod> getProd()
        {
            return produkty;
        }
        private void _getFile()
        {

            try { 
                tabProduct = File.ReadAllLines(FILE_NAME);
                istniejePlik = true;
            }
            catch (Exception)
            {
                istniejePlik = false;
                MessageBox.Show("Brak pliku z produktami");
            }
        }
    }
    class Prod
    {
        public string nazwa { get; set; }
        public int kalorie { get; set; }
        public float waga { get; set; }
        public string grupa { get; set; }
        public string polecany { get; set; }
    }
}

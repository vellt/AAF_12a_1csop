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

namespace WpfApp25
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int randomSzam;
        public MainWindow()
        {
            InitializeComponent();
            csuszka.ValueChanged += Csuszka_ValueChanged;
            gomb.Click += Gomb_Click;

            Random r = new Random();
            randomSzam = r.Next(1, 11);
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            int gep = randomSzam;
            int felh = Convert.ToInt32(csuszka.Value);
            if (gep==felh)
            {
                MessageBox.Show("Eltaláltad");
            }
            else if (felh > gep)
            {
                MessageBox.Show("Kisebbre godoltam");
            }
            else
            {
                MessageBox.Show("Nagyobbra gondoltam");
            }
        }

        private void Csuszka_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            szam.Text =Convert.ToInt32(csuszka.Value).ToString();
        }
    }
}

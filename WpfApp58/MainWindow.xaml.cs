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

namespace WpfApp58
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gomb.Click += Gomb_Click;
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            if (elsoElem.Text.Trim()=="" || hanyados.Text.Trim()=="" || hossz.Text.Trim()=="")
            {
                MessageBox.Show("Kötelező mindenhol az értéket megadni");
            }
            else
            {
                int a1 =Convert.ToInt32(elsoElem.Text);
                int q =Convert.ToInt32(hanyados.Text);
                int n =Convert.ToInt32(hossz.Text);

                List<int> sorozat = new List<int>();

                for (int i = 0; i < n; i++)
                {
                    int szam = a1 * (int)Math.Pow(q, i);
                    sorozat.Add(szam);
                }

                MessageBox.Show(string.Join(",", sorozat));

            }
        }
    }
}

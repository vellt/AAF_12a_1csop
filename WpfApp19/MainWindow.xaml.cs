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

namespace WpfApp19
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

            if (szam1.Text.Trim().Length==0 || szam2.Text.Trim().Length==0)
            {
                MessageBox.Show("kötelező megadni értékeket");
            }
            else
            {
                int sz1 = Convert.ToInt32(szam1.Text.Trim());
                int sz2 = Convert.ToInt32(szam2.Text.Trim());

                switch (comb.SelectedIndex)
                {
                    case 0:
                        MessageBox.Show($"{sz1 + sz2}");
                        break;
                    case 1:
                        MessageBox.Show($"{sz1 - sz2}");
                        break;
                    case 2:
                        MessageBox.Show($"{sz1 * sz2}");
                        break;
                    case 3:
                        MessageBox.Show($"{Math.Round(sz1 / Convert.ToDouble(sz2), 2)}");
                        break;
                }
            }
            

        }
    }
}

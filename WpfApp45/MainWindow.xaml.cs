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

namespace WpfApp45
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int index = 1;
        public MainWindow()
        {
            InitializeComponent();
            vissza.Click += Vissza_Click;
            elore.Click += Elore_Click;
        }

        private void Elore_Click(object sender, RoutedEventArgs e)
        {
            if (index ==5) // ha elértük az utolsó képet, ne növelje az indexet
            {
                index = 1; // állítsa az értékét egyre
            }
            else
            {
                index++; // ha még nem értük el az 5-öst, akkor növeljük
            }

            kepBetoltese();
        }

        private void Vissza_Click(object sender, RoutedEventArgs e)
        {
            if(index== 1)// ha elértük az első képet, ne csökkentse az indexet
            {
                index = 5;// állítsa az értékét 5-re
            }
            else
            {
                index--; // ha még nem értük el az 1-est, akkor csökkentsünk
            }
            kepBetoltese();
        }

        private void kepBetoltese()
        {
            kep.Source = new BitmapImage(new Uri($"0{index}.jpg", UriKind.Relative));
        }
    }
}

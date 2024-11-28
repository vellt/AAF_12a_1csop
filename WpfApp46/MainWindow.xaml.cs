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
using System.IO;

namespace WpfApp46
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] uzenetek = new string[]
        {
            "Eslő üzi",
            "Második üzi",
            "Harmadik üzi"
        };
        
        public MainWindow()
        {
            InitializeComponent();
            gomb.Click += Gomb_Click;

        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int index = r.Next(uzenetek.Length);
            uzi.Text = uzenetek[index];
        }
    }
}

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
        List<string> uzenetek = new List<string>();
        
        public MainWindow()
        {
            InitializeComponent();
            uzenetek = File.ReadAllLines("uzik.csv").ToList();
            gomb.Click += Gomb_Click;

        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int index = r.Next(uzenetek.Count());
            uzi.Text = uzenetek[index];
        }
    }
}

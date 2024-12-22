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
using Microsoft.Win32;

namespace memegenerátor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> szovegek = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            szovegek = File.ReadAllLines("meme_szovegek.csv").ToList();
            gomb.Click += Gomb_Click;
            

        }
        private void SaveStackPanelAsImage(object sender, RoutedEventArgs e)
        {
            // RenderTargetBitmap: a StackPanel képként való megjelenítése
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(
                (int)myStackPanel.ActualWidth,
                (int)myStackPanel.ActualHeight,
                96, 96, PixelFormats.Pbgra32);

            renderBitmap.Render(myStackPanel);

            // Kép mentése a SaveFileDialog segítségével
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JPG Image|*.jpg";
            saveFileDialog.DefaultExt = "png";
            saveFileDialog.FileName = $"StackPanel_{Guid.NewGuid()}";  // Egyedi fájlnév UUID-val

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;

                // Kép mentése fájlba
                using (FileStream fs = new FileStream(filePath, FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(renderBitmap));
                    encoder.Save(fs);
                }

                MessageBox.Show($"Kép sikeresen mentve: {filePath}");
            }
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            int kepsz = r.Next(szovegek.Count);
            szoveg.Text = $"{szovegek[kepsz]}";
            kep.Source = new BitmapImage(new Uri($"{r.Next(1,69)}.jpg", UriKind.Relative));
        }
    }
}

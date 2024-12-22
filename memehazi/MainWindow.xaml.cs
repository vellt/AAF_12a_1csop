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


namespace memehazi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>


    //public partial class MainWindow : Window
    //{
    //    List<string> memek = new List<string>(File.ReadAllLines("meme_szovegek.csv"));
    //    public MainWindow()
    //    {
    //        InitializeComponent();
    //        gomb.Click += Gomb_Click;
    //    }

    //    private void Gomb_Click(object sender, RoutedEventArgs e)
    //    {
    //        Random r = new Random();
    //        szoveg.Text = memek[r.Next(0, memek.Count)];
    //        kep.Source = new BitmapImage(new Uri($"{r.Next(1, 69)}.jpg", UriKind.Relative));
    //    }
    //}

    public partial class MainWindow : Window
    {
        List<string> memek = new List<string>(File.ReadAllLines("meme_szovegek.csv"));
        public MainWindow()
        {
            InitializeComponent();
            gomb.Click += Gomb_Click;
            mentesGomb.Click += MentesGomb_Click;
        }

        private void Gomb_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            szoveg.Text = memek[r.Next(0, memek.Count)];
            kep.Source = new BitmapImage(new Uri($"{r.Next(1, 69)}.jpg", UriKind.Relative));
        }

        private void MentesGomb_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string mappa = "MentettMemek";
                if (!Directory.Exists(mappa))
                    Directory.CreateDirectory(mappa);

                string fajlNev = $"{mappa}/{Guid.NewGuid()}.png";

                // RenderTargetBitmap készítése
                var renderTarget = new RenderTargetBitmap(
                    (int)mentendoPanel.ActualWidth,
                    (int)mentendoPanel.ActualHeight,
                    96, 96, PixelFormats.Pbgra32);
                renderTarget.Render(mentendoPanel);

                // PNG mentése
                var encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(renderTarget));
                using (var fileStream = new FileStream(fajlNev, FileMode.Create))
                {
                    encoder.Save(fileStream);
                }

                MessageBox.Show($"Kép sikeresen elmentve: {fajlNev}", "Mentés sikeres", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba történt a kép mentése közben: {ex.Message}", "Mentés hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }


}

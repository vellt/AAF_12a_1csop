using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using Storage2;

namespace WpfApp66
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool jatekVege = false;
        int pontszam = 0;
        public MainWindow()
        {
            InitializeComponent();
            // mind 3 ajtó ugyanazt az eseményt hívja meg..
            ajto1.MouseUp += ajtoNyitas;
            ajto2.MouseUp += ajtoNyitas;
            ajto3.MouseUp += ajtoNyitas;
            temaGomb.Click += TemaGomb_Click;
            ujJatek.Click += UjJatek_Click;
            HatterzeneHangLejatszasa();
            temaErvenyesitese();
            RekordBetoltese();
        }

        private void HatterzeneHangLejatszasa()
        {
            // loopolva tud lejátszani!
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation= "creepy_night.wav";
            player.PlayLooping();
        }

        private void PointsHangLejatszasa()
        {
            Uri uri = new Uri("points.wav", UriKind.Relative);
            MediaPlayer player = new MediaPlayer();
            player.Open(uri);
            player.Play();
        }

        private void PuttyHangLejatszasa()
        {
            Uri uri = new Uri("putty.wav", UriKind.Relative);
            MediaPlayer player = new MediaPlayer();
            player.Open(uri);
            player.Play();
        }

        private void UjJatek_Click(object sender, RoutedEventArgs e)
        {
            // új játéknak a logikája..
            jatekVege = false;
            pontszam = 0;
            pontszamSzoveg.Text= $"Pontszámod: {pontszam}";
            // szellemek eltüntetése
            szellemirto();
        }

        private void szellemirto()
        {
            // vagy konkrétan elnevezzük a szellemeket a nézeten és úgy hivatkozzuk le őket..
            szellem1.Visibility = Visibility.Hidden;
            // vagy lehivatkozzuk őket a this-től, azaz a window-tól kezdeve.. és eltrejtjük kőket
            (((this.Content as Grid).Children[4] as Grid).Children[0] as Image).Visibility = Visibility.Hidden;
            (((this.Content as Grid).Children[5] as Grid).Children[0] as Image).Visibility = Visibility.Hidden;
        }

        private void ajtoNyitas(object sender, MouseButtonEventArgs e)
        {
            if (jatekVege==false)
            {
                int ajtoAzonosito = Convert.ToInt32((sender as Image).Tag);
                Random r = new Random();
                int szellem = r.Next(1, 4);
                // játék vége változó igazat vesz fel, ha az ajtó száma megegyezik a szellemével
                jatekVege = ajtoAzonosito == szellem;
                if (jatekVege==false)
                {
                    // nem ért véget a játék azaz nem nyitottam ki olyan ajtót ami mögött szellem van
                    pontszam++;
                    pontszamSzoveg.Text = $"Pontszámod: {pontszam}";
                    PointsHangLejatszasa();
                    // ha meghaladta a pontszámom az eddigi rekordot
                    if (pontszam > Score.Read())
                    {
                        Score.Write(pontszam);
                        RekordBetoltese();
                    }
                }
                else
                {
                    PuttyHangLejatszasa();
                    (((sender as Image).Parent as Grid).Children[0] as Image).Visibility = Visibility.Visible;
                    // szellemet talátál
                }
            }
            else
            {
                MessageBox.Show("A játéknak vége", "Már nem tudsz több ajtót nyitni.");
            }
        }

        private void RekordBetoltese()
        {
            rekord.Text = $"Rekord: {Score.Read()}";
        }

        private void TemaGomb_Click(object sender, RoutedEventArgs e)
        {
            // téma váltó logika
            switch (Theme.Read())
            {
                case Themes.Dark:
                    Theme.Write(Themes.Light);
                    break;
                case Themes.Light:
                    Theme.Write(Themes.Dark);
                    break;
            }
            temaErvenyesitese();
        }

        private void temaErvenyesitese()
        {
            // témának megfelelően szinezünk mindent!
            this.Background = (Theme.Read() == Themes.Light) ? Brushes.AliceBlue : Brushes.Black;

            (leiras.Children[0] as TextBlock).Foreground= (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;
            (leiras.Children[1] as TextBlock).Foreground= (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;
            (leiras.Children[2] as TextBlock).Foreground= (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;

            cim.Foreground= (Theme.Read() == Themes.Light) ? Brushes.Black : Brushes.Orange;
        }
    }
}

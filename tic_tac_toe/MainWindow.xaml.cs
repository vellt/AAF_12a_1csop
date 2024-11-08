﻿using System;
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

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // globális változó, azért hogy a függvényeken belül el tudjam érni!
        // azért helyeztük ide!
        bool jatekVege = false;
        public MainWindow()
        {
            InitializeComponent();
            // linq-val körbejárjuk a Grid gyermekelemeit, amelyek mind Border-ek
            // és mindegyikhez 3 eseményt hozzárendelek!
            palya.Children.Cast<Border>().ToList().ForEach(x => 
            {
                x.MouseEnter += X_MouseEnter; // a kurzor belépett az elem felületére
                x.MouseLeave += X_MouseLeave; // a kurzor elhagyta az elem felületét
                x.MouseUp += X_MouseUp; // kattintási esemény azon elemeknek, amiknek nincs Click eseményük, Click eseménye csak a Buttonnak van!
            });
            ujJatek.MouseUp += UjJatek_MouseUp; // kattintási esemény azon elemeknek, amiknek nincs Click eseményük, Click eseménye csak a Buttonnak van!
        }

        private void UjJatek_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // reset
        }

        private void X_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // lekérdezem a mezőt amire kattintottam, a függvény
            // paramétere segítségével
            // egy object Borderré alakítása-->polimorfizmus (OOP-s fogalom, többalakúságot jelent)
            Border mezo = sender as Border;
            TextBlock textBlock= mezo.Child as TextBlock;

            bool szabadMezo = textBlock.Text == "";
            // játék menet
            if (jatekVege==false && szabadMezo==true)
            {
                // addig léphetek
                textBlock.Text = "X";
                jatekVegenekEllenorzese(); // lehet nyertem??
            }
        }

        private void jatekVegenekEllenorzese()
        {
            // lekérjük LINQ használatával az összes szabad mezőt

            // olyan elemeket keresünk a Where feltétellel, melyre igaz, 
            // hogy a Bordernek a gyermekének, amely egy TextBlock, a Text tulajdonsága üres!
            List<Border> szabadMezok = palya.Children.Cast<Border>()
                .Where(x => (x.Child as TextBlock).Text == "").ToList();

            // akkor van vége a játéknak, ha győzött az X vagy az O vagy már nincs szabad hely!
            jatekVege = Gyozott("X") || Gyozott("O") || szabadMezok.Count == 0;
        }

        private bool Gyozott(string jatekos)
        {
            // győzelmi logika megírása
            return false; // nem nyertem
        }

        private void X_MouseLeave(object sender, MouseEventArgs e)
        {
            // hover-hez kell
            Border mezo = sender as Border;
            mezo.Background = (Brush)new BrushConverter().ConvertFrom("#2D2D2D");
        }

        private void X_MouseEnter(object sender, MouseEventArgs e)
        {
            // hover-hez kell
            Border mezo = sender as Border;
            mezo.Background = (Brush)new BrushConverter().ConvertFrom("#383838");
        }
    }
}
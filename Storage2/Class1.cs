using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Storage2
{
    public enum Themes { Dark, Light }
    public class Theme
    {
        // Read - Beolvassa a "theme.txt" fájlt, és visszaadja a benne tárolt témát (enum formájában). 
        // Ha a fájl nem létezik (még), alapértelmezett téma adja vissza --> Light.
        public static Themes Read()
        {
            if (File.Exists("theme.txt"))
            {
                string text = File.ReadAllText("theme.txt");
                if (text == "Dark") return Themes.Dark;
                else return Themes.Light;
            }
            else
            {
                return Themes.Light;
            }
        }
        // Write - Egy paraméterben átadott témát ment a "theme.txt" fájlba.
        public static void Write(Themes theme)
        {
            File.WriteAllText("theme.txt", theme.ToString());
        }
    }
    public class Score
    {
        // Read - Beolvassa a "score.txt" fájlt, és visszaadja az abban tárolt pontszámot.
        // Ha a fájl nem létezik, 0 ponttal tér vissza (ez úgymond az alapértelmezett érték).
        public static int Read()
        {
            if (File.Exists("score.txt"))
            {
                string text = File.ReadAllText("score.txt");
                return Convert.ToInt32(text);
            }
            else
            {
                return 0;
            }
        }
        // Write - Egy paraméterben megadott pontszámot ment a "score.txt" fájlba.
        public static void Write(int score)
        {
            File.WriteAllText("score.txt", score.ToString());
        }
    }
}

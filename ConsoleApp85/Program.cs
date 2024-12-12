using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp85
{
    enum Tipusok
    {
        Viz, Tuz, Noveny, Elektromos
    }
    class Pokemon
    {
        public int Id { get; set; }
        public string Nev { get; set; }
        public int Szint { get; set; }
        public int TamadoEro { get; set; }
        public bool Tapasztalt =>Szint>16; 
        public Tipusok Tipus { get; set; }
        public int VedekezoEro { get; set; }

        public override string ToString()
        {
            return $"{Id} {Nev} {Szint} {TamadoEro} {Tapasztalt} {Tipus} {VedekezoEro}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> pokemonok = new List<Pokemon>()
            {
                new Pokemon()
                {
                    Id=1,
                    Nev="Lapras",
                    Tipus=Tipusok.Viz,
                    Szint=10,
                    TamadoEro=50,
                    VedekezoEro=20,
                },
                new Pokemon()
                {
                    Id=2,
                    Nev="Arcanine",
                    Tipus=Tipusok.Tuz,
                    Szint=60,
                    TamadoEro=80,
                    VedekezoEro=45
                }
            };

            // Számold meg mennyi tapasztalt tűz típusú Pokémonod van.
            int db = pokemonok.Where(x => x.Tapasztalt == true && x.Tipus == Tipusok.Tuz).Count();
            Console.WriteLine(db);

            // Átlagosan mennyi a támadóereje Pokémonjaidnak?
            double atlag = pokemonok.Average(x => x.TamadoEro);
            Console.WriteLine(Math.Round(atlag, 2));

            // Van olyan Pokémonod, amelynek a védekező és támadóereje több 45 - nél ?
            bool van = pokemonok.Exists(x => x.TamadoEro > 45 && x.VedekezoEro > 45);
            Console.WriteLine(van ? "igen" : "nem");

            // Listázd azon elektromos Pokémonjaidat, melyek támadóereje több 100 - nál.
            pokemonok.Where(x => x.Tipus == Tipusok.Elektromos && x.TamadoEro > 100)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Mennyi tapasztalt Pokémonod van?
            int db2 = pokemonok.Where(x => x.Tapasztalt == true).Count();
            Console.WriteLine(db2);

            // Írasd ki pokémonjaidat színjük szerint növekvősorrendbe rendezve.
            pokemonok.OrderBy(x => x.Szint).ToList().ForEach(x => Console.WriteLine(x));

            // Add össze Pokémonjaid összTÁMADÓerejét.
            int osszEro = pokemonok.Sum(x => x.TamadoEro);
            Console.WriteLine(osszEro);

            // Listázd ki az első 3 legnagyobb támadóerejű Pokémonodat.
            pokemonok.OrderByDescending(x => x.TamadoEro).Take(3).ToList().ForEach(x => Console.WriteLine(x));

            Console.ReadKey();
        }
    }
}

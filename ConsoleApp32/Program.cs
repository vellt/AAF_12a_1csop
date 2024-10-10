using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp32
{
    enum Nemek { Fiu, Lany}
    enum Szinek { Fekete, Feher, Szurke, Narancs, Lila}

    class Cica
    {
        public int Id { get; set; }
        public string Neve { get; set; }
        public Nemek Neme { get; set; }
        public int Suly { get; set; }
        public Szinek Szine { get; set; }
        public DateTime SzuletesiDatum { get; set; }
        public int Kor => DateTime.Now.Year - SzuletesiDatum.Year;

        public override string ToString()
        {
            return $"{Id,-5}{Neve,-15}{Neme,-10}{Suly,-5}{Szine,-15}{SzuletesiDatum.ToString("yyy.MM.dd"),-15}{Kor}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Cica> cicak = new List<Cica>()
            {
                new Cica()
                {
                    Id=1,
                    Neve="Megatron",
                    Suly=20,
                    Neme=Nemek.Fiu,
                    Szine=Szinek.Fekete,
                    SzuletesiDatum=new DateTime(2023,10,01),
                },
                new Cica()
                {
                    Id=2,
                    Neve="Pizsama",
                    Suly=4,
                    Neme=Nemek.Lany,
                    Szine=Szinek.Narancs,
                    SzuletesiDatum=new DateTime(2022,12,09),
                },
                new Cica()
                {
                    Id=3,
                    Neve="Cikk-cakk",
                    Suly=3,
                    Neme=Nemek.Lany,
                    Szine=Szinek.Lila,
                    SzuletesiDatum=new DateTime(2020,11,07),
                },
                new Cica()
                {
                    Id=4,
                    Neve="Radiátor",
                    Suly=5,
                    Neme=Nemek.Lany,
                    Szine=Szinek.Szurke,
                    SzuletesiDatum=new DateTime(2017,11,07),
                },
            };

            // első cica
            Cica elsoCica= cicak.First();
            Console.WriteLine(elsoCica.ToString());

            // utolso cica
            Cica utolsoCica = cicak.Last();

            // összes cica súly
            int osszSuly= cicak.Sum(x => x.Suly);
            Console.WriteLine(osszSuly);

            // átlag életkor
            double atlagKor= cicak.Average(x => x.Kor);
            Console.WriteLine(Math.Round(atlagKor,2));

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp78
{
    enum Markak { BMW, Audi, Volkswagen, Skoda, Suzuki }
    enum Uzemanyagok { Benzin, Dizel, Elektromos, Hibrid }

    class Auto
    {
        public int GyartasiEv { get; set; }
        public int Id { get; set; }
        public int Kor => DateTime.Now.Year - GyartasiEv;
        public Markak Marka { get; set; }
        public string Rendszam { get; set; }
        public bool UjRendszam => Rendszam.Length != 7;
        public Uzemanyagok Uzemanyag { get; set; }

        public override string ToString()
        {
            return $"{Id} {GyartasiEv} {Kor} {Marka} {Rendszam} {UjRendszam} {Uzemanyag}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>()
            {
                new Auto()
                {
                    Id=1,
                    GyartasiEv=2003,
                    Marka=Markak.Suzuki,
                    Rendszam="AAAA-123",
                    Uzemanyag=Uzemanyagok.Elektromos,
                },
                new Auto()
                {
                    Id=2,
                    GyartasiEv=2000,
                    Marka=Markak.Audi,
                    Rendszam="AAA-123",
                    Uzemanyag=Uzemanyagok.Hibrid,
                },
                new Auto()
                {
                    Id=3,
                    GyartasiEv=2020,
                    Marka=Markak.BMW,
                    Rendszam="AAAA-111",
                    Uzemanyag=Uzemanyagok.Dizel
                },
                new Auto()
                {
                    Id=4,
                    GyartasiEv=2016,
                    Marka=Markak.Skoda,
                    Rendszam="BBB-123",
                    Uzemanyag=Uzemanyagok.Hibrid
                }
            };

            // első autó
            Auto elso= autok.First();
            Console.WriteLine(elso);

            // első új rendszámos autó
            Auto elsoUj= autok.Where(x => x.UjRendszam).First();
            Console.WriteLine(elsoUj);

            // első elektromos autó
            Auto elsoe = autok.Where(x => x.Uzemanyag == Uzemanyagok.Elektromos).First();
            Console.WriteLine(elsoe);

            // utolsó autó
            Auto utolso = autok.Last();
            Console.WriteLine(utolso);

            // utolsó Audi
            Auto utolsoaudi = autok.Where(x => x.Marka == Markak.Audi).Last();
            Console.WriteLine(utolsoaudi);

            // hány évesek átlagosan az autók
            double atlag = autok.Average(x => x.Kor);
            Console.WriteLine(atlag);

            // mennyi a idős a legidősebb autó
            int kor = autok.OrderBy(x => x.Kor).Last().Kor;
            // vagy --> int kor = autok.Max(x=>x.Kor);
            Console.WriteLine(kor);

            // Mikor gyártották a legidősebb autót
            int idosebb = autok.Min(x => x.GyartasiEv);
            Console.WriteLine(idosebb);

            // Írasd ki az összes új rendszámos autót
            autok.Where(x => x.UjRendszam == true)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írasd ki az összes Benzines autót
            autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írasd ki az összes BMW - t, ami Benzines.
            autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin && x.Marka == Markak.BMW)
                .ToList().ForEach(x => Console.WriteLine(x));


            // Írasd ki az összes 2007 - nél újabb modellt
            autok.Where(x => x.GyartasiEv > 2007)
                .ToList().ForEach(x => Console.WriteLine(x));


            // Melyik az első autó, amely 5 évesnél idősebb?
            Auto elso5= autok.Where(x => x.Kor > 5).First();
            Console.WriteLine(elso5);

            // Hány elektromos autó van a listában?
            int elektromos = autok.Where(x => x.Uzemanyag == Uzemanyagok.Elektromos).Count();
            Console.WriteLine(elektromos);


            // Létezik - e a listában olyan autó, amelynek a gyártási éve 2010 előtti ?
            bool letezik = autok.Exists(x => x.GyartasiEv < 2010);
            Console.WriteLine(letezik);

            // Írd ki a 2015 után gyártott autókat rendszám szerint rendezve!
            autok.Where(x => x.GyartasiEv > 2015).OrderBy(x => x.Rendszam)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Az utolsó benzines autó a listában?
            Auto utolsobenzines= autok.Where(x => x.Uzemanyag == Uzemanyagok.Benzin).Last();
            Console.WriteLine(utolsobenzines);

            // Hány új rendszámos autó van a listában ?
            int db = autok.Where(x => x.UjRendszam).Count();
            Console.WriteLine(db);

            // Az 5 legfiatalabb autó a listából(kor szerint növekvő sorrendben)!
            autok.OrderBy(x => x.Kor).Take(5)
                .ToList().ForEach(x => Console.WriteLine(x));

            // Írd ki az összes autót, amely 2000 és 2010 között készült(gyártási év szerint rendezve)!
            autok.Where(x => x.GyartasiEv > 2000 && x.GyartasiEv < 2010)
                .OrderBy(x => x.GyartasiEv).ToList().ForEach(x => Console.WriteLine(x));

            // Hány olyan autó van, amely nem benzines?


            // Van - e a listában olyan autó, amelynek rendszáma "AAAA-123" ?


            // Hány autó készült 2020 után ?


            // Az összes autó, amelynek a rendszámában van a "123" szöveg. (x.Rendszam.Contains("123"))


            // Írd ki az összes autót, amelyik Audi vagy BMW márkájú!


            // Létezik - e olyan autó, amely pontosan 3 éves ?


            // Hány autó készült 2000 előtt ?


            // Hány olyan autó van, amelynek a rendszáma "B" betűvel kezdődik? (x.Rendszam.StartWith("B"))


            // Melyik az első olyan autó, amelynek a gyártási éve páros szám? (x.GyartasiEv % 2 == 0)


            // Az autók száma, amelynek a gyártási éve páratlan szám!

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp57
{
    enum KedvencHelyek { RegiKastely, Temeto, ElhagyatottHaz, Erdo, Alagut }
    enum SzellemFajtak { Kisertet, Kopogoszellem, Arnyek, Demonszellem, Koberlelek }
    class Szellem
    {
        public bool Artalmatlan => Fajta == SzellemFajtak.Koberlelek || Fajta == SzellemFajtak.Kisertet;
        public SzellemFajtak Fajta { get; set; }
        public bool Felelmetes => Fajta == SzellemFajtak.Kopogoszellem || Fajta == SzellemFajtak.Arnyek;
        public DateTime HalalIdopont { get; set; }
        public int Id { get; set; }
        public KedvencHelyek KedvencHely { get; set; }
        public string Nev { get; set; }
        public bool Veszelyes => Fajta == SzellemFajtak.Demonszellem;

        public override string ToString()
        {
            return $"{Artalmatlan} {Fajta} {Felelmetes} {HalalIdopont.ToShortDateString()} {Id} {KedvencHely} {Nev} {Veszelyes}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Szellem> szellemek = new List<Szellem>()
            {
                new Szellem()
                {
                    Fajta=SzellemFajtak.Demonszellem,
                    HalalIdopont= new DateTime(1870,10,03),
                    Id=1,
                    KedvencHely=KedvencHelyek.Temeto,
                    Nev="Michael Jackson",
                },
                new Szellem()
                {
                    Fajta=SzellemFajtak.Koberlelek,
                    HalalIdopont=new DateTime(2020,12,05),
                    KedvencHely= KedvencHelyek.ElhagyatottHaz,
                    Id=2,
                    Nev="Csapbetét Csabi"
                },
                new Szellem()
                {
                    Fajta=SzellemFajtak.Kisertet,
                    HalalIdopont= new DateTime(2003, 03,11),
                    Id=3,
                    KedvencHely=KedvencHelyek.ElhagyatottHaz,
                    Nev="Lakatos Lakat"
                },
                new Szellem()
                {
                    Fajta=SzellemFajtak.Koberlelek,
                    HalalIdopont= new DateTime(2000, 03,11),
                    Id=4,
                    KedvencHely=KedvencHelyek.Alagut,
                    Nev="Imre"
                },
            };
            //az összes szellem listázva
            szellemek.ForEach(x => Console.WriteLine(x));

            //elhalálozás szerint rendezd növekvő sorrendbe(orderBy)
            szellemek.OrderBy(x=>x.HalalIdopont).ToList()
                .ForEach(x => Console.WriteLine(x));

            //Az összes olyan szellem aki temetőben kísért(where)
            szellemek.Where(x=>x.KedvencHely==KedvencHelyek.Temeto).ToList()
                .ForEach(x => Console.WriteLine(x));

            //van olyan szellem aki régi kastélyban kísért, de ártalmatlan? (Exists)
            bool igazE= szellemek.Exists(x => x.Artalmatlan == true && x.KedvencHely == KedvencHelyek.RegiKastely);
            Console.WriteLine(igazE==true? "van":"nincs");

            //az összes szellem darabszáma(count)
            Console.WriteLine(szellemek.Count());

            //Az összes veszélyes és félelmetes szellem(where)
            szellemek.Where(x=>x.Veszelyes==true  || x.Felelmetes==true).ToList()
                .ForEach(x => Console.WriteLine(x));

            //A legrégebben meghalt szellem(orderBy--> first)
            Szellem szellem= szellemek.OrderBy(x => x.HalalIdopont).First();
            Console.WriteLine(szellem);

            //Az első szellem ártalmatlan szellem?
            bool artalmatlan = szellemek.First().Artalmatlan;
            Console.WriteLine(artalmatlan?"igen":"nem");
            Console.ReadKey();
        }
    }
}

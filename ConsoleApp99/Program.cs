using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage2;

namespace ConsoleApp99
{
    class Program
    {
        static void Main(string[] args)
        {
            Theme.Write(Themes.Dark);
            Score.Write(10);

            Console.WriteLine($"téma: {Theme.Read()}");
            Console.WriteLine($"rekord: {Score.Read()}");

            Console.ReadKey();
        }
    }
}

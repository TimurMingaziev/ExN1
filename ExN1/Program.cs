using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ExN1
{
    class Program
    {
        static List<int> mas = new List<int>();
         static void Main(string[] args)
        {
            SuperClass su = new SuperClass();
            su.readFileWhisMas();
            mas = su.sortMas();
            Console.WriteLine("Sorted mas in file sortedMasFile.txt" + '\n');
            su.writeFile(mas);
            Console.WriteLine("Press 'Enter' for end");
            Console.ReadLine();
            
        }
    }

}
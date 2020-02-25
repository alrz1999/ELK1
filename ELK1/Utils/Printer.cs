using ELK1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK1.Utils
{
    class Printer
    {
        public void Print(IReadOnlyCollection<Document> results)
        {
            Console.WriteLine("Search Results:\n");
            if (results.Count == 0)
                Console.WriteLine("nothing was found !!!");
            else
            {
                int counter = 1;
                foreach (var result in results)
                {
                    Console.WriteLine($@"{counter}-  {result.Text}");
                    counter++;
                }
            }
        }
    }
}

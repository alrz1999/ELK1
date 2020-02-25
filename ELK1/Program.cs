using System;
using System.Configuration;
using ELK1.Models;
using ELK1.Utils;
using Nest;

namespace ELK1
{
    class Program
    {
        private const string Path = "C://Users//Asus//source//repos//ConsoleApp1//ConsoleApp1//English.csv";
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            CsvToELK csvToELK = new CsvToELK(Path);
            //csvToELK.InsertDocuments();

            while (true)
            {
                var queryString = Console.ReadLine();
                var result = Client.Instance.searchStirngQuery(queryString);
                printer.Print(result);
            }

        }
    }
}

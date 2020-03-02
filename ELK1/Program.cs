using System;
using System.Configuration;
using ELK1.Factory;
using ELK1.Models;
using ELK1.Repository;
using ELK1.Utils;
using Nest;

namespace ELK1
{
    class Program
    {
        static void Main(string[] args)
        {
            Printer printer = new Printer();
            //CsvReader reader = new CsvReader();
            Uri uri = new Uri(ConfigurationManager.AppSettings["Search-Uri"]);
            ClientFactory clientFactory = new ClientFactory(uri,"document");
            IDocumentRepository<Document> documentRepository = new DocumentRepository(clientFactory.GetClient());

            while (true)
            {
                var queryString = Console.ReadLine();
                var result = documentRepository.Search(queryString);
                printer.Print(result);
            }

        }
    }
}

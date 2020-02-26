using ELK1.Models;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Nest;

namespace ELK1.Utils
{
    public class CsvReader  
    {
        private string path = "C://Users//Asus//source//repos//ConsoleApp1//ConsoleApp1//English.csv";

        public CsvReader(string path)
        {
            this.path = path;
        }

        public CsvReader()
        {
        }

        private IEnumerable<Document> ReadCsv()
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvHelper.CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Document>().ToList();
            }
        }
    }
}

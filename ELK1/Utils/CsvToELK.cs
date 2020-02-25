using ELK1.Models;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Nest;

namespace ELK1.Utils
{
    public class CsvToELK
    {
        private IEnumerable<Document> Documents;

        public CsvToELK(string path)
        {
            this.Documents = ReadCsv(path);
        }

        private IEnumerable<Document> ReadCsv(string path)
        {
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                return csv.GetRecords<Document>().ToList();
            }
        }

        public void InsertDocuments()
        {
            Client.Instance.ElasticClient.IndexMany(Documents);
        }

    }
}

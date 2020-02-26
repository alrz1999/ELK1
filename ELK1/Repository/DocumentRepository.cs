using ELK1.Factory;
using ELK1.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK1.Repository
{
    public class DocumentRepository : IDocumentRepository<Document>
    {
        private Client client;

        public DocumentRepository(Client client)
        {
            this.client = client;
        }
        public void Delete(string id)
        {
            this.client.Delete<Document>(id);
        }

        public Document Get(string id)
        {
            return client.Get<Document>(id).Source;
        }

        public void index(Document document)
        {
            client.IndexDocument<Document>(document);
        }

        public void indexMany(List<Document> documents)
        {
            client.IndexMany<Document>(documents);
        }

        public List<Document> Search(string phrase)
        {
            return client.Search<Document>(s => s.
                Query(q => q
                    .Match(m => m
                        .Field(f => f.Text)
                        .Query(phrase)
                        .Fuzziness(Fuzziness.Auto)
                    )
                )
            ).Documents.ToList();
        }

       
    }
}

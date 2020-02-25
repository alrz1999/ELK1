using ELK1.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ELK1
{
    public sealed class Client
    {
        public ElasticClient ElasticClient { get; }
        static Client()
        {
        }
        private Client()
        {
            var node = new Uri(ConfigurationManager.AppSettings["Search-Uri"]);
            var settings = new ConnectionSettings(node).DefaultIndex("document");
            ElasticClient = new ElasticClient(settings);

        }
        public static Client Instance { get; } = new Client();

        public IReadOnlyCollection<Document> searchStirngQuery(string queryString) {
            var result = Client.Instance.ElasticClient.Search<Document>(doc => doc
                .Index("document")
                .QueryOnQueryString(queryString));
            return result.Documents;

        }
    }
}

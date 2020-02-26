using ELK1.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ELK1.Factory
{
    public class Client : ElasticClient
    {
        public Client(IConnectionSettingsValues connectionSettings) : base(connectionSettings)
        {

        }
    }
}

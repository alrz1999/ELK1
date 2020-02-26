using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK1.Factory
{
    class ClientFactory
    {
        private IConnectionSettingsValues connectionSettings;

        public ClientFactory(Uri uri)
        {
            connectionSettings = new ConnectionSettings(uri);
        }

        public ClientFactory(Uri uri, string defaultIndex)
        {
            connectionSettings = new ConnectionSettings(uri).DefaultIndex(defaultIndex);
        }

        

        public Client GetClient() 
        {
            return new Client(this.connectionSettings);   
        }

    }
}

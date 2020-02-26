using ELK1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELK1.Repository
{
    public interface IClientRepository<T>
    {
        void index(T document);

        void indexMany(List<T> documents);

        void Delete(string id);

        T Get(string id);

        List<T> Search(string phrase);

    }
}

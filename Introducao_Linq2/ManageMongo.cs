using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Introducao_Linq2
{
    internal class ManageMongo
    {
        private readonly MongoClient _cliente = new("mongodb://root:Mongo%402024%23@127.0.0.1:27017/");

        public void InsertPenalties(List<PenalidadesAplicadas> lst)
        {
            var collection = _cliente.GetDatabase("Motoristas").GetCollection<PenalidadesAplicadas>("Penalidades");
            collection.InsertMany(lst);
        }
    }
}

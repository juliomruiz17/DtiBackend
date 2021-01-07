using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DtiBackend.Repositories
{
    public class MongoDBRepository
    {
            public MongoClient client;

            public IMongoDatabase db;

            public MongoDBRepository()
            {
                client = new MongoClient("mongodb+srv://DtiDigital:25932567@cluster0.e0o39.mongodb.net/DtiDigital?retryWrites=true&w=majority");

                db = client.GetDatabase("DtiBase");
            }
        }
}

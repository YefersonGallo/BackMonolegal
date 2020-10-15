using MongoDB.Driver;

namespace BackMonolegal.Repositories
{
    public class MongoDBRespository
    {
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDBRespository()
        {
            client = new MongoClient("mongodb://localhost:27017");
            db = client.GetDatabase("Invoices");
        }
    }
}
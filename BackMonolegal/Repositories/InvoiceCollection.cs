using BackMonolegal.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackMonolegal.Repositories
{
    public class InvoiceCollection : IInvoiceCollection
    {
        internal MongoDBRespository _repository = new MongoDBRespository();
        private IMongoCollection<Invoice> Collection;

        public InvoiceCollection()
        {
            Collection = _repository.db.GetCollection<Invoice>("Invoices");
        }

        public void CreateInvoice(Invoice invoice)
        {
            Collection.InsertOneAsync(invoice);
        }

        public void DeleteInvoice(string id)
        {
            var filter = Builders<Invoice>.Filter.Eq(s => s.Id, new ObjectId(id));
            Collection.DeleteOneAsync(filter);
        }

        public List<Invoice> getAllInvoices()
        {
            return Collection.FindAsync(new BsonDocument()).Result.ToList();
        }

        public Invoice getInvoiceById(string id)
        {
            return Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.First();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            var filter = Builders<Invoice>.Filter.Eq(s => s.Id, invoice.Id);
            Collection.ReplaceOneAsync(filter, invoice);
        }
    }
}
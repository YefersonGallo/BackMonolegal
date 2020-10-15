using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace BackMonolegal.Models
{
    public class Invoice
    {
        [BsonId]
        public ObjectId Id{ get; set; }
        public string InvoiceCode { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string City { get; set; }
        public string NIT { get; set; }
        public float InvioceFull { get; set; }
        public float SubTotal { get; set; }
        public float Iva { get; set; }
        public float Retencion { get; set; }
        public DateTime CreationDate { get; set; }
        public string State { get; set; }
        public bool Paid { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
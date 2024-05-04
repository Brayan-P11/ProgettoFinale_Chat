using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat_Online.Models
{
    public class Messaggio
    {
        [BsonId]
        public ObjectId MessaggioID { get; set; }

        [BsonElement("codi")]
        public string Codice { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("nomU")]
        public string? NomeUtente { get; set; }

        [BsonElement("cont")]
        public string? Contenuto { get; set; }

        [BsonElement("ora")]
        public DateTime Orario { get; set; }
    }
}

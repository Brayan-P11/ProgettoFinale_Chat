using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Chat_Online.Models
{
    public class Stanza
    {
        [BsonId]
        public ObjectId StanzaID { get; set; }

        [BsonElement("codS")]
        public string Codice { get; set; } = Guid.NewGuid().ToString();

        [BsonElement("nome")]
        public string? Nome { get; set; }

        [BsonElement("desc")]
        public string? Descrzione { get; set; }

        [BsonElement("utenti")]
        public List<string>? Utentes { get; set; }

        [BsonElement("messaggiID")]
        public List<ObjectId>? MessaggioID { get; set; }

        [BsonElement("messaggi")]
        public List<Messaggio>? Messaggios { get; set; }


    }
}

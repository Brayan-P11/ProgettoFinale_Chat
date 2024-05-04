using Chat_Online.Models;
using MongoDB.Driver;

namespace Chat_Online.Repositories
{
    public class StanzaRepo : IRepo<Stanza>
    {

        private IMongoCollection<Stanza> stanze;
        private readonly ILogger _logger;

        public StanzaRepo(IConfiguration configuration, ILogger<MessaggioRepo> logger)
        {
            this._logger = logger;

            string? connessioneLocale = configuration.GetValue<string>("MongoDbSettings:Locale");
            string? databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.stanze = _database.GetCollection<Stanza>("Stanzas");

        }

        public bool Delete(string code)
        {
            try
            {
                this.stanze.DeleteOne<Stanza>(s => s.Codice == code);

                _logger.LogInformation("Stanza eliminato");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public List<Stanza> GetAll()
        {
            return stanze.Find(s => true).ToList();
        }

        public Stanza? GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Stanza? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Stanza item)
        {
            try
            {
                if (stanze.Find(s => s.Codice == item.Codice).ToList().Count > 0)
                    return false;

                stanze.InsertOne(item);
                _logger.LogInformation("Stanza creata con successo");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public bool Update(Stanza item)
        {
            Stanza? stanzaTemp = GetByCode(item.Codice);
            if (stanzaTemp != null)
            {
                stanzaTemp.Nome = item.Nome != null ? item.Nome : stanzaTemp.Nome;
                stanzaTemp.Descrzione = item.Descrzione != null ? item.Descrzione : stanzaTemp.Descrzione;

                var filter = Builders<Stanza>.Filter.Eq(s => s.StanzaID, stanzaTemp.StanzaID);
                try
                {
                    stanze.ReplaceOne(filter, stanzaTemp);
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return false;
        }
    }
}

using Chat_Online.Models;
using MongoDB.Driver;

namespace Chat_Online.Repositories
{
    public class MessaggioRepo : IRepo<Messaggio>
    {
        private IMongoCollection<Messaggio> messaggi;
        private readonly ILogger _logger;
        public MessaggioRepo(IConfiguration configuration, ILogger<MessaggioRepo> logger)
        {
            this._logger = logger;

            string? connessioneLocale = configuration.GetValue<string>("MongoDbSettings:Locale");
            string? databaseName = configuration.GetValue<string>("MongoDbSettings:DatabaseName");

            MongoClient client = new MongoClient(connessioneLocale);
            IMongoDatabase _database = client.GetDatabase(databaseName);
            this.messaggi = _database.GetCollection<Messaggio>("Messaggios");

        }


        
        public List<Messaggio> GetAll()
        {
            //List<Messaggio> elenco = impiegati.AsQueryable().ToList();
            return messaggi.Find(m => true).ToList();
        }
        

        public Messaggio? GetByCode(string code)
        {
            throw new NotImplementedException();

        }

        public Messaggio? GetById(int id)
        {
            throw new NotImplementedException();
        }

        
        public bool Insert(Messaggio item) // da sistemare
        {
            try
            {
                if (messaggi.Find(m => m.Codice == item.Codice).ToList().Count > 0)
                    return false;

                messaggi.InsertOne(item);
                _logger.LogInformation("Messaggio inserito con successo");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public bool Delete(string code) // da controllare
        {
            try
            {
                this.messaggi.DeleteOne<Messaggio>(m => m.Codice == code);

                _logger.LogInformation("Messaggio eliminato");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public bool Update(Messaggio item) // da implementare
        {
            throw new NotImplementedException();
        }
    }
}

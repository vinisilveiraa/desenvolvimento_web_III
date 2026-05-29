using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Numerics;
using System.Security.Authentication;
using ex1.Models;


namespace ex1.Data
{
    public class ContextMongoDb
    {
        private readonly IMongoDatabase _database;
        public ContextMongoDb(IOptions<MongoSettings> settings)
        {
            var mongoSettings = settings.Value;
            var mongoUrl = new MongoUrl(mongoSettings.ConnectionString);
            var clientSettings = MongoClientSettings.FromUrl(mongoUrl);
            if (mongoSettings.IsSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }
            var client = new MongoClient(clientSettings);
            _database = client.GetDatabase(mongoSettings.Database);

        }
        public IMongoCollection<Trabalho> Trabalho
        {
            get { return _database.GetCollection<Trabalho>("Trabalho"); }
        }        
        public IMongoCollection<Avaliacao> Avaliacao
        {
            get { return _database.GetCollection<Avaliacao>("Avaliacao"); }
        }
        
    }
}

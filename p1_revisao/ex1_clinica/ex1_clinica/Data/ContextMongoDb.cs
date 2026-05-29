using ex1_clinica.Data;
using ex1_clinica.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Numerics;
using System.Security.Authentication;

// ACESSO REAL AO MONGODB
// conecta no mongo


namespace ex1_clinica.Data
{
    public class ContextMongoDb
    {
        // guarda conexao com o banco
        private readonly IMongoDatabase _database;

        // recebe as configs do appsettings por aqui
        public ContextMongoDb(IOptions<MongoSettings> settings)
        {
            var mongoSettings = settings.Value;
            // converte a string em objeto de conexao
            var mongoUrl = new MongoUrl(mongoSettings.ConnectionString);
            // cria config avançada do cliente Mongo

            var clientSettings = MongoClientSettings.FromUrl(mongoUrl);

            // ativa IsSsl se necessario
            if (mongoSettings.IsSsl)
            {
                clientSettings.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }
            // cria conexao com o mongodb
            var client = new MongoClient(clientSettings);
            // define _database (seleciona o banco)
            _database = client.GetDatabase(mongoSettings.Database);
        }
        // aqui representa a tabela clinica
        public IMongoCollection<Clinica> Clinica
        {
            // pega ela
            get { return _database.GetCollection<Clinica>("Clinica"); }
        }
    }
}

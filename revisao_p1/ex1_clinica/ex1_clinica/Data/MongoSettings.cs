namespace ex1_clinica.Data
{
    public class MongoSettings
    {
        // endereco do mongo
        public string ConnectionString { get; set; }
        // nome do banco
        public string Database { get; set; }
        // seguranca da conexao
        public bool IsSsl { get; set; }

    }
}

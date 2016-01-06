using MongoDB.Driver;

namespace Core.Data.Contexts
{
    public class MongoContext
    {
        public MongoClient Client { get; private set; }
        public IMongoDatabase Database { get; private set; }

        public MongoContext()
        {
            Client = new MongoClient();
            Database = Client.GetDatabase("Cadastros");
        }
    }
}

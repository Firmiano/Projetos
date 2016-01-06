
using Core.Data.Contexts;
using MongoDB.Driver;

namespace Core.Data.Repository
{
    public abstract class MongoRepository <T> where T : class 
    {
        public MongoContext Context { get; private set; }
        protected MongoRepository()
        {
            Context = new MongoContext();
        } 

        public IMongoCollection<T> Collection()
        {
            return Context.Database.GetCollection<T>("Enderecos");
        }
    }
}

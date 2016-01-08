
using System;
using Core.Data.Contexts;
using MongoDB.Bson;
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
            return Context.Database.GetCollection<T>(typeof(T).Name);
        }
        public IMongoCollection<BsonDocument> CollectionGeneric()
        {
            return Context.Database.GetCollection<BsonDocument>(typeof(T).Name);
        }

    }
}

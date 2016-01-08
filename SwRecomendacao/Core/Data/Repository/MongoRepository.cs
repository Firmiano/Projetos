
using System;
using Core.Data.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Core.Data.Repository
{
    public abstract class MongoRepository <T> where T : class 
    {
        public MongoContext Context { get; private set; }
        protected MongoRepository()
        {
            Context = new MongoContext();
        } 

        public IMongoCollection<BsonDocument> Collection()
        {
            return Context.Database.GetCollection<BsonDocument>(typeof(T).Name);
        }
    }
}

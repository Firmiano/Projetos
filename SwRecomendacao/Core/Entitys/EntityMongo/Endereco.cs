using MongoDB.Bson;

namespace Core.Entitys.EntityMongo
{
    public abstract class Endereco
    {
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Rua { get; set; }
        public BsonDocument Location { get; set; }
    }
}

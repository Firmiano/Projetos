using MongoDB.Bson;

namespace Core.Entitys.EntityMongo
{
    public abstract class Endereco
    {
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Bairoo { get; set; }
        public string Rua { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

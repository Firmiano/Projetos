using Core.Entitys.EntityMongo;

namespace Core.Data.Repository
{
    public class EnderecoRepository : MongoRepository<Endereco>
    {
        public void Insert(Endereco endereco)
        {
            Collection().InsertOne(endereco);
        }
    }
}

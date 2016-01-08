using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core.Entitys.EntityMongo;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Core.Data.Repository
{
    public class EnderecoRepository : MongoRepository<Endereco>
    {
        public void Insert(Endereco endereco)
        {
            Collection().InsertOne(endereco);
        }

        public BsonDocument FindByLojaId(int lojaId)
        {
            var query = "{'LojaId': " + lojaId + "}";
            var result = CollectionGeneric().Find(query).ToList().First();

            return result;
        }

        public BsonDocument FindByUsuarioId(int usuarioId)
        {
            var query = "{'UsuarioId': " + usuarioId + "}";
            var result = CollectionGeneric().Find(query).ToList().First();

            return result;
        }
        public ICollection<BsonDocument> FindByTipo(string tipo)
        {
            var query = "{'_t': '" + tipo + "'}";
            return CollectionGeneric().Find(query).ToList();
        }

        public ICollection<BsonDocument> ListarPotTipoRaio(double lat, double lng, string tipo, int raio)
        {
            var filtro = @"{'Location' : 
                                         { $near :
                                            {$geometry : {
                                                            type : 'Point' ,
                                                            coordinates :  ["
                                                                             + lat.ToString(CultureInfo.InvariantCulture).Replace(",", ".")
                                                                             + ","
                                                                             + lng.ToString(CultureInfo.InvariantCulture).Replace(",", ".")
                                                                             + @"]
                                                         },
                                                            $maxDistance : " + raio + @"
                                            }
                                          },
                                    '_t' : '" + tipo + "'}}";

            return CollectionGeneric().Find(filtro).ToList();
        }
    }
}

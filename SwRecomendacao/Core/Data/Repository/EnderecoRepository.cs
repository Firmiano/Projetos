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
        public void Insert(BsonDocument endereco)
        {
            Collection().InsertOne(endereco);
        }

        public BsonDocument FindByLojaId(int lojaId)
        {
            var query = "{'LojaId': " + lojaId + "}";
            var result = Collection().Find(query).ToList().First();

            return result;
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

            return Collection().Find(filtro).ToList();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Data.Repository;
using Core.Entitys.EntityMongo;
using Core.Mappers;
using Core.Model;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;
using Newtonsoft.Json;

namespace Core.Business
{
    public class ParceiroBs
    {
        public ParceiroBs()
        {
            AutoMapperConfig.RegisterMappings();
        }
        public void CadastrarEndereco(ParceiroEnderecoMd endereco)
        {
            var enderecoEntity = Mapper.Map<ParceiroEnderecoMd, ParceiroEndereco>(endereco);
            enderecoEntity.Location = GeoJson.Point(new GeoJson2DCoordinates(endereco.Latitude, endereco.Longitude)).ToBsonDocument();

            var repository = new EnderecoRepository();
            repository.Insert(BsonDocument.Create(enderecoEntity));
        }

        public ICollection<UsuarioEndereco> ListarUsuariosEntornoLoja(int lojaId, int raio)
        {
            var repository = new EnderecoRepository();

            var loja = repository.FindByLojaId(lojaId);

            var coordenadas = loja["Location"]["coordinates"];

            var result = repository.ListarPotTipoRaio(coordenadas[0].ToDouble(), coordenadas[1].ToDouble(), "UsuarioEndereco", raio);

            return result.Select(r => new UsuarioEndereco()
            {
                Cep = r["Cep"].ToString(),
                Location = (BsonDocument)r["Location"],
                Rua = r["Rua"].ToString(),
                Uf = r["Uf"].ToString(),
                UsuarioId = r["UsuarioId"].ToInt32()
            }).ToList();
        }
    }

}

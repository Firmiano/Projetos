using AutoMapper;
using Core.Data.Repository;
using Core.Entitys.EntityMongo;
using Core.Mappers;
using Core.Model;
using MongoDB.Bson;
using MongoDB.Driver.GeoJsonObjectModel;

namespace Core.Business
{
    public class UsuarioBs
    {
        public UsuarioBs()
        {
            AutoMapperConfig.RegisterMappings();
        }

        public void CadastrarEndereco(UsuarioEnderecoMd endereco)
        {
            var enderecoEntity = Mapper.Map<UsuarioEnderecoMd, UsuarioEndereco>(endereco);
            enderecoEntity.Location = GeoJson.Point(new GeoJson2DCoordinates(endereco.Latitude, endereco.Longitude)).ToBsonDocument();

            var repository = new EnderecoRepository();
            repository.Insert(BsonDocument.Create(enderecoEntity));
        }
    }
}

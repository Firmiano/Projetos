using AutoMapper;
using Core.Entitys.EntityMongo;
using Core.Model;

namespace Core.Mappers
{
    public class EntityToModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ParceiroEndereco, ParceiroEnderecoMd>();
            Mapper.CreateMap<UsuarioEndereco, UsuarioEnderecoMd>();
        }
    }
}

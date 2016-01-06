using AutoMapper;
using Core.Entitys.EntityMongo;
using Core.Model;

namespace Core.Mappers
{
    public class ModelToEntityMappingProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<ParceiroEnderecoMd,ParceiroEndereco>();
            Mapper.CreateMap<UsuarioEnderecoMd, UsuarioEndereco>();
        }
    }
}

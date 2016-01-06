using AutoMapper;
using Core.Data.Repository;
using Core.Entitys.EntityMongo;
using Core.Mappers;
using Core.Model;

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

            var repository = new EnderecoRepository();
            repository.Insert(enderecoEntity);
        }
    }
}

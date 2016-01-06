using AutoMapper;
using Core.Data.Repository;
using Core.Entitys.EntityMongo;
using Core.Mappers;
using Core.Model;

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
            var enderecoEntity = Mapper.Map<ParceiroEnderecoMd,ParceiroEndereco>(endereco);
            
            var repository = new EnderecoRepository();
            repository.Insert(enderecoEntity);
        }
    }
}

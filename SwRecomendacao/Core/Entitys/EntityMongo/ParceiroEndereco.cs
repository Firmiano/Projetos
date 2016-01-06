namespace Core.Entitys.EntityMongo
{
    public class ParceiroEndereco : Endereco
    {
        public int UsuarioIdParceiro { get; set; }
        public int LojaId { get; set; }
    }
}

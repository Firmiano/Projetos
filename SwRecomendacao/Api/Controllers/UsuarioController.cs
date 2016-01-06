using System.Web.Http;
using Core.Business;
using Core.Model;

namespace Api.Controllers
{
    public class UsuarioController : ApiController
    {
        public void Post([FromBody] UsuarioEnderecoMd endereco)
        {
            var bs = new UsuarioBs();
            bs.CadastrarEndereco(endereco);
        }
    }
}

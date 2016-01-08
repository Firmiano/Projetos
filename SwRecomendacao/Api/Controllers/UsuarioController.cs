using System.Linq;
using System.Web.Http;
using Api.Hubs;
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

            var lojas = bs.ListarLojasEntornoUsuario(endereco.UsuarioId, 5000).ToArray();
            
            UsuarioHub.PublicarNovoEndereco(lojas);
        }
    }
}

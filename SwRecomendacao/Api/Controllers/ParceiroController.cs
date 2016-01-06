using System.Web.Http;
using Core.Business;
using Core.Model;

namespace Api.Controllers
{
    public class ParceiroController : ApiController
    {
        public void Post([FromBody] ParceiroEnderecoMd endereco)
        {
            var bs = new ParceiroBs();
            bs.CadastrarEndereco(endereco);
        }
    }
}

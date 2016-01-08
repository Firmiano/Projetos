using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core.Business;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IDictionary<int, int> lojaUsuarios = new Dictionary<int, int>();

            var parceiroBs = new ParceiroBs();
            var lojas = parceiroBs.ListarLojas().GroupBy(x => new { x.UsuarioIdParceiro, x.LojaId });

            foreach (var loja in lojas)
            {
                var quantidade = parceiroBs.ListarUsuariosEntornoLoja(loja.Key.LojaId, 5000).Count;

                lojaUsuarios.Add(loja.Key.LojaId, quantidade);
            }

            var result =
                from id in lojas
                where lojaUsuarios.ContainsKey(id.Key.LojaId)
                let value1 = lojaUsuarios[id.Key.LojaId]
                let value2 = lojas.FirstOrDefault(c => c.Key.LojaId == id.Key.LojaId).Key.UsuarioIdParceiro
                select new LojasView() {LojaId = id.Key.LojaId, Usuarios = value1, UsuarioIdParceiro = value2};

            return View(result.ToArray());
        }
    }
}
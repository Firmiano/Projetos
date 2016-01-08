using Core.Business;
using Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteCore
{
    [TestClass]
    public class ParceiroBsTeste
    {
        [TestMethod]
        public void ListaUsuariosLojaPorRaio()
        {
            var parceiroBs = new ParceiroBs();
            var result = parceiroBs.ListarUsuariosEntornoLoja(31573, 1000).Count;
        }
    }
}

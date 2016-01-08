using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Importador
{
    public static class Parceiro
    {
        public static void Importar(StreamReader arquivo)
        {
            string linha;

            while ((linha = arquivo.ReadLine()) != null)
            {
                var dados = linha.Split(';');

                var parceiroview = new ParceiroView()
                {
                    UsuarioIdParceiro = Convert.ToInt32(dados[0]),
                    LojaId = Convert.ToInt32(dados[1]),
                    Cep = "0000000",
                    Latitude = Convert.ToDouble(dados[2]),
                    Longitude = Convert.ToDouble(dados[3]),
                    Rua = dados[4],
                    Uf = dados[5]
                };

                var json = JsonConvert.SerializeObject(parceiroview);

                var req = WebRequest.Create("http://localhost:56062/api/parceiro/");
                var enc = new UTF8Encoding(false);
                var data = enc.GetBytes(json);

                req.Method = "POST";
                req.ContentType = "application/json";
                req.ContentLength = data.Length;

                using (var sr = req.GetRequestStream())
                {
                    sr.Write(data, 0, data.Length);
                }
            }
        }
    }
}

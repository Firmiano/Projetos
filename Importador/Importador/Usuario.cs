using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Importador
{
    public static class Usuario
    {
        public static void Importar(StreamReader arquivo)
        {
            string linha;
            var arquivoErro = new StreamWriter(@"C:\Users\Firmiano\Desktop\WriteLines2.txt");

            while ((linha = arquivo.ReadLine()) != null)
            {
                var dados = linha.Split(';');

                var usuarioView = new UsuarioView()
                {
                    UsuarioId = Convert.ToInt32(dados[0]),
                    Cep = dados[1]
                };

                var dadosCorreios = ApiCorreios(usuarioView.Cep);

                string resultCorreio = dadosCorreios.ToString();

                if (!string.IsNullOrEmpty(resultCorreio) && !resultCorreio.Contains("erro"))
                {
                    var objCorreio = JsonConvert.DeserializeObject<dynamic>(dadosCorreios);
                    usuarioView.Rua = objCorreio.logradouro;
                    usuarioView.Uf = objCorreio.uf;

                    var dadosGoogle = ApiGoogleMaps(usuarioView.Rua, dados[2], objCorreio.bairro.ToString(),
                        usuarioView.Uf);
                    var objGoogle = JsonConvert.DeserializeObject<dynamic>(dadosGoogle);
                    var status = objGoogle["status"];

                    if (status != "OK")
                    {
                        dadosGoogle = ApiGoogleMaps(usuarioView.Rua, null, null, usuarioView.Uf);
                        objGoogle = JsonConvert.DeserializeObject<dynamic>(dadosGoogle);
                        status = objGoogle["status"];

                        if (status != "OK")
                        {
                            dadosGoogle = ApiGoogleMaps(null, null, null, null, usuarioView.Cep);
                            objGoogle = JsonConvert.DeserializeObject<dynamic>(dadosGoogle);
                            status = objGoogle["status"];

                            if (status != "OK")
                            {
                                arquivoErro.WriteLine(linha);
                                arquivoErro.Flush();
                            }
                        }
                    }
                    if (status == "OK")
                    {
                        usuarioView.Latitude = Convert.ToDouble(objGoogle["results"][0]["geometry"]["location"]["lat"]);
                        usuarioView.Longitude = Convert.ToDouble(objGoogle["results"][0]["geometry"]["location"]["lng"]);

                        var json = JsonConvert.SerializeObject(usuarioView);

                        var req = WebRequest.Create("http://localhost:56062/api/usuario/");
                        var enc = new UTF8Encoding(false);
                        var data = enc.GetBytes(json);

                        req.Method = "POST";
                        req.ContentType = "application/json";
                        req.ContentLength = data.Length;

                        using (var sr = req.GetRequestStream())
                        {
                            sr.Write(data, 0, data.Length);
                        }

                        Console.WriteLine("enviado");
                    }
                }
                else
                {
                    arquivoErro.WriteLine(linha);                   
                    arquivoErro.Flush();
                }
            }

            arquivoErro.Close();
        }

        private static dynamic ApiCorreios(string cep)
        {
            var url = string.Format("http://cep.correiocontrol.com.br/{0}.json", cep);

            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/json";
            HttpWebResponse webresponse = null;

            var contador = 0;
            while (contador <= 3)
            {
                try
                {
                    webresponse = (HttpWebResponse)webrequest.GetResponse();
                    contador = 4;
                }
                catch (Exception)
                {
                    webrequest = (HttpWebRequest)WebRequest.Create(url);
                    webrequest.Method = "GET";
                    webrequest.ContentType = "application/json";
                    Console.WriteLine(contador);
                    contador++;
                }
            }
            var result = string.Empty;

            if (webresponse != null)
            {
                var enc = Encoding.GetEncoding("utf-8");

                using (var responseStream = new StreamReader(webresponse.GetResponseStream(), enc))
                {
                    result = responseStream.ReadToEnd();
                }

                webresponse.Close();
            }
            return result;
        }

        private static dynamic ApiGoogleMaps(string rua, string numero, string bairro, string uf,string cep = null)
        {
            string url;
            if (cep == null)
            {
                if (string.IsNullOrEmpty(bairro) && string.IsNullOrEmpty(numero))
                    url = string.Format("http://maps.google.com/maps/api/geocode/json?address={0},{1}&sensor=true.", rua, uf);
                else
                    url = string.Format("http://maps.google.com/maps/api/geocode/json?address={0},{1},{2},{3}&sensor=true.", rua, numero, bairro, uf);
            }else
                url = string.Format("http://maps.google.com/maps/api/geocode/json?address={0}&sensor=true.", cep);

            var webrequest = (HttpWebRequest)WebRequest.Create(url);
            webrequest.Method = "GET";
            webrequest.ContentType = "application/json";
            HttpWebResponse webresponse = null;

            var contador = 0;
            while (contador <= 3)
            {
                try
                {
                    webresponse = (HttpWebResponse)webrequest.GetResponse();
                    contador = 4;
                }
                catch (Exception)
                {
                    webrequest = (HttpWebRequest)WebRequest.Create(url);
                    webrequest.Method = "GET";
                    webrequest.ContentType = "application/json";

                    Console.WriteLine(contador);
                    contador++;
                }
            }
            var result = string.Empty;

            if (webresponse != null)
            {
                var enc = Encoding.GetEncoding("utf-8");

                using (var responseStream = new StreamReader(webresponse.GetResponseStream(), enc))
                {
                    result = responseStream.ReadToEnd();
                }

                webresponse.Close();
            }
            return result;
        }
    }
}


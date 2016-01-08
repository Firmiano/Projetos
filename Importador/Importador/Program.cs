using System;
using System.IO;

namespace Importador
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader arquivo;
            try
            {
                arquivo = Arquivo(args[1]);
                switch (args[0])
                {
                    case "0":
                        Parceiro.Importar(arquivo);
                        break;
                    case "1":
                        Usuario.Importar(arquivo);
                        break;
                    default:
                        throw new Exception("Erro tipo de processamento");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            arquivo.Dispose();
            arquivo.Close();
        }

        public static StreamReader Arquivo(string caminho)
        {
            if (string.IsNullOrEmpty(caminho))
                throw new Exception("Erro caminho arquivo nulo");
            
            if(!File.Exists(caminho))
                throw new Exception("Caminho do arquivo não existe");
                
            return new StreamReader(caminho);
        }
    }
}

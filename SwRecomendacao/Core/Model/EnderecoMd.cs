namespace Core.Model
{
    public abstract class EnderecoMd
    {
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Bairoo { get; set; }
        public string Rua { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}

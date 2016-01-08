namespace Core.Model
{
    public abstract class EnderecoMd
    {
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Rua { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}

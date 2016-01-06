using System;
using Api.Entity;

namespace Api.Models
{
    public class Visita
    {
        public Produto Produto { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime Data { get; set; }
        public string Aplicacao { get; set; }
    }
}
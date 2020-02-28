using System;

namespace DCGP.TesteGol.Domain
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int QtdPassageiros { get; set; }
        public DateTime DataCriacaoRegistro { get; set; } = DateTime.Now;
    }
}

using System;

namespace DCGP.TesteGol.Domain.DTOs
{
    public class AirplaneDTO
    {
        public int modeloId { get; private set; }
        public string modeloAirplane { get; private set; }
        public int qtdPassengers { get; private set; }
        public DateTime dateCreated { get; private set; }

        public AirplaneDTO(int modeloId, string modeloAirplane, int qtdPassengers, DateTime dateCreated)
        {
            this.modeloId = modeloId;
            this.modeloAirplane = modeloAirplane;
            this.qtdPassengers = qtdPassengers;
            this.dateCreated = dateCreated;
        }
    }
}

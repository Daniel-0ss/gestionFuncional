using System;

namespace CitasService.Domain.Entities
{
    public class Cita
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }

        // Relación con Persona
        public Guid PacienteId { get; set; }
        public Guid MedicoId { get; set; }

        // Estado: "Pendiente", "En proceso", "Finalizada"
        public string Estado { get; set; }

        public void MarcarEnProceso()
        {
            Estado = "En proceso";
        }

        public void Finalizar()
        {
            Estado = "Finalizada";
        }
    }
}

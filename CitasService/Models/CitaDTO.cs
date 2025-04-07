using System;

namespace CitasService.Models
{
    public class CitaDto
    {
        public Guid Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public int PacienteId { get; set; }
        public int MedicoId { get; set; }
        public string Estado { get; set; } // "Pendiente", "En proceso", "Finalizada"
    }
}

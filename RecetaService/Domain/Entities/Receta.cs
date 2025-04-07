using System;

namespace RecetasService.Domain.Entities
{
    public class Receta
    {
        public int Id { get; set; }
        public string CodigoUnico { get; set; }  // identificador único
        public int PacienteId { get; set; }      // asociación a paciente
        public string Estado { get; set; }       // "Activa", "Vencida", "Entregada"
        public DateTime FechaCreacion { get; set; }
    }
}

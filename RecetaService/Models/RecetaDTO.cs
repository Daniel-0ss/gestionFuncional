using System;

namespace RecetasService.Models
{
    public class RecetaDto
    {
        public int Id { get; set; }
        public string CodigoUnico { get; set; }
        public int PacienteId { get; set; }
        public string Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

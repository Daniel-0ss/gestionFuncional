namespace PersonasService.Domain.Entities
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TipoPersona { get; set; } // "Paciente" o "Medico"
    }
}
namespace WebApiPacientes.Models
{
    public class Paciente
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        //lleno

        public string NumeroIdentidad { get; set; } = string.Empty;
        //13 exac
        public DateTime FechaNacimiento { get; set; }
        //menor a la actual

        public string Telefono { get; set; } = string.Empty;
        //min 8
        public bool Activo { get; set; } = true;
    }
}

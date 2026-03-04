using WebApiPacientes.Models;

namespace WebApiPacientes.Services
{
    public class PacientreDomainServices
    {
        public void ValidarPaciente(Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.NombreCompleto))
                throw new Exception("El nombre del paciente no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(paciente.NumeroIdentidad) || paciente.NumeroIdentidad.Length != 13)
                throw new Exception("La identidad debe tener exactamente 13 caracteres.");

            if (string.IsNullOrWhiteSpace(paciente.Telefono) || paciente.Telefono.Length < 8)
                throw new Exception("El teléfono debe tener minimo 8 dígitos para ser valido.");

            if (paciente.FechaNacimiento > DateTime.Now)
                throw new Exception("La fecha de nacimiento no puede ser mayor al año actual.");
        }
    }
}

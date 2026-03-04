
using WebApiPacientes.Models;
using WebApiPacientes.Services;

public class PacienteAppService
{
    private readonly List<Paciente> _pacientes;
    private readonly PacientreDomainServices _domainService;

    public PacienteAppService(PacientreDomainServices domainService)
    {
        _domainService = domainService;
        // Pacientes Inicializados
        _pacientes = new List<Paciente> {
            new Paciente { Id = 1, NombreCompleto = "Osama Vinladen", NumeroIdentidad = "0301199000234", FechaNacimiento = new DateTime(1990, 1, 1), Telefono = "1234567 "},
            new Paciente { Id = 2, NombreCompleto = "Garnacho Argent", NumeroIdentidad = "1201200219117", FechaNacimiento = new DateTime(1985, 5, 15), Telefono = "1234567" },
            new Paciente { Id = 3, NombreCompleto = "Antony Chirinos", NumeroIdentidad = "0307200500133", FechaNacimiento = new DateTime(2000, 10, 20), Telefono = "1234567" }
        };
    }

    public List<Paciente> ListarTodo() => _pacientes;

    public Paciente? ObtenerPorId(int id) => _pacientes.FirstOrDefault(p => p.Id == id);

    public void Agregar(Paciente nuevo)
    {
        //Se validan los datos
        _domainService.ValidarPaciente(nuevo); 
        nuevo.Id = _pacientes.Any() ? _pacientes.Max(p => p.Id) + 1 : 1;
        _pacientes.Add(nuevo);
    }

    public void Modificar(int id, Paciente actualizado)
    {
        var index = _pacientes.FindIndex(p => p.Id == id);
        if (index == -1) throw new Exception("El paciente no esta en la lista.");

        _domainService.ValidarPaciente(actualizado);
        actualizado.Id = id;
        _pacientes[index] = actualizado;
    }

    public void Eliminar(int id) => _pacientes.RemoveAll(p => p.Id == id);
}
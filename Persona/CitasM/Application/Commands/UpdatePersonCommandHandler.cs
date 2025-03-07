using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Personas.Application.DTO;
using Personas.Domain.Interfaces;
using Personas.Domain.Entities;
using Personas.Application.Commands;
using AutoMapper;

public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand, bool>
{
    private readonly IPersonaRepository _personaRepository;


    public UpdatePersonCommandHandler(IPersonaRepository personaRepository, IMapper mapper)
    {
        _personaRepository = personaRepository;

    }

    public async Task<bool> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        // Obtener la persona mediante algún método asíncrono (por ejemplo, GetByDocumentoAsync)
        var personaEntitie = await _personaRepository.GetByDocumentoAsync(request.Identificacion);
        if (personaEntitie == null)
        {
            return false;
        }

        // Actualizar propiedades
        personaEntitie.TipoIdentificacion = request._personaDto.TipoIdentificacion;
        personaEntitie.Identificacion = request._personaDto.Identificacion;
        personaEntitie.TipoPersonas = request._personaDto.TipoPersonas;
        personaEntitie.Nombres = request._personaDto.Nombres;
        personaEntitie.Apellidos = request._personaDto.Apellidos;

        // Actualizar la persona en el repositorio
        await _personaRepository.UpdatePerson(personaEntitie);
        return true;
    }
}

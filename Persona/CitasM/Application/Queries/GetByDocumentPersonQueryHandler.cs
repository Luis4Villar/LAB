using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Personas.Application.DTO;
using Personas.Application.Queries;
using Personas.Domain.Interfaces;


namespace Personas.Application.Handlers
{
    public class GetByDocumentPersonQueryHandler : IRequestHandler<GetByDocumentPersonQuery, PersonaDto>
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly IMapper _mapper;

        public GetByDocumentPersonQueryHandler(IPersonaRepository personaRepository, IMapper mapper)
        {
            _personaRepository = personaRepository;
            _mapper = mapper;
        }

        public async Task<PersonaDto> Handle(GetByDocumentPersonQuery request, CancellationToken cancellationToken)
        {
            var persona = await _personaRepository.GetByDocumentoAsync(request._Identificacion);
            return _mapper.Map<PersonaDto>(persona);
        }
    }
}

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using Citas.Domain.Interfaces;
using Citas.Application.Dto;

namespace Citas.CQRS.Queries
{
    public class GetCitaaByIdHandler : IRequestHandler<GetCitasByIdQuery, RecetasDto>
    {
        private readonly ICitasRepository _repository;
        private readonly IMapper _mapper;

        public GetCitaaByIdHandler(ICitasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<RecetasDto> Handle(GetCitasByIdQuery request, CancellationToken cancellationToken)
        {
            var receta = _repository.GetCitasId(request.Id);
            return _mapper.Map<RecetasDto>(receta);
        }
    }
}
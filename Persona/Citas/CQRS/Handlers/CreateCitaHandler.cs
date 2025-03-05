using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using Citas.Domain.Interfaces;
using Citas.CQRS.Commands;
using AutoMapper;
using Citas.Domain.Entities;

namespace Citas.CQRS.Handlers
{
	public class CreateCitaHandler
	{
        private readonly ICitasRepository _repository;
        private readonly IMapper _mapper;

        public CreateCitaHandler(ICitasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCitasCommand request, CancellationToken cancellationToken)
        {
            var recetaEntity = _mapper.Map<CitasM>(request.Receta);
            await _repository.Add(recetaEntity);
            return recetaEntity.Id;
        }
    }
}
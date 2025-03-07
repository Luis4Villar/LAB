using MediatR;
using Personas.Application.DTO;
using System.Collections.Generic;


namespace Personas.Application.Queries
{
	public class GetByDocumentPersonQuery : IRequest<PersonaDto>
    {
        public int _Identificacion { get; set; }

        public GetByDocumentPersonQuery(int Identificacion)
        {
            _Identificacion = Identificacion;
        }
    }
}
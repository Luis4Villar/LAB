using Citas.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citas.CQRS.Queries
{
    public class GetCitasByIdQuery : IRequest<RecetasDto>
    {
        public int Id { get; set; }

        public GetCitasByIdQuery(int id)
        {
            Id = id;
        }
    }
}
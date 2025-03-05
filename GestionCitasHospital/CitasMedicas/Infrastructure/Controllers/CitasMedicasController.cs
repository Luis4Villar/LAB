using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CitasMedicas.Infrastructure.Controllers
{
    [RoutePrefix("api/cita")]
    public class CitasMedicasController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok();
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KeepFit.Core.Domain.Gym;
using KeepFit.Core.Services.Gym;

namespace KeepFit.Web.Controllers.api
{
    public class GymsController : ApiController
    {
        readonly GymService _gymService = new GymService();

        public IEnumerable<Gym> GetAllGyms()
        {
            return _gymService.GetGyms();
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = _gymService.GetGyms().FirstOrDefault((p) => p.GymId == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}

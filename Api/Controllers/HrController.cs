using Api.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class HrController : ControllerBase
    {
        private readonly IHr _hrServices;
        public HrController(IHr HrServices)
        {
            _hrServices = HrServices;
        }
         [HttpGet]
        public IEnumerable<Hr> Get()
        {
            return _hrServices.GetHrDetails();
        }

        [HttpGet("{id}")]
        public IEnumerable<Hr> Get(int id)
        {
            return _hrServices.GeTHrDetailsById(id);    
        }

    }
}
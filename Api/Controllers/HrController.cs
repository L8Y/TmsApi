using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HrController : Controller
    {
        training_management_systemContext tms = new training_management_systemContext();
         [HttpGet]
        public IEnumerable<Hr> Get()
        {
            return tms.Hrs;
        }

        [HttpGet("{id}")]
        public IEnumerable<Hr> Get(int id)
        {
            return tms.Hrs.Where(hr => hr.Id == id);    
        }
    }
}
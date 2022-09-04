using Api.Interface;
using System.Collections;

namespace Api.Services
{
    public class HrServices : IHr
    {
        private readonly training_management_systemContext _context;
        public HrServices(training_management_systemContext context)
        {
            _context = context;
        }

        public IEnumerable GetHrDetails()
        {
            return _context.Hrs;
        }

        public IEnumerable<Hr> GeTHrDetailsById(int id)
        {
            return _context.Hrs.Where(hr => hr.Id == id);
        }
    }
}

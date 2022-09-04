using System.Collections;

namespace Api.Interface
{
    public interface IHr
    {
        public IEnumerable GetHrDetails();
        public IEnumerable<Hr> GeTHrDetailsById(int id);

    }
}
    
using Api.Interface;

namespace Api.Services
{
    public class EmployeeServices : IEmployee
    {
        private readonly training_management_systemContext _context;
        public EmployeeServices(training_management_systemContext context)
        {
            _context = context;
        }

        public bool DeleteEmployeeById(int empId)
        {
            var deleteEmployee = _context.Employees.FirstOrDefault(t => t.Id == empId);
            bool isDeleted = false;
            if (deleteEmployee != null)
            {
                _context.Employees.Remove(deleteEmployee);
                isDeleted = _context.SaveChanges() >0;
            }
            return isDeleted;
        }

        public bool AddEmployeeData(Employee e)
        {
            _context.Employees.Add(e);

            bool isEmployeeAdded = _context.SaveChanges() > 0;
            return isEmployeeAdded;
        }

    }
}

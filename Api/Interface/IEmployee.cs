namespace Api.Interface
{
    public interface IEmployee
    {
        public bool DeleteEmployeeById(int empId);
        public bool AddEmployeeData(Employee e);
    }
}

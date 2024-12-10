namespace On_call_masters.BLL
{

    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(Employee employee)
        {
            _employeeRepository.AddEmployee(employee);
        }
        public IEnumerable<Employee> FindEmployees(int? workRegionID)
        {
            return _employeeRepository.GetEmployeesByCriteria(workRegionID);
        }
    }
}


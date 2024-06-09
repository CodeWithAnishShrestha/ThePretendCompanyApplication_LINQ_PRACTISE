using TCPData;

namespace ThePretendCompanyApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //List<Employee> employeeList = Data.GetEmployees();

            //var filteredEmployees = employeeList.Filter(emp => emp.AnnualSalary > 60000);

            //foreach (var employee in filteredEmployees)
            //{
            //    Console.WriteLine($"First Name:{employee.FirstName} {employee.LastName}");
            //    Console.WriteLine($"Annual Salary :{employee.AnnualSalary}");
            //    Console.WriteLine($"Manager :{employee.IsManager}");
            //    Console.WriteLine();
            //}
            //Console.ReadKey();

            //List<Department> departmentList = Data.GetDepartments();

            //var filteredDepartments = departmentList.Where(dep => dep.ShortName == "FN" || dep.ShortName == "HR");

            //foreach (var department in filteredDepartments)
            //{
            //    Console.WriteLine($"Id:{department.Id} ");
            //    Console.WriteLine($"Short Name :{department.ShortName}");
            //    Console.WriteLine($"LongName :{department.LongName}");
            //    Console.WriteLine();
            //}
            //Console.ReadKey();

            List<Employee> employeeList = Data.GetEmployees();
            List<Department> departmentList = Data.GetDepartments();

            var resultList = from emp in employeeList
                             join dept in departmentList
                             on emp.DepartmentId equals dept.Id
                             select new
                             {
                                 FirstName = emp.FirstName,
                                 LastName = emp.LastName,
                                 AnnualSalary = emp.AnnualSalary,
                                 Manager = emp.IsManager,
                                 Department = emp.DepartmentId
                             };
            foreach (var employee in resultList)
            {
                Console.WriteLine($"First Name:{employee.FirstName} {employee.LastName}");
                Console.WriteLine($"Annual Salary :{employee.AnnualSalary}");
                Console.WriteLine($"Manager :{employee.Manager}");
                Console.WriteLine($"Department :{employee.Department}");

                Console.WriteLine();
            }

            var averageAnnualSalary = resultList.Average(a => a.AnnualSalary);
            var highestAnnualSalary = resultList.Max(a => a.AnnualSalary);
            var lowestAnnualSalary = resultList.Min(a => a.AnnualSalary);
            Console.WriteLine($"Average Annual Salary :{averageAnnualSalary}");
            Console.WriteLine($"Average Highest Salary :{highestAnnualSalary}");
            Console.WriteLine($"Average :loswest Salary :{lowestAnnualSalary}");

            Console.ReadKey();
        }
    }
}
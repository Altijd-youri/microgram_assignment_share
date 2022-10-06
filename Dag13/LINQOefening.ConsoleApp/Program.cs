using DataHelper;

namespace Lab_02
{
    class Program
    {
        private static IEnumerable<Employee> Employees = DataSource.Employees;
        private static IEnumerable<Product> Products = DataSource.Products;
        private static IEnumerable<ProductVendor> ProductVendors = DataSource.ProductVendors;
        private static IEnumerable<Vendor> Vendors = DataSource.Vendors;

        static void Main(string[] args)
        {
            Console.WriteLine("Lab 02 - LINQ");
            Console.WriteLine("=============\n");
            
            Exercise01();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }

        static void Exercise01()
        {
            // Are there any employees with less than 21 sick leave hours?
            // How many employees have less than 21 sick leave hours?
            // For each employee that has less than 21 sick leave hours, display his/her name, gender and number of sick leave hours.
            // Display the same list but now double sorted, first by gender and then by name.

            Console.WriteLine("Exercise 01 - Start");
            
            //TODO: Add code here
            bool employeesWithLessThan21SickLeaveHours = 
                Employees
                    .Any(employee => employee.SickLeaveHours < 21);
            
            int numberOfEmployeesWithLessThan21SickLeaveHours = 
                Employees
                .Count(employee => employee.SickLeaveHours < 21);
            
            List<Employee> ListEmployeesWithLessThan21SickLeaveHours = 
                Employees
                    .Where(employee => employee.SickLeaveHours < 21)
                    .Select(employee => );
            
            Console.WriteLine("Are there any employees with less than 21 sick leave hours?: " + employeesWithLessThan21SickLeaveHours);
            
            Console.WriteLine("How many employees have less than 21 sick leave hours?: " + numberOfEmployeesWithLessThan21SickLeaveHours);
            
            Console.WriteLine("Exercise 01 - End\n");
        }
    }
}

namespace CatWorx.BadgeMaker
{
    class PeopleFetcher
    {
        public static List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            while (true) 
            {
                Console.WriteLine("Enter first name: (leave empty to exit): ");

                string firstName = 
                    Console.ReadLine() // read the next line of characters in the input stream
                    ?? "";             // null coalescing operator catches null values and replace with the following value  
                if (firstName == "")
                {
                    break;
                }

                Console.WriteLine("Enter last name: ");
                string lastName = Console.ReadLine() ?? "";

                Console.WriteLine("Enter ID: ");
                int id = Int32.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Enter Photo URL: ");
                string photoUrl = Console.ReadLine() ?? "";

                Employee currentEmployee = new Employee(firstName, lastName, id, photoUrl);
                employees.Add(currentEmployee);
            }

            return employees;
        }
    }
}
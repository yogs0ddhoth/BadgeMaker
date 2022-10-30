namespace CatWorx.BadgeMaker
{
    using Newtonsoft.Json.Linq;
    class PeopleFetcher
    {
        async public static Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();

            Console.WriteLine("Import 'employee data'? (y/n)");
            while (true)
            {
                string input = Console.ReadLine() ?? "";
                if (input == "n") {
                    break;
                }
                if (input == "y") {
                    employees.AddRange(await GetFromApi());
                    break;
                }
                Console.WriteLine("(y/n");
            }
            
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

       async static Task<List<Employee>> GetFromApi()
        {
            List<Employee> employees = new List<Employee>();

            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync("https://randomuser.me/api/?results=10&nat=us&inc=name,id,picture");
                
                // convert response
                JObject json = JObject.Parse(response);

                // create List<Employee> for each person
                foreach (JToken person in json.SelectToken("results")!)
                {
                    Employee currentEmployee = new Employee
                    (
                        person.SelectToken("name.first")!.ToString(),
                        person.SelectToken("name.last")!.ToString(),
                        Int32.Parse(person.SelectToken("id.value")!.ToString().Replace("-", "")),
                        person.SelectToken("picture.large")!.ToString()
                    );
                    employees.Add(currentEmployee);
                }
            }

            return employees;
        }
    }
}
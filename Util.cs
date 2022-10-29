namespace CatWorx.BadgeMaker
{
    class Util
    {
        public static void PrintEmployees(List<Employee> employees)
        {
            Console.WriteLine("Employees:");

            int count = employees.Count;
            for (int i = 0; i < count; i++) 
            {
                Console.WriteLine(
                    String.Format(
                        "{0, -10}\t{1, -20}\t{2}", 
                        employees[i].GetId(), 
                        employees[i].GetFullName(), 
                        employees[i].GetPhotoUrl())
                );
            }
        }

        public static void/*?*/ WriteCSV(List<Employee> employees)
        {
            if (!Directory.Exists("data"))         // if 'data' folder does not exist:
            {   
                Directory.CreateDirectory("data"); // create it.
            }
            // write_to_file(path: data/employees.csv)
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID,Name,PhotoUrl");

                int count = employees.Count;
                for (int i = 0; i < employees.Count; i++)
                {
                    file.WriteLine(
                        String.Format(
                            "{0},{1},{2}", 
                            employees[i].GetId(), 
                            employees[i].GetFullName(), 
                            employees[i].GetPhotoUrl())
                    );
                }
            }
        }
    }
}
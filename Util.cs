namespace CatWorx.BadgeMaker
{
    using SkiaSharp;
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

        public static void WriteCSV(List<Employee> employees)
        {
            if (!Directory.Exists("data")) // if 'data' folder does not exist:
            {   
                Directory.CreateDirectory("data"); // create it.
            }
           
            // ensure correct use of IDisposable objects
            using (StreamWriter file = new StreamWriter("data/employees.csv"))
            {
                file.WriteLine("ID,Name,PhotoUrl");

                int count = employees.Count;
                for (int i = 0; i < count; i++)
                {
                    file.WriteLine(
                        String.Format(
                            "{0},{1},{2}", 
                            employees[i].GetId(), 
                            employees[i].GetFullName(), 
                            employees[i].GetPhotoUrl())
                    );
                }
            } // class instance initialized in the head is dropped from memory once scope ends
        }
        async public static Task WriteBadge(Employee employee, HttpClient client)
        {
            int BADGE_WIDTH = 669;
            int BADGE_HEIGHT = 1044;

            int PHOTO_LEFT_X = 184;
            int PHOTO_RIGHT_X = 486;
            int PHOTO_TOP_Y = 215;
            int PHOTO_BOTTOM_Y = 517;

            int COMPANY_NAME_Y = 150;
            int EMPLOYEE_NAME_Y = 600;
            int EMPLOYEE_ID_Y = 730;

            // create an SKImage instance from the Employee.photoUrl
            SKImage photo = SKImage.FromEncodedData(
                await client.GetStreamAsync(employee.GetPhotoUrl()));
            SKImage background = SKImage.FromEncodedData(File.OpenRead("badge.png"));

            SKBitmap badge = new SKBitmap(BADGE_WIDTH, BADGE_HEIGHT);
            SKCanvas canvas = new SKCanvas(badge); //wraps the bitmap allowing for edits to be made
            
            // put employee data into the bitmap
            canvas.DrawImage(background, new SKRect(0, 0, BADGE_WIDTH, BADGE_HEIGHT));
            canvas.DrawImage(photo, new SKRect(PHOTO_LEFT_X, PHOTO_TOP_Y, PHOTO_RIGHT_X, PHOTO_BOTTOM_Y));
            
            SKPaint paint = new SKPaint {
                TextSize = 42.0f,
                IsAntialias = true,
                Color = SKColors.White,
                IsStroke = false,
                TextAlign = SKTextAlign.Center,
                Typeface = SKTypeface.FromFamilyName("Arial")
            };
            canvas.DrawText(employee.GetCompanyName(), BADGE_WIDTH/2f, COMPANY_NAME_Y, paint);
            
            paint.Color = SKColors.Black;
            canvas.DrawText(employee.GetFullName(), BADGE_WIDTH/2f, EMPLOYEE_NAME_Y, paint);
            
            paint.Typeface = SKTypeface.FromFamilyName("Courier New");
            canvas.DrawText(employee.GetId().ToString(), BADGE_WIDTH/2f, EMPLOYEE_ID_Y, paint);
            
            // create new file
            SKImage finalImage = SKImage.FromBitmap(badge);
            SKData data = finalImage.Encode();
            data.SaveTo(File.OpenWrite(string.Format("data/{0}_badge.png", employee.GetId())));
        }
        async public static Task MakeBadge(Employee employee)
        {
            using (HttpClient client = new HttpClient())
            {
                await WriteBadge(employee, client);
            }
        }
        async public static Task MakeBadges(List<Employee> employees)
        {
            using (HttpClient client = new HttpClient())
            {
                int count = employees.Count;
                for (int i = 0; i < count; i++)
                {
                    await WriteBadge(employees[i], client);
                }
            }
        }
    }
}
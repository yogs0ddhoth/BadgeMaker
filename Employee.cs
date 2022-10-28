namespace CatWorx.BadgeMaker
{
    class Employee
    {
        string FirstName;
        string LastName;
        int Id;
        string PhotoUrl;
        public Employee(string firstName, string lastName,
                                  int id, string photoUrl) 
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            PhotoUrl = photoUrl;
        }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
        public int GetId() 
        {
            return Id;
        }
        public string GetPhotoUrl()
        {
            return PhotoUrl;
        }
    }
}
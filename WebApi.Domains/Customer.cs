namespace WebApi.Domains
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string FullName => (Name + " " + LastName).Trim();

        public override string ToString()
        {
            return $"Id : {Id}, Name : {FullName}";
        }
    }
}

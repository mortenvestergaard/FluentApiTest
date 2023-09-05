namespace FluentApiTest.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}

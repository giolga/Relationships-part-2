namespace RelationshipAPI2.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}

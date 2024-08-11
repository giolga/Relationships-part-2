namespace RelationshipAPI2.Models
{
    public class Publisher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public ICollection<BookPublisher> BookPublishers { get; set; }
    }
}

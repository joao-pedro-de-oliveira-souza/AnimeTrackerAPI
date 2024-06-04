namespace AnimeTracker.Entities
{
    public class Manga
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Volumes { get; set; }
        public double Rating { get; set; }
    }
}

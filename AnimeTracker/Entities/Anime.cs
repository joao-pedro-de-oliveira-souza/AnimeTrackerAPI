namespace AnimeTracker.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Episodes { get; set; }
        public double Rating { get; set; }
    }
}

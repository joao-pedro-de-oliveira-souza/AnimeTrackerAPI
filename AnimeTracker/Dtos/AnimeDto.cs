namespace AnimeTracker.Dtos
{
    public class AnimeDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public double Rating { get; set; }
    }
}

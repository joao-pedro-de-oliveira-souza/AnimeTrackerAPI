using AnimeTracker.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimeTracker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Anime> Animes { get; set; }
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<LightNovel> LightNovels { get; set; }
    }
}

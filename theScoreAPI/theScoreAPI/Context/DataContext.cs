using Microsoft.EntityFrameworkCore;

using theScoreAPI.Shared.Models;

namespace theScoreAPI.Context
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Rushing> Rushings { get; set; }
	}
}

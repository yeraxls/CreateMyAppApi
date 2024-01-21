using DB.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DB
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions options) 
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Project>().ToTable("Project");
        }

        public async Task<T> Insert<T>(T elemento) where T : class
        {
            await AddAsync<T>(elemento);
            return elemento;
        }

        public async Task SaveAll()
        {
            await SaveChangesAsync();
        }

        public void Delete<T>(T elemento) where T : class
        {
            Remove<T>(elemento);
        }
        public IQueryable<T> Queryable<T>(Expression<Func<T, bool>> expression = null) where T : class
        {
            if (expression == null)
                return Set<T>();
            return Set<T>().Where(expression);
        }
    }
}

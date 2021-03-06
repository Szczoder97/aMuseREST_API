using Microsoft.EntityFrameworkCore;
using Models;

namespace Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Lesson> lessons {get; set;}
        public DbSet<User> users {get; set;}
        public DbSet<Classroom> classrooms {get; set;}
    }
}
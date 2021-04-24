using Microsoft.EntityFrameworkCore;
using MyStatusSoftware.Data.Entities;

namespace MyStatusSoftware.Data
{
    public  class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
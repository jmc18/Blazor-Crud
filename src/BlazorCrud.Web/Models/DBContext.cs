using BlazorCrud.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Web.Models
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { }

        public DbSet<Person> Person { get; set; }
    }
}

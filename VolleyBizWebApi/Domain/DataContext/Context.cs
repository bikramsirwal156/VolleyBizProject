using Microsoft.EntityFrameworkCore;
using VolleyBizWebApi.Domain.Entities;

namespace VolleyBizWebApi.Domain.DataContext
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }
    }
}

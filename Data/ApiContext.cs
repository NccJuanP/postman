using Microsoft.EntityFrameworkCore;
using ApiPostman.Models;

namespace ApiPostman.Data{
    public class ApiContext : DbContext{
        public ApiContext(DbContextOptions<ApiContext> options) : base(options){

        }
        public DbSet<User> Users { get; set; }
    }
}
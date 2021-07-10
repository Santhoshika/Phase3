using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Laptopseller.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Laptop> Laptops { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)


        {
            optionsBuilder.UseSqlServer("Server=W106ZHLWT2\\SQLEXPRESS;Database=Phase3;Integrated Security=true;");
        }
    }
}

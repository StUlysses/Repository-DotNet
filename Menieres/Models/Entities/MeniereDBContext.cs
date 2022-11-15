using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class MeniereDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"server=LAPTOP-99O6S4U3\SQLEXPRESS;uid=sa;pwd=123456;database=Meniere");
        }
        public DbSet<Article> Article { get; set; }
        public DbSet<Complaint> Complaint { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Review> Review { get; set; }
    }
}

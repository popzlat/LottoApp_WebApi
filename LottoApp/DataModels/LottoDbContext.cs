using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModels
{
   public class LottoDbContext : DbContext
    {

        private readonly string _connectionString;

        public LottoDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }
        public LottoDbContext()
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<RoundResults> RoundResults { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
               .HasMany<Ticket>()
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId);
        }

    }
}

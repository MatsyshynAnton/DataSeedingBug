using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore
{
    public class DatabaseContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
                    => options.UseSqlServer("Server=localhost;Database=SeedDataBug;Trusted_Connection=True;");
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User{Id=1, FirstName="John", LastName="Gold", Age=27, Created=DateTime.Now, Modified=DateTime.Now},
                new User{Id=2, FirstName="Ronald", LastName="Weasley", Age=16, Created=DateTime.Now, Modified=DateTime.Now},
                new User{Id=3, FirstName="Sherlock ", LastName="Holmes", Age=18, Created=DateTime.Now, Modified=DateTime.Now}
            });
        }
    }
}

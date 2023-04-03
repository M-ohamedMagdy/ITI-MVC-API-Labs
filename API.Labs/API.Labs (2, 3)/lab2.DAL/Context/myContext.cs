using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2.DAL;

public class myContext : DbContext
{
    public DbSet<Ticket> Tickets => Set<Ticket>();
    public DbSet<Department> Departments { get; set; }
    public DbSet<Developer> Developers => Set<Developer>();
    public myContext(DbContextOptions options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>().HasData
            (
                new Department(10, "Electrical"),
                new Department(20, "Mechanical"),
                new Department(30, "Civil"),
                new Department(40, "Petroleum")
            );

        modelBuilder.Entity<Developer>().HasData
            (
                new Developer(1,"Jamal"),
                new Developer(2, "Mohamed"),
                new Developer(3, "Ali"),
                new Developer(4, "Ahmed")
            );

        modelBuilder.Entity<Ticket>().HasData
            (
            new Ticket(100, "ticket number one", 1111, 10),
            new Ticket(200, "ticket number two", 2222, 10),
            new Ticket(300, "ticket number three", 3333, 20),
            new Ticket(400, "ticket number four", 4444, 20)
            );

        base.OnModelCreating(modelBuilder);
    }
}

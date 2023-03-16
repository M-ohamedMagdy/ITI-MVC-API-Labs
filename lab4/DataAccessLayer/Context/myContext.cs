using DataAccessLayer.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context;

public class myContext : DbContext
{
    public DbSet<Ticket> tickets => Set<Ticket>();
    public DbSet<Developer> developers => Set<Developer>();
    public DbSet<Department> departments => Set<Department>();

	public myContext(DbContextOptions options) : base(options)
	{

	}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Department>().HasData
        //    (
        //        new Department("Electrical"),
        //        new Department("Mechanical"),
        //        new Department("Civil"),
        //        new Department("Petroleum")
        //    );

        //modelBuilder.Entity<Developer>().HasData
        //    (
        //        new Developer("Jamal","Ali"),
        //        new Developer("Mohamed","Magdy"),
        //        new Developer("Mina","Gerges"),
        //        new Developer("Mahmoud","Hesham"),
        //        new Developer("Ahmed","Khairy")
        //    );

        //modelBuilder.Entity<Ticket>().HasData
        //    (
        //    new Ticket("first", "ticket number one", Severity.High),
        //    new Ticket("second", "ticket number two", Severity.Medium),
        //    new Ticket("third", "ticket number three", Severity.Low),
        //    new Ticket("fourth", "ticket number four", Severity.High)
        //    );

        base.OnModelCreating(modelBuilder);
    }
}

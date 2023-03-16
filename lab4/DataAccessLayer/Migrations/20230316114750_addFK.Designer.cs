﻿// <auto-generated />
using System;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(myContext))]
    [Migration("20230316114750_addFK")]
    partial class addFK
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccessLayer.DomainModels.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("departments");

                    b.HasData(
                        new
                        {
                            Id = new Guid("dbc75f3d-98d7-49ad-abe2-9d064426854c"),
                            Name = "Electrical"
                        },
                        new
                        {
                            Id = new Guid("711e3ab5-c12c-4ac9-96ff-8abb9c58daa4"),
                            Name = "Mechanical"
                        },
                        new
                        {
                            Id = new Guid("29c13290-5f3d-4fa3-bae3-356f00f9bb6a"),
                            Name = "Civil"
                        },
                        new
                        {
                            Id = new Guid("432aa782-90a0-4598-9d8c-cca574f4fa51"),
                            Name = "Petroleum"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.DomainModels.Developer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("developers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a82ab199-e6d1-4b3a-8ae4-9324a204a719"),
                            FirstName = "Jamal",
                            LastName = "Ali"
                        },
                        new
                        {
                            Id = new Guid("9e77a4a9-c1b7-4c74-8aac-eeecacaeaa48"),
                            FirstName = "Mohamed",
                            LastName = "Magdy"
                        },
                        new
                        {
                            Id = new Guid("5594410a-9672-4634-8bc1-133cda07fc11"),
                            FirstName = "Mina",
                            LastName = "Gerges"
                        },
                        new
                        {
                            Id = new Guid("49f562e4-02de-44bd-9155-c7c153bdeb76"),
                            FirstName = "Mahmoud",
                            LastName = "Hesham"
                        },
                        new
                        {
                            Id = new Guid("11540754-253f-4c0f-9315-5c1d00c1b2a8"),
                            FirstName = "Ahmed",
                            LastName = "Khairy"
                        });
                });

            modelBuilder.Entity("DataAccessLayer.DomainModels.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeptId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Severity")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DeptId");

                    b.ToTable("tickets");

                    b.HasData(
                        new
                        {
                            Id = new Guid("18648f0b-b9b4-4d66-af4d-a710dd61c67a"),
                            Description = "ticket number one",
                            Severity = 2,
                            Title = "first"
                        },
                        new
                        {
                            Id = new Guid("bc5c1b56-a9f7-4668-9cd1-ff4f9515a7a3"),
                            Description = "ticket number two",
                            Severity = 1,
                            Title = "second"
                        },
                        new
                        {
                            Id = new Guid("566c7130-bcd2-4ef4-9166-e7e3d11b600f"),
                            Description = "ticket number three",
                            Severity = 0,
                            Title = "third"
                        },
                        new
                        {
                            Id = new Guid("04f9e64c-62e8-4c01-9390-37cbb29345a4"),
                            Description = "ticket number four",
                            Severity = 2,
                            Title = "fourth"
                        });
                });

            modelBuilder.Entity("DeveloperTicket", b =>
                {
                    b.Property<Guid>("DevelopersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TicketsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DevelopersId", "TicketsId");

                    b.HasIndex("TicketsId");

                    b.ToTable("DeveloperTicket");
                });

            modelBuilder.Entity("DataAccessLayer.DomainModels.Ticket", b =>
                {
                    b.HasOne("DataAccessLayer.DomainModels.Department", "Department")
                        .WithMany("Tickets")
                        .HasForeignKey("DeptId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("DeveloperTicket", b =>
                {
                    b.HasOne("DataAccessLayer.DomainModels.Developer", null)
                        .WithMany()
                        .HasForeignKey("DevelopersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccessLayer.DomainModels.Ticket", null)
                        .WithMany()
                        .HasForeignKey("TicketsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataAccessLayer.DomainModels.Department", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
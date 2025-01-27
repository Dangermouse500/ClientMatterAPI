﻿// <auto-generated />
using System;
using Client.Matter.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Client.Matter.Persistence.Migrations
{
    [DbContext(typeof(ClientMatterDbContext))]
    [Migration("20241117161343_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Client.Matter.Persistence.Entities.AddressEf", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("AddressLine2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("County")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Postcode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Client.Matter.Persistence.Entities.ClientEf", b =>
                {
                    b.Property<string>("ClientId")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("InceptionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MatterCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ClientId");

                    b.HasIndex("AddressId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Client.Matter.Persistence.Entities.MatterEf", b =>
                {
                    b.Property<string>("MatterId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatterCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MatterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MatterDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatterName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MatterId");

                    b.ToTable("Matter");
                });

            modelBuilder.Entity("Client.Matter.Persistence.Entities.PeopleEf", b =>
                {
                    b.Property<int>("PeopleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PeopleId"));

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ClientId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PreferredName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("PeopleId");

                    b.HasIndex("ClientId");

                    b.HasIndex("PeopleId", "ClientId")
                        .IsUnique();

                    b.ToTable("People");
                });

            modelBuilder.Entity("Client.Matter.Persistence.Entities.ClientEf", b =>
                {
                    b.HasOne("Client.Matter.Persistence.Entities.AddressEf", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Client.Matter.Persistence.Entities.PeopleEf", b =>
                {
                    b.HasOne("Client.Matter.Persistence.Entities.ClientEf", "Client")
                        .WithMany("People")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Client.Matter.Persistence.Entities.ClientEf", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}

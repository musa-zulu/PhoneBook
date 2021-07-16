﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneBook.Persistence;

namespace PhoneBook.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210716110657_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneBook.Domain.Entities.Entry", b =>
                {
                    b.Property<Guid>("EntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PhoneBookId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntryId");

                    b.HasIndex("PhoneBookId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("PhoneBook.Domain.Entities.PhoneBook", b =>
                {
                    b.Property<Guid>("PhoneBookDtoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateLastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastUpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneBookDtoId");

                    b.ToTable("PhoneBook");
                });

            modelBuilder.Entity("PhoneBook.Domain.Entities.Entry", b =>
                {
                    b.HasOne("PhoneBook.Domain.Entities.PhoneBook", "PhoneBook")
                        .WithMany("Entries")
                        .HasForeignKey("PhoneBookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhoneBook");
                });

            modelBuilder.Entity("PhoneBook.Domain.Entities.PhoneBook", b =>
                {
                    b.Navigation("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}

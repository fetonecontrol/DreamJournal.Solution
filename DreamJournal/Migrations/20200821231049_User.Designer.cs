﻿// <auto-generated />
using System;
using DreamJournal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DreamJournal.Migrations
{
    [DbContext(typeof(DreamJournalContext))]
    [Migration("20200821231049_User")]
    partial class User
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DreamJournal.Models.Dream", b =>
                {
                    b.Property<int>("DreamId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Title");

                    b.Property<string>("UserName");

                    b.HasKey("DreamId");

                    b.ToTable("Dreams");

                    b.HasData(
                        new
                        {
                            DreamId = 1,
                            Body = "I dreamt I was floating down a river in Thailand, that was forested, and had settlements on the side of the river.",
                            Date = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Example",
                            UserName = "Frederick Ernest"
                        });
                });

            modelBuilder.Entity("DreamJournal.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("UserName");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserName = "Frederick Ernest"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

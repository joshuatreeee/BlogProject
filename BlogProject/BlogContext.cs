﻿using BlogProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject
{
    public class BlogContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=(localdb)\\mssqllocaldb;Database=Blogs;Trusted_Connection=True;";

            optionsBuilder.UseSqlServer(connectionString)
                          .UseLazyLoadingProxies();

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Blog>().HasData(
                new Blog()
                {
                    BlogId = 1,
                    Name = "Dream Log",
                    Image = "/img/dreaming.jpg"
                },
                new Blog()
                {
                    BlogId = 2,
                    Name = "Ziplining",
                    Image = "/img/zipline.jpg"
                },
                new Blog()
                {
                    BlogId = 3,
                    Name = "Exotic Pets",
                    Image = "/img/lizard.jpg"
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}

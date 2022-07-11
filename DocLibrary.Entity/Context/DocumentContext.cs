using DocLibrary.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocLibrary.Entity.Context
{
    public class DocumentContext : DbContext
    {
        public DocumentContext(DbContextOptions<DocumentContext> options) : base(options)
        { }

        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<DocumentHistory> DocumentHistory { get; set; }
        public virtual DbSet<DocumentShare> DocumentShare { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.HasDefaultSchema("doc");
        }
    }
}

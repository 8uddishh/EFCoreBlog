using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCoreCheck.Db
{
    

    public class BloggingDbContext : DbContext
    {
        public BloggingDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Primary keys
            builder.Entity<Author>().HasKey(au => au.AuthorId);
            builder.Entity<Blog>().HasKey(bl => bl.BlogId);
            builder.Entity<Tag>().HasKey(tg => tg.TagId);
            builder.Entity<BlogTag>().HasKey(t => new { t.BlogId, t.TagId });
            builder.Entity<Comment>().HasKey(c => c.CommentId);

            // Identity
            builder.Entity<Author>().Property(au => au.AuthorId).ValueGeneratedOnAdd();
            builder.Entity<Blog>().Property(bl => bl.BlogId).ValueGeneratedOnAdd();
            builder.Entity<Tag>().Property(tg => tg.TagId).ValueGeneratedOnAdd();
            builder.Entity<Comment>().Property(c => c.CommentId).ValueGeneratedOnAdd();

            // Maxlengths
            builder.Entity<Author>().Property(au => au.FirstName).HasMaxLength(120).IsRequired();
            builder.Entity<Author>().Property(au => au.LastName).HasMaxLength(120).IsRequired();
            builder.Entity<Blog>().Property(bl => bl.Title).HasMaxLength(255).IsRequired();
            builder.Entity<Tag>().Property(tg => tg.TagName).HasMaxLength(50).IsRequired();
            builder.Entity<Comment>().Property(c => c.CommentInfo).HasMaxLength(120).IsRequired();
            builder.Entity<Comment>().Property(c => c.Email).HasMaxLength(120).IsRequired();
            builder.Entity<Comment>().Property(c => c.Homepage).HasMaxLength(120);
            builder.Entity<Comment>().Property(c => c.Name).HasMaxLength(50).IsRequired();


            // ColumnName
            builder.Entity<Comment>().Property(c => c.CommentInfo).HasColumnName("Comment");

            // Foreign Keys
            builder.Entity<Blog>().HasOne(bk => bk.Author).WithMany(au => au.Blogs);
            builder.Entity<BlogTag>().HasOne(bt => bt.Blog).WithMany(bl => bl.BlogTags);
            builder.Entity<BlogTag>().HasOne(tb => tb.Tag).WithMany(bl => bl.BlogTags);
            builder.Entity<Comment>().HasOne(c => c.Blog).WithMany(bl => bl.Comments);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}

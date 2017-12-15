using EntityCoreCheck.Db;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace EntityCoreCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            var contextFactory = new DesignTimeDbContextFactory();
            var dbcontext = contextFactory.CreateDbContext(configuration.GetConnectionString("BlogDb"));

            // Add Authors
            var bloggers = new[]
            {
                new Author
                {
                    FirstName = "Blogger",
                    LastName = "One",
                },
                new Author
                {
                    FirstName = "Blogger",
                    LastName = "Two",
                }
            };


            var tags = new[]
            {
                new Tag { TagName = "Fun" },
                new Tag { TagName = "Science" },
                new Tag { TagName = "Books" },
                new Tag { TagName = "Computers" }
            };


            dbcontext.Authors.AddRange(bloggers);
            dbcontext.Tags.AddRange(tags);


            var blogs = new[]
            {
                new Blog
                {
                    Author = bloggers[0],
                    BlogTags = new List<BlogTag>
                    {
                        new BlogTag { Tag = tags[0]},
                        new BlogTag { Tag = tags[2]}
                    },
                    PublishDate = DateTime.Now,
                    Title = "Blog Title #1",
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            CommentInfo = "Some comment",
                            Email = "xyzBlogger@blog.com",
                            Name = "Random Person #1"
                        },
                        new Comment
                        {
                            CommentInfo = "Some comment #1",
                            Email = "abcBlogger@blog.com",
                            Name = "Random Person #2"
                        }
                    }
                },
                new Blog
                {
                    Author = bloggers[1],
                    BlogTags = new List<BlogTag>
                    {
                        new BlogTag { Tag = tags[1]},
                        new BlogTag { Tag = tags[3]}
                    },
                    PublishDate = DateTime.Now,
                    Title = "Blog Title #2",
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            CommentInfo = "Some comment #3",
                            Email = "xyzBlogger@blog.com",
                            Name = "Random Person #1"
                        },
                        new Comment
                        {
                            CommentInfo = "Some comment #4",
                            Email = "abcBlogger@blog.com",
                            Name = "Random Person #2"
                        }
                    }
                }
            };

            dbcontext.Blogs.AddRange(blogs);
            dbcontext.SaveChanges();

            Console.WriteLine("Hello World!");
        }
    }
}

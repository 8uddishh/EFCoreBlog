using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityCoreCheck.Db
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BloggingDbContext>
    {
        public BloggingDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BloggingDbContext>();
            builder.UseSqlServer("Server=.\\SQLExpress;Database=Blogger;Trusted_Connection=Yes;Timeout=30;");
            return new BloggingDbContext(builder.Options);
        }

        public BloggingDbContext CreateDbContext(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<BloggingDbContext>();
            builder.UseSqlServer(connectionString);
            return new BloggingDbContext(builder.Options);
        }
    }
}

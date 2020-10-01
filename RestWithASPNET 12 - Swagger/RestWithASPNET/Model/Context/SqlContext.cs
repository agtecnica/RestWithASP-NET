using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNET.Model.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext() { }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }


        public DbSet<Person> person { get; set; }
        public DbSet<Book> book { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasCollation("my_collation", locale: "en-u-ks-primary", provider: "icu", deterministic: false);

            //builder.UseDefaultColumnCollation("my_collation");

        }
    }
}

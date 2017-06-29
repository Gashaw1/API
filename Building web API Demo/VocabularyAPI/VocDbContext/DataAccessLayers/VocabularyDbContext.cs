using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace VocDbContext
{
    public class VocabularyDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Vocabularys> Vocabularys { get; set; }
        public DbSet<Definitions> Definitions { get; set; }       
    }       
}
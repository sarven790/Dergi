using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DergiAboneTakip.Models
{
    public class Context:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(local); database=DbDergiAbonelik; integrated security=true;");
        }

        public DbSet<UyelerTablosu> uyelers { get; set; }
        public DbSet<DergilerTablosu> dergilers { get; set; }
        public DbSet<KategoriTablosu> kategoris { get; set; }
        public DbSet<AboneTablosu> abones { get; set; }
        public static object Session { get; internal set; }
    }
}

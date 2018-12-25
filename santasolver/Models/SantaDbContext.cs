using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SantaSolver.Models
{
    public class SantaDbContext : DbContext
    {
        public SantaDbContext(DbContextOptions<SantaDbContext> options)
            : base(options)
        { }

        public DbSet<Wish> Whishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Wish>().HasData(ReadNiceList());            
        }

        static IEnumerable<Wish> ReadNiceList()
        {
            string filename = @"./Resources/nicelist.txt";

            using (TextReader reader = File.OpenText(filename))
            {
                var csv = new CsvReader(reader);
                csv.Configuration.Delimiter = ";";
                var records = csv.GetRecords<Wish>();
                return records.ToList();
            }


        }
    }

}

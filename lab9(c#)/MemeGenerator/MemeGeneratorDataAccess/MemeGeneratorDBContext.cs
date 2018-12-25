using MemeGenerator.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGeneratorDataAccess
{
    public class MemeGeneratorDBContext : DbContext
    {
        public MemeGeneratorDBContext() : base("MemeGeneratorDb")
        {
            Database.SetInitializer<MemeGeneratorDBContext>(new CreateDatabaseIfNotExists<MemeGeneratorDBContext>());
        }
        public DbSet<Meme> Memes { get; set; }
   
    }
}

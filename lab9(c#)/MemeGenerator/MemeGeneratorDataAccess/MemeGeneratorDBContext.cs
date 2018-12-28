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
            Database.SetInitializer<MemeGeneratorDBContext>(new DropCreateDatabaseIfModelChanges<MemeGeneratorDBContext>());
        }

        public DbSet<Meme> Memes { get; set; }

        public DbSet<User> Users { get; set; }
   
    }
}

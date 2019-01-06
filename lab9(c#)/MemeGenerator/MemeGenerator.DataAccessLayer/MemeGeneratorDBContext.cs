using MemeGenerator.Model.Type;
using System.Data.Entity;

namespace MemeGenerator.DataAccessLayer
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

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

        public virtual DbSet<Meme> Memes { get; set; }

        public virtual DbSet<User> Users { get; set; }
   
    }
}

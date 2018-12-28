using MemeGenerator.Model;
using MemeGeneratorDataAccess;
using System.Linq;
using System.Threading.Tasks;

namespace MemeGeneratorServer.DAL
{
    public class UserRepository : GenericRepository<User,MemeGeneratorDBContext>
    {
        public UserRepository(MemeGeneratorDBContext context) : base(context)
        {
        }

        public User GetByUserName(string userName)
        {
            return  Context.Users.Where(x => x.UserName == userName).FirstOrDefault();
        }
        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}

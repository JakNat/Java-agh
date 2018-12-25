using MemeGenerator.Model;
using MemeGeneratorDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGeneratorServer.DAL
{
    public class MemeRepository : GenericRepository<Meme, MemeGeneratorDBContext>
    {
        public MemeRepository(MemeGeneratorDBContext context) : base(context)
        {
        }
    }
}

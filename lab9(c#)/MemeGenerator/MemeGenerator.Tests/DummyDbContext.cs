using MemeGenerator.Model.Type;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Tests
{
    class DummyDbContext :  DbContext
    {

        public DbSet<Meme> Memes { get; set; }

        public DbSet<User> Users { get; set; }
    }
}

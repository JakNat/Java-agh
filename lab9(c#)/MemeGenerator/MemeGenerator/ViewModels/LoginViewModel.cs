using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.ViewModels
{
    public class LoginViewModel : Screen
    {
        public void Login()
        {
            Client client = IoC.Get<Client>();
            client.GetConnection();
        }
    }
}

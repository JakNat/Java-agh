using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.ViewModels
{
    public class RegisterViewModel : Screen
    {
        private string _userName = "xd";
        private string _password = "lol";

        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                _password = value;
                var x = (MemeCreatorViewModel)IoC.GetInstance(typeof(MemeCreatorViewModel), "MemeCreator");
                x.TopText = "dziala kurwaa";
                NotifyOfPropertyChange(() => UserName);
            }
        }
        
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                var x = (MemeCreatorViewModel)IoC.GetInstance(typeof(MemeCreatorViewModel), "MemeCreator");
                x.TopText = "dziala kurwaa";
                NotifyOfPropertyChange(() => Password);
            }
        }

    }
}

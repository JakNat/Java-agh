using Caliburn.Micro;
using MemeGenerator.Views;
using Microsoft.Win32;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MemeGenerator.Models;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using NetworkCommsDotNet;
using System.Linq;
using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Connections.TCP;
using System.Drawing;
using MemeGenerator.Utils;

namespace MemeGenerator.ViewModels
{
    public class ShellViewModel : Conductor<object>
    {
        private readonly MemeCreatorViewModel memeCreatorViewModel;
        private readonly LoginViewModel loginViewModel;
        private readonly RegisterViewModel registerViewModel;
        private readonly ConnectionViewModel connectionViewModel;
        private readonly Client client;

        public ShellViewModel
            (
            MemeCreatorViewModel memeCreatorViewModel,
            LoginViewModel loginViewModel,
            RegisterViewModel registerViewModel,
            ConnectionViewModel connectionViewModel,
            Client client
            )
        {
            this.memeCreatorViewModel = memeCreatorViewModel;
            this.loginViewModel = loginViewModel;
            this.registerViewModel = registerViewModel;
            this.connectionViewModel = connectionViewModel;
            this.client = client;
        }

        public void LoadMemeCreatorPage()
        {
            ActivateItem(memeCreatorViewModel);
        }
        public void LoadLoginPage()
        {
            ActivateItem(loginViewModel);
        }
        public void LoadRegisterPage()
        {
            ActivateItem(registerViewModel);
        }

        public void Connect()
        {
            ActivateItem(connectionViewModel);
           // client.GetConnection();
        }
    }
}

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
    public class MemeViewModel : Conductor<object>
    {
        public void LoadMemeCreatorPage()
        {
            ActivateItem(new MemeCreatorViewModel());
        }
        public void LoadLoginPage()
        {
            ActivateItem(new LoginViewModel());
        }
        public void LoadRegisterPage()
        {
            ActivateItem(new RegisterViewModel());
        }
    }
}

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
    public class MemeViewModel : Screen
    {

        private string _topText = "Top text";
        private string _bottomText = "Bottom text";
        private BitmapImage _image;

        public string TopText
        {
            get { return _topText; }
            set
            {
                _topText = value;
                NotifyOfPropertyChange(() => TopText);
            }
        }
        public BitmapImage Image
        {
            get { return _image; }
            set {
                _image = value;
                NotifyOfPropertyChange(() => Image);
            }
        }
        public string BottomText
        {
            get { return _bottomText; }
            set
            {
                NotifyOfPropertyChange(() => BottomText);
                _bottomText = value;
            }
        }

        /// <summary>
        /// select image to generate your new meme
        /// </summary>
        public void UploadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(op.FileName));
                NotifyOfPropertyChange(() => Image);
            }

            var win = new Window();
            win.Content = new LoginViewModel();
            win.Show();
        }

        /// <summary>
        /// sending your meme properties to a MemeGeneratorServer
        /// </summary>
        public async void CreateByServer(BitmapImage image)
        {
            Bitmap bitmap = ImageHelper.BitmapImage2Bitmap(Image);
            ImageWrapper meme = new ImageWrapper("meme", TopText, BottomText, bitmap);

            SendReceiveOptions customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            ConnectionInfo connectionInfo = new ConnectionInfo("192.168.1.5", 12345);
            TCPConnection serverConnection = TCPConnection.GetConnection(connectionInfo, customSendReceiveOptions);

            serverConnection.SendObject("Meme", meme);

            //We have used comms so we make sure to call shutdown
            NetworkComms.Shutdown();
        }

        /// <summary>
        /// turn on or turn of "Generetae Meme" button
        /// </summary>
        public bool CanCreateByServer(BitmapImage image)
        {
            return image != null;
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

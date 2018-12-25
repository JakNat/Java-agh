using Caliburn.Micro;
using MemeGenerator.Models;
using MemeGenerator.Utils;
using Microsoft.Win32;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.DPSBase;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace MemeGenerator.ViewModels
{
   public class MemeCreatorViewModel : Screen
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
            set
            {
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
        /// sending your meme properties to a MemeGeneratorServer
        /// </summary>
        public async void CreateByServer(BitmapImage image)
        {
            Bitmap bitmap = ImageHelper.BitmapImage2Bitmap(Image);
            ImageWrapper meme = new ImageWrapper("meme", TopText, BottomText, bitmap);

            SendReceiveOptions customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            ConnectionInfo connectionInfo = new ConnectionInfo("192.168.1.5", 12345);
            TCPConnection serverConnection;
            try
            {
                 serverConnection = TCPConnection.GetConnection(connectionInfo, customSendReceiveOptions);
                 serverConnection.SendObject("Meme", meme);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to a server" +
                    "\nException message: " + ex.Message);
            }


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

            
        }
    }
}

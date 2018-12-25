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
        }

        /// <summary>
        /// sending your meme properties to a MemeGeneratorServer
        /// </summary>
        public async void CreateByServer()
        {
            byte[] imageEncoded = EncodeImage(Image);

            MemeDto meme = new MemeDto() { TopText = TopText, BottomText = BottomText, ImgByte = imageEncoded };

            SendReceiveOptions customSendReceiveOptions = new SendReceiveOptions<ProtobufSerializer>();
            ConnectionInfo connectionInfo = new ConnectionInfo("192.168.1.5", 12345);
            TCPConnection serverConnection = TCPConnection.GetConnection(connectionInfo, customSendReceiveOptions);

            serverConnection.SendObject("Meme", meme);

            //We have used comms so we make sure to call shutdown
            NetworkComms.Shutdown();
        }

        private byte[] EncodeText(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        private byte[] EncodeImage(BitmapImage Image)
        {
            int height = Image.PixelHeight;
            int width = Image.PixelWidth;
            int stride = width * ((Image.Format.BitsPerPixel + 7) / 8);

            byte[] bits = new byte[height * stride];
            Image.CopyPixels(bits, stride, 0);
            return bits;
        }  
    }
}

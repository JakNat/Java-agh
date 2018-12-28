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
using System.Windows.Controls;
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
        private BitmapImage _previewImage;

        public BitmapImage PreviewImage
        {
            get { return _previewImage; }
            set
            {
                _previewImage = value;
                NotifyOfPropertyChange(() => PreviewImage);
            }
        }

        public string BottomText
        {
            get { return _bottomText; }
            set
            {
                _bottomText = value;
                NotifyOfPropertyChange(() => BottomText);
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
                 serverConnection = IoC.Get<Client>()?.ServerConnection;
                if (serverConnection != null)
                {
                    serverConnection.SendObject("Meme", meme);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connect to a server" +
                    "\nException message: " + ex.Message);
            }


         
        }

        /// <summary>
        /// turn on or turn of "Generetae Meme" button
        /// </summary>
        public bool CanCreateByServer(BitmapImage image)
        {
            return image != null;
        }

        //public void Preview()
        //{
        //    string firstText = TopText;
        //    string secondText = BottomText;

        //    Bitmap image = ImageHelper.BitmapImage2Bitmap(this.Image);

        //    RectangleF TopSize = new RectangleF(new System.Drawing.Point(0, 0), new SizeF(image.Width, image.Height / 8));
        //    int y = (int)(image.Height * (7.0 / 8.0));
        //    RectangleF BottomSize = new RectangleF(new System.Drawing.Point(0, y), new SizeF(image.Width, image.Height / 8));

        //    StringFormat format = new StringFormat();
        //    format.LineAlignment = StringAlignment.Center;
        //    format.Alignment = StringAlignment.Center;

        //    using (Graphics graphics = Graphics.FromImage(image))
        //    {
        //        using (Font arialFont = new Font("Impact", image.Height / (14 / 1), System.Drawing.FontStyle.Bold, GraphicsUnit.Point))
        //        {
        //            graphics.DrawString(firstText, arialFont, Brushes.White, TopSize, format);
        //            graphics.DrawString(secondText, arialFont, Brushes.White, BottomSize, format);
        //        }
        //    }
        //    PreviewImage =  ImageHelper.Bitmap2BitmapImage(image);

        //    Window wnd = new Window();
        //    Grid grid = new Grid();
        //    wnd.Height = 200;
        //    wnd.Width = 150;
        //    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
        //    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        //    wnd.Content = grid;
        //    Image img = image;
           
         
          
        //    Grid.SetRow(img, 0);
 
        //    grid.Children.Add(img);
         
        //    wnd.Owner = MyMainWindow;
        //    wnd.ShowDialog();
        //}

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
             //   NotifyOfPropertyChange(() => Image);
            }

            
        }
    }
}

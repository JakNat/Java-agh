using Caliburn.Micro;
using MemeGenerator.Model.Dto;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using MemeGenerator.Client;
using MemeGenerator.Model;
using MemeGenerator.Client.Requests;
using MemeGenerator.Client.Utils;

namespace MemeGenerator.Client.ViewModels
{
    public class MemeCreatorViewModel : Screen
    {
        private readonly IClientApp client;
        private readonly IClientRequests clientRequests;

        private string _topText = "Top text";
        private string _bottomText = "Bottom text";
        private BitmapImage _image;
        private string _title;

        public MemeCreatorViewModel(IClientApp client ,IClientRequests clientRequests)
        {
            this.client = client;
            this.clientRequests = clientRequests;
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        public string TopText
        {
            get { return _topText; }
            set
            {
                _topText = value;
                NotifyOfPropertyChange(() => TopText);
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

        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                NotifyOfPropertyChange(() => Image);
                NotifyOfPropertyChange(() => CanCreateByServer);
            }
        }
        
        #region Buttons
        /// <summary>
        /// button -> sending your new meme properties to a server
        /// </summary>
        public async void CreateByServer()
        {
            Bitmap bitmap = ImageHelper.BitmapImage2Bitmap(Image);
            MemeDto meme = new MemeDto("meme", TopText, BottomText, bitmap);
            meme.Key = client.Key;

            try
            {
                string response = await Task.Run(() => clientRequests.CreateRequest(meme));
                MessageBox.Show("Server reponse: " + response);
            }
            catch (Exception)
            {
                MessageBox.Show("server not response");
            }
        }

        /// <summary>
        /// button -> select image to generate your new meme
        /// </summary>
        public void UploadImage()
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Title = "Select a picture",
                Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
            };
            if (op.ShowDialog() == true)
            {
                Image = new BitmapImage(new Uri(op.FileName));
            }
        }
        #endregion

        #region Validators
        /// <summary>
        /// Validator -> "Generetae Meme" button
        /// </summary>
        public bool CanCreateByServer
        {
            get { return Image != null && client.ServerConnection != null; }
        }
        #endregion
    }
}

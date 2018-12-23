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
    }
}

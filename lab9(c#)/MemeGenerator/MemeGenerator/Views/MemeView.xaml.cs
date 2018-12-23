using MemeGenerator.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;



namespace MemeGenerator.Views
{
    /// <summary>
    /// Interaction logic for MemeView.xaml
    /// </summary>
    public partial class MemeView : Window
    {
        public MemeView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button method for generate meme
        /// </summary>
        private void Create(object sender, RoutedEventArgs e)
        {
            string path = GetPath();

            var x = RenderVisual(elementToRender, Image);
            using (FileStream stream =
                new FileStream(path, FileMode.Create))
            {
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(x));
                encoder.Save(stream);

            }
        }
        /// <summary>
        /// Chosing path where we want to save our new meme
        /// </summary>
        private static string GetPath()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png |Tiff Image (.tiff)|*.tiff |Wmf Image (.wmf)|*.wmf";
            if (saveFileDialog.ShowDialog() == true)
            {
                return saveFileDialog.FileName;
            }
            return null;
        }

        /// <summary>
        /// Generate new meme based on xaml visualisation
        /// </summary>
        /// <param name="elt">Selected Grid that contains: Top text, bottom text and image</param>
        /// <param name="image">Selected image</param>
        RenderTargetBitmap RenderVisual( UIElement elt, UIElement image)
        {
            PresentationSource source = PresentationSource.FromVisual(elt);
            RenderTargetBitmap rtb = new RenderTargetBitmap((int)image.RenderSize.Width,
                  (int)image.RenderSize.Height, 96, 96, PixelFormats.Default);

            VisualBrush sourceBrush = new VisualBrush(elt);
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            using (drawingContext)
            {
                drawingContext.DrawRectangle(sourceBrush, null, new Rect(new Point(0, 0),
                      new Point(image.RenderSize.Width, image.RenderSize.Height)));
            }
            rtb.Render(drawingVisual);
            return rtb;
        }
    }
}

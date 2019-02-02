using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using MemeGenerator.Model.Dto;

namespace MemeGenerator.Server.Utils
{
    /// <summary>
    /// MemeBuilder class -> generate new Meme
    /// </summary>
    public static class MemeBuilder
    {
        public static Image GenerateMeme(MemeDto message)
        {

            string firstText = message.TopText;
            string secondText = message.BottomText;
            var image = message.Image;

            RectangleF TopSize = new RectangleF(new Point(0, 0), new SizeF(image.Width, image.Height / 8));
            int y = (int)(image.Height * (7.0 / 8.0));
            RectangleF BottomSize = new RectangleF(new Point(0, y), new SizeF(image.Width, image.Height / 8));

            StringFormat format = new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Center };

            PutText(firstText, secondText, image, TopSize, BottomSize, format);
            // var path = AppDomain.CurrentDomain.BaseDirectory + "test.jpg";
            //message.Image.Save(path);
            return image;
        }

        private static void PutText(string firstText, string secondText, Image image, RectangleF TopSize, RectangleF BottomSize, StringFormat format)
        {
            using (Graphics graphics = Graphics.FromImage(image))
            {
                using (Font arialFont = new Font("Impact", image.Height / (14 / 1), FontStyle.Bold, GraphicsUnit.Point))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.White, TopSize, format);
                    graphics.DrawString(secondText, arialFont, Brushes.White, BottomSize, format);
                }
            }
        }

    }
}
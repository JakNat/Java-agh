using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using ProtoBuf;

namespace MemeGenerator.Model.Dto
{
    [ProtoContract]
    public class MemeDto : IKeyDto
    {
        /// <summary>
        /// Private store of the image data as a byte[]
        /// This will be populated automatically when the object is serialised
        /// </summary>
        [ProtoMember(1)]
        private byte[] _imageData;

        /// <summary>
        /// The image name
        /// </summary>
        [ProtoMember(2)]
        public string ImageName { get; set; }

        [ProtoMember(4)]
        public string TopText { get; set; }

        [ProtoMember(5)]
        public string BottomText { get; set; }

        [ProtoMember(6)]
        public Guid Key { get; set; }

        /// <summary>
        /// The public accessor for the image. This will be populated
        /// automatically when the object is deserialised.
        /// </summary>
        public Image Image { get; set; }

        /// <summary>
        /// Private parameterless constructor required for deserialisation
        /// </summary>
        private MemeDto() { }

        public MemeDto(string imageName, string topText, string bottomText, Image image)
        {
            ImageName = imageName;
            TopText = topText;
            BottomText = bottomText;
            Image = image;
        }

        /// <summary>
        /// Before serialising this object convert the image into binary data
        /// </summary>
        [ProtoBeforeSerialization]
        private void Serialize()
        {
            if (Image != null)
            {
                using (MemoryStream inputStream = new MemoryStream())
                {
                    Image.Save(inputStream, ImageFormat.Jpeg);

                    //Store the binary image data as bytes[]
                    _imageData = inputStream.ToArray();
                }
            }
        }

        /// <summary>
        /// When deserialising the object convert the binary data back into an image object
        /// </summary>
        [ProtoAfterDeserialization]
        private void Deserialize()
        {
            MemoryStream ms = new MemoryStream(_imageData);
            Image = Image.FromStream(ms);
            _imageData = null;
        }
    }
}

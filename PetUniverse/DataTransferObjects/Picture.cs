using System;
using System.IO;

namespace DataTransferObjects
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/1/2020
    /// Approver: Ethan Holmes
    /// 
    /// Holds data relevant to a Picture.
    /// </summary>
    /// <remarks>
    /// Updater: Robert Holmes
    /// Updated: 04/29/2020
    /// Update: Switch class over to using byte[] as decided by the class.
    /// 
    /// </remarks>
    public class Picture
    {
        private byte[] _imageData;
        private string _imageMimeType;

        public int PictureID { get; set; }

        public string ProductID { get; set; }

        public string ImagePath { get; set; }

        public byte[] ImageData
        {
            get
            {
                byte[] temp = _imageData;
                if (_imageData == null)
                {
                    string path = "";
                    try
                    {
                        // path for WPF
                        path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, @"PresentationUtilityCode\Resources\MISSING.jpg");
                        temp = File.ReadAllBytes(path);
                    }
                    catch (NullReferenceException)
                    {
                        // path for MVC
                        temp = null;
                    }
                    
                }
                return temp;
            }
            set
            {
                _imageData = value;
            }
        }
        public string ImageMimeType
        {
            get
            {
                string temp = _imageMimeType;
                if (_imageData == null)
                {
                    temp = "image/jpeg";
                }
                return temp;
            }
            set
            {
                _imageMimeType = value;
            }
        }

        public bool IsUsingDefault
        {
            get
            {
                return (_imageData == null);
            }
        }
    }
}

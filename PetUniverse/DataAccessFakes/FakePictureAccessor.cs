using DataAccessInterfaces;
using DataTransferObjects;
using System.Collections.Generic;

namespace DataAccessFakes
{
    /// <summary>
    /// Creator: Rasha Mohammed
    /// Created: 4/8/2020
    /// Approver: Ethan Holmes
    /// 
    /// Fake picture accessor for testing purposes.
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated: 
    /// Update: 
    /// 
    /// </remarks>
    public class FakePictureAccessor : IPictureAccessor
    {
        private List<Picture> pictures;

        /// <summary>
        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        /// Sets up fake data for testing purposes.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        public FakePictureAccessor()
        {
            pictures = new List<Picture>()
            {
                new Picture()
                {
                    PictureID = 1,
                    ProductID = "1234567890120",
                    ImagePath = "pic1",
                },
                new Picture()
                {
                    PictureID = 2,
                    ProductID = "1234567890120",
                    ImagePath = "pic2",
                },
                new Picture()
                {
                    PictureID = 2,
                    ProductID = "1234567890121",
                    ImagePath = "pic3",
                }
            };
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Fake adds a picutre.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="picture"></param>
        /// <returns></returns>
        public int InsertPicture(Picture picture)
        {
            int oldCount = pictures.Count;
            pictures.Add(picture);
            return pictures.Count - oldCount;
        }

        /// <summary>
        /// <summary>
        /// Creator: Rasha Mohammed
        /// Created: 4/8/2020
        /// Approver: Ethan Holmes
        /// 
        /// Fake Pictures Accessor Method, return list of pictures for testing.
        /// </summary>
        /// <remarks>
        /// UPDATER: NA
        /// UPDATED: NA
        /// UPDATE: NA
        /// 
        /// </remarks>
        public List<Picture> SelectAllPicture()
        {
            return pictures;
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 04/29/2020
        /// Approver: Jaeho Kim
        /// 
        /// Returns a list of picutres that match the product ID.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="productID"></param>
        /// <returns></returns>
        public List<Picture> SelectAllPicturesByProductID(string productID)
        {
            var specificPics = new List<Picture>();
            foreach (var p in pictures)
            {
                if (p.ProductID.Equals(productID))
                {
                    specificPics.Add(p);
                }
            }
            return specificPics;
        }
    }
}

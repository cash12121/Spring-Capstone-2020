using System.Collections.Generic;

namespace DataTransferObjects
{
    public class TransactionLineProducts
    {
        public int TransactionID { get; set; }
        public List<ProductVM> ProductsSold { get; set; }
    }
}

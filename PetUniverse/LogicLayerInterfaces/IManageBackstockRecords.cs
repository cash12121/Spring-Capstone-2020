using DataTransferObjects;
using System.Collections.Generic;

namespace LogicLayerInterfaces
{
    /// <summary>
    /// Creator: Tener karar
    /// Created: 2020/02/7
    /// Approver: Steven Cardona
    ///
    /// The intercafe for the back stok record manger class
    /// Contains all methods for performing manging the stock record functions
    /// </summary>
    public interface IManageBackstockRecords
    {
        // bool isRecordsAdd(int RecordID);
        List<Item> getPetsInBackRoom();
        List<int> getItemLocations(int itemID);
        bool EditItemLocation(int itemID, int itemLocationID, int NewItemLocation);
    }
}

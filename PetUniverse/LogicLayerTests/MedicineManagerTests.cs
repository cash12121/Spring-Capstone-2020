using DataAccessFakes;
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LogicLayerTests
{
    /// <summary>
    ///     AUTHOR: Timothy Lickteig    
    ///     DATE: 2020-03-09
    ///     CHECKED BY: Zoey McDonald
    ///     Class for testing the Medicine Manager
    /// </summary>
    /// <remarks>
    ///     UPDATED BY: N/A
    ///     UPDATE DATE: N/A
    ///     WHAT WAS CHANGED: N/A
    /// </remarks>
    [TestClass]
    public class MedicineManagerTests
    {
        private IMedicineManager _manager;

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        ///     Setup method for MedicineManager Tests
        /// </summary>        
        [TestInitialize]
        public void TestSetup()
        {
            _manager = new MedicineManager(new FakeMedicineAccessor());
            //_manager = new MedicineManager();
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for MedicineManager CheckMedicineIN method
        /// </summary>
        [TestMethod]
        public void TestCheckMedicineIn()
        {
            Medicine medicine = new Medicine()
            {
                MedicineID = 1,
                MedicineName = "This is the medicine name",
                MedicineDosage = "This is the dosage amount",
                MedicineDescription = "This is the description"
            };

            int rows = _manager.CheckMedicineIn(medicine);

            Assert.AreEqual(1, rows);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        ///     Test method for MedicineManager CheckMedicineOut method
        /// </summary>
        [TestMethod]
        public void TestCheckMedicineOut()
        {
            Medicine medicine = new Medicine()
            {
                MedicineID = 2,
                MedicineName = "This is the medicine name",
                MedicineDosage = "This is the dosage amount",
                MedicineDescription = "This is the description"
            };
            _manager.CheckMedicineIn(medicine);

            int rows = _manager.CheckMedicineOut(2);

            Assert.AreEqual(1, rows);
        }

        [TestMethod]
        public void TestReturnAllMedicine()
        {
            List<Medicine> medicine = new List<Medicine>();

            medicine = _manager.ReturnAllMedicine();

            Assert.AreEqual(true, medicine.Count > 0);
        }

        /// <summary>
        ///     AUTHOR: Timothy Lickteig
        ///     DATE: 2020-03-09
        ///     CHECKED BY: Zoey McDonald
        ///     Cleanup method for MedicineManager tests
        /// </summary>
        [TestCleanup]
        public void TestTearDown()
        {
            _manager = null;
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Communication;
using JoystickInterface;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class DataPackerTest
    {

        private DataPacker dp;
        private byte[] AllowedPointOfViews = { 0, 1, 2, 4, 5, 6, 8, 9, 10 };

        [TestInitialize]
        public void Init()
        {
            IJoystick jm = new JoystickMock();
            dp = new DataPacker(jm);
        }

        [TestMethod]
        public void TestButtonsPressed()
        {
            byte buttons = dp.ButtonsPressed();
            Assert.IsTrue(buttons <= 127 && buttons >= 0);
        }

        [TestMethod]
        public void TestPointOfView() 
        {
            byte pov = dp.HatPov();
            Assert.IsTrue(AllowedPointOfViews.Contains(pov));
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QICConsoleApp;

namespace QIC.UnitTest
{
    [TestClass]
    public class DataTableProcessorTest
    {
        [TestMethod]
        public void GetMedianFromDataTableTest()
        {
            // prepared
            var reader = new CSVReader();
            var dt = reader.ConvertCSVtoDataTable(@".\comm_01.csv");
            Assert.IsNotNull(dt);

            var processer = new DataTableProcessor();
            // Assert
            var result = processer.GetMedianFromDataTable(dt, "Price SOD");
            Assert.AreEqual(result, 17.4398131);
        }

        [TestMethod]
        public void GetMedianFromArrayTest()
        {
            // prepared
            var processer = new DataTableProcessor();
            double[] arr = new double[] { 1, 1.5, 8, 6, 9 };
            // Assert
            var result = processer.GetMedianFromArray(arr);
            Assert.AreEqual(result, 6);
        }
    }
}
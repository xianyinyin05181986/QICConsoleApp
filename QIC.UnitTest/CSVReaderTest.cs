using Microsoft.VisualStudio.TestTools.UnitTesting;
using QICConsoleApp;

namespace QIC.UnitTest
{
    [TestClass]
    public class CSVReaderTest
    {
        [TestMethod]
        public void CanReadCSVFile()
        {
            // prepared
            var reader = new CSVReader();
            var dt = reader.ConvertCSVtoDataTable(@".\comm_01.csv");
            // Assert
            Assert.IsNotNull(dt);
        }
    }

}

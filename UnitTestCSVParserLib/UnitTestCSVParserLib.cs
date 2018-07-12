using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestCSVParserLib
{
    [TestClass]
    public class UnitTestCSVParserLib
    {
        [TestMethod]
        public void TestMethodParseEmployeesFromFile()
        {
            var resultList = CSVParserLib.Parser.ParseEmployeesFromFile("TestData.csv").ToList();
            Assert.AreEqual(resultList.Count, 7);
            Assert.AreEqual(resultList[0].Status, "valid");
            Assert.AreEqual(resultList[1].Status, "valid");
            Assert.AreEqual(resultList[2].Status, "invalid");
            Assert.AreEqual(resultList[3].Status, "invalid");
            Assert.AreEqual(resultList[4].Status, "invalid");
            Assert.AreEqual(resultList[5].Status, "valid");
            Assert.AreEqual(resultList[6].Status, "invalid");
        }
    }
}

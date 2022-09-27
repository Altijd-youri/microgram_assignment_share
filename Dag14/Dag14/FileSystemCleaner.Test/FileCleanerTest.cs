using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSystemCleaner.Test;

[TestClass]
public class FileCleanerTest
{
    private static readonly string TestFileLocation = Path.Combine(Environment.CurrentDirectory, "FileCleanerTest");
    private static readonly byte[] ByteArray30Bytes = { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0  };
    
    #region setupAndCleanup
        [TestInitialize]
        public void TestInitialize()
        {
            Directory.CreateDirectory(TestFileLocation);
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            Directory.Delete(TestFileLocation, true);
        }
    #endregion

    #region testHelpers
        private void CreateTestFile(string name, string subPath = "default")
        {
            string path = Path.Combine(TestFileLocation, subPath);
            Directory.CreateDirectory(path);
            
            string fileLocation = Path.Combine(path, name);
            using FileStream fs = new FileStream(fileLocation, FileMode.Create, FileAccess.Write, FileShare.None);
            fs.Write(ByteArray30Bytes);
            fs.Close();
        }
    #endregion
    
    // This Test is refactored into another more advanced test
    // [TestMethod]
    // public void Report_returnsListOfDirectoryContent_FilesAreShown()
    // {
    //     string directoryOfTestMethod = "openDirectory_returnsTheDirectory";
    //     CreateTestFile("30BytesFile.txt", "openDirectory_returnsTheDirectory");
    //     var sut = new FileCleaner();
    //
    //     var result = sut.Report(Path.Combine(TestFileLocation, directoryOfTestMethod));
    //
    //     var expected = new List<string>() { Path.Combine(TestFileLocation, directoryOfTestMethod, "30BytesFile.txt") };
    //     CollectionAssert.AreEqual(expected, result);
    // }
    
    [TestMethod]
    public void Report_ReturnsList_OfCleanerListings()
    {
        string directoryOfTestMethod = "Report_ReturnsListOfCleanerListings";
        CreateTestFile(".suo", directoryOfTestMethod);
        var sut = new FileCleaner();

        var result = sut.Report(Path.Combine(TestFileLocation, directoryOfTestMethod));

        var expected = new List<CleanerListing>{ new (".suo", 30) };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void Report_ReturnsFilteredList_OfCleanerListings()
    {
        string directoryOfTestMethod = "Report_ReturnsFilteredList_OfCleanerListings";
        CreateTestFile("30BytesFile.txt", directoryOfTestMethod);
        CreateTestFile(".suo", directoryOfTestMethod);
        var sut = new FileCleaner();

        var result = sut.Report(Path.Combine(TestFileLocation, directoryOfTestMethod));

        var expected = new List<CleanerListing> { new (".suo", 30) };
        CollectionAssert.AreEqual(expected, result);
    }
}
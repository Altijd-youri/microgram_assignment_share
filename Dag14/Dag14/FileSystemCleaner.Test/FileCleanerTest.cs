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
        private void CreateTestFile(string name, string subPath = "default", bool isDir = false)
        {
            string path = Path.Combine(TestFileLocation, subPath);
            if (isDir)
            {
                string pathOfDirectory = Path.Combine(path, name);
                Directory.CreateDirectory(pathOfDirectory);
            }
            else
            {
                Directory.CreateDirectory(path);
                string fileLocation = Path.Combine(path, name);
                using FileStream fs = new FileStream(fileLocation, FileMode.Create, FileAccess.Write, FileShare.None);
                fs.Write(ByteArray30Bytes);
                fs.Close();
            }
        }
    #endregion

    #region Refactored into more advanced tests
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
    #endregion

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
    
    [DataTestMethod]
    [DataRow(".suo", 30)]
    [DataRow("bin", 0, true)]
    [DataRow("node_modules", 0, true)]
    [DataRow("obj", 0, true)]
    public void Report_ReturnsFilteredList_OfCleanerListings(string fileName, long fileSize, bool isDir = false)
    {
        string directoryOfTestMethod = "Report_ReturnsFilteredList_OfCleanerListings"+"_"+fileName;
        CreateTestFile("30BytesFile.txt", directoryOfTestMethod);
        CreateTestFile(fileName, directoryOfTestMethod, isDir);
        var sut = new FileCleaner();

        var result = sut.Report(Path.Combine(TestFileLocation, directoryOfTestMethod));

        var expected = new List<CleanerListing> { new (fileName, fileSize) };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void Report_ReturnsFilteredListWithFilesAndDirectoriesMixed_OfCleanerListings()
    {
        string directoryOfTestMethod = "Report_ReturnsFilteredList_OfCleanerListings";
        CreateTestFile("30BytesFile.txt", directoryOfTestMethod);
        CreateTestFile("bin", directoryOfTestMethod, true);
        CreateTestFile(".suo", directoryOfTestMethod);
        var sut = new FileCleaner();

        var result = sut.Report(Path.Combine(TestFileLocation, directoryOfTestMethod));

        var expected = new List<CleanerListing>
        {
            new (".suo", 30),
            new ("bin", 0)
        };
        CollectionAssert.AreEqual(expected, result);
        Assert.AreEqual(2, result.Count);
    }
}
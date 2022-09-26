using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ.Test;

[TestClass]
public class LINQTest
{
    static readonly List<string> KlasDomainExpertCase = new List<string>
    {
        "Dennis", "Mark", "Ruben", "Milan", "Xander", "Arjen",
        "Maurice", "Stijn", "Raymon", "Lex", "Jort",
        "Melissa", "Erik", "Youri", "Wouter", "Wesley",
        "Wouter", "Jasper", "Jan", "Djurre", "Luuk", "Tim"
    };
    
    [TestMethod]
    public void FirstLettersOfEachStudentThatHasAnJInThouName_Comprehension()
    {
        var result = LINQKlas.FindWithJ_comperhension(KlasDomainExpertCase);

        var expected = new List<char> { 'A', 'S', 'J', 'J', 'J', 'D' };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void FirstLettersOfEachStudentThatHasAnJInThouName_Method()
    {
        List<string> klas = new List<string>
        {
            "Dennis", "Mark", "Ruben", "Milan", "Xander", "Arjen",
            "Maurice", "Stijn", "Raymon", "Lex", "Jort",
            "Melissa", "Erik", "Youri", "Wouter", "Wesley",
            "Wouter", "Jasper", "Jan", "Djurre", "Luuk"
        };

        var result = LINQKlas.FindWithJ_method(klas);

        var expected = new List<char> { 'A', 'S', 'J', 'J', 'J', 'D' };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void LengthOfNameForEachStudentThatStartWithLetterM_Method()
    {
        var result = LINQKlas.FindLengthStartingWithMDescending_method(KlasDomainExpertCase);

        var expected = new List<int> { 7, 7, 5, 4 };
        CollectionAssert.AreEqual(expected, result);
    }


    [TestMethod]
    public void LengthOfNameForEachStudentThatStartWithLetterM_Comprehension()
    {
        var result = LINQKlas.FindLengthStartingWithMDescending_comperhension(KlasDomainExpertCase);

        var expected = new List<int> { 7, 7, 5, 4 };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void CountOfNameLengthByLength_comperhension()
    {
        List<string> sut = new List<string>
        {
            "Twee", "Een", "Drie", "Vier", "Vijf", "Zes"
        };

        var result = LINQKlas.CountNameLengthByName_comperhension(sut);
        
        var expected = new List<int> { 2, 4 };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void CountOfNameLengthByLength_method()
    {
        List<string> sut = new List<string>
        {
            "Twee", "Een", "Zes"
        };

        var result = LINQKlas.CountNameLengthByName_method(sut);
        
        var expected = new List<int> { 2, 1 };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void CountOfNameLengthByLength_method_DomainCases()
    {
        var result = LINQKlas.CountNameLengthByName_method(KlasDomainExpertCase);
        
        var expected = new List<int> { 3, 4, 5, 8, 2 };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod]
    public void CountOfNameLengthByLength_comprehension_DomainCases()
    {
        var result = LINQKlas.CountNameLengthByName_comperhension(KlasDomainExpertCase);
        
        var expected = new List<int> { 3, 4, 5, 8, 2 };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod] 
    public void ThreeLetterNames_WithM_comprehension_DomainCases()
    {
        var result = LINQKlas.NamesShorterThanWithoutLetter_comprehension(KlasDomainExpertCase, 'm');
        
        var expected = new List<string> { "Jan", "Lex" };
        CollectionAssert.AreEqual(expected, result);
    }
    
    [TestMethod] 
    public void ThreeLetterNames_WithM_method_DomainCases()
    {
        var result = LINQKlas.NamesShorterThanWithoutLetter_method(KlasDomainExpertCase, 'm');
        
        var expected = new List<string> { "Jan", "Lex" };
        CollectionAssert.AreEqual(expected, result);
    }
}
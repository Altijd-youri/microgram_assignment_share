using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LINQ.Test;

[TestClass]
public class LINQTest
{
    [TestMethod]
    public void FirstLettersOfEachStudentThatHasAnJInThouName_Comprehension()
    {
        List<string> klas = new List<string>
        {
            "Dennis", "Mark", "Ruben", "Milan", "Xander", "Arjen",
            "Maurice", "Stijn", "Raymon", "Lex", "Jort",
            "Melissa", "Erik", "Youri", "Wouter", "Wesley",
            "Wouter", "Jasper", "Jan", "Djurre", "Luuk"
        };

        var result = LINQKlas.FindWithJ_comperhension(klas);

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
        List<string> klas = new List<string>
        {
            "Dennis", "Mark", "Ruben", "Milan", "Xander", "Arjen",
            "Maurice", "Stijn", "Raymon", "Lex", "Jort",
            "Melissa", "Erik", "Youri", "Wouter", "Wesley",
            "Wouter", "Jasper", "Jan", "Djurre", "Luuk"
        };

        var result = LINQKlas.FindLengthStartingWithMDescending_method(klas);

        var expected = new List<int> { 7, 7, 5, 4 };
        CollectionAssert.AreEqual(expected, result);
    }


    [TestMethod]
    public void LengthOfNameForEachStudentThatStartWithLetterM_Comprehension()
    {
        List<string> klas = new List<string>
        {
            "Dennis", "Mark", "Ruben", "Milan", "Xander", "Arjen",
            "Maurice", "Stijn", "Raymon", "Lex", "Jort",
            "Melissa", "Erik", "Youri", "Wouter", "Wesley",
            "Wouter", "Jasper", "Jan", "Djurre", "Luuk"
        };

        var result = LINQKlas.FindLengthStartingWithMDescending_comperhension(klas);

        var expected = new List<int> { 7, 7, 5, 4 };
        CollectionAssert.AreEqual(expected, result);
    }
}
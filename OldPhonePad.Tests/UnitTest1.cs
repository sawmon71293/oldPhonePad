namespace OldPhonePad.Tests;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using OldPhonePad;
[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestBasicSequence()
    {
        string input = "222#";
        string expected = "C";
        string actual = Program.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestWithSpacesAndMultipleLetters()
    {
        string input = "2 22 222#";
        string expected = "ABC";
        string actual = Program.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestBackspace()
    {
        string input = "8 88777444666*6649999#";
        string expected = "TURINNGZ";
        string actual = Program.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void TestNoHashMeansEmpty()
    {
        string input = "222";
        string expected = "";
        string actual = Program.OldPhonePad(input);
        Assert.AreEqual(expected, actual);
    }
}

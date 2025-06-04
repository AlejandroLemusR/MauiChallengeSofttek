using MauiChallenge.Helpers;

namespace UnitTest;

public class UnitTestRot13
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestNullInput()
    {
        // Arrange
        string input = null;
        
        // Act & Assert
        Assert.That(PasswordHelper.Rot13Password(input), Is.Null);
    }

    [Test]
    public void TestEmptyString()
    {
        // Arrange
        string input = string.Empty;
        
        // Act
        string result = PasswordHelper.Rot13Password(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }

    [Test]
    public void TestAlphabetLowercase()
    {
        // Arrange
        string input = "abcdefghijklmnopqrstuvwxyz";
        string expected = "nopqrstuvwxyzabcdefghijklm";
        
        // Act
        string result = PasswordHelper.Rot13Password(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestAlphabetUppercase()
    {
        // Arrange
        string input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string expected = "NOPQRSTUVWXYZABCDEFGHIJKLM";
        
        // Act
        string result = PasswordHelper.Rot13Password(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestMixedCase()
    {
        // Arrange
        string input = "AbCdEfGhIjKlMnOpQrStUvWxYz";
        string expected = "NoPqRsTuVwXyZaBcDeFgHiJkLm";
        
        // Act
        string result = PasswordHelper.Rot13Password(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestNonAlphabeticCharacters()
    {
        // Arrange
        string input = "123!@#$%^&*()_+-=[]{}|;:,.<>?/";
        string expected = "123!@#$%^&*()_+-=[]{}|;:,.<>?/";
        
        // Act
        string result = PasswordHelper.Rot13Password(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestMixedAlphanumericAndSpecialCharacters()
    {
        // Arrange
        string input = "Hello123!@#";
        string expected = "Uryyb123!@#";
        
        // Act
        string result = PasswordHelper.Rot13Password(input);
        
        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void TestDoubleRot13ReturnsOriginal()
    {
        // Arrange
        string input = "TestPassword123!";
        
        // Act
        string encoded = PasswordHelper.Rot13Password(input);
        string decoded = PasswordHelper.Rot13Password(encoded);
        
        // Assert
        Assert.That(decoded, Is.EqualTo(input), "Applying ROT13 twice should return the original string");
    }

    [Test]
    public void TestCommonPasswords()
    {
        // Test cases
        var testCases = new Dictionary<string, string>
        {
            { "password", "cnffjbeq" },
            { "12345678", "12345678" },
            { "qwerty", "djregl" },
            { "admin", "nqzva" }
        };

        foreach (var testCase in testCases)
        {
            // Act
            string result = PasswordHelper.Rot13Password(testCase.Key);
            
            // Assert
            Assert.That(result, Is.EqualTo(testCase.Value), 
                $"Failed for input '{testCase.Key}'. Expected '{testCase.Value}' but got '{result}'");
        }
    }
}

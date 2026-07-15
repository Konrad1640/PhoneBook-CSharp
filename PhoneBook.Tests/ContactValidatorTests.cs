using PhoneBook.Validators;

namespace PhoneBook.Tests;

public class ContactValidatorTests
{
    [Fact]
    public void IsValidPhoneNumber_ShouldReturnTrue_WhenNumberIsCorrect()
    {
        // Arrange
        var number = "123456789";

        // Act
        var result = ContactValidator.IsValidPhoneNumber(number);

        // Assert
        Assert.True(result);
    }


    [Fact]
    public void IsValidPhoneNumber_ShouldReturnFalse_WhenNumberIsTooShort()
    {
        var number = "123";

        var result = ContactValidator.IsValidPhoneNumber(number);

        Assert.False(result);
    }


    [Fact]
    public void IsValidName_ShouldReturnTrue_WhenNameExists()
    {
        var name = "Konrad";

        var result = ContactValidator.IsValidName(name);

        Assert.True(result);
    }


    [Fact]
    public void IsValidName_ShouldReturnFalse_WhenNameIsEmpty()
    {
        var name = "";

        var result = ContactValidator.IsValidName(name);

        Assert.False(result);
    }
}
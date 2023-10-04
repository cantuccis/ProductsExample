using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test;

[TestClass]
public class AuthTest
{
    [TestMethod]
    public void CreateAuthManagerTest()
    {
       var auth = new AuthManager();
       Assert.IsNotNull(auth);
    }

    [TestMethod]
    public void SignUpTest()
    {
        // Arrange
        var auth = new AuthManager();

        // Act
        auth.SignUp("someuser", "somepass");

        // Assert
        Assert.IsTrue(auth.ExistsUser("someuser"));
    }

    [TestMethod]
    public void SignUpShouldFailIfUsernameIsAlreadyTakenTest()
    {
        // Arrange
        var auth = new AuthManager();
        auth.SignUp("someuser", "somepass");

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => auth.SignUp("someuser", "pass1234"));

        // Assert
        Assert.AreEqual("Username already exists", exception.Message);
    }

    [TestMethod]
    public void SignInTest()
    {
        // Arrange
        var auth = new AuthManager();
        auth.SignUp("someuser", "somepass");

        // Act
        var credentials = auth.SignIn("someuser", "somepass");

        // Assert
        Assert.IsNotNull(credentials);
        Assert.AreEqual(credentials.Username);
    }

    [TestMethod]
    public void SignInShouldFailIfUserDoesNotExistTest()
    {
        // Arrange
        var auth = new AuthManager();
        auth.SignUp("someuser", "somepass");

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => auth.SignIn("someotheruser", "somepass"));

        // Assert
        Assert.AreEqual("Invalid username/password", exception.Message);
    }

    [TestMethod]
    public void SignInShouldFailIfPasswordIsIncorrectTest()
    {
        // Arrange
        var auth = new AuthManager();
        auth.SignUp("someuser", "somepass");

        // Act
        var exception = Assert.ThrowsException<ArgumentException>(() => auth.SignIn("someuser", "notthepass"));

        // Assert
        Assert.AreEqual("Invalid username/password", exception.Message);
    }
}

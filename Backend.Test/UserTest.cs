using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Test;

[TestClass]
public class UserTest
{
    [TestMethod]
    public void CreateUserTest()
    {
        var user = new User("someuser", "somepassword");
        Assert.IsNotNull(user);
        Assert.AreEqual(user.Username, "someuser");
        Assert.IsTrue(user.IsPasswordCorrect("somepassword"));
    }

    [TestMethod]
    public void UsernameShouldNotBeEmptyTest()
    {
        var exception = Assert.ThrowsException<ArgumentException>(() => new User("", "somepassword"));
        Assert.AreEqual("Username cannot be empty", exception.Message);
    }

    [TestMethod]
    public void PasswordShouldNotBeEmptyTest()
    {
        var exception = Assert.ThrowsException<ArgumentException>(() => new User("someuser", ""));
        Assert.AreEqual("Password cannot be empty", exception.Message);
    }
}

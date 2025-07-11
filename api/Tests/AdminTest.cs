using OpCuriosidade.Entities.PersonnelContext;

namespace Tests;

[TestClass]
public sealed class AdminTest
{
    [TestMethod]
    public void Admin_Name_Not_Valid_By_Widht()
    {
        Admin admin = new Admin(name:"Ricardo",email:"admin@email.com",isDeleted: false,password:"ASDassd546#");
        Console.WriteLine(admin.Name);
        Assert.AreEqual(true, admin.Validation());
    }
}

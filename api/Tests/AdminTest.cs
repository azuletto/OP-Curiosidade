using OpCuriosidade.Entities.PersonnelContext;

namespace Tests;

[TestClass]
public sealed class AdminTest
{
    [TestMethod]
    public void Admin_Name_Not_Valid_By_Widht()
    {
        Admin admin = new Admin(name: "", email: "admin@email.com", isDeleted: false, password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Name_Not_Valid_By_Characters()
    {
        Admin admin = new Admin(name: "Admin@123", email: "adim@email.com", isDeleted: false, password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }
    [TestMethod]
    public void Admin_Name_Imput_Not_Valid_By_Sql_Injection()
    {
        Admin admin = new Admin(name: "Admin' OR 1=1; --", email: "admin@email.com", isDeleted: false, password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());

    }
    [TestMethod]
    public void Admin_Name_Is_Valid()
    {
        Admin admin = new Admin(name: "Ricardo Gonçalves Filho", email: "admin@email.com", isDeleted: false, password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }
}

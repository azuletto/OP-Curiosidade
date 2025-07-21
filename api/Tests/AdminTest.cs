using OpCuriosidade.Entities.PersonnelContext;

namespace Tests;

[TestClass]
public sealed class AdminTest
{
    [TestMethod]
    public void Admin_Name_Not_Valid_By_Widht()
    {
        Admin admin = new Admin(
            name: "", 
            email: "admin@email.com", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Name_Imput_Not_Valid_By_Sql_Injection_Attempt()
    {
        Admin admin = new Admin(
            name: "Admin' OR 1=1; --", 
            email: "admin@email.com", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());

    }

    [TestMethod]
    public void Admin_Name_Is_Valid()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "admin@email.com", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Email_Not_Valid_By_Widht()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Email_Not_Valid_By_Format()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "adminemail.com", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Email_Input_Not_Valid_By_Sql_Injection_Attempt()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "admin' OR 1=1; --@email.com", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Email_Is_Valid()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "admin@email.com", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Password_Not_Valid_By_Widht()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "admin@email.com", 
            isDeleted: false, 
            password: "");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Password_Not_Valid_By_Format()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "admin@email.com", 
            isDeleted: false, 
            password: "123456");
        Assert.AreEqual(true, admin.Validation());
    }

    [TestMethod]
    public void Admin_Password_Is_Valid()
    {
        Admin admin = new Admin(
            name: "Ricardo Gonçalves Filho", 
            email: "admin@email.com", 
            isDeleted: false, 
            password: "ASDassd546#");
        Assert.AreEqual(true, admin.Validation());
    }
}

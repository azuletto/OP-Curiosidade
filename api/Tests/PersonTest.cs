using OpCuriosidade.Entities.PersonnelContext;
using OpCuriosidade.Entities.PersonnelContext.ValueObjects;

namespace Tests;

[TestClass]
public sealed class PersonTest
{
    [TestMethod]
    public void Person_Name_Not_Valid_By_Widht()
    {
        Person person = new Person(
            name: "J", // Nome válido
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Name_Imput_Not_Valid_By_Sql_Injection_Attempt()
    {
        Person person = new Person(
            name: "Person' OR 1=1; --",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
            );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Name_Is_Valid()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
            );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Email_Not_Valid_By_Widht()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Email_Not_Valid_By_Format()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "personemail.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Email_Input_Not_Valid_By_Sql_Injection_Attempt()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person' OR 1=1; --@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Email_Is_Valid()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
            );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_BirthDate_Not_Valid_By_FutureDate()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: DateOnly.FromDateTime(DateTime.Now.AddDays(1)), // Data futura
            status: true,
            address: "Av. Paulista, 1000"
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_BirthDate_Is_Valid()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Address_Not_Valid_By_Empty()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "" // Endereço vazio
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_Address_Input_Not_Valid_By_Sql_Injection_Attempt()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000'; DROP TABLE Persons; --"
        );
        Assert.AreEqual(false, person.Validation());
    }

    [TestMethod]
    public void Person_Address_Is_Valid()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000"
        );
        Assert.AreEqual(true, person.Validation());
    }

    [TestMethod]
    public void Person_OtherInfos_Is_Valid_When_Null()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000",
            otherInfos: null
        );
        Assert.AreEqual(true, person.Validation());
    }
    [TestMethod]
    public void Person_OtherInfos_Not_Valid_By_Sql_Injection_Attempt()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000",
            otherInfos: new OtherInfos(
                valors: "1234567890",
                feelings: "Some info'; DROP TABLE Persons; --",
                info: "Some info",
                interess: "Some interests"
                )
            );
        Assert.AreEqual(true, person.Validation());
    }
    [TestMethod]
    public void Person_OtherInfos_Is_Valid_By_Any_Field_Being_Null()
    {
        Person person = new Person(
            name: "Ricardo Gonçalves Filho",
            email: "person@email.com",
            isDeleted: false,
            birthDate: new DateOnly(1990, 1, 1),
            status: true,
            address: "Av. Paulista, 1000",
            otherInfos: new OtherInfos(
                valors: "1234567890",
                feelings: null, // Campo feelings é nulo
                info: "Some info",
                interess: "Some interests"
            )
        );
        Assert.AreEqual(true, person.Validation());
    }
}

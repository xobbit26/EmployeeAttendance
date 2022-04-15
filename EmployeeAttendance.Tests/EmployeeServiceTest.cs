using EmployeeAttendance.Data.Repository;
using EmployeeAttendance.Data.Repository.RepoConfig;
using Moq;
using NUnit.Framework;

namespace EmployeeAttendance.Tests;

public class EmployeeServiceTest
{
    [SetUp]
    public void Setup()
    {
    }


    [Test]
    public void FindById_SuccessTest()
    {
        //Arrange
        var mock = new Mock<IEmployeeRepository>();
        //mock.Setup(a => a.GetComputerList()).Returns(new List<Computer>());
        //HomeController controller = new HomeController(mock.Object);

        //// Act
        //ViewResult result = controller.Index() as ViewResult;

        //// Assert
        //Assert.IsNotNull(result.Model);
    }
}

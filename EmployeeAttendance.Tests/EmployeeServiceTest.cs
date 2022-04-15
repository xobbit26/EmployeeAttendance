using AutoMapper;
using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.Data.Repository;
using EmployeeAttendance.Data.Repository.RepoConfig;
using EmployeeAttendance.DTOs;
using EmployeeAttendance.Services;
using EmployeeAttendance.Services.Impl;
using EmployeeAttendance.Utils;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAttendance.Tests;

public class EmployeeServiceTest
{
    private IMapper mapper;
    private IEmployeeService employeeService;
    private Mock<IEmployeeRepository> employeeRepositoryMock;

    [SetUp]
    public void Setup()
    {
        var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfile()));
        mapper = mappingConfig.CreateMapper();

        employeeRepositoryMock = new Mock<IEmployeeRepository>();

        employeeService = new EmployeeService(mapper, employeeRepositoryMock.Object);
    }


    [Test]
    public void FindById_SuccessTest()
    {
        //Arrange
        //employeeRepositoryMock.Setup(x => x.FindByIdAsync(It.IsAny<long>()))
        //    .ReturnsAsync(null as Employee);
        const long id = 1;
        Employee? employee = GetEmployees().Find(x => x.Id == id);
        EmployeeDto expectedEmployeeDto = mapper.Map<EmployeeDto>(employee);

        employeeRepositoryMock.Setup(x => x.FindByIdAsync(It.Is<long>(x => x == id)))
            .Returns(Task.FromResult(employee));

        // Act
        EmployeeDto actual = employeeService.FindByIdAsync(id).Result;

        // Assert
        Assert.AreEqual(expectedEmployeeDto, actual);
        employeeRepositoryMock.Verify(x => x.FindByIdAsync(id), Times.Once());
    }


    private List<Employee> GetEmployees()
    {
        return new List<Employee>()
        {
            new Employee(1,
            "test_name_1",
            "test_surname_1",
            DateOnly.ParseExact("01.01.2000", Constants.DATE_FORMAT),
            DateOnly.ParseExact("01.01.2021", Constants.DATE_FORMAT),
            "test_position_1",
            "test_department_1",
            true,
            new List<Data.Entities.EmployeeAttendance>()),

            new Employee(2,
            "test_name_2",
            "test_surname_2",
            DateOnly.ParseExact("01.01.1999", Constants.DATE_FORMAT),
            DateOnly.ParseExact("01.01.2022", Constants.DATE_FORMAT),
            "test_position_2",
            "test_department_2",
            true,
            new List<Data.Entities.EmployeeAttendance>())
        };
    }
}

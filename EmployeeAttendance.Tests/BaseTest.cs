using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAttendance.Tests;

internal class BaseTest
{
    protected readonly IMapper _mapper;

    public BaseTest()
    {
        var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfile()));
        _mapper = mappingConfig.CreateMapper();
    }
}

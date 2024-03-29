﻿using AutoMapper;
using EmployeeAttendance.Data.Entities;
using EmployeeAttendance.DTOs;
using EmployeeAttendance.Utils;

namespace EmployeeAttendance;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(dest => dest.Birthday,
                opt => opt.MapFrom(src => src.Birthday.ToString()))
            .ForMember(dest => dest.HiringDate,
                opt => opt.MapFrom(src => src.HiringDate.ToString()));


        CreateMap<EmployeeDto, Employee>()
            .ForMember(dest => dest.Birthday,
                opt => opt.MapFrom(src => DateOnly.ParseExact(src.Birthday, Constants.DATE_FORMAT)))
            .ForMember(dest => dest.HiringDate,
                opt => opt.MapFrom(src => DateOnly.ParseExact(src.HiringDate, Constants.DATE_FORMAT)));


        CreateMap<EmployeeAttendanceDto, Data.Entities.EmployeeAttendance>().ReverseMap();
    }
}
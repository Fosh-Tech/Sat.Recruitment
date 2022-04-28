using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Dtos.Mapping
{
    internal class Class1
    {
    }
}


/*
 *
 *﻿using System.Net.Mime;
using AutoMapper;
using Services.DTO.Dto;
using Services.Domain.Entities;

using Profile = AutoMapper.Profile;
using Services.DTO.Profiles.Resolver;

namespace Services.DTO.Profiles
{
    public class ConfigParameterProfile : Profile
    {

        public ConfigParameterProfile() : base(nameof(ConfigParameterProfile))
        {
            Configure();
        }

        protected void Configure()
        {
            CreateMap<ConfigParameter, ConfigParameterDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.ResolveUsing<ConfigParameterValueResolver>());

            CreateMap<ConfigParameterDto, ConfigParameter>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.ConfigParameterPerRoleTypes, opt => opt.Ignore());
        }
    }

}



----------------------

public static class WebApiConfig
    {
        public static IocContainer UnityContainer { get; set; }

        public static void Register(HttpConfiguration config)
        {
            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            UnityContainer = new IocContainer();
            UnityContainer.Register();

            EmployeeMap mapper = new EmployeeMap();
            mapper.Configure();

        }
    }


----------------------------

                List<Employee> entities = _employeeServiceData.GetEmployees();
                List<EmployeeDto> dtos = AutoMapper.Mapper.Map<List<EmployeeDto>>(entities);



 *
 *
 */

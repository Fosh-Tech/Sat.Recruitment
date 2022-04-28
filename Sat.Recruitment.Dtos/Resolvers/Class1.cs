using System;
using System.Collections.Generic;
using System.Text;

namespace Sat.Recruitment.Dtos.Resolvers
{
    internal class Class1
    {



    }
}

/*
 *
 * using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using ore.Adapter.Extensions;
using Core.IoC;
using TEC.Services.DTO.Dto;
using TEC.Services.Domain.Entities;
using TEC.Services.DTO.Contracts;

namespace ervices.DTO.Profiles.Resolver
{
    /// <summary>
    /// Clase resolver que permite gestionar el origen del campo Name
    /// </summary>
    public class ConfigParameterValueResolver : IValueResolver<ConfigParameter, ConfigParameterDto, string>
    {
        /// <summary>
        /// Resuelve el orgien del campo Value
        /// </summary>
        /// <param name="source">Entity fuente de tipo <see cref="ConfigParameter"/></param>
        /// <param name="destination">Objeto destino</param>
        /// <param name="destMember">Tipo de retorno</param>
        /// <param name="context">Contexto</param>
        /// <returns>Contenido de value</returns>
        public string Resolve(ConfigParameter source, ConfigParameterDto destination, string destMember, ResolutionContext context)
        {
            // si existe un único ConfigParameterPerRoleType significa que la obtención de la entidad
            // se ha realizado en función de RoleType, en cuyo caso se toma en consideración 
            // que el campo Value del único hijo

            string value = null;

            if (source?.ConfigParameterPerRoleTypes?.Count(x => !x.IsDeleted) == 1)
            {
                ConfigParameterPerRoleType item = source.ConfigParameterPerRoleTypes.First(x => !x.IsDeleted);
                value = item.Value;
            }

            if (string.IsNullOrEmpty(value))
            {
                value = source?.Value;
            }

            return value;
        }

    }
}

 * 
 * 
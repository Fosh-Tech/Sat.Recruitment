using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Sat.Recruitment.Dtos.Dtos;
using Sat.Recruitment.Entities.Entities;

namespace Sat.Recruitment.Dtos.TypeConverters
{
    public class UserConverter : ITypeConverter<User, UserDto>
    {
        public UserDto Convert(User source, UserDto destination, ResolutionContext context)
        {
            UserDto result = null;

            if (source != null)
            {

                result = new UserDto(source.Name, source.Email, source.Address, source.Phone, source.UserType, source.Money);

            }

            return result;
        }

    }
}



/*
 * 
 * using AutoMapper;

namespace SheetMasterData.DTO.Profiles.TypeConverter
{
    /// <summary>
    /// Conversor entre tipos
    /// </summary>
    public class ModelSheeInfoConverter : ITypeConverter<ModelSheetInfo, ModelSheetInfoDto>
    {
        /// <summary>
        /// Mapea un registro procedente de CIM en una estructura equivalente para enviar a TEC services
        /// </summary>
        /// <param name="source">Fuente del mapeo</param>
        /// <param name="destination">Mapeo resultante</param>
        /// <param name="context">Contexto</param>
        /// <returns>Retorno</returns>
        public ModelSheetInfoDto Convert(ModelSheetInfo source, ModelSheetInfoDto destination, ResolutionContext context)
        {
            ModelSheetInfoDto result = null;

            if (source != null)
            {
                string mainTextResourceValue = GetResource(source.MainTextResourceId) ?? source.MainText;
                string accessoryTextResourceValue = GetResource(source.AccessoryTextResourceId) ?? source.AccessoryText;

                result = new ModelSheetInfoDto
                {
                    Id = source.Id,
                    ModelId = source.ModelId,
                    PictureId = source.PictureId,
                    MainTextResourceId = source.MainTextResourceId,
                    AccessoryTextResourceId = source.AccessoryTextResourceId,
                    MainText = mainTextResourceValue ??  source.MainText,
                    AccessoryText = accessoryTextResourceValue ?? source.AccessoryText
                };
            }

            return result;
        }

        /// <summary>
        /// Gestiona las traducciones
        /// </summary>
        /// <param name="resourceId">Identificador del recurso</param>
        /// <returns>Valor del recurso</returns>
        private string GetResource(string resourceId)
        {
            string name = null;

            if (resourceId != null)
            {
                ITranslationManager manager = IocManagerFactory.Instance().Resolve<ITranslationManager>();
                name = manager.GetTranslation(resourceId);
            }

            return name;
        }

    }

}

------------------------------
namespace SheetMasterData.DTO.Profiles
{

    public class ModelSheetInfoProfile : Profile
    {

        public ModelSheetInfoProfile() : base(nameof(ModelSheetInfoProfile))
        {
            Configure();
        }

        protected void Configure()
        {

            IMappingExpression<ModelSheetInfo, ModelSheetInfoDto> mapToDto = CreateMap<ModelSheetInfo, ModelSheetInfoDto>();
            mapToDto.ConvertUsing<ModelSheeInfoConverter>();

            CreateMap<ModelSheetInfoDto, ModelSheetInfo>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.ModelId))
                .ForMember(dest => dest.PictureId, opt => opt.MapFrom(src => src.PictureId))
                .ForMember(dest => dest.MainText, opt => opt.MapFrom(src => src.MainText))
                .ForMember(dest => dest.AccessoryText, opt => opt.MapFrom(src => src.AccessoryText))
                .ForMember(dest => dest.MainTextResourceId, opt => opt.MapFrom(src => src.MainTextResourceId))
                .ForMember(dest => dest.AccessoryTextResourceId, opt => opt.MapFrom(src => src.AccessoryTextResourceId))
            ;

        }
    }

}

 * 
 */ 
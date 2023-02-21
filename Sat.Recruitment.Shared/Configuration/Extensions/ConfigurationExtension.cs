using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sat.Recruitment.Shared.Configuration.Exceptions;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Sat.Recruitment.Shared.Configuration.Extensions
{
    public static class ConfigurationExtension
    {
        public static TOptions GetAndValidate<TOptions>(this IConfiguration rootConfig)
            where TOptions : class, new()
        {
            string sectionName = GetSectionName<TOptions>();
            IConfigurationSection optionsConfig = rootConfig.GetSection(sectionName);

            TOptions options = new();
            optionsConfig.Bind(options);

            ValidateOptions(options, optionsConfig.Path);

            return options;
        }

        public static IServiceCollection ConfigureAndValidate<TOptions>(this IServiceCollection services, IConfiguration rootConfig)
            where TOptions : class
        {
            string sectionName = GetSectionName<TOptions>();
            IConfigurationSection optionsConfig = rootConfig.GetSection(sectionName);

            services.Configure<TOptions>(options =>
            {
                optionsConfig.Bind(options);
                ValidateOptions(options, optionsConfig.Path);
            });

            return services;
        }

        private static string GetSectionName<TOptions>() => typeof(TOptions).Name.Replace("Options", string.Empty);

        private static void ValidateOptions(object instance, string parent)
        {
            List<string> errors = new();
            ValidateOptions(instance, parent, errors);

            if (errors.Any())
                throw new ConfigurationException(string.Join(Environment.NewLine, errors));
        }

        private static void ValidateOptions(object instance, string parent, List<string> errors)
        {
            switch (instance)
            {
                case IDictionary dictionary:
                    foreach (object key in dictionary.Keys)
                    {
                        object value = dictionary[key];
                        ValidateOptions(value, $"{parent}:{key}", errors);
                    }
                    break;
                case IEnumerable enumerable:
                    int i = 0;
                    foreach (object value in enumerable)
                    {
                        ValidateOptions(value, $"{parent}[{i}]", errors);
                        i++;
                    }
                    break;
                default:
                    ValidationContext context = new(instance, null, null);
                    List<ValidationResult> results = new();
                    if (!Validator.TryValidateObject(instance, context, results, true))
                        foreach (ValidationResult result in results)
                            errors.Add($"{parent}:{result.MemberNames.FirstOrDefault()} - {result.ErrorMessage}");

                    foreach (PropertyInfo propInfo in instance.GetType().GetProperties())
                    {
                        object value = propInfo.GetValue(instance, null);
                        if (value != null)
                        {
                            Type valueType = value.GetType();
                            if (valueType.IsClass && valueType != typeof(string))
                                ValidateOptions(value, $"{parent}:{propInfo.Name}", errors);
                        }
                    }
                    break;
            }
        }
    }
}

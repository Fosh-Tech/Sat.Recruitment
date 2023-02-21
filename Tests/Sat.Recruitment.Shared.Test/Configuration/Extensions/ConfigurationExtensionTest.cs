using Microsoft.Extensions.Configuration;
using Sat.Recruitment.Shared.Configuration.Exceptions;
using Sat.Recruitment.Shared.Configuration.Extensions;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Shared.Test.Configuration.Extensions
{
    public class ConfigurationExtensionTest
    {


        [Fact]
        public void Test_GetAndValidate_WithoutRequiredFields_ShouldRaiseAnException()
        {

            var configuration = new ConfigurationBuilder()
                                                    .AddJsonFile("./Configuration/Extensions/appsettingsWithoutRequiredFields.json", optional: false)
                                                    .Build();

            var ex = Assert.Throws<ConfigurationException>(() =>
                                    ConfigurationExtension.GetAndValidate<ApplicationSettings>(configuration));

            Assert.Contains("ApplicationSettings:SecuritySettings", ex.Message);
        }

        [Fact]
        public void Test_GetAndValidate_SectionExist()
        {
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("./Configuration/Extensions/appsettings.json", optional: false)
                                .Build();

            var result = ConfigurationExtension.GetAndValidate<ApplicationSettings>(configuration);

            Assert.IsType<ApplicationSettings>(result);
            Assert.False(result.ApplicationName == null &&
                        result.SecuritySettings == null, "Section is not configured in appsettings.json");
        }
    }

    #region FakeModel

    public interface IApplicationSettings
    {
        string ApplicationName { get; set; }
        SecuritySettings SecuritySettings { get; set; }
    }

    public class ApplicationSettings : IApplicationSettings
    {
        public string ApplicationName { get; set; }

        [Required]
        public SecuritySettings SecuritySettings { get; set; }
    }

    public interface ISecuritySettings
    {
        string JwtAudience { get; set; }
        string JwtIssuer { get; set; }
        string JwtSecurityKey { get; set; }
        string JwtDecryptionKey { get; set; }
    }

    public class SecuritySettings : ISecuritySettings
    {
        [Required]
        public string JwtSecurityKey { get; set; }

        public string JwtIssuer { get; set; }

        public string JwtAudience { get; set; }
        public string JwtDecryptionKey { get; set; }
    }
    #endregion
}

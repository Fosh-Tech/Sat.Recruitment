namespace Sat.Recruitment.Api
{
    internal abstract class Routing
    {
        public const string Version = "v{version:apiVersion}";        

        public class Parameters
        {            
            public const string UserName = "{userName}";
        }

        public class Resources
        {
            public const string User = "User";
            public const string Probe = "Probe";
        }     
    }
}

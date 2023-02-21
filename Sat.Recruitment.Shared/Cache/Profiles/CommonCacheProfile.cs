namespace Sat.Recruitment.Shared.Cache.Profiles
{
    public class CommonCacheProfile : BaseCacheProfile
    {
        public const string CACHERESPONSEPROFILENAME = "Common";

        public CommonCacheProfile(string cacheProfileName)
            : base(cacheProfileName)
        {
            // Gets or sets the duration in seconds for which response is cached. This sets "max-age" in "cache-control" header.
            this.Duration = 120;

            // Gets or sets the location where the data from a particular URL must be cached.
            // "ResponsCacheLocation.Any": works like response cached in both proxies and client and sets "cache-control" header to the public.
            // "ResponseCacheLocation.Client": works like response cached only in the client and sets "cache-control" header to private.
            // "ResponseCacheLocation.None": works like "cache-control" and "Pragma" headers set to "no-cache".
            this.Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Any;

            // Gets or sets the value which determines whether the data should store or not.
            // 'true': it sets the "cache-control" header to "no-store" and ignores the "Location" parameter for values other than "None" and ignores "Duration" as well.
            this.NoStore = false;
        }

        public static WithUserAgentCacheProfile GetDefault() => new (CACHERESPONSEPROFILENAME);
    }
}

namespace Sat.Recruitment.Shared.Cache.Profiles
{
    public abstract class BaseCacheProfile : Microsoft.AspNetCore.Mvc.CacheProfile
    {
        protected BaseCacheProfile(string cacheProfileName)
            : base() => this.CacheProfileName = cacheProfileName;

        public string CacheProfileName { get; private set; }
    }
}

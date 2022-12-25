using WebApi.Models;

namespace WebApi.Configuration
{
    public static class SiteConfig 
    {
        public static void AddSiteConfiguration(this IServiceCollection services, IConfiguration Configuration)
        {
            services.Configure<SiteSettings>(Configuration.GetSection(nameof(SiteSettings)));
            
        }
    }
}

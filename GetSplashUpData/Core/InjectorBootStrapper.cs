using GetSplashUpData.Core.Interfaces;
using GetSplashUpData.Core.Managers;
using GetSplashUpData.Core.Services;

namespace GetSplashUpData.Core
{
    public class InjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<IGovDbManager, GovDbManager>();
            services.AddScoped<IFindService, FindService>();
        }
    }
}

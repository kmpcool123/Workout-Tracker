using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Workout_Tracker.Startup))]

namespace Workout_Tracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

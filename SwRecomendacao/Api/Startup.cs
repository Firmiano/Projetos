using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;

namespace Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR(new HubConfiguration(){EnableJSONP = true});
        }
    }
}
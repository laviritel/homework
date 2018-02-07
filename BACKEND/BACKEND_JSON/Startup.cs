using Owin;
using System.Web.Http;

namespace BACKEND_JSON
{
    class Startup
    {
        public void Configuration(IAppBuilder buidlder)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();
            httpConfig.Routes.MapHttpRoute("API", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            buidlder.UseWebApi(httpConfig);
        }
    }
}

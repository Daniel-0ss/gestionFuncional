using System.Web.Http;

namespace PersonasService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Registra rutas y configuraci�n de Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Registra los componentes de Unity (Inyecci�n de dependencias)
            UnityConfig.RegisterComponents();
        }
    }
}

using System.Web.Http;

namespace CitasService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Registra rutas y configuración de Web API
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Registra los componentes de Unity (Inyección de dependencias)
            UnityConfig.RegisterComponents();
        }
    }
}

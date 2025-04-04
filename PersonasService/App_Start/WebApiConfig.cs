using System.Web.Http;

namespace PersonasService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configura rutas por atributos (recomendado)
            config.MapHttpAttributeRoutes();

            // Ruta por defecto (opcional)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Habilita JSON por defecto en lugar de XML
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}

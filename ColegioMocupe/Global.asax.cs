using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ColegioMocupe
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Constantes.host = Settings.Get<string>("host");
            Constantes.baseDatos = Settings.Get<string>("base");
        }

        public static class Settings
        {
            public static T Get<T>(string key)
            {
                var appSetting = ConfigurationManager.AppSettings[key];
                if (string.IsNullOrWhiteSpace(appSetting)) return default(T);
                var convert = TypeDescriptor.GetConverter(typeof(T));
                return (T)(convert.ConvertFromInvariantString(appSetting));
            }
        }
    }
}
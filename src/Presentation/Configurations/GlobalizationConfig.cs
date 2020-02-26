using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Configurations
{
    public static class GlobalizationConfig
    {
        public static IApplicationBuilder UseGlobalizationConfig(this IApplicationBuilder app)
        {
            var dafaultCulture = new CultureInfo("pt-BR");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(dafaultCulture),
                SupportedCultures = new List<CultureInfo> { dafaultCulture },
                SupportedUICultures = new List<CultureInfo> { dafaultCulture }
            };

            app.UseRequestLocalization(localizationOptions);
            return app;
        }
    }
}

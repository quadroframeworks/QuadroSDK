using Microsoft.Extensions.Configuration;
using Quadro.Api;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.FrontEnd.Wpf.App
{
    internal class ConfigurationHelper: IApiConfig
    {
        private readonly IConfiguration configuration;

        public ConfigurationHelper()
        {
            // Build configuration from appsettings.json
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Base path for the application
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }


        public string BaseUri
        {
            get
            {
                //return "https://localhost:7073/";
                var config = configuration["ApiSettings:BaseUri"]; // Access the BaseUri value
                return config == null ? "https://localhost:7073/" : config;
            }
        }

       
    }
}

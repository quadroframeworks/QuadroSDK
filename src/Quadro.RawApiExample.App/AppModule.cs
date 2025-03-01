using Ninject.Modules;
using Quadro.Api.Services.Default;
using Quadro.Api.Services;
using Quadro.Api;
using Quadro.FrontEnd.Wpf.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quadro.Utils.Logging;

namespace Quadro.UnitOfWorkExample.App
{
    public class AppModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILog>().To<ConsoleLog>();
            Bind<IApiConfig>().To<ConfigurationHelper>().InSingletonScope();
            Bind<IHttpClientProvider>().To<HttpClientProvider>().InSingletonScope();
            Bind<HttpJsonFunctions>().ToSelf().InSingletonScope();
            Bind<IAuthService>().To<AuthService>().InSingletonScope();
            Bind<IRawApiService>().To<RawApiService>().InSingletonScope();
            Bind<IUnitOfWorkService>().To<UnitOfWorkService>().InSingletonScope();
            Bind<IModellingService>().To<ModellingService>().InSingletonScope();
            Bind<IProductionService>().To<ProductionService>().InSingletonScope();
            Bind<IDrawingService>().To<DrawingService>().InSingletonScope();
            Bind<IWebShopApiService>().To<WebShopApiService>().InSingletonScope();
            Bind<IApiService>().To<HttpService>().InSingletonScope();
            Bind<IEntityTypeProvider>().To<OpenEntityTypeProvider>();


        }
    }
}

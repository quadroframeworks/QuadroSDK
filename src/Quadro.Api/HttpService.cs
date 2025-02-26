using Quadro.Api.Services;
using Quadro.Utils.Logging;

namespace Quadro.Api
{
    public class HttpService : IApiService
    {

        private readonly ILog log;


        public HttpService(ILog log, 
                            IAuthService authService, 
                            IUnitOfWorkService uowService, 
                            IModellingService modellingService, 
                            IDrawingService drawingService,
                            IProductionService productionService)
        {
            this.log = log;
            this.Auth = authService;
            this.UnitOfWork = uowService;
            this.Modelling = modellingService;
            this.Drawing = drawingService;
            this.Production = productionService;
        }


        public IAuthService Auth { get; }
        public IUnitOfWorkService UnitOfWork { get; }
        public IModellingService Modelling { get; }
        public IDrawingService Drawing { get; }
        public IProductionService Production { get; }


	




	}
}

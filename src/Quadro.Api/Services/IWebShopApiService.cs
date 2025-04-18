using Quadro.DataModel.Common;
using Quadro.DataModel.Entities.Images;
using Quadro.Documents.UnitOfWork;

namespace Quadro.Api.Services
{
    public interface IWebShopApiService
    {
        Task<UnitOfWork> GetShoppingCart();
        Task<List<WebShopModelMetaData>> GetWebShopModels();
        Task<ImageDto> GetCompanyLogo();
        Task<Theme> GetTheme();
    }


    public class WebShopModelMetaData
    {
        public string ModelId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Thumbnail? Thumbnail { get; set; }

    }
}

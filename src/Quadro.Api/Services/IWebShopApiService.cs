using Quadro.DataModel.Common;
using Quadro.Documents.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api.Services
{
    public interface IWebShopApiService
    {
        Task<UnitOfWork> GetShoppingCart();
        Task<List<WebShopModelMetaData>> GetWebShopModels();
    }


    public class WebShopModelMetaData
    {
        public string ModelId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public Thumbnail? Thumbnail { get; set; }

    }
}

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api
{
    public interface IHttpClientProvider
    {
        Task<HttpClient> GetClient();
    }
}

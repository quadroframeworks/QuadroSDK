using Quadro.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorApp
    {
        IApiService Api { get; }
        void AddSingleton<T>();
        void AddSingleton<T, I>() where I : T;
        void AddDynamic<T,I>() where I : T;
        void AddTabContent<T>() where T:IShopFloorTabContent;
        void ReportProgress(double progress, object sender);
        void ReportBusy();
        void ReportFinished();
    }
}

using Quadro.Api.Services;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorModule
    {

        string? Header { get; }
        void Init(IShopFloorApp app);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorTabContent
    {
        string Header { get; }

        void Init(IShopFloorTab tab);

    }


}

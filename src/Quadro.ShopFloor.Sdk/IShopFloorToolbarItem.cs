using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorToolbarItem
    {
        void Init(IShopFloorTab tab);
        string Header { get; }
        bool IsSelected { get; set; }
        Task OnClick();
    }
}

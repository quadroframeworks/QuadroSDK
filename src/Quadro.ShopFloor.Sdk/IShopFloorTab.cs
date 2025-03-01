using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorTab
    {
        void AddToolbarItem(IShopFloorToolbarItem item);
        void AddItem(IShopFloorItem item);
        void RemoveItem(IShopFloorItem item);
        IEnumerable<IShopFloorItem> GetItems();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorTab
    {
        void SetTabStyle(TabStyle tabStyle);
        void AddToolbarItem<T>() where T:IShopFloorToolbarItem;
        void AddItem(IShopFloorItem item);
        void RemoveItem(IShopFloorItem item);
        IEnumerable<IShopFloorItem> GetItems();
        void ReportProgress(double progress);
        void ReportBusy();
        void ReportFinished();
    }

    public enum TabStyle
    {
        ItemsList = 0,
        CheckedItemsList = 1,
    }
}

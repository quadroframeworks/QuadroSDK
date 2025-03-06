using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorTab
    {
        void SetHeader(string header);
        void AddToolbarItem(IShopFloorToolbarItem item);
        void AddItem(IShopFloorItem item);
        void RemoveItem(IShopFloorItem item);
        IEnumerable<IShopFloorItem> GetItems();
        void ReportProgress(double progress);
        void ReportBusy();
        void ReportFinished();
    }
}

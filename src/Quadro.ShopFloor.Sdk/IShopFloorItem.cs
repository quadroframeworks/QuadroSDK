using Quadro.Utils.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ShopFloor.Sdk
{
    public interface IShopFloorItem
    {
        string Header { get; }
        bool IsSelected { get; set; }
        Task OnClick();
        IList<ShopFloorItemMessage> Messages { get; }
    }

    public class ShopFloorItemMessage
    {
        public Severity Severity { get; set; }
        public string? Message { get; set; }
    }
}

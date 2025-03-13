using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.DataModel.Authorization
{
    public class RefreshTokenResult
    {
        public string? Bearer { get; set; }
        public string? RefreshToken { get; set; }
    }
}

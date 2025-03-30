using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Interface.Assemblies
{
    public interface IPartDistribution
    {
        string Id { get; }
        string NrHorizontal { get; set; }
        string NrVertical { get; set; }
        bool ExtendVertical { get; set; }
        string? ContraId { get; set; }
        string? SideProfileId { get; set; }
        string? MidProfileId { get; set; }
    }
}

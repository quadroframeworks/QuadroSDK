using Quadro.Interface.Assemblies;
using Quadro.Interface.Enums;
using Quadro.Interface.Solutions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Interface.RawFrames
{
    public interface IRawFrameFilling:IPartDistribution
    {
        string? Name { get; set; }
        AssemblyFillingType Type { get; set; }

        //Default filling
        string? AssemblyGroupId { get; set; }
        string? AssemblyApplicationId { get; set; }
        string? FillingAssemblyId { get; set; }
        string? PlacementOptionId { get; set; }
        string? RabbetSelectionId { get; set; }
        FillingTurnConfiguration TurnConfiguration { get; set; }
        TurnSide TurnSide { get; set; }

        //Part distribution
        bool EnablePartDistribution { get; set; }


        ICompartmentDescription Compartment { get; }

    }
}

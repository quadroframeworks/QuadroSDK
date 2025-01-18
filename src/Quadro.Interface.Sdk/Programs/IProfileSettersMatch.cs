using Quadro.Interface.Profiles;

namespace Quadro.Interface.Programs
{
	public interface IProfileSettersMatch
    {
        IEnumerable<IAppliedProfileProperty> Setters { get; }
    }
}
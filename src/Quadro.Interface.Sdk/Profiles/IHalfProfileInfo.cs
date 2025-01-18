namespace Quadro.Interface.Profiles
{
	public interface IHalfProfileInfo
    {

        double Height { get; }
        IEnumerable<CompiledProfilePropertySetter> Properties { get; }

    }

}

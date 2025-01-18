namespace Quadro.Interface.Tools
{
	public interface IToolImport
    {
        public IEnumerable<IToolHolderEntity> ImportToolHolders(string data);
    }
}

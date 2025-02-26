using Quadro.Documents;
using Quadro.Documents.Filtering;
using Quadro.Documents.Sdk;
using Quadro.Documents.UnitOfWork;

namespace Quadro.Api.Services
{
    public interface IUnitOfWorkService
    {
        //Generic
        Task<IEnumerable<SchemaInfo>> GetSchemaInfos();
        Task<UnitOfWork> StartNew(string endpoint);
        Task<UnitOfWork> Commit(string endpoint, UnitOfWork uow);
        Task<UnitOfWork> Discard(string endpoint, UnitOfWork uow);

        //CRUD per entity
        Task<DataTypeSchema> GetSchema(string endpoint);
        Task<UnitOfWork> Create(string endpoint, UnitOfWork uow, string actionId);
        Task<UnitOfWork> CreateOnProperty(string endpoint, UnitOfWork uow, string actionId, string dtoId);
        Task<UnitOfWork> Read(string endpoint, UnitOfWork uow, string actionId, string dtoId);
        Task<UnitOfWork> ReadOnProperty(string endpoint, UnitOfWork uow, string actionId, string dtoId);
        Task<UnitOfWork> Update(string endpoint, UnitOfWorkUpdate update);
        Task<UnitOfWork> UpdateProperty(string endpoint, UnitOfWork uow, string dtoId, string propertyName, string? value);
        Task<UnitOfWork> Delete(string endpoint, UnitOfWork uow, string actionId, string dtoId);

        //Actions per entity
        Task<UnitOfWork> Add(string endpoint, UnitOfWork uow, string actionId, string dtoId);
        Task<UnitOfWork> Remove(string endpoint, UnitOfWork uow, string actionId, string dtoId);
        Task<UnitOfWork> DoAction(string endpoint, UnitOfWork uow, string actionId, string dtoId);
        Task<UnitOfWork> DoCustomAction(string endpoint, CustomActionArgument uow, string actionId, string dtoId);
        Task<UnitOfWork> DoSchemaAction(string endpoint, CustomActionArgument uow, string actionId);

        //Collections per entity
        Task<EntityCollection> GetItems(string endpoint, string? filter);
        Task<EntitySummary> GetItem(string endpoint, string dtoId);
        Task<FilterTree> GetFilterTree(string endpoint);
        Task<SelectableValueCollection> GetSelectableValues(string endpoint, UnitOfWork uow, string dtoId, string propertyName);



    }
}

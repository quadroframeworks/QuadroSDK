using Quadro.Documents.Sdk;
using Quadro.Documents;
using Quadro.Documents.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api
{
    public interface IUnitOfWorkService
    {
        Task<UnitOfWork> Commit(string endpoint, UnitOfWork uow);
        Task<UnitOfWork> Create(string endpoint, UnitOfWork uow, string actionId, string? dtoId = null);
        Task<UnitOfWork> Delete(string endpoint, UnitOfWork uow, string? actionId, string dtoId);
        Task<UnitOfWork> Discard(string endpoint, UnitOfWork uow);
        Task<UnitOfWork> DoAction(string endpoint, UnitOfWork uow, string actionId, string dtoId);
        Task<EntityCollection> GetItems(string endpoint, string? filter);
        Task<DataTypeSchema> GetSchema(string endpoint);
        Task<SelectableValueCollection> GetSelectableValues(string endpoint, UnitOfWork uow, string dtoId, string propertyName);
        Task<UnitOfWork> Read(string endpoint, UnitOfWork uow, string? actionId, string dtoId);
        Task<UnitOfWork> StartNew(string endpoint);
        Task<UnitOfWork> Update(string endpoint, UnitOfWorkUpdate update);
        Task<UnitOfWork> UpdateProperty(string endpoint, UnitOfWork uow, string dtoId, string propertyName, string? value);
    }
}

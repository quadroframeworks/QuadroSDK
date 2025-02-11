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

        Task<UnitOfWork> Create(string endpoint, UnitOfWork uow, string actionId);
        Task<UnitOfWork> Read(string endpoint, UnitOfWork uow, string entityId);
        Task<UnitOfWork> Update(string endpoint, UnitOfWorkUpdate update);
        Task<UnitOfWork> Delete(string endpoint, UnitOfWork uow, string entityId);
        Task<UnitOfWork> DoAction(string endpoint, UnitOfWork uow, string entityId, string actionId);

    }
}

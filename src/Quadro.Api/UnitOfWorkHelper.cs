using Quadro.Api.Services;
using Quadro.Documents;
using Quadro.Documents.Fluent;
using Quadro.Documents.UnitOfWork;
using Quadro.Utils.Storage;
using System.Linq.Expressions;

namespace Quadro.Api
{
    public class UnitOfWorkHelper
    {
        private readonly IUnitOfWorkService service;
        private readonly DataTypeSchema schema;
        public UnitOfWorkHelper(IUnitOfWorkService service, DataTypeSchema schema)
        {
            this.service = service;
            this.schema = schema;
        }


        public async Task<UnitOfWork> StartNew()
        {
            return await service.StartNew(schema.StartNewEndpoint);
        }

        public async Task<UnitOfWork> Commit(UnitOfWork uow)
        {
            return await service.Commit(schema.CommitEndPoint, uow);
        }

        public async Task<UnitOfWork> Discard(UnitOfWork uow)
        {
            return await service.Discard(schema.DiscardEndPoint, uow);
        }

        public async Task<UnitOfWork> Create(UnitOfWork uow)
        {
            var createaction = schema.Actions.First(a => a.ActionType == ActionType.Create);
            return await service.Create(schema.CreateEndPoint, uow, createaction.Id);
        }

        public async Task<UnitOfWork> Read(UnitOfWork uow, string entityId)
        {
            return await service.Read(schema.ReadEndPoint, uow, null, entityId);
        }

        public async Task<UnitOfWork> Update<T>(UnitOfWork uow, T entity) where T : class, IStorable
        {
            var update = new UnitOfWorkUpdate() { Uow = uow, Model =  entity};
            return await service.Update(schema.UpdateEndPoint, update);
        }

        public async Task<UnitOfWork> UpdateProperty<T>(UnitOfWork uow, Expression<Func<T, object?>> expression, string entityId, object? value) where T : class,IStorable
        {
            var propertyname = ExpressionInfo.GetNameFromMemberExpression(expression)?.ToLower();
            return await service.UpdateProperty(schema.UpdatePropertyEndPoint, uow, entityId, propertyname!, value?.ToString());
        }

        public async Task<UnitOfWork> Delete(UnitOfWork uow, string entityId)
        {
            return await service.Read(schema.DeleteEndPoint, uow, null, entityId);
        }

        public async Task<IEnumerable<T>> GetAll<T>(IProgress<double> progress) where T:class, IStorable
        {
            var result = new List<T>();
            var readaction = schema.Actions.Single(a => a.ActionType == ActionType.Read);
            var entities = await service.GetItems(schema.GetItemsEndPoint, null);
            foreach (var entity in entities.Entities)
            {
                var uow = await service.StartNew(schema.StartNewEndpoint);
                uow = await service.Read(schema.ReadEndPoint, uow, readaction.Id, entity.Id);
                result.Add((T)uow.Containers.Single().Model);
            }

            return result;
        }
    }
}

using Quadro.Api.Services;
using Quadro.DataModel.Entities.Customers;
using Quadro.Documents;
using Quadro.Documents.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.UnitOfWorkExample.App.Examples
{
    internal class CustomersExampleRaw
    {
        private readonly IUnitOfWorkService api;
        public CustomersExampleRaw(IApiService api)
        {
            this.api = api.UnitOfWork;
        }

        internal async Task RunCustomersExample()
        {
            Console.WriteLine("Reading all schema info objects");
            var schemainfos = await api.GetSchemaInfos();
            var customerschemainfo = schemainfos.Single(s => s.TypeName == typeof(CustomerDto).FullName);

            Console.WriteLine($"Reading schema at {customerschemainfo.GetSchemaEndPoint}");
            var schema = await api.GetSchema(customerschemainfo.GetSchemaEndPoint);

            if (schema == null)
            {
                Console.WriteLine($"Failed reading schema for type {customerschemainfo.TypeName}");
                return;
            }
            Console.WriteLine($"Succesfully read schema for type {schema.TypeName}");

            Console.WriteLine("");
            Console.WriteLine("Current items are:");
            await ReadItems(schema);

            Console.WriteLine("");
            Console.WriteLine("Creating new unit of work");
            var uow = await api.StartNew(schema.StartNewEndpoint);

            Console.WriteLine("Creating customer");
            var createaction = schema.Actions.First(a => a.ActionType == ActionType.Create);
            uow = await api.Create(schema.CreateEndPoint, uow, createaction.Id);

            Console.WriteLine("Change customer name");
            var customer = (CustomerDto)uow.Containers.First().Model;
            var nameproperty = nameof(customer.Name);
            uow = await api.UpdateProperty(schema.UpdatePropertyEndPoint, uow, customer.Id, nameproperty, "Customer X");

            Console.WriteLine("");
            await ShowSelectableValues(schema, uow, customer);

            Console.WriteLine("Commit changes");
            uow = await api.Commit(schema.CommitEndPoint, uow);

            Console.WriteLine("");
            Console.WriteLine("Current items are:");
            await ReadItems(schema);

            Console.WriteLine("Deleting all customers with name Customer X");
            await DeleteItems(schema);

            Console.WriteLine("");
            Console.WriteLine("Current items are:");
            await ReadItems(schema);

            Console.WriteLine("Finished");

        }

        async Task ReadItems(DataTypeSchema schema)
        {
            Console.WriteLine("Reading items...");
            var items = await api.GetItems(schema.GetItemsEndPoint, null);

            Console.WriteLine(string.Join(",", items.Headers.Select(h => h.PropertyName)));

            foreach (var item in items.Entities)
            {
                Console.WriteLine(string.Join(",", item.Values));
            }
        }


        async Task DeleteItems(DataTypeSchema schema)
        {
            Console.WriteLine("Deleting items...");
            var readaction = schema.Actions.Single(a => a.ActionType == ActionType.Read);
            var deleteaction = schema.Actions.Single(a => a.ActionType == ActionType.Delete);
            var items = await api.GetItems(schema.GetItemsEndPoint, null);
            var customertype = schema.Types.Single(t => t.FullTypeName == schema.TypeName);
            var uow = await api.StartNew(schema.StartNewEndpoint);

            foreach (var item in items.Entities)
            {
                uow = await api.Read(schema.ReadEndPoint, uow, readaction.Id, item.Id);

                var customer = uow.Containers.Select(c => c.Model).OfType<CustomerDto>().Single(c => c.Id == item.Id);
                if (customer.Name == "Customer X")
                    uow = await api.Delete(schema.DeleteEndPoint, uow, deleteaction.Id, item.Id);
            }

            await api.Commit(schema.CommitEndPoint, uow);
        }

        async Task ShowSelectableValues(DataTypeSchema schema, UnitOfWork uow, CustomerDto customer)
        {
            Console.WriteLine("Selectable values for the CustomerDto.PriceListId field:");
            var selectables = await api.GetSelectableValues(schema.GetSelectableValuesEndPoint, uow, customer.Id, nameof(customer.PriceListId));
            foreach (var selectable in selectables.Values)
            {
                Console.WriteLine($"{selectable.Value} {selectable.Description}");
            }

        }
    }
}

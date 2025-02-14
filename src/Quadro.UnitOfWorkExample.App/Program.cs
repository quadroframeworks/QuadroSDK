using Quadro.Api;
using Quadro.DataModel.Entities.Customers;
using Quadro.Documents;
using Quadro.FrontEnd.Wpf.App;

Console.WriteLine("App started");

var api = new UnitOfWorkService(null, new ConfigurationHelper());

Console.WriteLine("Reading schema at /CustomerV2/GetSchema");
var schema = await api.GetSchema("/CustomerV2/GetSchema");
Console.WriteLine($"Succesfully read schema for type {schema.TypeName}");

Console.WriteLine("");
Console.WriteLine("Current items are:");
await ReadItems();

Console.WriteLine("");
Console.WriteLine("Creating new unit of work");
var uow = await api.StartNew(schema.StartNewEndpoint);

Console.WriteLine("Creating customer");
var createaction = schema.Actions.First(a => a.ActionType == Quadro.Documents.ActionType.Create);
uow = await api.Create(schema.CreateEndPoint, uow, createaction.Id, null);

Console.WriteLine("Change customer name");
var customer = (CustomerDto)uow.Containers.First().Model;
var nameproperty = nameof(customer.Name);
uow = await api.UpdateProperty(schema.UpdatePropertyEndPoint, uow, customer.Id, nameproperty, "Customer X");

Console.WriteLine("");
await ShowSelectableValues();

Console.WriteLine("Commit changes");
uow = await api.Commit(schema.CommitEndPoint, uow);

Console.WriteLine("");
Console.WriteLine("Current items are:");
await ReadItems();

Console.WriteLine("Deleting all customers with name Customer X");
await DeleteItems(schema);

Console.WriteLine("");
Console.WriteLine("Current items are:");
await ReadItems();

Console.WriteLine("Finished");

Console.ReadLine();


async Task ReadItems()
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
    var items = await api.GetItems(schema.GetItemsEndPoint, null);
    var customertype = schema.Types.Single(t => t.FullTypeName == schema.TypeName);
    var uow = await api.StartNew(schema.StartNewEndpoint);

    foreach (var item in items.Entities)
    {
        uow = await api.Read(schema.ReadEndPoint, uow, null, item.Id);

        var customer = uow.Containers.Select(c => c.Model).OfType<CustomerDto>().Single(c=>c.Id == item.Id);
        if (customer.Name == "Customer X")
            uow = await api.Delete(schema.DeleteEndPoint, uow, null, item.Id);
    }

    await api.Commit(schema.CommitEndPoint, uow);
}

async Task ShowSelectableValues()
{
    Console.WriteLine("Selectable values for the CustomerDto.PriceListId field:");
    var selectables = await api.GetSelectableValues(schema.GetSelectableValuesEndPoint, uow, customer.Id, nameof(customer.PriceListId));
    foreach (var selectable in selectables.Values)
    {
        Console.WriteLine($"{selectable.Value} {selectable.Description}");
    }

}
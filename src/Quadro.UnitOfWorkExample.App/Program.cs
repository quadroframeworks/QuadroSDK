// See https://aka.ms/new-console-template for more information
using Quadro.Api;
using Quadro.Documents.UnitOfWork;
using Quadro.FrontEnd.Wpf.App;

Console.WriteLine("App started");

var api = new UnitOfWorkService(null, new ConfigurationHelper());
var uow = new UnitOfWork();
uow = await api.Create("/CustomerV2/Create", uow, "abc123");


Console.WriteLine("Entity created");

Console.ReadLine();

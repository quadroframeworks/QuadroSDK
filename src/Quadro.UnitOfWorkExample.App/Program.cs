using Ninject;
using Quadro.Api.Services;
using Quadro.UnitOfWorkExample.App;
using Quadro.UnitOfWorkExample.App.Examples;


var kernel = new StandardKernel();
kernel.Load<AppModule>();
var api = kernel.Get<IApiService>();

Console.WriteLine("App started");

Console.WriteLine("Signing in...");
var signinresult = await api.Auth.SignIn("onno@ojn-it.nl", "onno");

if (signinresult.Succes)
    Console.WriteLine("Signing in succesfull");
else
    Console.WriteLine("Signing in failed");

var customerexample = kernel.Get<CustomersExampleRaw>();
await customerexample.RunCustomersExample();

var bomexample = kernel.Get<BomExample>();
await bomexample.RunBomExample();

Console.ReadLine();
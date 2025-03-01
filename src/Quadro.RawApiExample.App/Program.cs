using Ninject;
using Quadro.Api.Services;
using Quadro.UnitOfWorkExample.App;
using Quadro.UnitOfWorkExample.App.Examples;
using Quadro.Utils.Logging;

var kernel = new StandardKernel();
kernel.Load<AppModule>();
var log = kernel.Get<ILog>();
var api = kernel.Get<IApiService>();

log.Debug("App started");

log.Debug("Signing in...");
var signinresult = await api.Auth.SignIn("[username]", "[password]");

if (signinresult.Succes)
    log.Debug("Signing in succesfull");
else
    log.Debug("Signing in failed");

var customerexample = kernel.Get<CustomersExampleRaw>();
await customerexample.RunRawExample();

log.Debug("Finished");

Console.ReadLine();
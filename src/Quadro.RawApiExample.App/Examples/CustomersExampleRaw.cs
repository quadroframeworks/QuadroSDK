using Quadro.Api.Services;
using Quadro.DataModel.Entities.Customers;
using Quadro.Utils.Logging;

namespace Quadro.UnitOfWorkExample.App.Examples
{
    internal class CustomersExampleRaw
    {
        private readonly ILog log;
        private readonly IApiService api;
        public CustomersExampleRaw(ILog log, IApiService api)
        {
            this.log = log;
            this.api = api;
        }

        internal async Task RunRawExample()
        {
            log.Debug("");
            log.Debug("Reading all customers");
            var customers = await api.Raw.GetAllRaw<CustomerDto>();
            foreach (var customer in customers)
                log.Debug($" Customer {customer.Name}");

            log.Debug("");
            log.Debug("Creating new customer with name Customer X");
            var newcustomer = await api.Raw.CreateRaw<CustomerDto>();
            newcustomer.Name = "Customer X";

            log.Debug("Updating new customer");
            newcustomer = await api.Raw.UpdateRaw<CustomerDto>(newcustomer);

            log.Debug("");
            log.Debug("Reading new customer");
            newcustomer = await api.Raw.ReadRaw<CustomerDto>(newcustomer.Id);

            log.Debug("");
            log.Debug("Reading all customers again");
            customers = await api.Raw.GetAllRaw<CustomerDto>();
            foreach (var customer in customers)
                log.Debug($" Customer {customer.Name}");


            log.Debug("");
            log.Debug("Deleting new customers");
            foreach (var customerx in customers.Where(c => c.Name == "Customer X"))
            {
                var deletedcustomer = await api.Raw.DeleteRaw<CustomerDto>(customerx);
            }

            log.Debug("");
            log.Debug("Reading all customers again");
            customers = await api.Raw.GetAllRaw<CustomerDto>();
            foreach (var customer in customers)
                log.Debug($" Customer {customer.Name}");
        }

      
    }
}

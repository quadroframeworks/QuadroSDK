using Quadro.Api;
using Quadro.Api.Services;
using Quadro.DataModel.Entities.Projects;
using System.Text.Json;

namespace Quadro.UnitOfWorkExample.App.Examples
{
    internal class BomExample
    {
        private readonly IApiService api;
        private readonly HttpJsonFunctions jsonFunctions;
        public BomExample(IApiService api, HttpJsonFunctions jsonFunctions) 
        {
            this.api = api;
            this.jsonFunctions = jsonFunctions;
        }

        public async Task RunBomExample()
        {
            Console.WriteLine("Reading all schema info objects");
            var schemainfos = await api.UnitOfWork.GetSchemaInfos();
            var projectschemainfo = schemainfos.Single(s => s.TypeName == typeof(ProjectDto).FullName);

            Console.WriteLine($"Reading schema at {projectschemainfo.GetSchemaEndPoint}");
            var schema = await api.UnitOfWork.GetSchema(projectschemainfo.GetSchemaEndPoint);

            if (schema == null)
            {
                Console.WriteLine($"Failed reading schema for type {projectschemainfo.TypeName}");
                return;
            }
            Console.WriteLine($"Succesfully read schema for type {schema.TypeName}");

            Console.WriteLine($"Reading projects");
            var projects = await api.UnitOfWork.GetItems(schema.GetItemsEndPoint, null);

            foreach (var projectsummary in projects.Entities)
            {
                var uow = await api.UnitOfWork.StartNew(schema.StartNewEndpoint);
                var readaction = schema.Actions.Single(a => a.ActionType == Documents.ActionType.Read);
                uow = await api.UnitOfWork.Read(schema.ReadEndPoint, uow, readaction.Id, projectsummary.Id);

                var project = (ProjectDto)uow.Containers.Single(c => c.Id == projectsummary.Id).Model;

                foreach (var mo in project.manufacturingOrders)
                {
                    foreach (var line in mo.lines.Where(l => l.BomId != null))
                    {
                        var file = $"C:\\Temp\\{project.ProjectNumber}_{mo.BatchNumber}_{line.Tag}.json";
                        Console.WriteLine($"Creating json file {file} from bom");
                        var bom = await api.Production.GetOrderLineBomModel(line.BomId!);
                        var json = JsonSerializer.Serialize(bom, jsonFunctions.JsonOptions);
                        await File.WriteAllTextAsync(file, json);
                    }
                }
            }
        }
    }
}

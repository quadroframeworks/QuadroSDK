using Quadro.DataModel.Drawing;
using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using Quadro.DataModel.Production;
using Quadro.ToolSet;
using Quadro.Utils.Logging;
using System.Net.Http.Json;

namespace Quadro.Api.Services.Default
{
    public class DrawingService : IDrawingService
    {

        private readonly ILog log;
        private readonly IHttpClientProvider clientProvider;
        private readonly HttpJsonFunctions jsonFunctions;

        public DrawingService(ILog log, IHttpClientProvider clientProvider, HttpJsonFunctions jsonFunctions)
        {
            this.log = log;
            this.clientProvider = clientProvider;
            this.jsonFunctions = jsonFunctions;
        }

        private string baseUri = "Drawing";
        public async Task<Drawing2DDto> GetFrontView(MainAssemblyModelDto model)
        {
            var url = $"{baseUri}/GetFrontView";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<Drawing2DDto> GetSectionView(MainAssemblyModelDto model, int sectionId)
        {
            var url = $"{baseUri}/GetSectionView?sectionId={sectionId}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<Drawing2DDto>(response);
        }

        public async Task<string> GetFrontViewSvg(MainAssemblyModelDto model)
        {
            var url = $"{baseUri}/GetFrontViewSvg";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<string> GetSectionViewSvg(MainAssemblyModelDto model, int sectionId)
        {
            var url = $"{baseUri}/GetSectionViewSvg?sectionId={sectionId}";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<HeaderedDescription> GetFrameDescription(MainAssemblyModelDto model)
        {
            var url = $"{baseUri}/GetFrameDescription";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, model, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadFromJsonAsync<HeaderedDescription>(response);
        }

        public async Task<string> ConvertDrawingToDxf(Drawing2DDto drawing)
        {
            var url = $"{baseUri}/ConvertDrawingToDxf";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, drawing, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<string> ConvertDrawingToSvg(Drawing2DDto drawing)
        {
            var url = $"{baseUri}/ConvertDrawingToSvg";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, drawing, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<byte[]> ConvertWorkbookToPdf(WorkbookDto workbook)
        {
            var url = $"{baseUri}/ConvertWorkbookToPdf";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, workbook, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsByteArrayAsync(response);
        }

        public async Task<string> ConvertWorkbookToSvg(WorkbookDto workbook)
        {
            var url = $"{baseUri}/ConvertWorkbookToSvg";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, workbook, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<string> ConvertWorkbookToDxf(WorkbookDto workbook)
        {
            var url = $"{baseUri}/ConvertWorkbookToDxf";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, workbook, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsStringAsync(response);
        }

        public async Task<byte[]> ConvertSawListToPdf(SawListDto sawList)
        {
            var url = $"{baseUri}/ConvertSawListToPdf";
            var client = clientProvider.GetClient();
            var response = await client.PutAsJsonAsync(url, sawList, jsonFunctions.JsonOptions);
            return await jsonFunctions.ReadAsByteArrayAsync(response);
        }
    }
}

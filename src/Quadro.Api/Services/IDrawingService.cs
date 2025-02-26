using Quadro.DataModel.Drawing;
using Quadro.DataModel.Geometrics;
using Quadro.DataModel.Model;
using Quadro.DataModel.Production;
using Quadro.ToolSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Api.Services
{
    public interface IDrawingService
    {

        Task<Drawing2DDto> GetFrontView(MainAssemblyModelDto model);
        Task<Drawing2DDto> GetSectionView(MainAssemblyModelDto model, int sectionId);
        Task<string> GetFrontViewSvg(MainAssemblyModelDto model);
        Task<string> GetSectionViewSvg(MainAssemblyModelDto model, int sectionId);
        Task<HeaderedDescription> GetFrameDescription(MainAssemblyModelDto model);
        Task<string> ConvertDrawingToDxf(Drawing2DDto drawing);
        Task<string> ConvertDrawingToSvg(Drawing2DDto drawing);
        Task<string> ConvertWorkbookToDxf(WorkbookDto workbook);
        Task<string> ConvertWorkbookToSvg(WorkbookDto workbook);
        Task<byte[]> ConvertWorkbookToPdf(WorkbookDto workbook);
        Task<byte[]> ConvertSawListToPdf(SawListDto sawList);
    }
}

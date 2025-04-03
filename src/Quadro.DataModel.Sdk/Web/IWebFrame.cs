using Quadro.DataModel.Entities.Solutions;

namespace Quadro.DataModel.Entities.Web
{
    public interface IWebFrameDto
    {
        bool ApplyBorder { get; set; }
        bool ApplySill { get; set; }
        string? ColorId { get; set; }
        string Description { get; set; }
        string? FillingColorId { get; set; }
        List<WebFrameFillingDto> Fillings { get; set; }
        string? GlassGroupId { get; set; }
        double MaxUValue { get; set; }
        string? PaintSystemId { get; set; }
        List<WebFramePropertySetting> Properties { get; set; }
        string? RawMaterialId { get; set; }
        string? SolutionModelId { get; set; }
        string Tag { get; set; }
        string WebOrderId { get; set; }
        WebOrderState WebOrderState { get; set; }
    }
}
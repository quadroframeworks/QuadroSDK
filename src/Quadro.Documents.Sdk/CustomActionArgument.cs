namespace Quadro.Documents
{
    public class CustomActionArgument
    {
        public CustomActionArgument() { }
        public CustomActionArgument(CustomFormat headerformat, string? header, CustomFormat bodyformat, string? body)
        {
            HeaderFormat = headerformat;
            Header = header;
            BodyFormat = bodyformat;
            Body = body;
        }
        public UnitOfWork.UnitOfWork? UnitOfWork { get; set; }
        public CustomFormat HeaderFormat { get; set; }
        public CustomFormat BodyFormat { get; set; }
        public string? Header { get; set; }
        public string? Body { get; set; }
        
    }

    public enum CustomFormat
    {
        Text = 0,
        Xml = 1,
        Json = 2,
        Dxf = 3,
        Bmp = 4,
    }
}

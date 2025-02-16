using System.Linq.Expressions;
using System.Text.Json.Serialization;

namespace Quadro.Documents
{
    public class ActionDescription
    {
        public ActionDescription() { }

        public List<NamingTranslation> Headers { get; set; } = new List<NamingTranslation>();
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Url { get; set; } = null!;
        public bool IsColumnVisible { get; set; }

        public string GetBaseUrl()
        {
            int index = Url.LastIndexOf("/");
            if (index >= 0)
            {
                var result = Url.Substring(0, index);
                return result;
            }
            else
                throw new Exception($"Invalid url {Url}");
        }

        public ActionType ActionType { get; set; }

        [JsonIgnore]
        public List<Func<DataDocument, DataInstance, bool>> Conditions { get; set; } = new List<Func<DataDocument, DataInstance, bool>>();
    }


    public enum ActionType
    {
        Create,
        Read,
        Update,
        Delete,
        CreateAndAdd,
        Remove,
        CreateCopy,
        CreateVariant,
        Custom,
    }


    public class UserActionCollection
    {
        public string DataType { get; set; } = null!;
        public string DtoId { get; set; } = null!;
        public List<ActionDescription> Actions { get; set; } = new List<ActionDescription>();
    }


  
}

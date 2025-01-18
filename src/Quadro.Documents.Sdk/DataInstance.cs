using Quadro.Documents.Fluent;
using System.Linq.Expressions;

namespace Quadro.Documents
{
	public class DataInstance
    {
        public DataInstance() { }

        public List<NamingTranslation> Headers { get; set; } = new List<NamingTranslation>();
        public string DataType { get; set; } = null!;
        public string DtoId { get; set; } = null!;
        public string? ParentDtoId { get; set; }
        public ComponentState State { get; set; }
        public bool IsValid { get; set; } = true;
        public List<ValueProperty> ValueProperties { get; set; } = new List<ValueProperty>();
        public List<DataObjectProperty> ObjectProperties { get; set; } = new List<DataObjectProperty>();
        public List<DataListProperty> ListProperties { get; set; } = new List<DataListProperty>();
        public List<DataAction> Actions { get; set; } = new List<DataAction>();


		public TValue? GetValue<TValue>(string propertyname)
		{
			var property = ValueProperties.SingleOrDefault(p => p.PropertyName.ToLower() == propertyname.ToLower());
			if (property != null)
				return property.GetValue<TValue>();
			else
				throw new Exception($"Could not find value property {propertyname}");
		}

		public TValue? GetValue<TDto, TValue>(Expression<Func<TDto, TValue>> expression)
        {
            var propertyname = Fluent.ExpressionInfo.GetNameFromMemberExpression(expression)?.ToLower();
            var property = ValueProperties.SingleOrDefault(p=>p.PropertyName.ToLower() == propertyname);
            if (property != null)
                return property.GetValue<TValue>();
            else
                throw new Exception($"Could not find value property {propertyname}");
        }


        public DataInstance? GetValue<TDto, TValue>(Expression<Func<TDto, TValue>> listproperty, DataDocument document)
        {
            var result = new List<DataInstance>();
            var name = ExpressionInfo.GetNameFromMemberExpression(listproperty)?.ToLower();
            var property = this.ObjectProperties.Single(p=>p.PropertyName.ToLower() == name);
            var item = document.DataObjects.SingleOrDefault(d => d.DtoId == property.ItemId);
            return item;
        }

		public void SetValue<TValue>(string propertyname, object? value)
		{
			var property = ValueProperties.Single(p => p.PropertyName.ToLower() == propertyname.ToLower());
			property.SetValue<TValue>(value);
		}

		public void SetValue<TDto, TValue>(Expression<Func<TDto, TValue>> expression, object? value)
        {
            var propertyname = Fluent.ExpressionInfo.GetNameFromMemberExpression(expression)?.ToLower();
            var property = ValueProperties.Single(p => p.PropertyName.ToLower() == propertyname);
            property.SetValue<TValue>(value);
        }

        public void SetValue<TDto, TValue>(Expression<Func<TDto, TValue>> expression, DataInstance? instance, DataDocument document)
        {
            var propertyname = Fluent.ExpressionInfo.GetNameFromMemberExpression(expression)?.ToLower();
            var property = this.ObjectProperties.Single(p => p.PropertyName.ToLower() == propertyname);
            property.ItemId = instance?.DtoId;
        }

        public void AddToList<TDto>(Expression<Func<TDto, object>> listproperty, DataInstance instanceToAdd)
        {
            var name = ExpressionInfo.GetNameFromMemberExpression(listproperty)?.ToLower();
            var list = this.ListProperties.Single(l => l.PropertyName.ToLower() == name);
            instanceToAdd.ParentDtoId = this.DtoId;
            list.ItemIds.Add(instanceToAdd.DtoId);
        }

        public void RemoveFromList<TDto>(Expression<Func<TDto, object>> listproperty, DataInstance instanceToRemove)
        {
            var name = ExpressionInfo.GetNameFromMemberExpression(listproperty)?.ToLower();
            var list = this.ListProperties.Single(l => l.PropertyName.ToLower() == name);
            list.ItemIds.Remove(instanceToRemove.DtoId);
        }

        public void ClearList<TDto>(Expression<Func<TDto, object>> listproperty)
        {
            var name = ExpressionInfo.GetNameFromMemberExpression(listproperty)?.ToLower();
            var list = this.ListProperties.Single(l => l.PropertyName.ToLower() == name);
            list.ItemIds.Clear();
        }

        public IEnumerable<DataInstance> GetList<TDto>(Expression<Func<TDto, object>> listproperty, DataDocument document)
        {
            var result = new List<DataInstance>();
            var name = ExpressionInfo.GetNameFromMemberExpression(listproperty)?.ToLower();
            var list = this.ListProperties.Single(l => l.PropertyName.ToLower() == name);
            foreach (var itemid in list.ItemIds)
            {
                var item = document.DataObjects.SingleOrDefault(d => d.DtoId == itemid);
                result.Add(item);
            }
            return result;
        }

		public bool IsOfType<TDto>() => typeof(TDto).FullName == this.DataType;



    }

    public class ValueProperty
    {
        public ValueProperty()
        {

        }
        public ValueProperty(PropertyDescription description)
        {
            this.PropertyName = description.PropertyName;
            foreach (var action in description.Actions)
                this.Actions.Add(new DataAction(action.Url, true));
        }

        public string? Value { get; set; }
        public string? Description { get; set; }    
        public string PropertyName { get; set; } = null!;
        public bool IsValid { get; set; } = true;
        public bool IsVisible { get; set; } = true;
        public string? ValidationMessage { get; set; }
        public List<DataAction> Actions { get; set; } = new List<DataAction>();

        public T? GetValue<T>()
        {
            var result = GetValue(typeof(T));
            return (T)result;
        }

        public object? GetValue(Type type)
        {
            object? result = null;
            if (type == typeof(string))
                result = Value;
            else if (type == typeof(bool))
                result = Value == null ? null : Convert.ToBoolean(Value);
            else if (type == typeof(int))
                result = Value == null ? null : Convert.ToInt32(Value);
            else if (type == typeof(double))
                result = Value == null ? null : Convert.ToDouble(Value);
            else if (type == typeof(byte))
                result = Value == null ? null : Convert.ToByte(Value);
            else if (type == typeof(TimeSpan))
                result = Value == null ? null : TimeSpan.Parse(Value);
            else if (type.IsEnum)
                result = Enum.Parse(type, Description!);
            else if (type == typeof(Nullable<bool>))
                result = Value == null ? null : Convert.ToBoolean(Value);
            else if (type == typeof(Nullable<int>))
                result = Value == null ? null : Convert.ToInt32(Value);
            else if (type == typeof(Nullable<double>))
                result = Value == null ? null : Convert.ToDouble(Value);
            else if (type == typeof(Nullable<byte>))
                result = Value == null ? null : Convert.ToByte(Value);
            else if (type == typeof(Nullable<TimeSpan>))
                result = Value == null ? null : TimeSpan.Parse(Value);
            else
                throw new NotSupportedException($"Getting value of property {PropertyName} failed because type is not supported.");

            return result;
        }


        public void SetValue<T>(object? value)
        {
            if (typeof(T).IsEnum)
            {
                Value = ((int)value!).ToString();
                Description = value?.ToString();
            }
            else
                Value = value?.ToString();
        }
    }


    public class DataObjectProperty
    {
        public DataObjectProperty() { }
        public DataObjectProperty(PropertyDescription description) 
        { 
            PropertyName = description.PropertyName;

            foreach (var action in description.Actions)
                this.Actions.Add(new DataAction(action.Url, true));
        }
        
        public string? ItemId{ get; set; }
        public string PropertyName { get; set; } = null!;
        public bool IsVisible { get; set; } = true;
        public List<DataAction> Actions { get; set; } = new List<DataAction>();
    }

    public class DataListProperty
    {
        public DataListProperty() { }
        public DataListProperty(PropertyDescription description)
        {
            PropertyName = description.PropertyName;

            foreach (var action in description.Actions)
                this.Actions.Add(new DataAction(action.Url, true));
        }

        public List<string> ItemIds { get; set; } = new List<string>();
        public string PropertyName { get; set; } = null!;
        public bool IsVisible { get; set; } = true;
        public List<DataAction> Actions { get; set; } = new List<DataAction>();
    }

    public class DataAction
    {
        public DataAction() { }
        public DataAction(string url, bool isVisible)
        {
            Url = url;
            IsVisible = isVisible;
        }

        public string Url { get; set; }= null!;
        public bool IsVisible { get; set; }= false;
    }
}

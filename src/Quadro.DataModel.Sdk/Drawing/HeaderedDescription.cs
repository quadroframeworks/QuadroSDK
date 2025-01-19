using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.ToolSet
{

    
    public class HeaderedDescription
    {
        public string? Header { get; set; }
        public string? Description { get; set; }
        public double? Quantity { get; set; }
        public string? Unit { get; set; }
        public int Level { get; set; }
        public List<HeaderedDescription> Children { get; set; } = new List<HeaderedDescription>();

        public override string ToString()
        {

            var builder = new StringBuilder();

            if (Header != null && Description != null)
                builder.AppendLine(String.Format("{0,-30}{1,-30}",Header, Description));
            else if (Header != null)
                builder.AppendLine(Header);
            else if (Description != null) 
                builder.AppendLine(Description);

            foreach (var child in Children)
            {
                if (child.Level == 0)
                    builder.AppendLine("");

                var childdescription = child.ToString();
                if (String.IsNullOrWhiteSpace(childdescription))
                    continue;

                builder.Append(childdescription);   
            }


            return builder.ToString();
        }
    }

   
}

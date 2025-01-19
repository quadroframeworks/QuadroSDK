using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Documents.Filtering
{
	public class FilterTreeItem
	{

		public string? Header { get; set; }
		public string FilterString { get; set; } = null!;
		public List<FilterTreeItem> Children { get; set; } = new List<FilterTreeItem>();
	}

	public class FilterTree
	{
		public List<FilterTreeItem> Items { get; set; } = null!;
	}
}

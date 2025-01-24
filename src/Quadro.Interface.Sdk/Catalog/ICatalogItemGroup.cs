using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Interface.Catalog
{
	public interface ICatalogItemGroup
	{
		string Name { get; }
		double SalesMargin { get; }
	}
}

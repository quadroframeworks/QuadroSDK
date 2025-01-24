using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Interface.Customers
{
	public interface ICustomerPriceList
	{
		string Name { get; }
		IEnumerable<ICustomerPriceRule> PriceRules { get; }
	}

	public interface ICustomerPriceRule
	{
		PriceRuleRangeType RangeType { get; }
		double QuantityFrom { get; }
		double QuantityTo { get; }
		double PriceThreshold { get; }
		double WholeSaleDiscount { get; }
		
	}

	public enum PriceRuleRangeType
	{
		Disabled,
		Quantity,
		PriceThreshold,
	}
}

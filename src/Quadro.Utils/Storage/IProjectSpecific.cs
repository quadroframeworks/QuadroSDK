using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Utils.Storage
{
	public interface IProjectSpecific
	{
		string? ProjectId { get; set; }
		string? ProjectName { get; set; }
	}
}

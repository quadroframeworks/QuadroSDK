using Quadro.Utils.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quadro.Utils.Storage
{
	public interface IDatabase
	{
		T GetObject<T, D>(string id) where T : IStorable<D>;

		void UpdateObject<T, D>(T o) where T : IStorable<D>;

		void RemoveObject<T, D>(T o) where T : IStorable<D>;

		IList<T> GetCollection<T, D>() where T : IStorable<D>;
	}


}

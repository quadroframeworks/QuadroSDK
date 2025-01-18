using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quadro.Utils.Storage
{
	public interface IDatabase<D> where D : IStorable
	{
		D GetObject<T>(string id) where T : D;
		Task<D> GetObjectAsync<T>(string id) where T : D;
		IEnumerable<T> Query<T>(Expression<Func<T, bool>> filter = null) where T : D;
		Task<IEnumerable<T>> QueryAsync<T>(Expression<Func<T, bool>> filter = null) where T : D;
		void UpdateObject(D o);
		Task UpdateObjectAsync(D o);
		void RemoveObject(D o);
		Task RemoveObjectAsync(D o);


		IList<D> GetCollection<T>() where T : D;
		void CreateObject(D o);
		void CreateMany(IEnumerable<D> o);
	}

}

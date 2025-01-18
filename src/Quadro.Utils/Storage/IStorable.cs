using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quadro.Utils.Storage
{

	public interface IStorable<D>
	{
		string Id { get; set; }

		D Data { get; set; }

	}

	public interface IStorable
	{
		string Id { get; set; }
	}

	[Serializable]
	public class Storable : IStorable
	{
		[StringLength(256)]
		[Column(Order = 0)]
		public string Id { get; set; }
	}

	[Serializable]
	public class StorableGuid : IStorable
	{
		public StorableGuid()
		{
			Id = Guid.NewGuid().ToString();
		}
		[StringLength(256)]
		[Column(Order = 0)]
		public string Id { get; set; }
	}
}

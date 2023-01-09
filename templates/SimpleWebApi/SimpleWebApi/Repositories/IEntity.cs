using System;

namespace SimpleWebApi.Repositories
{
	public interface IEntity<TKey>
	{
		public TKey Id { get; set; }
	}
}

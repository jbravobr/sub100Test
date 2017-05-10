using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace sb100DemoApp
{
	public interface IApplicationService<T> where T : EntityBase
	{
		Task<int> InsertAndReturnInsertedPK(T TEntity);

		Task Insert(T TEntity);
		Task Update(T TEntity);
		Task Delete(T TEntity);

		Task<T> Get();
		Task<T> GetById(int pkId);
		Task<T> GetByPredicate(Expression<Func<T, bool>> predicate);

		Task<List<T>> GetAll();
		Task<List<T>> GetAllByPredicate(Expression<Func<T, bool>> predicate);

		Task<bool> Any();

		Task<T> FetchDataFromServer();
	}
}
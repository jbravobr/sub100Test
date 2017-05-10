using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace sb100DemoApp
{
	public interface IRootObjectService<T> where T : EntityBase
	{
		Task<int> InsertAndReturnInsertedPK(RootObject TEntity);

		Task Insert(RootObject TEntity);
		Task Update(RootObject TEntity);
		Task Delete(RootObject TEntity);

		Task<RootObject> Get(EnumAPIPath path, int? imovelId = null);
		Task<RootObject> GetById(int pkId);
		Task<RootObject> GetByPredicate(Expression<Func<RootObject, bool>> predicate);

		Task<List<RootObject>> GetAll();
		Task<List<RootObject>> GetAllByPredicate(Expression<Func<RootObject, bool>> predicate);

		Task<bool> Any();

		Task<RootObject> FetchDataFromServer(EnumAPIPath path, int? imovelId = null);
	}
}
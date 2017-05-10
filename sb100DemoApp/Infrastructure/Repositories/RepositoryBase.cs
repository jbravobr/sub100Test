using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;

namespace sb100DemoApp
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase, new()
	{
		public object _lock = new object();

		public RepositoryBase()
		{
			if (App.AppDBConnection == null)
				App.AppDBConnection = DBContext.Instance;

			CheckDatabase();
		}

		void CheckDatabase()
		{
			App.AppDBConnection.DropTable<Cliente>();
			App.AppDBConnection.DropTable<Endereco>();
			App.AppDBConnection.DropTable<Imovei>();
			App.AppDBConnection.DropTable<Imovel>();

			App.AppDBConnection.CreateTable<Cliente>(SQLite.CreateFlags.None);
			App.AppDBConnection.CreateTable<Endereco>(SQLite.CreateFlags.None);
			App.AppDBConnection.CreateTable<Imovei>(SQLite.CreateFlags.None);
			App.AppDBConnection.CreateTable<Imovel>(SQLite.CreateFlags.None);
		}

		public bool Any()
		{
			lock (_lock)
				return App.AppDBConnection.Table<T>().Any();
		}

		public void Delete(T TEntity)
		{
			lock (_lock)
				App.AppDBConnection.Delete(TEntity);
		}

		public List<T> GetAll()
		{
			lock (_lock)
				return App.AppDBConnection.GetAllWithChildren<T>(null, recursive: true);
		}

		public List<T> GetAllByPredicate(Expression<Func<T, bool>> predicate)
		{
			lock (_lock)
				return App.AppDBConnection.GetAllWithChildren(predicate, recursive: true);
		}

		public T GetById(int pkId)
		{
			lock (_lock)
				return App.AppDBConnection.GetWithChildren<T>(pkId, recursive: true);
		}

		public T GetByPredicate(Expression<Func<T, bool>> predicate)
		{
			lock (_lock)
			{
				var entity = App.AppDBConnection.Table<T>().FirstOrDefault(predicate);
				if (entity != null)
					return App.AppDBConnection.GetWithChildren<T>(entity.Id, recursive: true);

				return new T();
			}
		}

		public void Insert(T TEntity)
		{
			lock (_lock)
				App.AppDBConnection.InsertOrReplaceWithChildren(TEntity, recursive: true);
		}

		public void Update(T TEntity)
		{
			lock (_lock)
				App.AppDBConnection.UpdateWithChildren(TEntity);
		}

		public int InsertAndReturnInsertedPK(T TEntity)
		{
			lock (_lock)
			{
				App.AppDBConnection.InsertOrReplaceWithChildren(TEntity);
				var last = App.AppDBConnection.GetAllWithChildren<T>(null, recursive: true);
				return last.Last().Id;
			}
		}
	}
}
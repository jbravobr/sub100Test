using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace sb100DemoApp
{
	public class RootApplicationService<T> : IRootObjectService<T> where T : EntityBase, new()
	{
		readonly IRepositoryBase<T> _repository;
		readonly IConnectivityFunctions _connectivityService;

		public RootApplicationService(IRepositoryBase<T> repository,
									  IConnectivityFunctions connectivityService)
		{
			_repository = repository;
			_connectivityService = connectivityService;

			if (App.baseHttpClient == null)
				App.baseHttpClient = BaseHttpClient.Instance;
		}

		public Task<bool> Any()
		{
			throw new NotImplementedException();
		}

		public Task Delete(RootObject TEntity)
		{
			throw new NotImplementedException();
		}

		public async Task<RootObject> Get(EnumAPIPath path, int? imovelId = null)
		{
			if (!await _connectivityService.IsConnected())
				throw new NoConnectionException();

			var data = await FetchDataFromServer(path, imovelId);
			if (data != null)
			{
				if (path == EnumAPIPath.imoveis)
					data.Imoveis.ForEach((obj) => _repository.Insert(obj as T));
				else
					_repository.Insert(data.Imovel as T);

				return data;
			}
			return new RootObject();
		}

		public Task<List<RootObject>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<List<RootObject>> GetAllByPredicate(Expression<Func<RootObject, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task<RootObject> GetById(int pkId)
		{
			throw new NotImplementedException();
		}

		public Task<RootObject> GetByPredicate(Expression<Func<RootObject, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Task Insert(RootObject TEntity)
		{
			throw new NotImplementedException();
		}

		public Task<int> InsertAndReturnInsertedPK(RootObject TEntity)
		{
			throw new NotImplementedException();
		}

		public Task Update(RootObject TEntity)
		{
			throw new NotImplementedException();
		}

		public async Task<RootObject> FetchDataFromServer(EnumAPIPath path, int? imodelId)
		{
			HttpResponseMessage data = null;

			if (path == EnumAPIPath.imoveis)
				data = await App.baseHttpClient.GetAsync(path.ToString());
			else
				data = await App.baseHttpClient.GetAsync($"{EnumAPIPath.imoveis.ToString()}/{imodelId}");

			if (data != null && data.IsSuccessStatusCode)
			{
				var dataAsString = await data.Content.ReadAsStringAsync();
				if (!string.IsNullOrEmpty(dataAsString))
				{
					var obj = JsonConvert.DeserializeObject<RootObject>(dataAsString);
					return obj;
				}
			}

			return new RootObject();
		}
	}
}

using System;
using System.Net.Http;

namespace sb100DemoApp
{
	public sealed class BaseHttpClient
	{
		static volatile BaseHttpClient instance;
		static readonly object syncLock = new object();
		static HttpClient _baseHttpClient;

		BaseHttpClient()
		{
			var client = new HttpClient
			{
				BaseAddress = new Uri(Constants.BaseURL),
				Timeout = TimeSpan.FromSeconds(10)
			};

			_baseHttpClient = client;
		}

		public static HttpClient Instance
		{
			get
			{
				if (instance == null)
				{
					lock (syncLock)
					{
						if (instance == null)
							instance = new BaseHttpClient();
					}
				}

				return _baseHttpClient;
			}
		}
	}
}
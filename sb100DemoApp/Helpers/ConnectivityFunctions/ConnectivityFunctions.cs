using System;
using System.Threading.Tasks;
using Plugin.Connectivity.Abstractions;

namespace sb100DemoApp
{
	public class ConnectivityFunctions : IConnectivityFunctions
	{
		readonly IConnectivity _connectivityPlugin;

		public ConnectivityFunctions(IConnectivity connectivityPlugin)
		{
			_connectivityPlugin = connectivityPlugin;
		}

		public async Task<bool> IsConnected()
		{
			if (!_connectivityPlugin.IsConnected)
				return await Task.FromResult(false);

			var ping = await _connectivityPlugin.IsRemoteReachable("https://www.google.com", 80, 5000);
			return await Task.FromResult(ping);
		}
	}
}

using System.Threading.Tasks;

namespace sb100DemoApp
{
	public interface IConnectivityFunctions
	{
		Task<bool> IsConnected();
	}
}
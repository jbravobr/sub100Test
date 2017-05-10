using SQLite;
using Xamarin.Forms;

namespace sb100DemoApp
{
	public sealed class DBContext
	{
		static volatile DBContext instance;
		static readonly object syncLock = new object();
		static SQLiteConnection conn;

		DBContext()
		{
			conn = DependencyService.Get<ISQLite>(DependencyFetchTarget.GlobalInstance).GetConn();
		}

		public static SQLiteConnection Instance
		{
			get
			{
				if (instance == null)
				{
					lock (syncLock)
					{
						if (instance == null)
							instance = new DBContext();
					}
				}

				return conn;
			}
		}
	}
}
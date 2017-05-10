using SQLite;

namespace sb100DemoApp
{
	public interface ISQLite
	{
		SQLiteConnection GetConn();
	}
}
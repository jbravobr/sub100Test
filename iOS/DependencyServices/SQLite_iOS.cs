using System;
using System.IO;
using sb100DemoApp.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace sb100DemoApp.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLiteConnection GetConn()
		{
			var sqliteFilename = "sb100DemoApp.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, sqliteFilename);
			var conn = new SQLiteConnection(path);

			return conn;
		}
	}
}
using SQLite;

namespace sb100DemoApp
{
	public class EntityBase
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
	}
}
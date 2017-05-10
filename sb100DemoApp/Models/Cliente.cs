using SQLiteNetExtensions.Attributes;

namespace sb100DemoApp
{
	public class Cliente : EntityBase
	{
		public int CodCliente { get; set; }
		public string NomeFantasia { get; set; }

		[ForeignKey(typeof(Imovei))]
		public int ImoveiId { get; set; }

		[ForeignKey(typeof(Imovel))]
		public int ImovelId { get; set; }
	}
}
using SQLiteNetExtensions.Attributes;

namespace sb100DemoApp
{
	public class Endereco : EntityBase
	{
		public string Numero { get; set; }
		public string CEP { get; set; }
		public string Bairro { get; set; }
		public string Cidade { get; set; }
		public string Estado { get; set; }
		public string Zona { get; set; }
		public string Logradouro { get; set; }
		public string Complemento { get; set; }

		[ForeignKey(typeof(Imovei))]
		public int ImoveiId { get; set; }

		[ForeignKey(typeof(Imovel))]
		public int ImovelId { get; set; }
	}
}
using System;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace sb100DemoApp
{
	public class Imovei : EntityBase
	{
		public int CodImovel { get; set; }
		public string TipoImovel { get; set; }

		[OneToOne(CascadeOperations = CascadeOperation.All)]
		public Endereco Endereco { get; set; }

		public int PrecoVenda { get; set; }
		public int Dormitorios { get; set; }
		public int Suites { get; set; }
		public int Vagas { get; set; }
		public int AreaUtil { get; set; }
		public int AreaTotal { get; set; }
		public DateTime DataAtualizacao { get; set; }

		[OneToOne(CascadeOperations = CascadeOperation.All)]
		public Cliente Cliente { get; set; }

		public string UrlImagem { get; set; }
		public string SubTipoOferta { get; set; }
		public string SubtipoImovel { get; set; }
		public bool? StatusQualidadeTotal { get; set; }
		public string EstagioObra { get; set; }
		public double? DistanciaKilometros { get; set; }

		[Ignore]
		public string EnderecoFormatado
		{
			get
			{
				if (!string.IsNullOrEmpty(Endereco.Complemento))
					return $"{Endereco.Complemento}, {Endereco.Bairro.ToUpper()}";

				return $"{Endereco.Bairro.ToUpper()}";
			}
		}

		[Ignore]
		public string PrecoVendaFormatado
		{
			get
			{
				return $"R${PrecoVenda.ToString("N0").Replace(',', '.')}";
			}
		}

		[Ignore]
		public string AreaTotalFormatado
		{
			get
			{
				return $"{AreaTotal} m²";
			}
		}
	}
}
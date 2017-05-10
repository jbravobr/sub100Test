using System;
using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Linq;

namespace sb100DemoApp
{
	public class Imovel : EntityBase
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

		[TextBlob("FotosPath")]
		[Ignore]
		public List<string> Fotos { get; set; }
		public string FotosPath { get; set; }

		public string SubTipoOferta { get; set; }
		public string Observacao { get; set; }

		[TextBlob("CaracteristicasPath")]
		[Ignore]
		public List<string> Caracteristicas { get; set; }
		public string CaracteristicasPath { get; set; }

		public int PrecoCondominio { get; set; }
		public string SubtipoImovel { get; set; }

		[TextBlob("CaracteristicasComumPath")]
		[Ignore]
		public List<string> CaracteristicasComum { get; set; }
		public string CaracteristicasComumPath { get; set; }

		public string InformacoesComplementares { get; set; }

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
		public string PrecoCondominioFormatado
		{
			get
			{
				return $"R${PrecoCondominio.ToString("N0").Replace(',', '.')}";
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
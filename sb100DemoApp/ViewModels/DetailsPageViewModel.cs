using System.Threading.Tasks;
using Prism.Navigation;
using PropertyChanged;
using System.Linq;
using System.Collections.Generic;

namespace sb100DemoApp.ViewModels
{
	[ImplementPropertyChanged]
	public class DetailsPageViewModel : BaseViewModel, INavigationAware
	{
		public Imovel Imovel { get; set; }
		public List<string> Fotos { get; set; }
		public List<string> Caracteristicas { get; set; }
		public List<string> CaracateristicasComum { get; set; }
		public string BackgroundImage { get; set; }
		public bool IsDataPresented { get; set; } = true;

		int imovelId { get; set; }

		readonly IRootObjectService<Imovel> _rootObjectService;
		readonly IApplicationService<Imovel> _imovelService;
		readonly IDialogsFunctions _dialogService;

		public DetailsPageViewModel(IRootObjectService<Imovel> rootObjectService,
									IDialogsFunctions dialogService,
									IApplicationService<Imovel> imovelService)
		{
			_rootObjectService = rootObjectService;
			_imovelService = imovelService;
			_dialogService = dialogService;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		public async void OnNavigatingTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("imovelId"))
				imovelId = (int)parameters["imovelId"];

			if (imovelId > 0)
				await SetData();
			else
				_dialogService.ShowToast(EnumToastType.Error, Constants.ErrorFetchAPIData, 8000);
		}

		async Task SetData()
		{
			_dialogService.ShowLoading("Carregando detalhes");

			var data = await _rootObjectService.Get(EnumAPIPath.details, imovelId);

			if (data != null)
			{
				var imoveis = await _imovelService.GetAll();
				if (imoveis != null)
				{
					Imovel = imoveis.FirstOrDefault(x => x.CodImovel == imovelId);
					if (Imovel != null)
						ConfigureImovelForPresentation();
				}
			}
			else
				IsDataPresented = false;

			_dialogService.HideLoading();
		}

		void ConfigureImovelForPresentation()
		{
			if (!string.IsNullOrEmpty(Imovel.FotosPath))
			{
				Fotos = new List<string>();
				Imovel.FotosPath
					  .Replace("[", "")
					  .Replace("]", "")
					  .Replace("\"", "")
					  .Split(',')
					  .ToList()
					  .ForEach((nome) => Fotos.Add(nome));

				BackgroundImage = Imovel.Fotos[0];
			}

			if (!string.IsNullOrEmpty(Imovel.CaracteristicasPath))
			{
				Caracteristicas = new List<string>();
				Imovel.CaracteristicasPath
					  .Replace("[", "")
					  .Replace("]", "")
					  .Replace("\"", "")
					  .Split(',')
					  .ToList()
					  .ForEach((nome) => Caracteristicas.Add(nome));
			}

			if (!string.IsNullOrEmpty(Imovel.CaracteristicasComumPath))
			{
				CaracateristicasComum = new List<string>();
				Imovel.CaracteristicasComumPath
					  .Replace("[", "")
					  .Replace("]", "")
					  .Replace("\"", "")
					  .Split(',')
					  .ToList()
					  .ForEach((nome) => CaracateristicasComum.Add(nome));
			}

		}
	}
}
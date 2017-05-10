using Prism.Commands;
using System;
using Polly;
using PropertyChanged;
using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Net.Http;
using System.Linq;
using Prism.Services;

namespace sb100DemoApp.ViewModels
{
	[ImplementPropertyChanged]
	public class MainPageViewModel : BaseViewModel
	{
		readonly INavigationService _navigationService;
		readonly IApplicationService<Imovei> _imovelService;
		readonly IRootObjectService<Imovei> _rootObjectService;
		readonly IDialogsFunctions _dialogService;
		readonly IPageDialogService _pageService;

		public ObservableCollection<Imovei> Imoveis { get; set; }
		public DelegateCommand<Imovei> ItemTappedCommand { get; set; }
		public DelegateCommand OrderByCommand { get; set; }
		public bool IsDataPresented { get; set; } = true;

		public MainPageViewModel(IDialogsFunctions dialogService,
								 IApplicationService<Imovei> imovelService,
								 INavigationService navigationService,
								 IRootObjectService<Imovei> rootObjectService,
								 IPageDialogService pageService)
		{
			_navigationService = navigationService;
			_dialogService = dialogService;
			_imovelService = imovelService;
			_rootObjectService = rootObjectService;
			_pageService = pageService;

			ItemTappedCommand = new DelegateCommand<Imovei>(ItemTapped);
			OrderByCommand = new DelegateCommand(OrderBy);

			Task.Delay(3000);
			GetData();
		}

		async Task GetData()
		{
			var policy = Policy
				.Handle<Exception>()
				.FallbackAsync(async (Task) => _dialogService.ShowToast(EnumToastType.Error, Constants.GeneralError));

			await policy.ExecuteAsync(async () => { await SetData(); });
		}

		Action OrderBy
		{
			get
			{
				return new Action(async () =>
				{
					var orderSelection = await _pageService.DisplayActionSheetAsync("Ordenar por",
															   string.Empty,
															   "Cancelar",
															   new string[]
					{
						EnumOrderType.Preco.GetDescription(),
						EnumOrderType.Dormitorios.GetDescription(),
						EnumOrderType.Suites.GetDescription(),
						EnumOrderType.Vagas.GetDescription(),
						EnumOrderType.AreaTotal.GetDescription()
					});

					if (orderSelection != null && !orderSelection.Equals("Cancelar"))
						OrderList(orderSelection);
				});
			}
		}

		void OrderList(string orderBy)
		{
			_dialogService.ShowLoading("Atualizando");

			if (orderBy.Equals(EnumOrderType.Preco.GetDescription()))
				Imoveis = new ObservableCollection<Imovei>(Imoveis.OrderByDescending(x => x.PrecoVenda));
			if (orderBy.Equals(EnumOrderType.Dormitorios.GetDescription()))
				Imoveis = new ObservableCollection<Imovei>(Imoveis.OrderByDescending(x => x.Dormitorios));
			if (orderBy.Equals(EnumOrderType.Suites.GetDescription()))
				Imoveis = new ObservableCollection<Imovei>(Imoveis.OrderByDescending(x => x.Suites));
			if (orderBy.Equals(EnumOrderType.Vagas.GetDescription()))
				Imoveis = new ObservableCollection<Imovei>(Imoveis.OrderByDescending(x => x.Vagas));
			if (orderBy.Equals(EnumOrderType.AreaTotal.GetDescription()))
				Imoveis = new ObservableCollection<Imovei>(Imoveis.OrderByDescending(x => x.AreaTotal));

			_dialogService.HideLoading();
		}

		Action<Imovei> ItemTapped
		{
			get
			{
				return new Action<Imovei>(async (imovel) =>
				{
					var policy = Policy
						.Handle<Exception>()
						.FallbackAsync(async (task) => _dialogService.ShowToast(EnumToastType.Error, Constants.GeneralError));

					await policy.ExecuteAsync(async () => await NavigateTo(EnumMenuPages.DetailsPage.GetDescription(), imovel.CodImovel));
				});
			}
		}

		async Task NavigateTo(string page, int imovelId)
		{
			try
			{
				var parameters = new NavigationParameters();
				parameters.Add("imovelId", imovelId);

				await _navigationService.NavigateAsync($"{page}", parameters);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		async Task SetData()
		{
			_dialogService.ShowLoading("Carregando imóveis");

			var data = await _rootObjectService.Get(EnumAPIPath.imoveis);

			if (data != null)
			{
				var imoveis = await _imovelService.GetAll();
				if (imoveis != null && imoveis.Any())
					Imoveis = new ObservableCollection<Imovei>(imoveis);
			}
			else
				IsDataPresented = false;

			_dialogService.HideLoading();
		}
	}
}
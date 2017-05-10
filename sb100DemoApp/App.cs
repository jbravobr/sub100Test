using Prism.Unity;
using Microsoft.Practices.Unity;
using SQLite;
using sb100DemoApp.Views;
using System.Net.Http;
using Xamarin.Forms.Xaml;

namespace sb100DemoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public class App : PrismApplication
	{
		public static SQLiteConnection AppDBConnection { get; set; }
		public static HttpClient baseHttpClient { get; set; }

		protected override void OnInitialized()
		{
			NavigationService.NavigateAsync("BaseNavigationPage/MainPage");
		}

		protected override void RegisterTypes()
		{
			// Register Classe for IoC
			Container.RegisterType(typeof(IApplicationService<>), typeof(ApplicationService<>));
			Container.RegisterType(typeof(IRootObjectService<>), typeof(RootApplicationService<>));
			Container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			Container.RegisterType(typeof(IDialogsFunctions), typeof(DialogsFunctions));
			Container.RegisterType(typeof(IConnectivityFunctions), typeof(ConnectivityFunctions));

			// Register 3rd Party Classes for IoC
			Container.RegisterInstance(Acr.UserDialogs.UserDialogs.Instance);
			Container.RegisterInstance(Plugin.Connectivity.CrossConnectivity.Current);

			// Register pages for Navigation (PRISM)
			Container.RegisterTypeForNavigation<MainPage>();
			Container.RegisterTypeForNavigation<BaseNavigationPage>();
			Container.RegisterTypeForNavigation<DetailsPage>();
		}
	}
}
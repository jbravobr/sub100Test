using Xamarin.Forms;

namespace sb100DemoApp.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			NavigationPage.SetHasBackButton(this, false);
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}
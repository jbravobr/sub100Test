using Xamarin.Forms;

namespace sb100DemoApp.Views
{
	public partial class BaseNavigationPage : NavigationPage
	{
		public BaseNavigationPage(Page page) : base(page)
		{
			InitializeComponent();
		}
	}
}
using Prism.Mvvm;

namespace sb100DemoApp
{
	public class BaseViewModel : BindableBase
	{
		public bool IsBusy { get; set; } = true;

		public BaseViewModel()
		{
		}
	}
}
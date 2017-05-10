namespace sb100DemoApp
{
	public interface IDialogsFunctions
	{
		void ShowAlert(string message, int? timeout = null);
		void ShowLoading(string message, int? timeout = null);
		void HideLoading();
		void ShowToast(EnumToastType type, string message, int timeout = 5000);
	}
}
using System;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace sb100DemoApp
{
	public class DialogsFunctions : IDialogsFunctions
	{
		public IUserDialogs _userDialogs;

		public DialogsFunctions(IUserDialogs userDialogs)
		{
			_userDialogs = userDialogs;
		}

		public void HideLoading()
		{
			Device.BeginInvokeOnMainThread(() => _userDialogs.HideLoading());
		}

		public void ShowAlert(string message, int? timeout = default(int?))
		{
			var config = new AlertConfig
			{
				Message = string.Empty,
				OkText = "OK",
				Title = message
			};

			Device.BeginInvokeOnMainThread(() => _userDialogs.Alert(config));
		}

		public void ShowLoading(string message, int? timeout = default(int?))
		{
			Device.BeginInvokeOnMainThread(() => _userDialogs.ShowLoading(message));
		}

		public void ShowToast(EnumToastType type, string message, int timeout = 5000)
		{
			ToastConfig config = new ToastConfig(message)
			{
				Message = message,
				Duration = TimeSpan.FromMilliseconds(timeout),
				MessageTextColor = System.Drawing.Color.White,
				BackgroundColor = type == EnumToastType.Error ?
										  System.Drawing.Color.Crimson :
										  type == EnumToastType.Info || type == EnumToastType.Warning ?
										  System.Drawing.Color.Goldenrod :
										  System.Drawing.Color.Green
			};

			Device.BeginInvokeOnMainThread(() => _userDialogs.Toast(config));
		}
	}
}
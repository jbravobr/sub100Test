using System;
using Xamarin.Forms;

namespace sb100DemoApp.Views
{
	public partial class GalleryImagePreviewPage : ContentPage
	{
		const uint animationDuration = 100;
		TapGestureRecognizer doubleTapGestureRecognizer = null;

		public GalleryImagePreviewPage(ImageSource source, string address = "")
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			img.Source = source;

			if (!string.IsNullOrEmpty(address))
			{
				lblIcoPlace.IsVisible = true;
				lblAddress.Text = address;
				lblAddress.IsVisible = true;
			}

			if (Device.RuntimePlatform == Device.iOS)
			{
				var g = new TapGestureRecognizer();
				g.Tapped += OnCloseButtonClicked;
				g.NumberOfTapsRequired = 1;

				lblClose.GestureRecognizers.Add(g);
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (doubleTapGestureRecognizer == null)
			{
				doubleTapGestureRecognizer = new TapGestureRecognizer();
				doubleTapGestureRecognizer.NumberOfTapsRequired = 2;
			}

			doubleTapGestureRecognizer.Tapped += OnImagePreviewDoubleTapped;
			img.GestureRecognizers.Add(doubleTapGestureRecognizer);
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			doubleTapGestureRecognizer.Tapped -= OnImagePreviewDoubleTapped;
			img.GestureRecognizers.Remove(doubleTapGestureRecognizer);
		}

		async void OnImagePreviewDoubleTapped(object sender, EventArgs args)
		{
			if ((int)img.Scale == 1)
				await img.ScaleTo(2, animationDuration, Easing.SinInOut);
			else
				await img.ScaleTo(1, animationDuration, Easing.SinInOut);
		}

		async void OnCloseButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PopModalAsync();
		}
	}
}
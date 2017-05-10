using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace sb100DemoApp.Views
{
	public partial class ImageGalleryImage : ContentView
	{
		public static BindableProperty ImageProperty =
			BindableProperty.Create(
				nameof(Image),
				typeof(ImageSource),
				typeof(ImageGalleryImage),
				null,
				defaultBindingMode: BindingMode.OneWay
			);

		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public ImageGalleryImage()
		{
			InitializeComponent();
		}

		private async void OnImageTapped(Object sender, EventArgs e)
		{
			var selectedItem = (ImageGalleryImage)sender;
			var socialGalleryImagePreview = new GalleryImagePreviewPage(selectedItem.Image);

			await Navigation.PushModalAsync(new NavigationPage(socialGalleryImagePreview));
		}
	}
}
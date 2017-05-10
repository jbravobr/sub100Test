using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using FFImageLoading.Forms.Droid;

namespace sb100DemoApp.Droid
{
	[Activity(Label = "sb100DemoApp", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			CachedImageRenderer.Init();
			UXDivers.Artina.Shared.GrialKit.Init(this, "sb100DemoApp.Droid.GrialLicense");
			Acr.UserDialogs.UserDialogs.Init(() => (Activity)Forms.Context);

			LoadApplication(new App());
		}
	}
}

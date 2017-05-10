using Xamarin.Forms;

namespace sb100DemoApp.CustomRenderers
{
	public class LineEntry : Entry
	{
		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create("BorderColor", typeof(Color), typeof(LineEntry), Color.Black);

		public Color BorderColor
		{
			get { return (Color)GetValue(BorderColorProperty); }
			set { SetValue(BorderColorProperty, value); }
		}

		public static readonly BindableProperty PlaceholderTextColorProperty =
			BindableProperty.Create("PlaceholderTextColor", typeof(Color), typeof(LineEntry), Color.Default);

		public Color PlaceholderTextColor
		{
			get { return (Color)GetValue(PlaceholderTextColorProperty); }
			set { SetValue(PlaceholderTextColorProperty, value); }
		}

		public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create("FontSize", typeof(double), typeof(LineEntry), Font.Default.FontSize);

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		public static readonly BindableProperty FontProperty =
			BindableProperty.Create("Font", typeof(Font), typeof(LineEntry), new Font());

		public Font Font
		{
			get { return (Font)GetValue(FontProperty); }
			set { SetValue(FontProperty, value); }
		}
	}
}
using System;
using System.Globalization;
using Xamarin.Forms;

namespace sb100DemoApp
{
	public class ItemTappedEventArgsConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var itemTapped = value as ItemTappedEventArgs;
			return itemTapped.Item;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
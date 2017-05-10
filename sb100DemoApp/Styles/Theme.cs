using sb100DemoApp.CustomRenderers;
using Xamarin.Forms;

namespace sb100DemoApp
{
	public static class Theme
	{
		public static double MainWrapperPadding = 0;
		public static double BaseFontSize = 16;
		public static double BaseButtonHeight = 44;
		public static double MainMenuIconFontsize = 20;
		public static double MainMenuLabelTranslationX = 10;
		public static double MainMenuLabelFontsize = 18;

		public static string IconsFontFamily = "grialshapes";
		public static string IconsFontAwesome = "FontAwesome";

		public static Color OverImageTextColor = Color.FromHex("#FFFFFF");
		public static Color AccentColor = Color.FromHex("#FFDA125F");
		public static Color PhotoButtonColor = Color.FromHex("#3399FF");
		public static Color LabelButtonColor = Color.FromHex("#ffffff");
		public static Color ErrorColor = Color.Red;
		public static Color BasePageColor = Color.FromHex("#FFFFFF");
		public static Color MainWrapperBackgroundColor = Color.FromHex("#EFEFEF");
		public static Color MainWrapperBackgroundColorDark = Color.FromHex("#D7D7D7");
		public static Color BaseTextColor = Color.FromHex("#666666");
		public static Color MainMenuBackgroundColor = Color.FromHex("#F1F3F5");
		public static Color MainMenuSeparatorColor = Color.Transparent;
		public static Color MainMenuIconColor = Color.FromHex("#666666");
		public static Color MainMenuTextColor = Color.FromHex("#666666");
		public static Color PseudoTableSectionTitleBackgroundColor = Color.FromHex("#05000000");
		public static Color PlaceholderColorEntry = Color.FromHex("#FFFFFF");
		public static Color TranslucidBlack = Color.FromHex("#44000000");
		public static Color ListViewSeparatorColor = Color.FromHex("#D3D3D3");

		public static FileImageSource SocialHeaderBackgroundImage = new FileImageSource
		{
			File = "social_header_bg_0.jpg"
		};

		public static FileImageSource HamburguerIcon = new FileImageSource
		{
			File = "hamburguer_icon.png"
		};

		public static FileImageSource BrandImage = new FileImageSource
		{
			File = "logo.png"
		};

		public static Style LoginBackgroundImage = new Style(typeof(Image))
		{
			Setters =
			{
				new Setter
				{
					Property = Image.AspectProperty,
					Value = Aspect.AspectFill
				},
				new Setter
				{
					Property = Image.SourceProperty,
					Value = "bg2.jpg"
				},
				new Setter
				{
					Property = VisualElement.OpacityProperty,
					Value = 0.9
				}
			}
		};

		public static Style BrandNameOrnamentStyle = new Style(typeof(BoxView))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 4
				},
				new Setter
				{
					Property = View.VerticalOptionsProperty,
					Value = LayoutOptions.End
				},
				new Setter
				{
					Property = View.HorizontalOptionsProperty,
					Value = LayoutOptions.Start
				},
				new Setter
				{
					Property = VisualElement.WidthRequestProperty,
					Value = 10
				},
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = AccentColor
				}
			}
		};

		public static Style LoginEntryStyle = new Style(typeof(Entry))
		{
			Setters =
			{
				new Setter
				{
					Property = Entry.TextColorProperty,
					Value = Color.White
				},
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = Color.Transparent
				}
			}
		};

		public static Style ArtinaLoginEntryStyle = new Style(typeof(LineEntry))
		{
			BasedOn = LoginEntryStyle,
			Setters =
			{
				new Setter
				{
					Property = LineEntry.BorderColorProperty,
					Value = OverImageTextColor
				},
				new Setter
				{
					Property = LineEntry.PlaceholderTextColorProperty,
					Value = OverImageTextColor
				}
			},
			Triggers =
			{
				new Trigger(typeof(Entry))
				{
					Property = VisualElement.IsFocusedProperty,
					Value = true,
					Setters =
					{
						new Setter
						{
							Property = LineEntry.BorderColorProperty,
							Value = AccentColor
						}
					}
				}
			}
		};

		public static Style RoundedButtonStyle = new Style(typeof(Button))
		{
			Setters =
			{
				new Setter
				{
					Property = Button.FontSizeProperty,
					Value = BaseFontSize
				},
				new Setter
				{
					Property = Button.BorderRadiusProperty,
					Value = 22
				},
				new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = BaseButtonHeight
				}
			}
		};

		public static Style PrimaryActionButtonStyle = new Style(typeof(Button))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = AccentColor
				},
				new Setter
				{
					Property = Button.TextColorProperty,
					Value = LabelButtonColor
				}
			},
			BasedOn = RoundedButtonStyle
		};

		public static Style PhotoButtonStyle = new Style(typeof(Button))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = PhotoButtonColor
				},
				new Setter
				{
					Property = Button.TextColorProperty,
					Value = LabelButtonColor
				}
			},
			BasedOn = RoundedButtonStyle
		};

		public static Style ValidationEntryErrorStyle = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = ErrorColor
				},
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = Color.White
				},
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 22
				}
			}
		};

		public static Style SocialHeaderStyle = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.TranslationXProperty,
					Value = 20
				},
				new Setter
				{
					Property = View.VerticalOptionsProperty,
					Value = LayoutOptions.CenterAndExpand
				},
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 14
				},
				new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 46
				},
				new Setter
				{
					Property = Label.VerticalTextAlignmentProperty,
					Value = TextAlignment.Center
				},
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = BaseTextColor
				}
			}
		};

		public static Style MainMenuStyle = new Style(typeof(ContentPage))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = MainMenuBackgroundColor
				}
			}
		};

		public static Style MainMenuListViewStyle = new Style(typeof(ListView))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = MainMenuBackgroundColor
				},
				new Setter
				{
					Property = ListView.SeparatorVisibilityProperty,
					Value = SeparatorVisibility.None
				},
				new Setter
				{
					Property = ListView.SeparatorColorProperty,
					Value = MainMenuSeparatorColor
				},
				new Setter
				{
					Property = ListView.RowHeightProperty,
					Value = 55
				}
			}
		};

		public static Style MainMenuIconStyle = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = MainMenuIconColor
				},
				new Setter
				{
					Property = Label.FontFamilyProperty,
					Value = "grialshapes"
				},
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = MainMenuIconFontsize
				},
				new Setter
				{
					Property = View.VerticalOptionsProperty,
					Value = LayoutOptions.CenterAndExpand
				}
			}
		};

		public static Style MainMenuLabelStyle = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = MainMenuTextColor
				},
				new Setter
				{
					Property = Label.VerticalTextAlignmentProperty,
					Value = TextAlignment.Center
				},
				new Setter
				{
					Property = VisualElement.TranslationXProperty,
					Value = MainMenuLabelTranslationX
				},
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = MainMenuLabelFontsize
				},
				new Setter
				{
					Property = View.HorizontalOptionsProperty,
					Value = LayoutOptions.StartAndExpand
				},
				new Setter
				{
					Property = View.VerticalOptionsProperty,
					Value = LayoutOptions.CenterAndExpand
				},
				new Setter
				{
					Property = Label.LineBreakModeProperty,
					Value = LineBreakMode.TailTruncation
				}
			}
		};

		public static Style BrandContainerStyle = new Style(typeof(StackLayout))
		{
			Setters =
			{
				new Setter
				{
					Property = View.HorizontalOptionsProperty,
					Value = LayoutOptions.Start
				},
				new Setter
				{
					Property = View.VerticalOptionsProperty,
					Value = LayoutOptions.Start
				}
			}
		};

		public static Style BrandNameStyle = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 24
				},
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = BaseTextColor
				}
			}
		};

		public static Style FontIconFontAwesome = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.FontFamilyProperty,
					Value = IconsFontAwesome
				}
			}
		};

		public static Style FontIcon = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.FontFamilyProperty,
					Value = IconsFontFamily
				}
			}
		};

		public static Style PseudoTableSectionTitleBackgroundStyle = new Style(typeof(AbsoluteLayout))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = PseudoTableSectionTitleBackgroundColor
				},
				new Setter
				{
					Property = AbsoluteLayout.LayoutBoundsProperty,
					Value = "0,0,1,60"
				},
				new Setter
				{
					Property = AbsoluteLayout.LayoutFlagsProperty,
					Value = AbsoluteLayoutFlags.WidthProportional
				}
			}
		};

		public static Style PseudoTableSectionTitleIconStyle = new Style(typeof(Label))
		{
			BasedOn = FontIcon,
			Setters =
			{
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = AccentColor
				},
				new Setter
				{
					Property = Label.VerticalTextAlignmentProperty,
					Value = TextAlignment.End
				},
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 16
				},
				new Setter
				{
					Property = VisualElement.TranslationXProperty,
					Value = 10
				},
				new Setter
				{
					Property = VisualElement.TranslationYProperty,
					Value = -10
				}
			}
		};
		public static Style PseudoTableSectionTitleStyle = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = AccentColor
				},
				new Setter
				{
					Property = Label.VerticalTextAlignmentProperty,
					Value = TextAlignment.End
				},
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 12
				},
				new Setter
				{
					Property = Label.FontAttributesProperty,
					Value = FontAttributes.Bold
				},
				new Setter
				{
					Property = VisualElement.TranslationXProperty,
					Value = 30
				},
				new Setter
				{
					Property = VisualElement.TranslationYProperty,
					Value = -10
				}
			}
		};

		public static Style PseudoTableSectionLineBaseStyle = new Style(typeof(BoxView))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 1
				}
			}
		};

		public static Style PseudoTableSectionTitleLineStyle = new Style(typeof(BoxView))
		{
			BasedOn = PseudoTableSectionLineBaseStyle,
			Setters =
			{
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = AccentColor
				},
				new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 1
				},
				new Setter
				{
					Property = AbsoluteLayout.LayoutBoundsProperty,
					Value = "0, 1, 1, 1"
				},
				new Setter
				{
					Property = AbsoluteLayout.LayoutFlagsProperty,
					Value = AbsoluteLayoutFlags.WidthProportional & AbsoluteLayoutFlags.YProportional
				}
			}
		};

		public static Style StyleForCurrencyValues = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 10
				},
				new Setter
				{
					Property = Label.HorizontalTextAlignmentProperty,
					Value = TextAlignment.Start
				},
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = Color.FromHex("#F2F2F2")
				}
			}
		};

		public static Style StyleForPrecoFormatado = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 18
				},
				new Setter
				{
					Property = Label.HorizontalTextAlignmentProperty,
					Value = TextAlignment.Start
				},
				new Setter
				{
					Property = Label.TextColorProperty,
					Value = OverImageTextColor
				},
				new Setter
				{
					Property = Label.FontAttributesProperty,
					Value = FontAttributes.Bold
				}
			}
		};

		public static Style StyleForValueStack = new Style(typeof(StackLayout))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.WidthRequestProperty,
					Value = 100
				},
				new Setter
				{
					Property = View.HorizontalOptionsProperty,
					Value = LayoutOptions.Start
				},
				new Setter
				{
					Property = View.VerticalOptionsProperty,
					Value = LayoutOptions.End
				},
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = Color.Black
				},
				new Setter
				{
					Property = VisualElement.OpacityProperty,
					Value = 0.7
				}
			}
		};

		public static Style StyleForValueCenteredStack = new Style(typeof(StackLayout))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.WidthRequestProperty,
					Value = 100
				},
				new Setter
				{
					Property = View.HorizontalOptionsProperty,
					Value = LayoutOptions.Center
				},
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = Color.Black
				},
				new Setter
				{
					Property = VisualElement.OpacityProperty,
					Value = 0.7
				}
			}
		};

		public static Style StyleForEnderecoFormatado = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = Label.FontSizeProperty,
					Value = 12
				},
				new Setter
				{
					Property = Label.HorizontalTextAlignmentProperty,
					Value = TextAlignment.Start
				}
			}
		};

		public static Style ToolbarStyle = new Style(typeof(Grid))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 60
				},
				new Setter
				{
					Property = Grid.ColumnSpacingProperty,
					Value = 0
				}
			}
		};

		public static Style SocialHeaderStyleBorderBottomStyle = new Style(typeof(Label))
		{
			Setters =
			{
				new Setter
				{
					Property = VisualElement.HeightRequestProperty,
					Value = 1
				},
				new Setter
				{
					Property = VisualElement.BackgroundColorProperty,
					Value = ListViewSeparatorColor
				}
			}
		};
	}
}
using System;
using System.Linq;
using System.Reflection;

namespace sb100DemoApp
{
	public static class GetEnumDescriptionAttribute
	{
		public static T GetAttributeOfType<T>(this Enum enumVal) where T : Attribute
		{
			var typeInfo = enumVal.GetType().GetTypeInfo();
			var v = typeInfo.DeclaredMembers.First(x => x.Name == enumVal.ToString());

			return v.GetCustomAttribute<T>();
		}

		public static string GetDescription(this Enum enumVal)
		{
			var attr = GetAttributeOfType<EnumDescriptionAttribute>(enumVal);

			return attr != null ? attr.Description : string.Empty;
		}
	}
}
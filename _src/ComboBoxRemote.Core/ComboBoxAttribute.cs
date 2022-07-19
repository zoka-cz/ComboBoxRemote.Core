using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace Zoka.ComboBoxRemote
{
	/// <summary>Attribute to decorate the property of the View model to use it as ComboBoxRemote</summary>
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public class ComboBoxAttribute : Attribute, Zoka.IMetadataAwareCore.IMetadataAware
	{
		/// <summary>The type of the data provider, which provides the items inside the ComboBox</summary>
		public Type											DataProvider { get; set; }
		/// <summary>If true, the user may select multiple choices from ComboBox instead of only single</summary>
		public bool											Multiselect { get; set; }
		/// <summary>Optional parameter </summary>
		public object										Param1 { get; set; }

		/// <summary>Constructor</summary>
		public ComboBoxAttribute(Type _data_provider)
		{
			DataProvider = _data_provider;
		}

		/// <inheritdoc />
		public virtual void									GetDisplayMetadata(DisplayMetadataProviderContext context)
		{
			context.DisplayMetadata.AdditionalValues.Add("DataProviderType", DataProvider);
			context.DisplayMetadata.AdditionalValues.Add("Multiselect", Multiselect);
			context.DisplayMetadata.AdditionalValues.Add("Param1", Param1);
			context.DisplayMetadata.TemplateHint = Multiselect ? "ComboBoxMultiselect" : "ComboBox";
		}
	}
}

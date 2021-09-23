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
	public class ComboBoxRemoteAttribute : ComboBoxAttribute
	{
		/// <summary>Constructor</summary>
		public ComboBoxRemoteAttribute(Type _data_provider)
			: base(_data_provider)
		{
		}

		/// <inheritdoc />
		public override void								GetDisplayMetadata(DisplayMetadataProviderContext context)
		{
			base.GetDisplayMetadata(context);
			context.DisplayMetadata.AdditionalValues.Add("IsRemote", true);
		}
	}
}

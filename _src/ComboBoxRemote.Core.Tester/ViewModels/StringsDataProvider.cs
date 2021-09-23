using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComboBoxRemote.Core.Tester.ViewModels
{
	public class StringsDataProvider : Zoka.ComboBoxRemote.IComboBoxDataProvider
	{
		/// <inheritdoc />
		public IEnumerable<SelectListItem> GetComboBoxItems(ClaimsPrincipal _claims_principal)
		{
			var strings = new string [] {
				"String 01",
				"String 02",
				"String 03",
				"String 04"
			};

			return new List<SelectListItem>(strings.Select(s => new SelectListItem(s, s)));
		}
	}
}

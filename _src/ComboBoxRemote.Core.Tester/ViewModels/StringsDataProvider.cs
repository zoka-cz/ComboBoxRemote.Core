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
		public Task<IEnumerable<SelectListItem>> GetComboBoxItemsAsync(ClaimsPrincipal _claims_principal)
		{
			var strings = new string [] {
				"String 01",
				"String 02",
				"String 03",
				"String 04"
			};

			return Task.FromResult(strings.Select(s => new SelectListItem(s, s)));
		}
	}
}

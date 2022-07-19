using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComboBoxRemote.Core.Tester.ViewModels
{
	public class IntDataProvider : Zoka.ComboBoxRemote.IComboBoxDataProvider
	{
		/// <inheritdoc />
		public Task<IEnumerable<SelectListItem>> GetComboBoxItemsAsync(ClaimsPrincipal _claims_principal, object _param1)
		{
			var int_array = new int [] {
				1, 15, 69, 85, 10288
			};

			return Task.FromResult(int_array.Select(i => new SelectListItem($"Number {i}", i.ToString())));
		}
	}
}

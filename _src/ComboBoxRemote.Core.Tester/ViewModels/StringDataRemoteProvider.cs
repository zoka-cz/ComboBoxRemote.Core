using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComboBoxRemote.Core.Tester.ViewModels
{
	public class StringDataRemoteProvider : Zoka.ComboBoxRemote.IComboBoxDataProvider
	{
		/// <inheritdoc />
		public Task<IEnumerable<SelectListItem>> GetComboBoxItemsAsync(ClaimsPrincipal _claims_principal, object _param1)
		{
			var strings = new string [] {
				"Remote String 01",
				"Remote String 02",
				"Remote String 03",
				"Remote String 04"
			};
			var items = new List<SelectListItem>();

			for (int i = 0; i < strings.Length; i++)
			{
				items.Add(new SelectListItem(strings[i], (i + (int)_param1).ToString()));
			}

			return Task.FromResult(items.AsEnumerable());
		}
	}
}

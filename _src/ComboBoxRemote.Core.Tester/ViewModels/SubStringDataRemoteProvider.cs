using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComboBoxRemote.Core.Tester.ViewModels
{
	public class SubStringDataRemoteProvider : Zoka.ComboBoxRemote.IComboBoxRemoteDataProvider
	{
		/// <inheritdoc />
		public Task<IEnumerable<SelectListItem>> GetComboBoxItemsAsync(ClaimsPrincipal _claims_principal, string _param1)
		{
			var strings = new string [] {
				$"{_param1} World",
				$"{_param1} Europe",
				$"{_param1} Asia",
				$"{_param1} America"
			};
			var items = new List<SelectListItem>();

			for (int i = 0; i < strings.Length; i++)
			{
				items.Add(new SelectListItem(strings[i], strings[i]));
			}

			return Task.FromResult(items.AsEnumerable());
		}
	}
}

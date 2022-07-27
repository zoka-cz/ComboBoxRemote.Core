using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ComboBoxRemote.Core.Tester.ViewModels
{
	public class StringDataRemoteProvider : Zoka.ComboBoxRemote.IComboBoxRemoteDataProvider
	{
		/// <inheritdoc />
		public Task<IEnumerable<SelectListItem>> GetComboBoxItemsAsync(ClaimsPrincipal _claims_principal, string _param1)
		{
			var param = int.Parse(_param1);

			var strings = new string [] {
				$"Remote String {0 + param:00}",
				$"Remote String {1 + param:00}",
				$"Remote String {2 + param:00}",
				$"Remote String {3 + param:00}"
			};
			var items = new List<SelectListItem>();

			for (int i = 0; i < strings.Length; i++)
			{
				items.Add(new SelectListItem(strings[i], (i + param).ToString()));
			}

			return Task.FromResult(items.AsEnumerable());
		}
	}
}

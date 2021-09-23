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
		public IEnumerable<SelectListItem> GetComboBoxItems(ClaimsPrincipal _claims_principal)
		{
			var strings = new string [] {
				"Remote String 01",
				"Remote String 02",
				"Remote String 03",
				"Remote String 04"
			};

			return new List<SelectListItem>(strings.Select(s => new SelectListItem(s, s.GetHashCode().ToString())));
		}
	}
}

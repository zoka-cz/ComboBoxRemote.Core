﻿using System;
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
		public IEnumerable<SelectListItem> GetComboBoxItems(ClaimsPrincipal _claims_principal)
		{
			var int_array = new int [] {
				1, 15, 69, 85, 10288
			};

			return new List<SelectListItem>(int_array.Select(i => new SelectListItem($"Number {i}", i.ToString())));
		}
	}
}
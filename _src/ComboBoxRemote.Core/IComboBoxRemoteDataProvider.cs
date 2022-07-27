using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zoka.ComboBoxRemote
{
	/// <summary>Data provider, which allows you to pass items into combobox</summary>
	public interface IComboBoxRemoteDataProvider : IInjectable.IInjectable
	{
		/// <summary>Returns the list of items (SelectListItem), which is displayed in the ComboBox</summary>
		Task<IEnumerable<SelectListItem>> GetComboBoxItemsAsync(ClaimsPrincipal _claims_principal, string _param1);
	}
}

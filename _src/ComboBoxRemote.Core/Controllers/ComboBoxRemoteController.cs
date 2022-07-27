using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zoka.ComboBoxRemote.Controllers
{
	/// <summary></summary>
	public class ComboBoxRemoteController : Controller
	{
		private readonly IServiceProvider					m_ServiceProvider;

		/// <summary>Constructor</summary>
		public ComboBoxRemoteController(IServiceProvider _service_provider)
		{
			m_ServiceProvider = _service_provider;
		}

		/// <summary></summary>
		public Task<IEnumerable<SelectListItem>>			GetItems(string provider_type, string param2)
		{
			var type = Type.GetType(provider_type);
			if (type != null)
			{
				var provider = m_ServiceProvider.GetService(type) as IComboBoxRemoteDataProvider;
				if (provider != null)
					return provider.GetComboBoxItemsAsync(this.User, param2);
			}
			return Task.FromResult(Enumerable.Empty<SelectListItem>());
		}
	}
}

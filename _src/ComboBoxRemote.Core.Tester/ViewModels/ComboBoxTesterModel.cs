using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ComboBoxRemote.Core.Tester.ViewModels
{
	public class ComboBoxTesterModel
	{
		[Zoka.ComboBoxRemote.ComboBox(typeof(IntDataProvider))]
		public int											IntSelector { get; set; }

		[Zoka.ComboBoxRemote.ComboBox(typeof(StringsDataProvider), Multiselect = true)]
		[Required]
		public IEnumerable<string>							StringsSelector { get; set; }

		[Zoka.ComboBoxRemote.ComboBoxRemote(typeof(StringDataRemoteProvider), Param1 = 15)]
		public string										StringRemoteSelector { get; set; }
	}
}

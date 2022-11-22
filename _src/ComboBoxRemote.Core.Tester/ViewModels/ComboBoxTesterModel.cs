using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ComboBoxRemote.Core.Tester.ViewModels
{
	public class ComboBoxTesterSubModel
	{
		[HiddenInput(DisplayValue = false)]
		public string										Param1Value { get; set; } = "Hi, Hello ";

		[Zoka.ComboBoxRemote.ComboBoxRemote(typeof(SubStringDataRemoteProvider), Param1 = nameof(Param1Value))]
		public string										StringRemoteSubselector { get; set; }
	}

	public class ComboBoxTesterModel
	{
		[Zoka.ComboBoxRemote.ComboBox(typeof(IntDataProvider))]
		public int IntSelector { get; set; }

		[Zoka.ComboBoxRemote.ComboBox(typeof(StringsDataProvider), Multiselect = true)]
		[Required]
		public IEnumerable<string> StringsSelector { get; set; }

		[HiddenInput(DisplayValue = false)]
		public int											Param1Value { get; set; } = 10010;

		[Zoka.ComboBoxRemote.ComboBoxRemote(typeof(StringDataRemoteProvider), Param1 = nameof(Param1Value))]
		public string										StringRemoteSelector { get; set; }

		public ComboBoxTesterSubModel						SubStringRemoteSelector { get; set; } = new ComboBoxTesterSubModel();
	}
}

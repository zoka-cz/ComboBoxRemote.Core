// based on boiler plate from: https://stackoverflow.com/a/34812932/1038496
 
module ComboBoxRemote {

	export interface IComboBoxRemoteOptions {
		OnCreatedCallback: (el: JQuery) => any;
		OnItemsAddedCallback: (el: JQuery) => any;
		RetrieveRemoteItemsUrl: string;
	}

	export class ComboBoxRemoteOptions implements IComboBoxRemoteOptions {
		OnCreatedCallback: (el: JQuery) => any;

		OnItemsAddedCallback: (el: JQuery) => any;

		RetrieveRemoteItemsUrl: string;

		constructor(
			_on_created_callback: (el: JQuery) => any,
			_onitems_added_callback: (el: JQuery) => any,
			_retrieve_remote_items_url: string) {
			this.OnCreatedCallback = _on_created_callback;
			this.OnItemsAddedCallback = _onitems_added_callback;
			this.RetrieveRemoteItemsUrl = _retrieve_remote_items_url;
		}
	}

	export class ComboBoxRemote {
		element: JQuery; 
		options: IComboBoxRemoteOptions;

		constructor(element: JQuery, options: IComboBoxRemoteOptions) {
			this.element = element;
			this.options = options;
			if (this.element.hasClass("ComboBoxRemote")) {
				let param1 = this.element.data("param1");
				// param1 may be direct value, but also the other input. Try it first.
				let param1selector = this.GetParamValueSelector(param1);
				let param1val = jQuery("input[name='" + param1selector + "']").val();
				if (!param1val)
					param1val = param1;
				$.ajax({
					url: "/ComboBoxRemote/GetItems?provider_type=" + this.element.data("provider-type") + "&param2=" + param1val,
					method: "get",
					success: (data) => {
						//console.log(JSON.stringify(data));
						this.element.empty();
						$.each(data, (idx, item) =>  {
							this.element.append($("<option>", { value: item.value }).text(item.text));
						});
						var initial_val = this.element.data("initial-value");
						if (initial_val)
							this.element.val(initial_val); 
						if (this.options.OnItemsAddedCallback != null)
							this.options.OnItemsAddedCallback(this.element);
					}
				});  
			}

			this.OnCreate();
		}

		private GetParamValueSelector(_param1: string): string {
			let thisname_arr = this.element.attr("name").split(".");
			let thisname;
			if (thisname_arr.length > 1)
				thisname = thisname_arr.slice(0, thisname_arr.length - 1).join(".") + "." + _param1;
			else
				thisname = _param1;

			return thisname;
		}

		OnCreate() {
			if (this.options.OnCreatedCallback != null)
				this.options.OnCreatedCallback(this.element);
		}
	}
}

;
(function (w, $) {
	if (!$) return false; 

	$.fn.extend({
		ComboBox: function (options) {

			// defaults
			let defaults = new ComboBoxRemote.ComboBoxRemoteOptions(null, null, options.RetrieveRemoteItemsUrl);

			let opts = $.extend({}, defaults, options);

			return this.each(function () {
				var o = opts;
				var obj = $(this);
				new ComboBoxRemote.ComboBoxRemote(obj, o);
			});
		}
	});
})(window, jQuery);


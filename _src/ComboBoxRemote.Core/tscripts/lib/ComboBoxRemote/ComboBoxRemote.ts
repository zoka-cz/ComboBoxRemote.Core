// based on boiler plate from: https://stackoverflow.com/a/34812932/1038496

module ComboBoxRemote {

	interface IComboBoxRemoteOptions {
		OnCreatedCallback: (el: JQuery) => any;
	}

	export class ComboBoxRemoteOptions implements IComboBoxRemoteOptions {
		OnCreatedCallback: (el: JQuery) => any;

		constructor(_on_created_callback: (el: JQuery) => any) {
			this.OnCreatedCallback = _on_created_callback;
		}
	}

	export class ComboBoxRemote {
		element: JQuery;
		options: IComboBoxRemoteOptions;

		constructor(element: JQuery, options: IComboBoxRemoteOptions) {
			this.element = element;
			this.options = options;

			this.OnCreate();
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
			let defaults = new ComboBoxRemote.ComboBoxRemoteOptions(null);

			let opts = $.extend({}, defaults, options);

			return this.each(function () {
				var o = opts;
				var obj = $(this);
				new ComboBoxRemote.ComboBoxRemote(obj, o);
			});
		}
	});
})(window, jQuery);

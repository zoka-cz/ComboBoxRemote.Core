// based on boiler plate from: https://stackoverflow.com/a/34812932/1038496
var ComboBoxRemote;
(function (ComboBoxRemote_1) {
    var ComboBoxRemoteOptions = /** @class */ (function () {
        function ComboBoxRemoteOptions(_on_created_callback, _onitems_added_callback, _retrieve_remote_items_url) {
            this.OnCreatedCallback = _on_created_callback;
            this.OnItemsAddedCallback = _onitems_added_callback;
            this.RetrieveRemoteItemsUrl = _retrieve_remote_items_url;
        }
        return ComboBoxRemoteOptions;
    }());
    ComboBoxRemote_1.ComboBoxRemoteOptions = ComboBoxRemoteOptions;
    var ComboBoxRemote = /** @class */ (function () {
        function ComboBoxRemote(element, options) {
            var _this = this;
            this.element = element;
            this.options = options;
            if (this.element.hasClass("ComboBoxRemote")) {
                var param1 = this.element.data("param1");
                var param1val = jQuery("input[name='" + param1 + "']").val();
                if (!param1val)
                    param1val = param1;
                $.ajax({
                    url: "/ComboBoxRemote/GetItems?provider_type=" + this.element.data("provider-type") + "&param2=" + param1val,
                    method: "get",
                    success: function (data) {
                        //console.log(JSON.stringify(data));
                        _this.element.empty();
                        $.each(data, function (idx, item) {
                            _this.element.append($("<option>", { value: item.value }).text(item.text));
                        });
                        if (_this.options.OnItemsAddedCallback != null)
                            _this.options.OnItemsAddedCallback(_this.element);
                    }
                });
            }
            this.OnCreate();
        }
        ComboBoxRemote.prototype.OnCreate = function () {
            if (this.options.OnCreatedCallback != null)
                this.options.OnCreatedCallback(this.element);
        };
        return ComboBoxRemote;
    }());
    ComboBoxRemote_1.ComboBoxRemote = ComboBoxRemote;
})(ComboBoxRemote || (ComboBoxRemote = {}));
;
(function (w, $) {
    if (!$)
        return false;
    $.fn.extend({
        ComboBox: function (options) {
            // defaults
            var defaults = new ComboBoxRemote.ComboBoxRemoteOptions(null, null, options.RetrieveRemoteItemsUrl);
            var opts = $.extend({}, defaults, options);
            return this.each(function () {
                var o = opts;
                var obj = $(this);
                new ComboBoxRemote.ComboBoxRemote(obj, o);
            });
        }
    });
})(window, jQuery);
////# sourceMappingURL=ComboBoxRemote.js.map
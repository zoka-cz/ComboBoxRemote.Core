// based on boiler plate from: https://stackoverflow.com/a/34812932/1038496
var ComboBoxRemote;
(function (ComboBoxRemote_1) {
    var ComboBoxRemoteOptions = /** @class */ (function () {
        function ComboBoxRemoteOptions(_on_created_callback) {
            this.OnCreatedCallback = _on_created_callback;
        }
        return ComboBoxRemoteOptions;
    }());
    ComboBoxRemote_1.ComboBoxRemoteOptions = ComboBoxRemoteOptions;
    var ComboBoxRemote = /** @class */ (function () {
        function ComboBoxRemote(element, options) {
            this.element = element;
            this.options = options;
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
            var defaults = new ComboBoxRemote.ComboBoxRemoteOptions(null);
            var opts = $.extend({}, defaults, options);
            return this.each(function () {
                var o = opts;
                var obj = $(this);
                new ComboBoxRemote.ComboBoxRemote(obj, o);
            });
        }
    });
})(window, jQuery);
//# sourceMappingURL=ComboBoxRemote.js.map
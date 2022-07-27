// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(function () {
	$(".ComboBox").ComboBox(
		{
			OnCreatedCallback: function (el) {
				el.chosen();
			},
			OnItemsAddedCallback: function (el) {
				el.trigger("chosen:updated");
			}
		}
	);

	$(".ComboBoxRemote").ComboBox({
		OnCreatedCallback: function (el) {
			el.chosen();
		},
		OnItemsAddedCallback: function (el) {
			el.trigger("chosen:updated");
		}
	});

});
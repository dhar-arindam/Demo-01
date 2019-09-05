// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const app = (() => {
    const settings = {
        pageer: '#pager',
        addButton: '#btnAddNew',
        displayContainer: '#displayContainer',
        editContainer: '#editContainer',
        saveButton: '#btnSave',
        cancelButton: '#btnCancel',
        fromData: '#frmData'
    };

    const init = () => {
        $(settings.addButton).on('click', () => {
            $(settings.displayContainer).addClass('hidden');
            $(settings.editContainer).removeClass('hidden');
        });

        $(settings.cancelButton).on('click', () => {
            clearForm();
        });
    };

    const clearForm = () => {
        $(settings.displayContainer).removeClass('hidden');
        $(settings.editContainer).addClass('hidden');

        $(settings.fromData).find('input[type!=radio]').val('');
        $(settings.fromData).find('input[id="female"]').attr('checked', true);
    };

    return {
        init: init
    };
})();

$(document).ready(() => app.init());

$(function () {
    $("table.tablesorter").tablesorter({
        theme: "bootstrap",
        widthFixed: true,
        widgets: ["uitheme", "filter", "columns", "zebra"],
        widgetOptions: {
            zebra: ["even", "odd"],
            columns: ["primary", "secondary", "tertiary"],
            filter_reset: ".reset",
            filter_cssFilter: "form-control",
        },
        sortList: [[0, 0]]
    }).tablesorterPager({
        container: $("#pager"),
        size: $(".pagesize option:selected").val()
    });
});
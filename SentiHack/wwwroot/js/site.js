// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

var url = "https://api.data.gov.sg/v1//environment/air-temperature";

function weather() {
    $.ajax({
        url: url,
        type: "get", //send it through get method
        data: {
            date: Date().getTime()
        },
        success: function (response) {
            console.log(response);
        },
        error: function (xhr) {
            console.log(xhr);
        }
    });
}
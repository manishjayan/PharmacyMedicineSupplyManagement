// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function SearchSchedule() {
    var date = $("#dates").val();
        alert(date);
        $.ajax({
            type: "Post",
            url: "/Home/Schedule",
            data: { "startDate": date },
            success: function (res) { alert("gh"); $("#list").html(res); },
            error:
                function () { alert("error");}
        });
    return false;
    }

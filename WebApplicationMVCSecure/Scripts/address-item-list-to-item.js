$(document).ready(function () {
    $("#addressList > div").on("click", function () {
        var val = $(this).data("id");
        $.ajax({
            url: "/User/BoxedAddressItem",
            type: "GET",
            data: { id: val }
        })
        .done(function (partialViewResult) {
            $("#boxedAddressItem").html(partialViewResult);
        });
    });
});
$(document).ready(function () {
    $('#AddressValidation').on('click', function () {
        var data = '{';
        $('#myModal').find('input').each(function () {
            data += '"' + $(this).attr('id') + '"' + ':' + '"' + $(this).val() + '"' + ',';
        });
        data = data.substring(0, data.length - 1);
        data += '}';

        $.ajax({
            url: '/User/AddAddress',
            type: 'GET',
            data: { json: data }
        })
        .done(function (partialViewResult) {
            $('#boxedAddressItem').html(partialViewResult);
        });
    });
});
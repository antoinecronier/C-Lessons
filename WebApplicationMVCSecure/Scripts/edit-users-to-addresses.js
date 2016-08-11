$(document).ready(function () {
    $('#EditUsersToAddresses').on('click', function () {
        var user = $('#Id').val();
        var data = '[';

        $('#addressListUser').find('li').each(function () {
            data += '{"UserId"' + ':' + '"' + user + '"' + ',' + '"AddressId"' + ':' + '"' + $(this).attr('id') + '"' + '},';
        });

        if (data.substring(data.length, data.length - 1) == ',') {
            data = data.substring(0, data.length - 1);
            data += ']';
        } else {
            data = '[{"UserId"' + ':' + '"' + user + '"' + ',' + '"AddressId"' + ':' + '"' + 0 + '"' + '}]';
        }

        $.ajax({
            url: '/User/EditUsersToAddresses',
            type: 'POST',
            data: { json: data }
        });

        window.location.replace("http://localhost:58271/User/");
    });
});
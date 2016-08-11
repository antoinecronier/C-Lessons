$(document).ready(function () {
    $('#EditUsersToAddresses').on('click', function () {
        var user = $('#Id').val();
        var data = [];

        $('#addressListUser').find('li').each(function () {
            data.push({ 'UserId': user, 'AddressId': $(this).attr('id') });
        });

        alert(JSON.stringify(data, null, 2));

        $.ajax({
            url: '/User/EditUsersToAddresses',
            type: 'POST',
            data: { json: JSON.stringify(data, null, 1) }
        });

        window.location.replace("http://localhost:58271/User/");
    });
});
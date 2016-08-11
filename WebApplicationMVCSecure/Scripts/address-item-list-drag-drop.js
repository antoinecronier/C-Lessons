$(function () {
    $("#addressListUser, #addressListAll").sortable({
        connectWith: ".connectedSortable"
    }).disableSelection();
});
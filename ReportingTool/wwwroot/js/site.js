$(document).on("click", ".btn-editform", function () {

    var callid = $(this).data('callid');
    $(".modal-body-edit #formEditRoute").val(callid);
    alert(callid);
});

// Pass the route call information to the edit modal
$(document).on("click", ".btn-editform", function () {
    var callid = $(this).data('callid');
    var route = $(this).data('route');
    var cycledays = $(this).data('cycledays');
    var labourhours = $(this).data('labourhours');
    var plandate = $(this).data('plandate');

    $(".modal-body-edit #formEditCallId").val(callid);
    $(".modal-body-edit #formEditRoute").val(route);
    $(".modal-body-edit #formEditCycle").val(cycledays);
    $(".modal-body-edit #formEditLabourHours").val(labourhours);
    $(".modal-body-edit #formEditPlannedDate").val(plandate);
});


$(function () {
    $(document).on("click", ".editroutecallsubmit", function () {
        //alert("submitting form");
        $('#editroutecall').submit();
    });
});


$(function () {
    $(document).on("click", ".btnYesCompleteRoute", function () {
        $('#completeroute').submit();
    });
});


$(function () {
    $(document).on("click", ".btnCreateReportSubmit", function () {
        $('#createreport').submit();
    });
});

$(function () {
    $(document).on("click", ".btnCreateNewMachineNote", function () {
        $('#createnewmachinenote').submit();
    });
});

$('#modalArchiveNote').on('show.bs.modal', function (event) {
    
    var button = $(event.relatedTarget); // Button that triggered the modal
    var id = button.data('machinenoteid');
    var modal = $(this);
    modal.find('.modal-body input').val(id);
})

$(function () {
    $(document).on("click", ".btnYesArachiveMachineNote", function () {
        $('#archivemachinenoteform').submit();
    });
});

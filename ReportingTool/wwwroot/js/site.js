
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


//---------------------------Edit Route Call ---------------------------//
$(function () {
    $(document).on("click", ".editroutecallsubmit", function () {
        //alert("submitting form");
        $('#editroutecall').submit();
    });
});
//---------------------------Edit Route Call ---------------------------//

//---------------------------Complete Route ---------------------------//
$(function () {
    $(document).on("click", ".btnYesCompleteRoute", function () {
        $('#completeroute').submit();
    });
});
//---------------------------Complete Route ---------------------------//


//---------------------------Create New Report ---------------------------//
$(function () {
    $(document).on("click", ".btnCreateReportSubmit", function () {
        $('#createreport').submit();
    });
});
//---------------------------Create New Report ---------------------------//

//---------------------------Create New Machine Train Note ---------------------------//
$(function () {
    $(document).on("click", ".btnCreateNewMachineNote", function () {
        $('#createnewmachinenote').submit();
    });
});
//---------------------------Create New Machine Train Note ---------------------------//

//---------------------------for archive machine train note ---------------------------//
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
//---------------------------for archive machine train note ---------------------------//


//---------------------------for edit machine train note ---------------------------//
$('#modalEditNote').on('show.bs.modal', function (event) {

    var button = $(event.relatedTarget); // Button that triggered the modal

    var id = button.data('machinenoteid');
    var machine_train_note = button.data('machinenote');

    var modal = $(this);
    modal.find('.modal-body input#machinetrainnoteid').val(id);
    modal.find('.modal-body textarea').val(machine_train_note);
})

$(function () {
    $(document).on("click", ".btnYesEditMachineNote", function () {
        $('#editmachinenoteform').submit();
    });
});
//---------------------------for archive machine train note ---------------------------//
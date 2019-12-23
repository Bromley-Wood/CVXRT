
// Pass the route call information to the edit modal
$(document).on("click", ".btn-editform", function () {
    //alert($(this).data('route'));

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
        //alert("submitting complete form");
        $('#completeroute').submit();
    });
});


$(function () {
    $(document).on("click", ".btnCreateReportSubmit", function () {
        //alert("submitting complete form");
        
        $('#createreport').submit();
    });
});

$(function () {
    $(document).on("click", ".btnCreateNewMachineNote", function () {
        //alert("submitting complete form");

        $('#createnewmachinenote').submit();
    });
});
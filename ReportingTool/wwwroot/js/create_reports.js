$(document).on("change", "#machinesOnRoute tbody .rt-radio-unique input[type='radio']", function () {
    $(this).closest("tr").find("input.form-control.form-control-sm").not(this).prop('disabled', false);
    $(this).closest("tr").find("select").not(this).prop('disabled', false);
});

$(document).on("change", "#machinesOnRoute tbody .rt-radio-default input[type='radio']", function () {
    $(this).closest("tr").find("input.form-control.form-control-sm").not(this).prop('disabled', true);
    $(this).closest("tr").find("select").not(this).prop('disabled', true);
});

$(document).on("change", "#machinesOnRoute tbody .rt-radio-amber input[type='radio']", function () {
    $(this).closest("tr").find("input.form-control.form-control-sm").not(this).prop('disabled', true);
    $(this).closest("tr").find("select").not(this).prop('disabled', true);
});
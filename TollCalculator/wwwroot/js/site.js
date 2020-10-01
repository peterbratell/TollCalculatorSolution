// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.
$(document).ready(function () {
    $('#datepicker').datepicker({
        showOptions: { speed: 'fast' },
        changeMonth: false,
        changeYear: false,
        dateFormat: 'dd/mm/yy',
        gotoCurrent: true
    });
    $('#timepicker').timepicker();
});

$(document.body).on('change', '#SelectedVehicleId', function () {
    //alert($('#SelectedStaffId').val());
    var number = parseInt($('#SelectedVehicleId').val());
    var date = $('#CurrentDate').val();
    var time = $('#CurrentTime').val();
    window.location.href = '/Pages/Demo?VehicleId=' + number + '&aDate=' + date + '&aTime=' + time;
});
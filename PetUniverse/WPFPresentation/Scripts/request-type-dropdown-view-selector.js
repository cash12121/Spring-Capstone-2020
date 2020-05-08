
//    CREATOR: Kaleb Bachert
//    CREATED: 2020 / 3 / 19
//    APPROVER: Lane Sandburg
//    JQuery script to show a View depending on the DropDown selection

$(document).ready(function () {
    $('.timeOffHideableViewDiv').hide();
    $('.availabilityHideableViewDiv').hide();
    $('.scheduleChangeHideableViewDiv').hide();
});

$('.requestTypesDropDown').change(function () {
    $('.timeOffHideableViewDiv').hide();
    $('.availabilityHideableViewDiv').hide();
    $('.scheduleChangeHideableViewDiv').hide();
    if (this.value == 'Time Off') {
        $('.timeOffHideableViewDiv').show();
    }
    else if (this.value == 'Availability Change') {
        $('.availabilityHideableViewDiv').show();
    }
    else if (this.value == 'Schedule Change') {
        $('.scheduleChangeHideableViewDiv').show();
    }
});
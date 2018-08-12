"use strict";
const PHONE_INPUT_MASK = '+375 (99) 999-99-99';


$('document').ready(function () {
    $("#droplist.dropdown-toggle").click(function () {
        $(this).dropdown("toggle");
        return false;
    });
});
$('document').ready(function () {
    $('#datetimepicker').datetimepicker(
        {
            format: 'DD.MM.YYYY',
            locale: 'en',
            minDate: moment(),
            defaultDate : moment(),
            maxDate : moment().add(7, 'days')
        });
    $('#timepicker').datetimepicker(
        {
            format: 'HH:mm',
            locale: 'en',
            minDate: moment(),
            defaultDate: moment(),
        });

    /////////////Phone Mask
    $("#phone").inputmask(PHONE_INPUT_MASK);

    $('.spoiler-explore').click(function () {
        $(this).parent().children('div.spoiler-content').toggle('fast');
        return false;
    });

});



"use strict";
$('document').ready(function () {
    $(".dropdown-toggle").click(function () {
        $(this).dropdown("toggle");
        return false;
    });
});
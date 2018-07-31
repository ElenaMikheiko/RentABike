'use strict';
let menuItems = $('.menuitems'),
    buttonClose = $('.closebtn').eq(0),
    menuList = $('.menulist').eq(0);

function navToggle() {
    if (menuList.hasClass('menu__list_max-height')) {
        menuList
            .removeClass('menu__list_max-height')
            .addClass('menu__list_min-height');

        menuItems.each(function () {
            $(this)
                .removeClass('menu__items_show')
                .addClass('menu__items_hide');
        });
    } else {
        menuList
            .removeClass('menu__list_min-height')
            .addClass('menu__list_max-height');

        setTimeout(function () {
            menuItems.each(function () {
                $(this)
                    .removeClass('menu__items_hide')
                    .addClass('menu__items_show');
            });
        }, 100);
    }
};

$(document).ready(function () {
    menuList.addClass('menu__list_min-height');

   menuItems.each(function () {
       $(this).addClass('menu__items_hide');
   });

   buttonClose.on('click', function () {
       let menuIcon = buttonClose.children();

        menuIcon.each(function () {
            $(this).toggleClass('active');
        });
   });

   buttonClose.on('click', navToggle);
});

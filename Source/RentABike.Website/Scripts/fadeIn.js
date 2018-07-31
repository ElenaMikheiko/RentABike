'use strict';

$(document).ready(function () {
    const DELAY_TIME = 300,
        MAX_FILE_SIZE = 3000000;

    ///////////Hint
    let hintText = 'To create your resume, please click Resume button',
        hintBlock = '<div class="hint clearfix"><span class="hint_text">' + hintText + '</span><div class="hint_arrow"></div></div>';

    if ($('.current__page').val() === "False") {
        $('#overlay').fadeIn(DELAY_TIME);
        $('.container__header_user').addClass('hint__visual')
            .append(hintBlock);
        $('.hint_arrow').append('<img id="arrow" src="/images/arrow.png" alt="arrow" />');
    }

    $(document).click(function () {
        $('.container__header_user').removeClass('hint__visual');
        $('.hint').remove();
        $('#overlay').fadeOut(DELAY_TIME, function () {
        });
    });

    ///////Show or hide "upload image" block
    $('.content__image_block').on('click', function () {
        $('.content__pop-up').show();
        $('.content__pop-up_upload').hide();
    });

    $('.content__pop-up_close').on('click', function () {
        $('.content__pop-up').hide();
        $("#canvas").remove();
    });

    $('#fileInput').on('change', function () {
        $('.content__image_wrapper').empty()
            .append('<canvas id="canvas">');

        //////////PhotoEdit
        let canvas = $("#canvas"),
            context = canvas.get(0).getContext("2d"),
            $result = $('.content__image_block'),
            popUpText = 'Download failed. Check the size and format of the file. You can upload the image in JPG, JPEG, PNG, BMP formats.File size should not exceed 3 Mbyte.';

        if (this.files && this.files[0]) {

            if (this.files[0].size > MAX_FILE_SIZE) {
                $('.content__pop-up_error').remove();
                $('.content__upload_label').append('<div class="content__pop-up_error">' + popUpText + '</div>');
                $('.content__pop-up_image').hide();
            } else {
                $('.content__pop-up_error').remove();
                $('.content__pop-up_image').show();

                let $previews = $('.content__pop-up_preview'),
                    reader = new FileReader();

                reader.onload = function (evt) {
                    let img = new Image();

                    img.onload = function () {
                        context.canvas.height = img.height;
                        context.canvas.width = img.width;
                        context.drawImage(img, 0, 0);

                        let cropper = canvas.cropper({
                            aspectRatio: 1 / 1,
                            ready: function (e) {
                                let $clone = $(this).clone().removeClass('cropper-hidden');

                                $clone.css({
                                    display: 'block',
                                    width: '100%',
                                    minWidth: 0,
                                    minHeight: 0,
                                    maxWidth: 'none',
                                    maxHeight: 'none'
                                });
                            }
                        });

                        $('.content__pop-up_button').click(function () {
                            try {
                                let formData = new FormData(),
                                    croppedImageDataURL = canvas.cropper('getCroppedCanvas').toDataURL("image/png");

                                formData.append("fileInput", croppedImageDataURL);
                                $result.append($('.content__main_image').attr('src', croppedImageDataURL));
                                $result.append($('#Base65Image').attr('value', croppedImageDataURL));
                                $('.content__pop-up').hide();
                                //$.ajax({
                                //    url: "/Home/SavePhoto",
                                //    type: "POST",
                                //    data: formData,
                                //    contentType: false,
                                //    processData: false
                                //});
                            }
                            catch (error) {
                                if (error.name !== "TypeError") {
                                    console.info(error);
                                }
                            }
                        });
                    };
                    img.src = evt.target.result;
                };
                reader.readAsDataURL(this.files[0]);
            }
        }
    });
});
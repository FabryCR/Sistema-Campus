
$(document).ready(function () {
    $('.submitBTN').attr('disabled', true);
});

$(':input[type=text],[type=password]').keyup(function () {

    var atLeastOneEmpty = false;

    $('input[type=text],[type=password]').each(function () {
        if ($(this).val().trim() == '') {
            atLeastOneEmpty = true;
        }
    });

    if (atLeastOneEmpty) {
        $('.submitBTN').attr('disabled', true);
    } else {
        $('.submitBTN').attr('disabled', false);
    }
});


$(".numeric").keypress(function (e) {
    var charCode = (e.which) ? e.which : e.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
});
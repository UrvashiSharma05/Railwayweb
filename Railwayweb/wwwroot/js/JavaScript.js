$(document).ready(function () {
    GetCountry();


    $('#To').attr('disabled', true);
    $('#Trainno').attr('disabled', true);

    //$('#price').attr('disabled', true);
    $('#From').change(function () {
        $('#To').attr('disabled', false);
        var id = $(this).val();
        $('#To').empty();
        $('#To').append('<option>---Select source station--</option>');
        $.ajax({
            url: '/Railway/To?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#To').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
        });
    });
    $('#To').change(function () {
        $('#Trainno').attr('disabled', false);
        var id = $(this).val();
        $('#Trainno').empty();
        $('Trainno').append('<option>-------------Select Class------------</option>');
        $.ajax({
            url: '/Railway/TrainName?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Trainno').append('<option value=' + data.id + '>' + data.name + '</option>');
                });
            }
        });
    });


    $('#Trainno').change(function () {
        $('#Money').attr('disabled', false);
        var id = $(this).val();
        $('#Money').empty();
        $('#Money').append('<option>----Select price----</option>');
        $.ajax({
            url: '/Railway/TPrice?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#Money').append('<option value=' + data.id + '>' + data.price + '</option>');
                });
            }
        });
    });

});

function GetCountry() {
    $.ajax({
        url: '/Railway/From',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#From').append('<option value=' + data.id + '>' + data.name + '</option');
            });
        }
    });
}
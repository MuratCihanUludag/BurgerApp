function reloadDrinksList() {
    $('#drinksListContainer').load('/Admin/Drink/DrinkList');
}

$(document).ready(function () {
    $('#createButton').click(function () {
        $.get('/Admin/Drink/Create', function (data) {
            $('#modalBody').html(data);
            $('#modal').modal('show');
        });
    });

    $(document).on('click', '.editLink', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('#modalBody').html(data);
            $('#modal').modal('show');
        });
    });

    $(document).on('click', '.detailsLink', function (e) {
        e.preventDefault();
        var url = $(this).attr('href');
        $.get(url, function (data) {
            $('#modalBody').html(data);
            $('#modal').modal('show');
        });
    });

    $(document).on('submit', '#createForm, #editForm', function (e) {
        e.preventDefault();
        var formData = new FormData(this);
        var url = $(this).attr('action');
        $.ajax({
            url: url,
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                $('#modal').modal('hide');
                reloadDrinksList();
            },
            error: function () {
                alert("İçecek işlemi sırasında bir hata oluştu.");
            }
        });
    });
    
    reloadDrinksList()
});
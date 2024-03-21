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

    $(document).on('click', '.deleteLink', function (e) {
        e.preventDefault();
        var drinkId = $(this).data('id');
        var deleteUrl = `/Admin/Drink/Delete/${drinkId}`;
        $.get(deleteUrl, function (data) {
            $('#modalBody').html(data);
            $('#deleteModal').modal('show');
        }).fail(function () {
            alert("İçecek bilgisi yüklenirken bir hata oluştu.");
        });
    });

    $(document).on('submit', '#deleteForm', function (e) {
        e.preventDefault();
        var form = $(this);
        $.ajax({
            type: form.attr('method'),
            url: form.attr('action'),
            data: form.serialize(),
            success: function (response) {
                $('#deleteModal').modal('hide');
                reloadDrinksList();
            },
            error: function (xhr, status, error) {
                alert("İçecek silinirken bir hata oluştu.");
            }
        });
    });
    reloadDrinksList();
});
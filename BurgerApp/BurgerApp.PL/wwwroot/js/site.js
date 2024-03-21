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
        if (drinkId) {
            if (confirm('Bu içeceği silmek istediğinize emin misiniz?')) {
                $.ajax({
                    url: '/Admin/Drink/DeleteConfirmed/' + drinkId,
                    type: 'POST',
                    data: {
                        id: drinkId,
                        __RequestVerificationToken: $('input[name="__RequestVerificationToken"]').val()
                    },
                    success: function () {
                        reloadDrinksList();
                    },
                    error: function () {
                        alert("İçeceği silerken bir hata oluştu.");
                    }
                });
            }
        } else
        {
            console.error("Silme işlemi için içecek ID'si bulunamadı.");
            alert("Bir hata oluştu, lütfen sayfayı yenileyin ve tekrar deneyin.");
        }
    });

    reloadDrinksList();
});
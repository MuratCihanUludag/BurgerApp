$(document).ready(function () {
    loadOrderDetails();

    function loadOrderDetails() {
        $.ajax({
            url: '/OrderDetail/GetTableList',
            type: 'GET',
            success: function (data) {
                $('#orderDetailsList').html(data);
            }
        });
    }

    $('body').on('click', '.delete-orderDetail', function () {
        var id = $(this).data('id');
        $('#deleteOrderDetailModal').find('.btn-confirm-delete').data('id', id);
        $('#deleteOrderDetailModal').modal('show');
    });

    $('body').on('click', '.edit-orderDetail', function () {
        var id = $(this).data('id');
        $.ajax({
            url: `/OrderDetail/Edit/${id}`,
            type: 'GET',
            success: function (data) {
                $('#editOrderDetailContent').html(data);
                $('#editOrderDetailModal').modal('show');
            }
        });
    });

    $('.btn-confirm-delete').click(function () {
        var id = $(this).data('id');
        $.ajax({
            url: `/OrderDetail/DeleteConfirmed/${id}`,
            type: 'POST',
            success: function (result) {
                $('#deleteOrderDetailModal').modal('hide');
                loadOrderDetails();
            }
        });
    });

    $('body').on('submit', '#editOrderDetailForm', function (e) {
        e.preventDefault();
        $.ajax({
            url: $(this).attr('action'),
            type: 'POST',
            data: $(this).serialize(),
            success: function (result) {
                $('#editOrderDetailModal').modal('hide');
                loadOrderDetails();
            }
        });
    });
});
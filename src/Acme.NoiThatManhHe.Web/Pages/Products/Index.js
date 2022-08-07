$(function () {
    var l = abp.localization.getResource('NoiThatManhHe');
    var createModal = new abp.ModalManager(abp.appPath + 'Products/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Products/EditModal');
    var checkModal = new abp.ModalManager(abp.appPath + 'Images/Index');

    var dataTable = $('#ProductsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.noiThatManhHe.products.product.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: "Edit",
                                    //visible: abp.auth.isGranted('BookStore.Books.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: "Delete",
                                    //visible: abp.auth.isGranted('BookStore.Books.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'ProductDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        acme.noiThatManhHe.products.product
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    "SuccessfullyDeleted"
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                },
                                {
                                    text: "Consult",
                                    action: function (data) {
                                        window.location.href = "/Images?id=" + data.record.id
                                    }

                                }
                            ]
                    }
                },
                {
                    title: "Name",
                    data: "name"
                },
                {
                    title: "Price",
                    data: "price"
                },
                {
                    title: "WarrantyPeriod",
                    data: "warrantyPeriod",
                },
                {
                    title: "TransportFee",
                    data: "transportFee",
                },
                {
                    title: "Description",
                    data: "description"
                },
                {
                    title: "ImageAvatarUrl",
                    data: "imageAvatarUrl",
                    render: function (data) {
                        return "<img src="+data+ " alt='Flowers in Chania' style='width:200px;height:200px'/>";
                    }
                }
            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewProductButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
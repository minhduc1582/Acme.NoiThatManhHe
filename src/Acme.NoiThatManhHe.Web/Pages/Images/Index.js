$(function () {
    var l = abp.localization.getResource('NoiThatManhHe');
    var createModal = new abp.ModalManager(abp.appPath + 'Images/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Images/EditModal');
    var generic_id = $('#custId').val();
    var input = {
        filter: generic_id
    };
    var dataTable = $('#ImagesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.noiThatManhHe.images.image.getListByGenericId, input),
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
                                        acme.noiThatManhHe.images.image
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(
                                                    "SuccessfullyDeleted"
                                                );
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: "Mô Tả",
                    data: "description"
                },
                {
                    title: "Hình Ảnh",
                    data: "imageUrl",
                    render: function (data) {
                        return "<img src='" + data + "' alt='Flowers in Chania' style='width:200px;height:200px'/>";
                    }
                },
                {
                    title: "Tên Hình",
                    data: "name"
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

    $('#NewImageButton').click(function (e) {
        e.preventDefault();
        createModal.open({ id: generic_id });
    });
    console.log(generic_id);
});
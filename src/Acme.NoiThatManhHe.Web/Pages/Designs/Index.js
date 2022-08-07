$(function () {
    var l = abp.localization.getResource('NoiThatManhHe');
    var createModal = new abp.ModalManager(abp.appPath + 'Designs/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Designs/EditModal');
    var designType_id = $('#custId').val();
    var input = {
        filter: designType_id
    };

    var dataTable = $('#DesignsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.noiThatManhHe.designs.design.getListByDesignTypeId, input),
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
                                        editModal.open({ id: data.record.id, designTypeId: designType_id });
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
                                        acme.noiThatManhHe.designs.design
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
                    title: "Tiêu Đề",
                    data: "title"
                },
                {
                    title: "Mô Tả",
                    data: "description"
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

    $('#NewDesignButton').click(function (e) {
        e.preventDefault();
        createModal.open({ id: designType_id });
    });
});
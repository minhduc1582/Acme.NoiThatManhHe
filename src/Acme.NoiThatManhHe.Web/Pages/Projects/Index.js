$(function () {
    var l = abp.localization.getResource('NoiThatManhHe');
    var createModal = new abp.ModalManager(abp.appPath + 'Projects/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Projects/EditModal');

    var dataTable = $('#ProjectsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.noiThatManhHe.projects.project.getList),
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
                                        acme.noiThatManhHe.projects.project
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
                    title: "Công Trình",
                    data: "constructionName"
                },
                {
                    title: "Tên Khách Hàng",
                    data: "customerName"
                },
                {
                    title: "Dịa Chỉ",
                    data: "address"
                },
                {
                    title: "Diện tích",
                    data: "area",
                },
                {
                    title: "Phong Cách",
                    data: "style"
                },
                {
                    title: "Image Avatar Url",
                    data: "avatarUrl",
                    render: function (data) {
                        return "<img src=" + data + " alt='image' style='width:200px;height:200px'/>";
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
    $('#NewProjectButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
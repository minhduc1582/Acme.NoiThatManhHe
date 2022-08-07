$(function () {
    var l = abp.localization.getResource('NoiThatManhHe');

    var dataTable = $('#DesignTypesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(acme.noiThatManhHe.designs.design.getDesignTypeLookup),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: "Consult",
                                    action: function (data) {
                                        window.location.href = "/Designs?id=" + data.record.id
                                    }

                                }
                            ]
                    }
                },
                {
                    title: "Design Type Name",
                    data: "name"
                }
            ]
        })
    );

});
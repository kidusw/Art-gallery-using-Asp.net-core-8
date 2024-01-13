
var dataTable;
$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            url: '/admin/art/getall'
        }, "columns": [
            { data: 'title', "width": "10%" },
            { data: 'artist', "width": "15%" },
            { data: 'description', "width": "20%" },
            { data: 'category.name', "width": "15%" },
           
            {
                data: "id",
                "render": function (data) {
                    return `<div class="w-80 btn-group" role="group">
                    <a href="/admin/art/upsert?id=${data}" class="btn btn-primary mx-1"> <i class="bi bi-pencil-square"></i> Edit</a>"
                      <a onClick=Delete("/admin/art/delete/${data}") class="btn btn-danger mx-1"> <i class="bi bi-pencil-square"></i> Delete</a>"
                    </div>`
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
            })
        }
    });
}


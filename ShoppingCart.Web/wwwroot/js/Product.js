
var dataTable;

$(document).ready(function () {
    dataTable = $('#productsTable').DataTable({
        "ajax": { "url": "/Admin/Product/AllProducts" },
        "columns": [
            { "data": "name" },
            { "data": "description" },
            { "data": "price" },
            { "data": "category.name" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <a href="/Admin/Product/CreateUpdate?id=${data}"><i class="bi bi-pencil-square"></i></a>
                        <a onclick=removeProduct("/Admin/Product/Delete/${data}")><i class="bi bi-pencil-trash"></i></a>
                    `
                }
            },
        ]
    })
})

function removeProduct(url) {
    Swal.fire({
        title: "Sure ?",
        text: "Deleted items can't be reverted",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: '#d33',
        confirmButtonText: "Delete!"
    }).then((result) => {
        if (result.isConfirmed) {

        }
    })
}
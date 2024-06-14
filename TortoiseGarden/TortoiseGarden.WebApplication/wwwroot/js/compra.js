$(document).ready(function () {
    $.ajax({
        url: '/Compra/ObtenerCompras',
        method: 'GET',
        success: function (data) {
            var tableBody = $('#comprasTable tbody');
            tableBody.empty();

            data.forEach(function (compra) {
                var row = '<tr>';
                compra.forEach(function (cell) {
                    row += '<td>' + cell + '</td>';
                });
                row += '</tr>';
                tableBody.append(row);
            });
        },
        error: function (err) {
            console.error('Error', err);
        }
    });
});
let content = document.querySelector(".content");
let containerFormCompra = document.getElementById("containerFormCompra");
let containerFormAgregarCompra = document.getElementById("containerFormAgregarCompra");
content.removeChild(containerFormCompra);
content.removeChild(containerFormAgregarCompra);

let btnlistarCompra = document.getElementById("listarCompra");
let agregarCompra = document.getElementById("agregarCompra");

btnlistarCompra.addEventListener("click", () => {
    content.appendChild(containerFormCompra);
    content.removeChild(containerFormAgregarCompra);
});
agregarCompra.addEventListener("click", () => {
    content.appendChild(containerFormAgregarCompra);
    content.removeChild(containerFormCompra);
});
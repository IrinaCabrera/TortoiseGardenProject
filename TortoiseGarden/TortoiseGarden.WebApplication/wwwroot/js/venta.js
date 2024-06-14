$(document).ready(function () {
    $.ajax({
        url: '/Venta/ObtenerVentas',
        method: 'GET',
        success: function (data) {
            var tableBody = $('#ventasTable tbody');
            tableBody.empty();

            data.forEach(function (venta) {
                var row = '<tr>';
                venta.forEach(function (cell) {
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
let containerFormVenta = document.getElementById("containerFormVenta");
let containerFormAgregarVenta = document.getElementById("containerFormAgregarVenta");
content.removeChild(containerFormVenta);
content.removeChild(containerFormAgregarVenta);

let btnlistarVenta = document.getElementById("listarVenta");
let agregarVenta = document.getElementById("agregarVenta");

btnlistarVenta.addEventListener("click", () => {
    content.appendChild(containerFormVenta);
    content.removeChild(containerFormAgregarVenta);
});
agregarVenta.addEventListener("click", () => {
    content.appendChild(containerFormAgregarVenta);
    content.removeChild(containerFormVenta);
});
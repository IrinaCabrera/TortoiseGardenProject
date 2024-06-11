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

let buttonListarCompra = document.getElementById("listarCompra");
let containerCompra = document.getElementById("containerCompra");
console.log(buttonListarCompra, containerCompra);

buttonListarCompra.addEventListener("click",() => {
    if (containerCompra.style.visibility === "visible") {

        containerCompra.style.visibility = "hidden";

    } else {
        containerCompra.style.visibility = "visible";
    }
    
});
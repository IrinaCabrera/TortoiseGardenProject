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
    if (containerCompra.style.display === "block") {

        containerCompra.style.display = "none";

    } else {
        containerCompra.style.display = "block";
    }
    
});
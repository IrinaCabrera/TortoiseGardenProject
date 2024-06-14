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


let buttonListarVenta = document.getElementById("listarVenta");
let containerVenta = document.getElementById("containerVenta");
console.log(buttonListarVenta, containerVenta);

buttonListarVenta.addEventListener("click", () => {
    if (containerVenta.style.display === "block") {

        containerVenta.style.display = "none";

    } else {
        containerVenta.style.display = "block";
    }

});
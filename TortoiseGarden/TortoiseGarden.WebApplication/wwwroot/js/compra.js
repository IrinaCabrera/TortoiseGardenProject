
let content = document.querySelector(".content");
let containerFormCompra = document.getElementById("containerFormCompra");
let containerFormAgregarCompra = document.getElementById("containerFormAgregarCompra");
content.removeChild(containerFormCompra);
content.removeChild(containerFormAgregarCompra);

let btnlistarCompra = document.getElementById("listarCompra");
let agregarCompra = document.getElementById("agregarCompra");
function RellenarCampos() {
    /*Campo de UsuarioId*/

    /*Campo de producto*/
    $(document).ready(function () {
        $.ajax({
            url: '/Compra/ObtenerNombreProducto',
            method: 'GET',
            success: function (data) {
                console.log(data);
                var select = $('#NombreProducto');
                select.empty();
                data.forEach(function (producto) {
                    var option = $('<option></option>').text(producto);
                    select.append(option);
                });
            },
            error: function (err) {
                console.error('Error', err);
            }
        });
    });
}
btnlistarCompra.addEventListener("click", () => {

    if (content.contains(containerFormAgregarCompra)) {
        content.removeChild(containerFormAgregarCompra);
    }
    content.appendChild(containerFormCompra);
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

     
});
agregarCompra.addEventListener("click", () => {

    if (content.contains(containerFormCompra)) {
        content.removeChild(containerFormCompra);
    }
    content.appendChild(containerFormAgregarCompra);
    RellenarCampos();
});
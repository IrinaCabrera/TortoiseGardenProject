
let content = document.querySelector(".content");
let containerFormCompra = document.getElementById("containerFormCompra");
let containerFormAgregarCompra = document.getElementById("containerFormAgregarCompra");
content.removeChild(containerFormCompra);
content.removeChild(containerFormAgregarCompra);

let btnlistarCompra = document.getElementById("listarCompra");
let agregarCompra = document.getElementById("agregarCompra");

let RellenarCampos = () => {
    /*Campo de UsuarioId*/
        $.ajax({
            url: '/Compra/ObtenerIdUsuarios',
            method: 'GET',
            success: function (data) {
                var select = $('#IdUsuario');
                select.empty();
                data.forEach(function (idUsuario) {
                    var option = $('<option></option>').text(idUsuario);
                    select.append(option);
                });

            },
            error: function (err) {
                console.error('Error', err);
            }
        });
    /*campo Fecha*/
    AjustarFecha();
    /*Campo de producto*/
        $.ajax({
            url: '/Compra/ObtenerNombreProducto',
            method: 'GET',
            success: function (data) {
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
}
let AjustarFecha = () => {
    let inputFecha = document.getElementById("fecha");
    let ahora = new Date();
    let sieteDiasAtras = new Date();
    sieteDiasAtras.setDate(sieteDiasAtras.getDate() - 7);
    let ahoraISO = ahora.toISOString().split('.')[0];

    inputFecha.setAttribute('min', sieteDiasAtras.toISOString().split('.')[0]);
    inputFecha.setAttribute('max', ahoraISO);
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

let content = document.querySelector(".content");
let containerFormCompra = document.getElementById("containerFormCompra");
let containerFormAgregarCompra = document.getElementById("containerFormAgregarCompra");
content.removeChild(containerFormCompra);
content.removeChild(containerFormAgregarCompra);

let btnlistarCompra = document.getElementById("listarCompra");
let agregarCompra = document.getElementById("agregarCompra");

let RellenarCampos = (inputFecha) => {

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
    AjustarFecha(inputFecha);

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
let AjustarFecha = (inputFecha) => {
    let ahora = new Date();
    let sieteDiasAtras = new Date();
    sieteDiasAtras.setDate(sieteDiasAtras.getDate() - 7);

    ahora.setHours(0, 0, 0, 0);
    sieteDiasAtras.setHours(0, 0, 0, 0);

    let hoyISO = ahora.toISOString().split('T')[0];
    let sieteDiasAtrasISO = sieteDiasAtras.toISOString().split('T')[0];

    inputFecha.setAttribute("min", sieteDiasAtrasISO);
    inputFecha.setAttribute("max", hoyISO);

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
    let inputFecha = document.getElementById("fecha");
    RellenarCampos(inputFecha);

    let btnAceptarCompra = document.getElementById("btn-AceptarRegistro");

    

    btnAceptarCompra.addEventListener("click", () => {

        let NombreProducto = document.getElementById("NombreProducto").value;
        let cantidad = document.getElementById("cantidad").value;
        let idUsuario = document.getElementById("IdUsuario").value;
        let horaActual = new Date().toTimeString().split(' ')[0];
        let fechaCompleta = inputFecha.value + 'T' + horaActual;

        let datos = {
            idUsuario: idUsuario,
            fecha: fechaCompleta,
            nombreProducto: NombreProducto,
            cantidadProducto: cantidad,  
            
        };
        $.ajax({
            url: '/Compra/AgregarCompra',
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(datos),
            success: function (data) {
                console.log('Success:', data);
                

            },
            error: function (err) {
                console.log('Error:', err);
            }
        });
    });
    
});


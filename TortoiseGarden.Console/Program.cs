using TortoiseGarden.Core.Business;
using TortoiseGarden.Core.Entities;

// See https://aka.ms/new-console-template for more information

var business = new ProductBusiness();

/*
var productos = business.obtenerProductos();

foreach (var item in productos)
{
    Console.WriteLine(
        $"Producto: {item[0]} " +
        $" Categoria: {item[1]} " +
        $" Habilitado: {item[2]}");

}

var productosM = business.obtenerProductosModificables();

foreach (var item in productosM)
{
    Console.WriteLine(
        $"ProductoID: {item[0]} " +
        $" Producto: {item[1]} " +
        $" Habilitado: {item[2]} " +
        $" CategoriaId: {item[3]} " +
        $" Categoria: {item[4]}");

}
*/
/*
var productoEspecificoID = business.obtenerProductoEspecifico(1);
var productoEspecificoNombre = business.obtenerProductoEspecifico("Cesped");
*/
//estos devuelven null
//var productoEspecificoIDerror = business.obtenerProductoEspecifico(100);
//var productoEspecificoNombreerror = business.obtenerProductoEspecifico("C");

/*
var categorias = business.obtenerCategoria();
foreach (var categoria in categorias)
{
    Console.WriteLine(categoria.ToString());
}

//usuario ingresa producto
Producto p = new Producto("Terrario 1m x 2m", 3, true);
//1) existe?
var productoEspecificoNombre = business.obtenerProductoEspecifico(p.Nombre);
//no? creo:

if (productoEspecificoNombre == null)
{
    
    business.CrearProducto(p);
    productoEspecificoNombre = business.obtenerProductoEspecifico(p.Nombre);
    
    Console.WriteLine("Se ha creado con éxito: ");
}
else//si? entonces mensaje
{
    Console.WriteLine("Este producto ya existe: ");
}
//muestro la info completa:
Console.WriteLine(productoEspecificoNombre);
*/

/*
 Eliminar producto

Producto pA = new Producto("irina", 1 , true);


var busqueda = business.obtenerProductoEspecifico(pA.Nombre);
var p = new Producto(busqueda.ProductoId,busqueda.Nombre, busqueda.CategoriaId, busqueda.Habilitado);

if (busqueda != null)
{
    business.EliminarProducto(p);
}

if(business.obtenerProductoEspecifico(p.ProductoId) == null) {
    Console.WriteLine("eliminado.");

}
 */

/*modificacion de producto*/
/*

Producto pNuevo = new Producto("Casa Cueva A", 3, true);
int id = 38;

business.ModificarProducto(id, pNuevo);

*/


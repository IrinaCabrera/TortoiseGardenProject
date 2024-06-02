using TortoiseGarden.Core.Business;
using TortoiseGarden.Core.Entities;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var business = new ProductBusiness();


var productos = business.obtenerProductos();

foreach (var item in productos)
{
    Console.WriteLine(item.ToString());
}
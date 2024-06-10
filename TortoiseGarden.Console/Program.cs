using TortoiseGarden.Core.Business;
using TortoiseGarden.Core.Entities;

// See https://aka.ms/new-console-template for more information



ConsoleKeyInfo seleccion;
do
{
    
    Console.WriteLine("Seleccione del 1 al 5 en el menú.");
    Console.WriteLine(
        "PRODUCTOS\n" +
        "---------------------------------------------------------------------\n" +
        "1_ LISTAR    2_ BUSCAR    3_ AGREGAR    4_ MODIFICAR    5_ ELIMINAR\n" +
        "---------------------------------------------------------------------");

    seleccion = Console.ReadKey();
    switch (seleccion.Key)
    {
        /*------------ LISTAR ---------------*/

        case ConsoleKey.D1:
            case ConsoleKey.NumPad1:
                ListarCategorias();
                ListarProductos();
            break;
        
         /*----------- BUSCAR --------------*/

        case ConsoleKey.D2:
        case ConsoleKey.NumPad2:
            BuscarProductos();
            break;

        /*----------- AGREGAR --------------*/

        case ConsoleKey.D3:
        case ConsoleKey.NumPad3:
            CrearProducto();
            break;

        /*----------- MODIFICAR --------------*/

        case ConsoleKey.D4:
        case ConsoleKey.NumPad4:
            ModificarProducto();
            break;

        /*----------- ELIMINAR --------------*/

        case ConsoleKey.D5:
        case ConsoleKey.NumPad5:
            EliminarProducto();
            break;

        default:
            Console.WriteLine("\nSeleccione nuevamente. Sólo 1, 2, 3, 4 y 5.\n");
            break;
    }
} while (true);


static void ListarCategorias()
{
    ProductBusiness business = new ProductBusiness();
    var categorias = business.obtenerCategoria();
    Console.WriteLine("\n");
    foreach (var item in categorias)
    {
        Console.WriteLine(item.ToString());
    }
    Console.WriteLine("\n");
}
static void ListarProductos()
{
    ProductBusiness business = new ProductBusiness();
    var productos = business.obtenerProductos();

    foreach (var item in productos)
    {
        Console.WriteLine(
            $"Producto: {item[0]} " +
            $" Categoria: {item[1]} " +
            $" Habilitado: {item[2]}");

    }
    Console.WriteLine("\n");
}
static void BuscarProductos()
{
    ProductBusiness business = new ProductBusiness();
    Console.WriteLine("Puede buscar por id o por nombre.\nIngrese el dato.");
    Console.WriteLine("No recuerda? F1 p/ listar productos. cualquier tecla p/ Continuar");
    ConsoleKeyInfo recuerdo = Console.ReadKey();
    if (recuerdo.Key == ConsoleKey.F1)
    {
        ObtenerProductosConInformacionCompleta();
    }
    else
    {
        Console.WriteLine("\ndato:");
        var ingreso = Console.ReadLine();
        var producto = business.obtenerProductoEspecifico(ingreso);
        Console.WriteLine(producto.ToString());
    }
   
}
static void CrearProducto()
{
    ListarCategorias();

    ProductBusiness business = new ProductBusiness();
    
    Console.WriteLine("Nombre: ");
    string Nombre = Console.ReadLine();
    var productoBuscado = business.obtenerProductoEspecifico(Nombre);

    if (productoBuscado == null)
    {
        Console.WriteLine("ID de categoria: ");
        int CategoriaId = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Está habilitado? -->true / -->false");
        bool Habilitado = Convert.ToBoolean(Console.ReadLine());

        Producto p = new Producto(Nombre, CategoriaId, Habilitado);
        business.CrearProducto(p);
        if (business.obtenerProductoEspecifico(p.Nombre) != null)
        {
            Console.WriteLine("Se ha creado con éxito");
            Console.Write(business.obtenerProductoEspecifico(p.Nombre).ToString());
        }
        else
        {
            Console.WriteLine("Ha pasado lo inpensable.");
        }
    }
    else
    {
        Console.Write("El producto ya existe");
        Console.Write(productoBuscado.ToString());
    }
}
static void ModificarProducto()
{
    ListarCategorias();
    ProductBusiness business = new ProductBusiness();
    Console.WriteLine("\nIngrese el Id del producto que desea modificar.");
    Console.WriteLine("No recuerda? F1 p/ listar productos. cualquier tecla p/ Continuar");
    ConsoleKeyInfo recuerdo = Console.ReadKey();
    if (recuerdo.Key == ConsoleKey.F1)
    {
        ObtenerProductosConInformacionCompleta();
    }
    else
    {
        Console.WriteLine("\nId:");
        string ingreso = Console.ReadLine();
        var producto = business.obtenerProductoEspecifico(ingreso);
        if (producto != null)
        {
            Console.WriteLine("Nombre: ");
            string Nombre = Console.ReadLine();
            producto = business.obtenerProductoEspecifico(Nombre);
            if (producto==null)
            {
                Console.WriteLine("ID de categoria: ");
                int CategoriaId = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Está habilitado? -->true / -->false");
                bool Habilitado = Convert.ToBoolean(Console.ReadLine());

                Producto p = new Producto(Nombre, CategoriaId, Habilitado);
                business.ModificarProducto(Convert.ToInt32(ingreso), p);
                
                Console.WriteLine(business.obtenerProductoEspecifico(Nombre).ToString());
            }
            else
            {
                Console.WriteLine("Ese producto ya existe, no está disponible ese nombre. Vuelva a intentar.");
                Console.WriteLine(producto.ToString());
            }
        }
        else
        {
            Console.WriteLine("El producto que desea modificar no existe.");
        }

        
    }

}
static void EliminarProducto()
{
    ProductBusiness business = new ProductBusiness();
    Console.WriteLine("\nIngrese el  id del producto que desea eliminar.\nIngrese el dato.");
    Console.WriteLine("No recuerda? F1 p/ listar productos. cualquier tecla p/ Continuar");
    ConsoleKeyInfo recuerdo = Console.ReadKey();
    if (recuerdo.Key == ConsoleKey.F1)
    {
        ObtenerProductosConInformacionCompleta();
    }
    else
    {
        Console.WriteLine("\nId:");
        var ingreso = Console.ReadLine();
        var producto = business.obtenerProductoEspecifico(ingreso);
        if (producto != null)
        {
            Console.WriteLine("Seguro que desea eliminar? 1: si, cualquier tecla: No");
            ConsoleKeyInfo eliminar = Console.ReadKey();
            
            if (eliminar.Key == ConsoleKey.D1 || eliminar.Key == ConsoleKey.NumPad1)
            {
                business.EliminarProducto(producto);
                if (business.obtenerProductoEspecifico(ingreso) == null)
                {
                    Console.WriteLine("\nSe ha eliminado con exito.");
                }
                else
                {
                    Console.WriteLine("\nOcurrió algún imprevisto.");
                }
            }
            else
            {
                Console.WriteLine("\nProceso cancelado.");
            }


        }
        else
        {
            Console.WriteLine("No se ha encontrado el producto para eliminar.");
        }
    }
}
static void ObtenerProductosConInformacionCompleta()
{
    ProductBusiness business = new ProductBusiness();
    var productosM = business.ObtenerProductosConInformacionCompleta();

    foreach (var item in productosM)
    {
        Console.WriteLine(
            $"ProductoID: {item[0]} " +
            $" Producto: {item[1]} " +
            $" Habilitado: {item[2]} " +
            $" CategoriaId: {item[3]} " +
            $" Categoria: {item[4]}");

    }
}


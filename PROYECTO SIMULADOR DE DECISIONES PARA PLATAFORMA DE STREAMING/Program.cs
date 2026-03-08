Console.WriteLine("====MENU===");
Console.WriteLine("1. Tipo de contenido (película, serie, documental, evento en vivo");
Console.WriteLine("2. Duración en minutos");
Console.WriteLine("3. Clasificación (todo público, +13, +18)");
Console.WriteLine("4. Hora programada (0–23)");
Console.WriteLine("5. Nivel de producción (bajo, medio, alto)");
Console.WriteLine("0. Salir");

int opcion = int.Parse(Console.ReadLine());
switch (opcion)
{
    case 1:

    break;
    case 2:
        Console.WriteLine("Duracion en minutos");
        int duracion = int.Parse(Console.ReadLine());
        if (duracion >= 120)
        {
            Console.WriteLine("impacto alto");
        }
        else if (duracion >= 60 && duracion <= 120)
        {
            Console.WriteLine("impacto medio");
        }
        else
        {
            Console.WriteLine("impacto bajo");
        }
            break;
    case 3:

    break;
    case 4:

    break;
    case 5:

    break;
    case 0:

    break;
}
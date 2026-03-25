using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Xml.XPath;
int opcion;


do
{
    int opcioncontenido;

    Console.Clear();
    Console.WriteLine("====MENU===");
    Console.WriteLine("1. Validacion tecnica");
    Console.WriteLine("2. Mostrar las reglas del sistema");
    Console.WriteLine("3. Estadisticas de sesión");
    Console.WriteLine("4. Reiniciar estadisticas");
    Console.WriteLine("5. Salir");
    opcion = int.Parse(Console.ReadLine());

    switch (opcion)
    {

        case 1:
            do { 
                Console.Clear() ;
                Console.WriteLine("Seleccione su tipo de contenido");
                Console.WriteLine("1. Pelicula");
                Console.WriteLine("2. Serie");
                Console.WriteLine("3. Documental");
                Console.WriteLine("4. Evento en vivo");
                Console.WriteLine("0. Salir y regresar al menu de contenido");
                opcioncontenido = int.Parse(Console.ReadLine());
                switch (opcioncontenido)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ingrese la duracion en minutos de la Pelicula");
                        int pelicula;
                        if (int.TryParse(Console.ReadLine(), out pelicula))
                        {
                            Console.WriteLine("Dato erroneo");
                        }
                        else if(pelicula <= 60 || pelicula >= 180)
                        {
                            Console.WriteLine("El contenido no cumple con la validacion");
                        }
                        else
                        {
                            Console.WriteLine("El contenido se registro");
                        }
                        regresaralmenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Ingrese la duracion en minutois de la Serie");
                        int serie;
                        if (int.TryParse(Console.ReadLine(), out serie))
                        {
                            Console.WriteLine("Dato erroneo");
                        }
                        else if(serie <= 20 || serie >= 90)
                        {
                            Console.WriteLine("el contenido no cumple la validación");
                        }
                        else
                        {
                            Console.WriteLine("El contenido se registro");
                        }
                        regresaralmenu();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Ingrese la duracion en minutois del Documental");
                        int documental;
                        if (int.TryParse(Console.ReadLine(), out documental))
                        {
                            Console.WriteLine("Dato erroneo");
                        }
                        else if(documental <= 30 || documental >= 120)
                        {
                            Console.WriteLine("el contenido no cumple la validación");
                        }
                        else
                        {
                            Console.WriteLine("El contenido se registro");
                        }
                        regresaralmenu();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Ingrese la duracion en minutois del Evento en vivo");
                        int eventoenvivo;
                        if (int.TryParse(Console.ReadLine(), out eventoenvivo))
                        {
                            Console.WriteLine("Dato erroeno");
                        }
                        else if(eventoenvivo <= 30 || eventoenvivo >= 240)
                        {
                            Console.WriteLine("el contenido no cumple la validación");
                        }
                        else
                        {
                            Console.WriteLine("El contenido se registro");
                        }
                        regresaralmenu();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo....");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            } while (opcioncontenido != 0) ;
            regresaralmenu();
            break;
        case 2:
            {
                Console.WriteLine("Reglas del sistema");
                Console.WriteLine("Reglas de clasificación y horario\r\n• Todo público: cualquier hora\r\n• +13: entre 6 y 22 horas\r\n• +18: entre 22 y 5 horas\r\nReglas de duración por tipo\r\n• Película: 60–180 minutos\r\n• Serie: 20–90 minutos\r\n• Documental: 30–120 minutos\r\n• Evento en vivo: 30–240 minutos\r\nSi la duración está fuera del rango permitido, el contenido no cumple la validación técnica.\r\nReglas de producción\r\n• Producción baja solo válida para Todo público o +13\r\n• Producción media o alta válida para cualquier clasificación");
            }
        break;
        case 3:
            {
                Console.WriteLine("Estadisticas de sesion");
            }

            break;
        case 4:
            {
                Console.Clear ();
                Console.WriteLine("Estadisticas reiniciadas");
                regresaralmenu();
            }
        break;
        case 5:
            {
                Console.WriteLine("Resumen final");
            }
        break;
    }
} while (opcion != 5);



void regresaralmenu()
{
    Console.WriteLine("Presione ENTER para regresar al menu");
    Console.ReadKey();
}
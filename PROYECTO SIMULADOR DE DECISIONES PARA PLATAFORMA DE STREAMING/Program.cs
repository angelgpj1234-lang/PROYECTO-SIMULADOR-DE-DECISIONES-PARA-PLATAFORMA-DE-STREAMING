using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Xml;
using System.Xml.XPath;
int opcion;
int totalevaluados = 0;
int publicados = 0;
int rechazados = 0;

do
{
    
    int opcionproduccion;
    int hora = 0;
    int opcionclas;
    int opcioncontenido;
    bool contendiovalido = false;

    Console.Clear();
    Console.WriteLine("==== MENU ===");
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
                Console.WriteLine("==== Seleccione su tipo de contenido ====");
                Console.WriteLine("1. Pelicula");
                Console.WriteLine("2. Serie");
                Console.WriteLine("3. Documental");
                Console.WriteLine("4. Evento en vivo");
                Console.WriteLine("0. Para continuar");
                opcioncontenido = int.Parse(Console.ReadLine());
                switch (opcioncontenido)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Ingrese la duracion en minutos de la Pelicula");
                        int pelicula;
                        if (!int.TryParse(Console.ReadLine(), out pelicula))
                        {
                            Console.WriteLine("Dato erroneo");
                        }
                        else if(pelicula < 60 || pelicula > 180)
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
                        if (!int.TryParse(Console.ReadLine(), out serie))
                        {
                            Console.WriteLine("Dato erroneo");
                        }
                        else if(serie < 20 || serie > 90)
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
                        if (!int.TryParse(Console.ReadLine(), out documental))
                        {
                            Console.WriteLine("Dato erroneo");
                        }
                        else if(documental < 30 || documental > 120)
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
                        if (!int.TryParse(Console.ReadLine(), out eventoenvivo))
                        {
                            Console.WriteLine("Dato erroeno");
                        }
                        else if(eventoenvivo < 30 || eventoenvivo > 240)
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
                        Console.WriteLine("=== MENU DE ===");
                        break;
                    default:
                        Console.WriteLine("Opcion invalida");
                        break;
                }
            } while (opcioncontenido != 0) ;


            do
            {
                Console.WriteLine("Clasificacion");
                Console.WriteLine("1. Todo publico; Cualquier hora");
                Console.WriteLine("2. +13; entre 6 y 22 horas");
                Console.WriteLine("3. +18; entre 22 y 5 horas");
                Console.WriteLine("0. Salir");
                opcionclas = int.Parse(Console.ReadLine());
                
                switch (opcionclas)
                {
                    case 1:
                        Console.WriteLine("Ingrese la hora entre 0-23");
                        if (!int.TryParse(Console.ReadLine(), out hora))
                        {
                            Console.WriteLine("hora invalida");
                        }
                        else
                        {
                            Console.WriteLine("Lo puede ver cualquier persona a cualqueir hora");
                        }
                        break;
                    case 2:
                        if (hora < 6 || hora > 22)
                        {
                            Console.WriteLine("Horario invalido para +13");
                        }
                        break;
                    case 3:
                        if (hora >= 22 || hora <= 5)
                        {
                            Console.WriteLine("Horario invalido para +18");
                        }
                        break;
                    case 0:
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("opcion erronea");
                        break;
                }

            } while (opcionclas != 0);

            do
            {
                Console.WriteLine("Produccion");
                Console.WriteLine("1. baja");
                Console.WriteLine("2. media");
                Console.WriteLine("3. alta");
                Console.WriteLine("0. contuniar");
                opcionproduccion = int.Parse(Console.ReadLine());

                if (!int.TryParse(Console.ReadLine(), out opcionproduccion))
                {
                    Console.WriteLine("Entrada invalida");
                    continue;
                }
                if (opcionproduccion == 0) break;
                
                if (opcionproduccion == 1 && opcionclas == 3)
                {
                    Console.WriteLine("Produccion baja, no permitida para +18");
                    contendiovalido = false;
                }
                else
                {
                    Console.WriteLine("Produccion aceptada");
                }
                regresaralmenu();
            } while (opcionproduccion != 0);

            totalevaluados++;
            if (contendiovalido)
            {
                Console.WriteLine("Contenido publicado");
                publicados++;
            }
            else
            {
                Console.WriteLine("Contenido rechazado");
                rechazados++;
            }
            break;

        case 2:
            {
                Console.WriteLine("==== Reglas del sistema ====");
                Console.WriteLine("Todo público: cualquier hora");
                Console.WriteLine("+13: entre 6 y 22 horas");
                Console.WriteLine("+18: entre 22 y 5 horas");
                Console.WriteLine();
                Console.WriteLine("=== Reglas de duración por tipo ===");
                Console.WriteLine("Película: 60–180 minutos");
                Console.WriteLine("Serie: 20–90 minutos");
                Console.WriteLine("Documental: 30–120 minutos");
                Console.WriteLine("Evento en vivo: 30–240 minutos");
                Console.WriteLine("Si la duración está fuera del rango permitido, el contenido no cumple la validación técnica.");
                Console.WriteLine();
                Console.WriteLine("==== Reglas de producción ====");
                Console.WriteLine("Producción baja solo válida para Todo público o +13");
                Console.WriteLine("Producción media o alta válida para cualquier clasificación");
            }
        break;
        case 3:
            {
                Console.WriteLine("Estadisticas de sesion: ");
                Console.WriteLine("1. Total evaluados" + totalevaluados);
                Console.WriteLine("2. Publicados" + publicados);
                Console.WriteLine("3. Rechazados" + rechazados);
                Console.WriteLine("4. En revisión");
                Console.WriteLine("5. Impacto predominante");
                Console.WriteLine("6. Porcentaje de aprobación");
            }

            break;
        case 4:
            {
                totalevaluados = 0;
                publicados = 0;
                rechazados = 0;
                Console.WriteLine("Estadisticas reiniciadas");
                regresaralmenu();
            }
        break;
        case 5:
            {
                Console.WriteLine("Resumen final");
            }
        break;
        default:
            Console.WriteLine("Opcion invalida");
            break;  
    }
} while (opcion != 5);



void regresaralmenu()
{
    Console.WriteLine("Presione ENTER para regresar al menu");
    Console.ReadLine();
}


using System.Reflection;
using System.Threading.Tasks.Dataflow;

int opcion;
int totalevaluados = 0;
int publicados = 0;
int rechazados = 0;
int revision = 0;

int bajo = 0;
int medio = 0;
int alto = 0;

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
    Console.WriteLine("2. Mostrar reglas");
    Console.WriteLine("3. Estadisticas");
    Console.WriteLine("4. Reiniciar");
    Console.WriteLine("5. Salir");

    if (!int.TryParse(Console.ReadLine(), out opcion))
    {
        Console.WriteLine("Entrada invalida");
        regresaralmenu();
        continue;
    }

    switch (opcion)
    {
        case 1:

            do
            {
                Console.Clear();
                Console.WriteLine("== SELECCION DE CONTENIDO ===");
                Console.WriteLine("1. Pelicula");
                Console.WriteLine("2. Serie");
                Console.WriteLine("3. Documental");
                Console.WriteLine("4. Evento en vivo");
                Console.WriteLine("0. Continuar");

                if (!int.TryParse(Console.ReadLine(), out opcioncontenido))
                    continue;

                if (opcioncontenido == 0) break;

                Console.WriteLine("Ingrese duracion:");
                if (!int.TryParse(Console.ReadLine(), out int duracion))
                {
                    Console.WriteLine("Error");
                    continue;
                }

                switch (opcioncontenido)
                {
                    case 1:
                        contendiovalido = (duracion >= 60 && duracion <= 180);
                        break;
                    case 2:
                        contendiovalido = (duracion >= 20 && duracion <= 90);
                        break;
                    case 3:
                        contendiovalido = (duracion >= 30 && duracion <= 120);
                        break;
                    case 4:
                        contendiovalido = (duracion >= 30 && duracion <= 240);
                        break;
                }

                Console.WriteLine(contendiovalido ? "Valido" : "No valido");
                regresaralmenu();

            } while (opcioncontenido != 0);

            if (!contendiovalido) break;

            do
            {
                Console.Clear();
                Console.WriteLine("== SELECCION DE CLASIFICACIÓN ===");
                Console.WriteLine("1. Todo publico");
                Console.WriteLine("2. +13");
                Console.WriteLine("3. +18");
                Console.WriteLine("0. Continuar");

                if (!int.TryParse(Console.ReadLine(), out opcionclas))
                    continue;

                if (opcionclas == 0) break;

                Console.WriteLine("Ingrese hora (0-23):");
                if (!int.TryParse(Console.ReadLine(), out hora))
                    continue;

                switch (opcionclas)
                {
                    case 1:
                        break;

                    case 2:
                        if (hora < 6 || hora > 22)
                        {
                            Console.WriteLine("Horario invalido");
                            contendiovalido = false;
                        }
                        break;

                    case 3:
                        if (!(hora >= 22 || hora <= 5))
                        {
                            Console.WriteLine("Horario invalido");
                            contendiovalido = false;
                        }
                        break;
                }

                regresaralmenu();

            } while (opcionclas != 0);
            if (opcionclas == 0)
            {
                Console.WriteLine("Contenido en revisión");
                revision++;
                totalevaluados++;
                regresaralmenu();
                break;
            }

            if (!contendiovalido)
            {
                Console.WriteLine("Rechazado por clasificación");
                rechazados++;
                totalevaluados++;
                regresaralmenu();
                break;
            }
            do
            {
                Console.Clear();
                Console.WriteLine("== SELECCION DE IMPACTO ===");
                Console.WriteLine("1. Baja");
                Console.WriteLine("2. Media");
                Console.WriteLine("3. Alta");
                Console.WriteLine("0. Continuar");

                if (!int.TryParse(Console.ReadLine(), out opcionproduccion))
                    continue;

                if (opcionproduccion == 0) break;

                if (opcionproduccion == 1 && opcionclas == 3)
                {
                    Console.WriteLine("No permitido");
                    contendiovalido = false;
                }
                if (opcionproduccion == 1) bajo++;
                if (opcionproduccion == 2) medio++;
                if (opcionproduccion == 3) alto++;

                regresaralmenu();

            } while (opcionproduccion != 0);
            if (opcionproduccion == 0)
            {
                Console.WriteLine("Contenido en revisión");
                revision++;
                totalevaluados++;
                regresaralmenu();
                break;
            }
            totalevaluados++;

            if (contendiovalido)
            {
                Console.WriteLine("CONTENIDO PUBLICADO");
                publicados++;
            }
            else
            {
                Console.WriteLine("CONTENIDO RECHAZADO");
                rechazados++;
            }

            regresaralmenu();
            break;
        case 2:
            { Console.WriteLine("==== Reglas del sistema ===="); 
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
                Console.WriteLine("Producción media o alta válida para cualquier clasificación"); }
            break;

        case 3:
            Console.WriteLine($"Total Evaluados: {totalevaluados}");
            Console.WriteLine($"Publicados: {publicados}");
            Console.WriteLine($"Rechazados: {rechazados}");
            Console.WriteLine($"En revision: {revision}");
            if (totalevaluados > 0)
            {
                double porcentaje = (publicados*100) / totalevaluados;
                Console.WriteLine($"porcentaje de aprobación: {porcentaje}");
            }
            
            if (bajo > medio && bajo > alto)
            {
                Console.WriteLine("Impacto predominante: bajo");
            }    
            else if (medio > alto)
            {
                Console.WriteLine("Impacto predominante: medio");
            }
            else if (alto > 0)
            {
                Console.WriteLine("Impacto predominante: alto");
            }    
            regresaralmenu();
            break;

        case 4:
            totalevaluados = publicados = rechazados = 0;
            Console.WriteLine("Reiniciado");
            regresaralmenu();
            break;

    }

} while (opcion != 5);

void regresaralmenu()
{
    Console.WriteLine("Presione ENTER para regresar");
    Console.ReadLine();
}
 
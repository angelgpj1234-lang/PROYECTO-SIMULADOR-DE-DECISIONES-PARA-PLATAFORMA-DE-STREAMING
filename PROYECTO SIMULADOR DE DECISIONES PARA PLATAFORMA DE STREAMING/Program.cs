

using System.Reflection;

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

            if (!contendiovalido) break;

            do
            {
                Console.Clear();
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

                regresaralmenu();

            } while (opcionproduccion != 0);

            totalevaluados++;

            if (contendiovalido)
            {
                Console.WriteLine("PUBLICADO");
                publicados++;
            }
            else
            {
                Console.WriteLine("RECHAZADO");
                rechazados++;
            }

            regresaralmenu();
            break;

        case 3:
            Console.WriteLine($"Total Evaluados: {totalevaluados}");
            Console.WriteLine($"Publicados: {publicados}");
            Console.WriteLine($"Rechazados: {rechazados}");
            Console.WriteLine("En revision");
            Console.WriteLine("Impacto predominante");
            Console.WriteLine("Porcentaje de aprobación");
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

AssemblyDelaySignAttribute
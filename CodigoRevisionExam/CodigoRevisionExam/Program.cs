
using System;

class Program
{
    static string[] respuestasCorrectas;
    static int totalPreguntas = 0;

    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine(" SISTEMA DE CALIFICACION");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Registrar examen");
            Console.WriteLine("2. Calificar estudiante");
            Console.WriteLine("3. Mostrar respuestas correctas");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opcion: ");

            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    RegistrarExamen();
                    break;

                case 2:
                    CalificarEstudiante();
                    break;

                case 3:
                    MostrarRespuestas();
                    break;

                case 4:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida.");
                    Pausa();
                    break;
            }

        } while (opcion != 4);
    }

    static void RegistrarExamen()
    {
        Console.Clear();

        Console.Write("Cantidad de preguntas: ");
        totalPreguntas = Convert.ToInt32(Console.ReadLine());

        respuestasCorrectas = new string[totalPreguntas];

        Console.WriteLine("\nIngrese las respuestas correctas:");

        for (int i = 0; i < totalPreguntas; i++)
        {
            Console.Write($"Pregunta {i + 1}: ");
            respuestasCorrectas[i] = Console.ReadLine().ToUpper();
        }

        Console.WriteLine("\nExamen registrado correctamente.");
        Pausa();
    }

    static void CalificarEstudiante()
    {
        Console.Clear();

        if (respuestasCorrectas == null)
        {
            Console.WriteLine("Primero debe registrar un examen.");
            Pausa();
            return;
        }

        string nombre;
        int correctas = 0;

        Console.Write("Nombre del estudiante: ");
        nombre = Console.ReadLine();

        string[] respuestasAlumno = new string[totalPreguntas];

        Console.WriteLine("\nIngrese las respuestas del estudiante:");

        for (int i = 0; i < totalPreguntas; i++)
        {
            Console.Write($"Pregunta {i + 1}: ");
            respuestasAlumno[i] = Console.ReadLine().ToUpper();

            if (respuestasAlumno[i] == respuestasCorrectas[i])
            {
                correctas++;
            }
        }

        double nota = (double)correctas / totalPreguntas * 100;

        Console.WriteLine("\n========== RESULTADO ==========");
        Console.WriteLine($"Estudiante: {nombre}");
        Console.WriteLine($"Correctas: {correctas}");
        Console.WriteLine($"Incorrectas: {totalPreguntas - correctas}");
        Console.WriteLine($"Nota: {nota:F2}");

        Console.WriteLine("\nPreguntas incorrectas:");

        bool tieneErrores = false;

        for (int i = 0; i < totalPreguntas; i++)
        {
            if (respuestasAlumno[i] != respuestasCorrectas[i])
            {
                Console.WriteLine(
                    $"Pregunta {i + 1}: Correcta={respuestasCorrectas[i]} | Alumno={respuestasAlumno[i]}"
                );

                tieneErrores = true;
            }
        }

        if (!tieneErrores)
        {
            Console.WriteLine("Ninguna. Examen perfecto.");
        }

        Pausa();
    }

    static void MostrarRespuestas()
    {
        Console.Clear();

        if (respuestasCorrectas == null)
        {
            Console.WriteLine("No existe un examen registrado.");
            Pausa();
            return;
        }

        Console.WriteLine("RESPUESTAS CORRECTAS\n");

        for (int i = 0; i < totalPreguntas; i++)
        {
            Console.WriteLine($"Pregunta {i + 1}: {respuestasCorrectas[i]}");
        }

        Pausa();
    }

    static void Pausa()
    {
        Console.WriteLine("\nPresione una tecla para continuar...");
        Console.ReadKey();
    }
}
using System;
using System.IO;

string path;
bool continuar = true;
do
{
    Console.Clear();
    Console.WriteLine(new string('-', 100)); // separador visual
    Console.WriteLine("\n\t\tTALLER DE LENGUAJES I");
    Console.Write("\n\tIngrese el direcorio a examinar (ENTER PARA CANCELAR): ");
    path = Console.ReadLine();
    if (string.IsNullOrEmpty(path)) break;
    DirectoryInfo directorio = new DirectoryInfo(path);
    if (directorio.Exists)
    {
        FileInfo[] archivos = directorio.GetFiles();
        DirectoryInfo[] subDirectorios = directorio.GetDirectories();
        Console.WriteLine("\n\t\t---SUBDIRECTORIOS---");
        if (subDirectorios.Length>0)
        {
            foreach (DirectoryInfo sub in subDirectorios)
            {
                Console.WriteLine($"\t|--{sub.Name}");
            }
        }else{
            Console.WriteLine("\n\t\t---VACÍO---");
        }
        Console.WriteLine("\n\t\t---ARCHIVOS---");
        if (archivos.Length > 0)
        {
            Console.WriteLine($"\t| {"NOMBRE",-40}| {"TAMAÑO(bytes)",-40}");
            Console.WriteLine(new string('-', 90)); // separador visual
            foreach (FileInfo file in archivos)
            {
                Console.WriteLine($"\t| {file.Name,-40}| {file.Length, -13} Bytes");
            }
        }else
        {
            Console.WriteLine("\n\t\t---VACÍO---");
        }
    }

    do{
        Console.Write("\n\t\tDesea continuar? (ESC = NO | ENTER = SÍ): ");
        ConsoleKey tecla = Console.ReadKey(true).Key;
        if(tecla == ConsoleKey.Escape || tecla == ConsoleKey.Enter){    /* solo entra si se apreto esc o enter */
            continuar = (tecla == ConsoleKey.Enter) ? true : false; /* le asigno un valor a continuar segun la tecla que se apreto */
            break;
        }
        Console.WriteLine("\n\t\t---OPCIÓN NO VALIDA, REINGRESE---");
    }while(true); /* no es necesario cambiar la condicion pues cuando se cumplae el if se rompe el bucle */
} while (continuar);
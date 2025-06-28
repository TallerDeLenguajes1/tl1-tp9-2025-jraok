using System;
using System.IO;

// ruta por defecto con los archivos MP3
string path = "MP3/";
DirectoryInfo carpeta = new DirectoryInfo(path);    /* instancia de directorio para listar los archivos */

if (carpeta.Exists) /* verifico la existencia de la ruta */
{
    FileInfo[] canciones = carpeta.GetFiles("*.mp3");   /* arreglo con solo los archivos MP3 de la ruta */
    if (canciones.Length > 0)   /* si encuentra archivos en la ruta */
    {
        /* bucle para mostrar las canciones y elegir una de la lista */
        do
        {
            Console.Clear();    /* limpieza de la terminal */
            Console.Write(new string('-', 80)); /* separador visual */
            Console.WriteLine("\n\t\t---TALLER DE LENGUAJES I---");

            // menu para elegir una cancion
            Console.WriteLine("\n\t\t---LISTA DE CANCIONES---");
            for (int i = 0; i < canciones.Length; i++)  /* bucle para mostrar las canciones del arreglo */
            {
                Console.WriteLine($"\t|--> {i+1}_ {canciones[i].Name}");
            }
            Console.Write("\n\t\tSeleccione una canción (ÍNDICE): ");
            string? indice = Console.ReadLine();    /* lectura del indice de la cancion */

            // validacion del indice ingresado, debe ser un entero y mantenerse en el rango de la lista
            if (!int.TryParse(indice, out int posicion) || posicion < 1 || posicion > canciones.Length){
                Console.WriteLine("\n\t\t---ÍNDICE INVÁLIDO---");
                System.Threading.Thread.Sleep(1200);    /* pausa para mostrar el mensaje */
                continue;
            }else{
                break;  /* salida del bucle */
            }
        } while (true);
    }else
    {
        Console.WriteLine("\n\t\t---Sin Canciones---");
    }
}else{
    Console.WriteLine("\n\t\t---LA CARPETA NO EXISTE----");
}

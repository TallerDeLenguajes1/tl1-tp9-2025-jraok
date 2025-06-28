using System;
using System.IO;
using EspacioMP3;

// ruta por defecto con los archivos MP3
string path = "MP3/";
DirectoryInfo carpeta = new DirectoryInfo(path);    /* instancia de directorio para listar los archivos */

if (carpeta.Exists) /* verifico la existencia de la ruta */
{
    FileInfo[] canciones = carpeta.GetFiles("*.mp3");   /* arreglo con solo los archivos MP3 de la ruta */
    if (canciones.Length > 0)   /* si encuentra archivos en la ruta */
    {
        FileInfo? cancion = null;
        /* bucle para mostrar las canciones y elegir una de la lista */
        do
        {
            System.Threading.Thread.Sleep(1200);    /* pausa para mostrar el mensaje */
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
                cancion = canciones[posicion-1];    /* asignacion de la cancion elegida */
                break;  /* salida del bucle */
            }
        } while (true);
        
        try
        {
            byte[] arreglo = new byte[128];    /* arreglo para guardar los datos de la cancion */
            using FileStream MiCancion = new FileStream(cancion.FullName, FileMode.Open);    /* instancia para leer el archivo */
            MiCancion.Seek(-128, SeekOrigin.End); /* posicionamiento al final del archivo */
            MiCancion.ReadExactly(arreglo, 0, 128); /* lectura de los datos de la cancion */

            InfoMP3 informacion = InfoMP3.LeerBytes(arreglo);   /* instancia con la informacion de la cancion */
            // impresion de la informacion de la cancion
            Console.WriteLine($"\n\t\t---INFORMACION DE LA CANCIÓN---");
            Console.WriteLine($"\t TÍTULO: {informacion.Titulo}");
            Console.WriteLine($"\t ARTISTA: {informacion.Artista}");
            Console.WriteLine($"\t ÁLBUM: {informacion.Album}");
            Console.WriteLine($"\t AÑO: {informacion.Anio}");
            Console.WriteLine($"\t COMENTARIO: {informacion.Comentario}");
            Console.WriteLine($"\t GÉNERO: {informacion.Genero}");
        }
        catch (Exception error)
        {
            Console.WriteLine($"\n\t\tERROR: {error.Message}"); /* mensaje de la exepcion dentro del metodo LeerBytes */
        }
    }else{
        Console.WriteLine("\n\t\t---Sin Canciones---");
    }
}else{
    Console.WriteLine("\n\t\t---LA CARPETA NO EXISTE----");
}

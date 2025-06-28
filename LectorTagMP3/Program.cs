using System;
using System.IO;
using Internal;

Console.Clear();
string path = "MP3/";
DirectoryInfo carpeta = new DirectoryInfo(path);

if (carpeta.Exists)
{
    FileInfo[] canciones = carpeta.GetFiles("*.mp3");
    if (canciones.Length > 0)
    {
        int i = 0;
        bool salir = true;
        do
        {
            Console.WriteLine("\n\t\t---LISTA DE CANCIONES---");
            foreach (FileInfo cancion in canciones)
            {   
                Console.WriteLine($"\t|--> {++i + "_" + cancion.Name}");
            }
            Conosle.Write("\n\t\t---Seleccione una canción (ÍNDICE): ");
            string indice = Console.read();
            if (!int.TryParse(indice, out i) || i < 1 || i > canciones.Length){
                Console.WriteLine("\n\t\t---ÍNDICE INVÁLIDO---");
            }else{
                salir = false;
            }
        } while (salir);
    }else
    {
        Console.WriteLine("\n\t\t---Sin Canciones---");
    }
}else{
    Console.WriteLine("\n\t\t---LA CARPETA NO EXISTE----");
}

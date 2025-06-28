using System;
using System.IO;

string path = "MP3/";
DirectoryInfo carpeta = new DirectoryInfo(path);

if (carpeta.Exists)
{
    FileInfo[] canciones = carpeta.GetFiles("*.mp3");
    if (canciones.Length > 0)
    {
        int i;
        bool salir = true;
        do
        {
            Console.Clear();
            Console.Write(new string('-', 80));
            Console.WriteLine("\n\t\t---LISTA DE CANCIONES---");
            i = 0;
            foreach (FileInfo cancion in canciones)
            {   
                Console.WriteLine($"\t|--> {++i + "_ " + cancion.Name}");
            }
            Console.Write("\n\t\tSeleccione una canción (ÍNDICE): ");
            string indice = Console.ReadLine();
            if (!int.TryParse(indice, out i) || i < 1 || i > canciones.Length){
                Console.WriteLine("\n\t\t---ÍNDICE INVÁLIDO---");
                System.Threading.Thread.Sleep(1200);
                continue;
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

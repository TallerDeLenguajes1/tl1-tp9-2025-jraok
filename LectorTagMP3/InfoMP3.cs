using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace EspacioMP3;
// clase para la informacion de los archivos MP3
public class InfoMP3
{
    // campos privados con la información de la clase
    private string titulo;    
    private string artista;
    private string album;
    private int anio;
    private string comentario;
    private byte genero;

    public static InfoMP3 LeerBytes(byte[] arreglo){
        if (arreglo == null || arreglo.Length != 128)
        {
            throw new ArgumentException("Datos insuficientes para procesar");
        }

        string tag = Encoding.ASCII.GetString(arreglo, 0, 3);
        if (tag != "TAG"){
            throw new InvalidDataException("El formato incorrecto, falta ID3v1");
        }
        string titulo = Encoding.ASCII.GetString(arreglo, 3, 30);
        string artista = Encoding.ASCII.GetString(arreglo, 33, 30);
        string album = Encoding.ASCII.GetString(arreglo, 63, 30);
        string anioArreglo = Encoding.ASCII.GetString(arreglo,93, 4 );
        string comentario = Encoding.ASCII.GetString(arreglo, 97, 30);
        byte genero = arreglo[127];

        int anio = 0;
        int.TryParse(anioArreglo, out anio);

        return new InfoMP3(titulo, artista, album, anio, comentario, genero);
    }


    // propiedades publicas para la lectura de los campos
    public string Titulo => titulo;
    public string Artista => artista;
    public string Album => album;
    public int Anio => anio;
    public string Comentario => comentario;
    public byte Genero => genero;

}
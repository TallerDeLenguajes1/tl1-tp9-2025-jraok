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

    // metodo para crear una instancia de InfoMP3
    public static InfoMP3 LeerBytes(byte[] arreglo){
        // excepciones para el manejo desde main 
        if (arreglo == null || arreglo.Length != 128)   /* excepsion en caso de no cumplir con los 128 bytes o ser nulo */
        {
            throw new ArgumentException("Datos insuficientes para procesar");
        }

        string tag = Encoding.ASCII.GetString(arreglo, 0, 3);   /* lectura de la etiqueta en el arreglo */
        if (tag != "TAG"){  /* excepcion en caso de no ser el formato correcto */
            throw new InvalidDataException("El formato incorrecto, falta ID3v1");
        }
        /* guardado de la informacion partiendo de los datos del arreglo */
        string titulo = Encoding.ASCII.GetString(arreglo, 3, 30);
        string artista = Encoding.ASCII.GetString(arreglo, 33, 30);
        string album = Encoding.ASCII.GetString(arreglo, 63, 30);
        string anioArreglo = Encoding.ASCII.GetString(arreglo,93, 4 );
        string comentario = Encoding.ASCII.GetString(arreglo, 97, 30);
        byte genero = arreglo[127];
        /* cambio el tipo de dato para el año */
        int anio = 0;
        int.TryParse(anioArreglo, out anio);
        /* retorno exitoso de la nueca instancia */
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
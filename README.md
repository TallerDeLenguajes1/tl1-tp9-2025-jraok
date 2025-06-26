# TP09 - Taller de Lenguajes I (2025)

## 📘 Descripción general

Este proyecto resuelve el **Trabajo Práctico N°9** de la materia **Taller de Lenguajes I** (Universidad Nacional de Tucumán, 2025). El objetivo principal es el manejo avanzado de archivos en C#, incluyendo:

- Exploración y análisis de archivos en directorios.
- Generación de archivos de salida (`.csv`).
- Lectura de etiquetas ID3v1 de archivos MP3.
- Uso básico de archivos JSON como medio de almacenamiento estructurado.

---

## 🧠 Ejercicios

### ✅ Ejercicio 1: Exploración de archivos

- Solicita al usuario un directorio.
- Recorre todos los archivos que contiene.
- Para cada archivo, obtiene:
  - Nombre
  - Extensión
  - Tamaño en bytes
  - Fecha de última modificación
- Guarda los datos en un archivo `archivos.csv`.

### ✅ Ejercicio 2: Lectura de etiquetas ID3v1

- Permite al usuario seleccionar un archivo `.mp3`.
- Utiliza `FileStream` y `BinaryReader` para acceder a los últimos 128 bytes del archivo.
- Extrae campos como:
  - Título
  - Artista
  - Álbum
  - Año
- Muestra la información por consola.

---
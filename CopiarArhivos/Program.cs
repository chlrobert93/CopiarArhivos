using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CopiarArhivos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Ingresa la extención del archivo a seperar");
            string extencionArchivo = Console.ReadLine();

            string ruta = @"C:\Users\ianma\Prueba\";
            //string formato = "*."+ extencionArchivo;
            //string rutaFormato = ruta + formato;
            string destinoFinal = @"C:\Users\ianma\destinoPrueba\";
            string[] nombreArchivoFormato;

            


            try
            {
                string[] dirDirectories = Directory.GetDirectories(ruta);



                foreach (string directories in dirDirectories)
                {
                    string[] dirsrchivo = Directory.GetFiles(directories);
                    string nombreRut = directories;
                    int archivosEncontrados = dirsrchivo.Count();

                    if (archivosEncontrados != 0)
                    {
                        int ac = 0;
                        foreach (string dirArch in dirsrchivo)
                        {


                            string nombre = dirArch;
                            char delimitador = '\\';
                            char delimitadorPunto = '.';

                            string[] nombreArchivo = nombre.Split(delimitador);

                            nombreArchivoFormato = nombreArchivo[5].Split(delimitadorPunto);

                            nombre.EndsWith(extencionArchivo);

                            if (dirArch != "" && nombre.EndsWith(extencionArchivo))
                            {

                                ac++;

                                if (nombre.EndsWith(extencionArchivo) && ac == archivosEncontrados)
                                {

                                    //System.IO.File.Move(dir, destinoFinal + nombreArchivo[4]);

                                    char delimitadorRut = '\\';
                                    string[] nombreCarpeta = nombreRut.Split(delimitadorRut);

                                    //total = Directory.GetFiles(dir, "*.jpg", SearchOption.AllDirectories).Length;


                                    System.IO.Directory.Move(directories, destinoFinal + nombreCarpeta[4]);
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("SUCCES ARCHIVOS COPIADOS");
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(destinoFinal + nombreCarpeta[4]);

                                }

                            }


                            else
                            {

                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("NO SE LOGRARON MOVER");
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("Tiene archivos cond diferentes extenciones: " + nombreRut);
                                //break;


                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("CARPETA VACIA");

                        Console.WriteLine("No se encontro ningun archivo en la carpeta:  "+ nombreRut);
                    }

                }

            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: {0}", e.ToString());
            }
        }
    }
}

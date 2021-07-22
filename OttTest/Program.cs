using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace OttTest
{
    class Program
    {       

        private static string revisarPalabra(string[] palabra)
        {
            var lineaReversa = "";
            for (int i = palabra.Length-1; i >= 0; i--)
            {
                if (i == 0)
                {
                    lineaReversa += palabra[i];
                }
                else
                {
                    lineaReversa += palabra[i] + " ";
                }
            }
            return lineaReversa;

        }

        private static void lectura(string archivo)
        {
            string pathArchivoSalida = 
                Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Resources\Salida.txt");
            try
            {
                using (FileStream fs = File.Create(pathArchivoSalida))
                {
                    string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Resources\{archivo}");
                    string[] lineas = File.ReadAllLines(path);
                    for (int i = 1; i < lineas.Length; i++)
                    {
                        var linea = lineas[i].Split(' ');
                        var reversa = revisarPalabra(linea);
                        var lineaSalida = $"Case #{i}: {reversa}";
                        Console.WriteLine(lineaSalida);
                        byte[] info = new UTF8Encoding(true).GetBytes(lineaSalida+"\n"); 
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static void Main(string[] args)
        {
            //lectura("B-small-practice.in");
            lectura("B-large-practice.in");
        }
    }
}

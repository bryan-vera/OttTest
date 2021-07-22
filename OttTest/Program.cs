using System;
using System.IO;
using System.Reflection;

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
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Resources\{archivo}");
            string[] lineas = File.ReadAllLines(path);
            for (int i = 1; i < path.Length; i++)
            {
                var linea = lineas[i].Split(' ');
                var reversa = revisarPalabra(linea);
                Console.WriteLine($"Case #{i}: {reversa}");
            }
        }

        static void Main(string[] args)
        {
            lectura("B-small-practice.in");
            //lectura("B-large-practice.in");
        }
    }
}

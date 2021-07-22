using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace OttTest
{
    class Program
    {
        static IDictionary<char,string> iniciarDiccionario()
        {
            IDictionary<char, string> d = new Dictionary<char, string>();
            d.Add(new KeyValuePair<char, string>('a',"2" ));
            d.Add(new KeyValuePair<char, string>('b',"22"));
            d.Add(new KeyValuePair<char, string>('c', "222"));
            d.Add(new KeyValuePair<char, string>('d', "3"));
            d.Add(new KeyValuePair<char, string>('e', "33"));
            d.Add(new KeyValuePair<char, string>('f',"333"));
            d.Add(new KeyValuePair<char, string>('g',"4"));
            d.Add(new KeyValuePair<char, string>('h',"44"));
            d.Add(new KeyValuePair<char, string>('i',"444"));
            d.Add(new KeyValuePair<char, string>('j',"5"));
            d.Add(new KeyValuePair<char, string>('k',"55"));
            d.Add(new KeyValuePair<char, string>('l',"555"));
            d.Add(new KeyValuePair<char, string>('m',"6"));
            d.Add(new KeyValuePair<char, string>('n',"66"));
            d.Add(new KeyValuePair<char, string>('o',"666"));
            d.Add(new KeyValuePair<char, string>('p',"7"));
            d.Add(new KeyValuePair<char, string>('q',"77"));
            d.Add(new KeyValuePair<char, string>('r',"777"));
            d.Add(new KeyValuePair<char, string>('s',"7777"));
            d.Add(new KeyValuePair<char, string>('t',"8"));
            d.Add(new KeyValuePair<char, string>('u',"88"));
            d.Add(new KeyValuePair<char, string>('v',"888"));
            d.Add(new KeyValuePair<char, string>('w',"9"));
            d.Add(new KeyValuePair<char, string>('x',"99"));
            d.Add(new KeyValuePair<char, string>('y',"999"));
            d.Add(new KeyValuePair<char, string>('z',"9999"));
            d.Add(new KeyValuePair<char, string>(' ',"0"));
            return d;
        }
         
        private static string revisarSpelling(char[] palabra)
        {
            var dict = iniciarDiccionario();
            var lineaSpelling="";
            var valueAnterior = "";
            for (int i = 0; i < palabra.Length; i++)
            {
                var value = "";
                dict.TryGetValue(palabra[i], out value);
                if (value == valueAnterior)
                {
                    lineaSpelling += " " + value;
                }
                else
                {
                    lineaSpelling += value;
                }
                valueAnterior = value;
            }

            return lineaSpelling;
        
        }



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
                    for (int i = 14; i < lineas.Length; i++)
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

        private static void spelling(string archivo)
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
                        var linea = lineas[i].ToCharArray();
                        var spelling = revisarSpelling(linea);
                        var lineaSalida = $"Case #{i}: {spelling}";
                        Console.WriteLine(lineaSalida);
                        byte[] info = new UTF8Encoding(true).GetBytes(lineaSalida + "\n");
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
            //lectura("B-large-practice.in");
            spelling("C-small-practice.in");
            //spelling("C-large-practice.in");
        }
    }
}

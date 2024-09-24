using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        string cuil;
        do
        {
            Console.WriteLine("Ingrese el CUIL en formato N-NNNNNNNN-N:");
            cuil = Console.ReadLine();

            if (EsCuilValido(cuil))
            {
                string dni = ExtraerDNI(cuil);
                Console.WriteLine($"El DNI extraído es: {dni}");
            }
            else
            {
                Console.WriteLine("El CUIL no es válido.");
            }

            Console.WriteLine("¿Desea ingresar otro CUIL? (s/n):");
            string respuesta = Console.ReadLine();
            if (respuesta?.ToLower() != "s")
            {
                break; // Salir del bucle si la respuesta no es 's'
            }

        } while (true); // Repetir hasta que el usuario decida salir

        Console.WriteLine("Gracias por usar el validador de CUIL. Presione Enter para salir...");
        Console.ReadLine(); // Espera a que el usuario presione Enter
    }

    static bool EsCuilValido(string cuil)
    {
        string patron = @"^\d{1,2}-\d{8}-\d$"; // Patrón para el formato N-NNNNNNNN-N (dos números iniciales)
        return Regex.IsMatch(cuil, patron);
    }

    static string ExtraerDNI(string cuil)
    {
        // Extraer los 8 dígitos del CUIL
        string[] partes = cuil.Split('-');
        return partes[1]; // Devuelve la parte central que contiene el DNI
    }
}

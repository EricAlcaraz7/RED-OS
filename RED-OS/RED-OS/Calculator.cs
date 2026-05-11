//Calculator.cs
using System;

namespace CosmosKernel1
{
    public static class Calculator
    {
        public static void Ejecutar()
        {
            Console.WriteLine("\n--- CALCULADORA REDos ---");
            Console.Write("Operacio (+, -, *, /, %, sqrt): ");
            string op = Console.ReadLine().ToLower().Trim();

            try
            {
                if (op == "sqrt")
                {
                    Console.Write("Numero: ");
                    double n = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("> Resultat: " + Math.Sqrt(n));
                }
                else
                {
                    Console.Write("Num 1: ");
                    double a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Num 2: ");
                    double b = Convert.ToDouble(Console.ReadLine());

                    if (op == "+") Console.WriteLine("> Resultat: " + (a + b));
                    else if (op == "-") Console.WriteLine("> Resultat: " + (a - b));
                    else if (op == "*") Console.WriteLine("> Resultat: " + (a * b));
                    else if (op == "/") Console.WriteLine("> Resultat: " + (b != 0 ? (a / b).ToString() : "Error Div/0"));
                    else if (op == "%") Console.WriteLine("> Resultat: " + (a % b));
                    else { Console.WriteLine("No valida."); Sound.ErrorSound(); return; }
                }
                Sound.SuccessSound();
            }
            catch { Sound.ErrorSound(); Console.WriteLine("Error: Introdueix numeros."); }
        }
    }
}
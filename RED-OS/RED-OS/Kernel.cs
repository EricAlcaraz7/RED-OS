using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        const string Version = "1.0.0";

        public static void WaitMilliSeconds(int MilliSeconds)
        {
            DateTime T = DateTime.Now;
            while (DateTime.Now < T.AddMilliseconds(MilliSeconds)) { }
        }

        public static void ShowRedOSLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%");
            Console.WriteLine(@"  %@@@    ##########       ##########       ##########           @@@%");
            Console.WriteLine(@"  %@@@    ##      ##       ##               ##       ##          @@@%");
            Console.WriteLine(@"  %@@@    ##########       #######          ##       ##          @@@%");
            Console.WriteLine(@"  %@@@    ##    ##         ##               ##       ##          @@@%");
            Console.WriteLine(@"  %@@@    ##      ##       ##########       ###########          @@@%");
            Console.WriteLine(@"  %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // --- CALCULADORA ---
        public static void EjecutarCalculadora()
        {
            Console.WriteLine("\n==================================");
            Console.WriteLine("        CALCULADORA REDos         ");
            Console.WriteLine("==================================");
            Console.WriteLine("  + : Suma          - : Resta     ");
            Console.WriteLine("  * : Multiplicar   / : Dividir   ");
            Console.WriteLine("  % : Modul       sqrt : Arrel    ");
            Console.WriteLine("==================================");

            Console.Write("\nTria operacio: ");
            string op = Console.ReadLine().ToLower().Trim();

            try
            {
                if (op == "sqrt")
                {
                    Console.Write("Introdueix el numero: ");
                    double n = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\n> RESULTAT: " + Math.Sqrt(n));
                }
                else
                {
                    Console.Write("Primer numero: ");
                    double a = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Segon numero: ");
                    double b = Convert.ToDouble(Console.ReadLine());

                    if (op == "+") Console.WriteLine("\n> RESULTAT: " + (a + b));
                    else if (op == "-") Console.WriteLine("\n> RESULTAT: " + (a - b));
                    else if (op == "*") Console.WriteLine("\n> RESULTAT: " + (a * b));
                    else if (op == "/") Console.WriteLine("\n> RESULTAT: " + (a / b));
                    else if (op == "%") Console.WriteLine("\n> RESULTAT: " + (a % b));
                    else Console.WriteLine("\n> Operacio no valida.");
                }
            }
            catch
            {
                Console.WriteLine("\n[!] Error: Introdueix nomes numeros.");
            }
            Console.WriteLine("==================================\n");
        }

        protected override void BeforeRun()
        {
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());
            ShowRedOSLogo();
            Console.WriteLine("\nEscriu 'help' per veure la llista de comandos.");
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nREDos > ");
            Console.ForegroundColor = ConsoleColor.White;

            string input = Console.ReadLine()?.ToLower().Trim();
            if (string.IsNullOrEmpty(input)) return;

            switch (input)
            {
                case "help":
                    Console.WriteLine("\n------- MENU D'INSTRUCCIONS -------");
                    Console.WriteLine("  ver      - Versio del sistema");
                    Console.WriteLine("  clear    - Netejar la pantalla");
                    Console.WriteLine("  logo     - Tornar a veure el logo");
                    Console.WriteLine("  calc     - Obrir la calculadora");
                    Console.WriteLine("  reboot   - Reiniciar el sistema");
                    Console.WriteLine("  shutdown - Apagar el sistema");
                    Console.WriteLine("-----------------------------------\n");
                    break;

                case "ver":
                    Console.WriteLine("REDos Kernel v" + Version);
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "logo":
                    ShowRedOSLogo();
                    break;

                case "calc":
                    EjecutarCalculadora();
                    break;

                case "reboot":
                    Console.WriteLine("Reiniciant...");
                    //Cosmos.Sys.Deboot.Reboot();
                    Cosmos.System.Power.Reboot();
                    break;

                case "shutdown":
                    Console.WriteLine("Apagant...");
                    Cosmos.Sys.Deboot.ShutDown();
                    break;

                default:
                    Console.WriteLine("Comando '" + input + "' no reconegut.");
                    break;
            }
        }
    }
}

namespace Cosmos.Sys
{
    public static class Deboot
    {
        public static void ShutDown() { Cosmos.System.Power.Shutdown(); }
        public static void Reboot() { Cosmos.System.Power.Reboot(); }
    }
}
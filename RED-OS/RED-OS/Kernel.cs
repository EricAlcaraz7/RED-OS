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
            Console.WriteLine(@"  %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%");
            Console.WriteLine(@"  %@@@                                                           @@@%");
            WaitMilliSeconds(30);
            Console.WriteLine(@"  %@@@    ##########       ##########       ##########           @@@%");
            Console.WriteLine(@"  %@@@    ##########       ##########       ###########          @@@%");
            Console.WriteLine(@"  %@@@    ##      ##       ##               ##       ##          @@@%");
            Console.WriteLine(@"  %@@@    ##      ##       ##               ##       ##          @@@%");
            WaitMilliSeconds(30);
            Console.WriteLine(@"  %@@@    ##########       #######          ##       ##          @@@%");
            Console.WriteLine(@"  %@@@    ##########       #######          ##       ##          @@@%");
            Console.WriteLine(@"  %@@@    ##    ##         ##               ##       ##          @@@%");
            Console.WriteLine(@"  %@@@    ##     ##        ##               ##       ##          @@@%");
            WaitMilliSeconds(30);
            Console.WriteLine(@"  %@@@    ##      ##       ##########       ###########          @@@%");
            Console.WriteLine(@"  %@@@    ##       ##      ##########       ##########           @@@%");
            Console.WriteLine(@"  %@@@                                                           @@@%");
            Console.WriteLine(@"  %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%");
            Console.WriteLine(@"  %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n                [ RED Operating System - Build " + Version + " ]");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                [ Base: Cosmos Kernel | Status: Ready  ]");
            Console.WriteLine(" -------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected override void BeforeRun()
        {
            ShowRedOSLogo();
            Console.WriteLine("\nEscriu 'help' per veure els comandos disponibles.");
            Console.WriteLine();
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("REDos > ");
            Console.ForegroundColor = ConsoleColor.White;

            var input = Console.ReadLine()?.ToLower().Trim();

            if (string.IsNullOrEmpty(input)) return;

            switch (input)
            {
                case "help":
                    Console.WriteLine("\n--- COMANDOS DE REDos ---");
                    Console.WriteLine("ver      - Mostra la versio del sistema.");
                    Console.WriteLine("clear    - Neteja la consola.");
                    Console.WriteLine("logo     - Torna a mostrar el logo d'inici.");
                    Console.WriteLine("reboot   - Reinicia la maquina.");
                    Console.WriteLine("shutdown - Apaga el sistema.");
                    Console.WriteLine("-------------------------\n");
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

                case "reboot":
                    Sys.Power.Reboot();
                    break;

                case "shutdown":
                    Sys.Power.Shutdown();
                    break;

                default:
                    Console.WriteLine("Comando '" + input + "' no reconegut. Escriu 'help'.");
                    break;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        const string Version = "1.1.0";
        // 1. Instància global del sistema de fitxers
        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();

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
            catch { Console.WriteLine("\n[!] Error: Introdueix nomes numeros."); }
            Console.WriteLine("==================================\n");
        }

        protected override void BeforeRun()
        {
            // 2. Registre del VFS (Sitema de Fitxers)
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
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
                    Console.WriteLine("  ls       - Llistar fitxers i carpetes");
                    Console.WriteLine("  crear    - Crear un fitxer de text");
                    Console.WriteLine("  llegir   - Llegir contingut de fitxer");
                    Console.WriteLine("  status   - Info de la unitat (0:\\)");
                    Console.WriteLine("  ver      - Versio del sistema");
                    Console.WriteLine("  calc     - Obrir la calculadora");
                    Console.WriteLine("  clear    - Netejar la pantalla");
                    Console.WriteLine("  reboot   - Reiniciar el sistema");
                    Console.WriteLine("  shutdown - Apagar el sistema");
                    Console.WriteLine("-----------------------------------\n");
                    break;

                case "ls":
                    try
                    {
                        var files_list = Directory.GetFiles(@"0:\");
                        var directory_list = Directory.GetDirectories(@"0:\");
                        foreach (var directory in directory_list) Console.WriteLine("<DIR> " + directory);
                        foreach (var file in files_list) Console.WriteLine("      " + file);
                    }
                    catch (Exception e) { Console.WriteLine("Error: " + e.Message); }
                    break;

                case "crear":
                    try
                    {
                        Console.Write("Nom del fitxer: ");
                        string nom = Console.ReadLine();
                        Console.Write("Contingut: ");
                        string text = Console.ReadLine();
                        File.WriteAllText(@"0:\" + nom, text);
                        Console.WriteLine("Fitxer creat!");
                    }
                    catch (Exception e) { Console.WriteLine("Error: " + e.Message); }
                    break;

                case "llegir":
                    try
                    {
                        Console.Write("Quin fitxer vols llegir?: ");
                        string file = Console.ReadLine();
                        if (File.Exists(@"0:\" + file))
                        {
                            Console.WriteLine("Contingut: " + File.ReadAllText(@"0:\" + file));
                        }
                        else Console.WriteLine("El fitxer no existeix.");
                    }
                    catch (Exception e) { Console.WriteLine("Error: " + e.Message); }
                    break;

                case "status":
                    try
                    {
                        var available_space = fs.GetAvailableFreeSpace(@"0:\");
                        var fs_type = fs.GetFileSystemType(@"0:\");
                        Console.WriteLine("Tipus de sistema: " + fs_type);
                        Console.WriteLine("Espai lliure: " + available_space + " bytes");
                    }
                    catch (Exception e) { Console.WriteLine("Error: " + e.Message); }
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
                    Cosmos.System.Power.Reboot();
                    break;

                case "shutdown":
                    Console.WriteLine("Apagant...");
                    Cosmos.System.Power.Shutdown();
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
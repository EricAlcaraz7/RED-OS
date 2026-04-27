using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    // 🔊 CLASSE DE SO
    public static class Sound
    {
        public static void Beep(int frequency, int duration)
        {
            try
            {
                Console.Beep(frequency, duration);
            }
            catch { }
        }

        public static void StartupSound()
        {
            Beep(800, 150);
            Beep(1000, 150);
            Beep(1200, 200);
        }

        public static void SuccessSound()
        {
            Beep(1000, 100);
            Beep(1200, 100);
        }

        public static void ErrorSound()
        {
            Beep(400, 300);
        }
    }

    public class Kernel : Sys.Kernel
    {
        const string Version = "1.2.0";

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

            Console.Write("\nTria operacio: ");
            string op = Console.ReadLine().ToLower().Trim();

            try
            {
                if (op == "sqrt")
                {
                    Console.Write("Introdueix el numero: ");
                    double n = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("\n> RESULTAT: " + Math.Sqrt(n));
                    Sound.SuccessSound();
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
                    else
                    {
                        Console.WriteLine("\n> Operacio no valida.");
                        Sound.ErrorSound();
                        return;
                    }

                    Sound.SuccessSound();
                }
            }
            catch
            {
                Sound.ErrorSound();
                Console.WriteLine("\n[!] Error: Introdueix nomes numeros.");
            }

            Console.WriteLine("==================================\n");
        }

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());

            ShowRedOSLogo();
            Sound.StartupSound(); // 🔊 SO INICI

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
                    Sound.SuccessSound();
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

                        foreach (var directory in directory_list)
                            Console.WriteLine("<DIR> " + directory);

                        foreach (var file in files_list)
                            Console.WriteLine("      " + file);

                        Sound.SuccessSound();
                    }
                    catch (Exception e)
                    {
                        Sound.ErrorSound();
                        Console.WriteLine("Error: " + e.Message);
                    }
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
                        Sound.SuccessSound();
                    }
                    catch (Exception e)
                    {
                        Sound.ErrorSound();
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;

                case "llegir":
                    try
                    {
                        Console.Write("Quin fitxer vols llegir?: ");
                        string file = Console.ReadLine();

                        if (File.Exists(@"0:\" + file))
                        {
                            Console.WriteLine("Contingut: " + File.ReadAllText(@"0:\" + file));
                            Sound.SuccessSound();
                        }
                        else
                        {
                            Console.WriteLine("El fitxer no existeix.");
                            Sound.ErrorSound();
                        }
                    }
                    catch (Exception e)
                    {
                        Sound.ErrorSound();
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;

                case "status":
                    try
                    {
                        var available_space = fs.GetAvailableFreeSpace(@"0:\");
                        var fs_type = fs.GetFileSystemType(@"0:\");

                        Console.WriteLine("Tipus de sistema: " + fs_type);
                        Console.WriteLine("Espai lliure: " + available_space + " bytes");

                        Sound.SuccessSound();
                    }
                    catch (Exception e)
                    {
                        Sound.ErrorSound();
                        Console.WriteLine("Error: " + e.Message);
                    }
                    break;

                case "ver":
                    Console.WriteLine("REDos Kernel v" + Version);
                    Sound.SuccessSound();
                    break;

                case "clear":
                    Console.Clear();
                    Sound.SuccessSound();
                    break;

                case "logo":
                    ShowRedOSLogo();
                    Sound.SuccessSound();
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
                    Sound.ErrorSound();
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
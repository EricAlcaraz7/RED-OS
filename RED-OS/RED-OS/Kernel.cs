// Kernel.cs
using System;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;

        protected override void BeforeRun()
        {
            // 1. Teclado español
            Sys.KeyboardManager.SetKeyLayout(new Sys.ScanMaps.ESStandardLayout());

            // 2. Gráficos - pantalla de bienvenida
            GraphicsManager.Init();
            GraphicsManager.DrawWelcomeScreen();

            // 3. Sistema de ficheros
            try
            {
                fs = new Sys.FileSystem.CosmosVFS();
                Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            }
            catch { }

            // 4. Sonido de inicio
            Sound.StartupSound();

            // 5. Esperar ENTER
            bool continuar = false;
            while (!continuar)
            {
                if (Sys.KeyboardManager.TryReadKey(out var key))
                {
                    if (key.Key == Sys.ConsoleKeyEx.Enter)
                        continuar = true;
                }
            }

            // 6. Interfície principal
            Console.Clear();
            GraphicsManager.DrawInterface();
        }

        protected override void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("REDos > ");
            Console.ForegroundColor = ConsoleColor.White;

            var input = Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                string cmd = input.ToLower().Trim();
                CommandManager.Save(cmd);
                ExecuteCommand(cmd);
            }

            GraphicsManager.DrawInterface();
        }

        public void ExecuteCommand(string input)
        {
            switch (input)
            {
                case "help":
                    UI.MostrarAyuda();
                    break;
                case "ls":
                    FileSystemManager.ListarDirectorio(@"0:\");
                    break;
                case "crear":
                    FileSystemManager.CrearFitxer();
                    break;
                case "llegir":
                    FileSystemManager.LlegirFitxer();
                    break;
                case "calc":
                    Calculator.Ejecutar();
                    break;
                case "history":
                    CommandManager.Show();
                    string recovered = CommandManager.GetCommand();
                    if (recovered != null)
                    {
                        Console.WriteLine($"Executant: {recovered}");
                        ExecuteCommand(recovered);
                    }
                    break;
                case "clear":
                    Console.Clear();
                    GraphicsManager.DrawInterface();
                    break;
                case "status":
                    FileSystemManager.MostrarStatus(fs);
                    break;
                case "reboot":
                    Sys.Power.Reboot();
                    break;
                case "shutdown":
                    Sys.Power.Shutdown();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Comanda no reconeguda: " + input);
                    Console.ForegroundColor = ConsoleColor.White;
                    Sound.ErrorSound();
                    break;
            }
        }
    }
}
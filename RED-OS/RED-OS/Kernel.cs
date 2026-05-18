// Kernel.cs (menÃº SIN fs_ prefijos)

using System;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            GraphicsManager.Init();
            FileSystemManager.Init();

            Sound.StartupSound();

            GraphicsManager.WriteLine("REDos v1.5.0");
            GraphicsManager.WriteLine("----------------");
            GraphicsManager.WriteLine("help -> veure comandes");
            GraphicsManager.WriteLine("");
        }

        protected override void Run()
        {
            string cmd = InputManager.ReadLine();

            if (string.IsNullOrWhiteSpace(cmd))
                return;

            CommandManager.Save(cmd);

            switch (cmd.ToLower())
            {
                case "help":
                    GraphicsManager.WriteLine("");
                    GraphicsManager.WriteLine("===== COMANDES =====");
                    GraphicsManager.WriteLine("help");
                    GraphicsManager.WriteLine("calc");
                    GraphicsManager.WriteLine("clear");
                    GraphicsManager.WriteLine("history");
                    GraphicsManager.WriteLine("ls");
                    GraphicsManager.WriteLine("create");
                    GraphicsManager.WriteLine("read");
                    GraphicsManager.WriteLine("status");
                    GraphicsManager.WriteLine("reboot");
                    GraphicsManager.WriteLine("shutdown");
                    GraphicsManager.WriteLine("====================");
                    break;

                case "calc":
                    Calculator.Ejecutar();
                    break;

                case "history":
                    CommandManager.Show();
                    break;

                case "clear":
                    GraphicsManager.Clear();
                    break;

                // FILESYSTEM
                case "ls":
                    FileSystemManager.Listar(@"0:\");
                    break;

                case "create":
                    FileSystemManager.CrearFitxer();
                    break;

                case "read":
                    FileSystemManager.LlegirFitxer();
                    break;

                case "status":
                    FileSystemManager.MostrarStatus();
                    break;

                case "reboot":
                    Sys.Power.Reboot();
                    break;

                case "shutdown":
                    Sys.Power.Shutdown();
                    break;

                default:
                    GraphicsManager.WriteLine("Comanda desconeguda.");
                    Sound.ErrorSound();
                    break;
            }
        }
    }
}
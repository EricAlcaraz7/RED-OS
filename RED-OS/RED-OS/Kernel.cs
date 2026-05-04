using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        private Canvas canvas;
        private Font font = PCScreenFont.Default;

        const string Version = "2.0.0";

        Sys.FileSystem.CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();

        private static List<string> history = new List<string>();

        protected override void BeforeRun()
        {
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            canvas = FullScreenCanvas.GetFullScreenCanvas();

            DrawWelcomeScreen();
        }

        protected override void Run()
        {
            DrawUI();

            Console.Write("REDos > ");
            string input = Console.ReadLine();

            if (input == null) return;

            input = input.ToLower().Trim();
            if (input == "") return;

            SaveCommand(input);
            ExecuteCommand(input);
        }

        // ===========================
        // 🎨 PANTALLA DE BIENVENIDA
        // ===========================
        private void DrawWelcomeScreen()
        {
            canvas.Clear(Color.Black);

            // Marco rojo
            canvas.DrawRectangle(Color.Red, 50, 50, 700, 400);
            canvas.DrawFilledRectangle(Color.DarkRed, 51, 51, 698, 398);

            // Logo / texto
            canvas.DrawString("REDos", font, Color.White, 320, 120);
            canvas.DrawString("Sistema Operatiu", font, Color.White, 290, 160);
            canvas.DrawString("Version " + Version, font, Color.Gray, 300, 200);

            canvas.Display();

            Sys.PIT.Wait(2000);
        }

        // ===========================
        // 🎨 UI PRINCIPAL
        // ===========================
        private void DrawUI()
        {
            canvas.Clear(Color.Black);

            // Barra superior
            canvas.DrawFilledRectangle(Color.DarkRed, 0, 0, canvas.Mode.Width, 30);
            canvas.DrawString("REDos v" + Version, font, Color.White, 10, 8);

            // Panel lateral
            canvas.DrawFilledRectangle(Color.DarkBlue, 0, 30, 200, canvas.Mode.Height - 30);
            canvas.DrawString("Comandes:", font, Color.White, 10, 40);
            canvas.DrawString("help", font, Color.White, 10, 60);
            canvas.DrawString("ls", font, Color.White, 10, 80);
            canvas.DrawString("calc", font, Color.White, 10, 100);

            // Zona consola
            canvas.DrawRectangle(Color.White, 210, 40, 550, 400);

            canvas.Display();
        }

        // ===========================
        // 🧠 HISTORIAL
        // ===========================
        private void SaveCommand(string cmd)
        {
            history.Add(cmd);
            if (history.Count > 5)
                history.RemoveAt(0);
        }

        private void ShowHistory()
        {
            foreach (var cmd in history)
                Console.WriteLine(cmd);
        }

        // ===========================
        // ⚙️ COMANDOS
        // ===========================
        private void ExecuteCommand(string input)
        {
            switch (input)
            {
                case "help":
                    Console.WriteLine("help, ls, calc, clear, history");
                    break;

                case "history":
                    ShowHistory();
                    break;

                case "clear":
                    Console.Clear();
                    break;

                case "ls":
                    foreach (var f in Directory.GetFiles(@"0:\"))
                        Console.WriteLine(f);
                    break;

                case "calc":
                    Console.Write("A: ");
                    double a = Convert.ToDouble(Console.ReadLine());

                    Console.Write("B: ");
                    double b = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Result: " + (a + b));
                    break;

                default:
                    Console.WriteLine("Comando no reconegut");
                    break;
            }
        }
    }
}
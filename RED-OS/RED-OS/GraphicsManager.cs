// GraphicsManager.cs
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Drawing;

namespace CosmosKernel1
{
    public static class GraphicsManager
    {
        private static Canvas canvas;
        private static int W = 800;
        private static int H = 600;

        // Colores Cosmos
        private static Color COL_BG = Color.Black;
        private static Color COL_RED = Color.Red;
        private static Color COL_WHITE = Color.White;
        private static Color COL_GRAY = Color.Gray;
        private static Color COL_CYAN = Color.Cyan;
        private static Color COL_GREEN = Color.Green;

        public static void Init()
        {
            try
            {
                canvas = FullScreenCanvas.GetFullScreenCanvas(
                    new Mode(800, 600, ColorDepth.ColorDepth32)
                );

                W = 800;
                H = 600;
            }
            catch
            {
                canvas = FullScreenCanvas.GetFullScreenCanvas(
                    new Mode(640, 480, ColorDepth.ColorDepth32)
                );

                W = 640;
                H = 480;
            }
        }

        public static void DrawWelcomeScreen()
        {
            canvas.Clear(COL_BG);

            // Marco
            canvas.DrawRectangle(COL_RED, 5, 5, W - 10, H - 10);
            canvas.DrawRectangle(COL_GRAY, 8, 8, W - 16, H - 16);

            // Logo ASCII
            int x = 120;

            canvas.DrawString(
                "  ____  _____ ____",
                PCScreenFont.Default,
                COL_RED,
                x,
                150
            );

            canvas.DrawString(
                " |  _ \\\\| ____|  _ \\\\  ___  ___",
                PCScreenFont.Default,
                COL_RED,
                x,
                166
            );

            canvas.DrawString(
                " | |_) |  _| | | | |/ _ \\\\/ __|",
                PCScreenFont.Default,
                COL_RED,
                x,
                182
            );

            canvas.DrawString(
                " |  _ <| |___| |_| | (_) \\\\__ \\",
                PCScreenFont.Default,
                COL_RED,
                x,
                198
            );

            canvas.DrawString(
                " |_| \\\\_\\\\_____|____/ \\\\___/|___/",
                PCScreenFont.Default,
                COL_RED,
                x,
                214
            );

            canvas.DrawString(
                "v1.5.0  -  Sistema Operatiu REDos",
                PCScreenFont.Default,
                COL_WHITE,
                x,
                250
            );

            canvas.DrawString(
                "Cosmos Graphic Subsystem actiu",
                PCScreenFont.Default,
                COL_GRAY,
                x,
                266
            );

            canvas.DrawLine(COL_RED, 100, 300, W - 100, 300);

            canvas.DrawString(
                "Prem ENTER per continuar...",
                PCScreenFont.Default,
                COL_CYAN,
                x,
                325
            );

            canvas.Display();
        }

        public static void DrawInterface()
        {
            canvas.Clear(COL_BG);

            // Barra superior
            canvas.DrawFilledRectangle(COL_RED, 0, 0, W, 28);

            canvas.DrawString(
                "REDos OS  v1.5.0",
                PCScreenFont.Default,
                COL_WHITE,
                10,
                6
            );

            canvas.DrawString(
                "Cosmos Graphic Subsystem",
                PCScreenFont.Default,
                COL_WHITE,
                W - 230,
                6
            );

            // Panel izquierdo
            canvas.DrawRectangle(COL_GRAY, 5, 35, 180, H - 70);

            canvas.DrawString(
                "[ SISTEMA ]",
                PCScreenFont.Default,
                COL_RED,
                12,
                42
            );

            canvas.DrawString(
                "CPU:  x86",
                PCScreenFont.Default,
                COL_WHITE,
                12,
                58
            );

            canvas.DrawString(
                "FS:   FAT32",
                PCScreenFont.Default,
                COL_WHITE,
                12,
                73
            );

            canvas.DrawString(
                "[ COMANDES ]",
                PCScreenFont.Default,
                COL_RED,
                12,
                98
            );

            canvas.DrawString("help", PCScreenFont.Default, COL_GREEN, 12, 114);
            canvas.DrawString("ls", PCScreenFont.Default, COL_GREEN, 12, 129);
            canvas.DrawString("crear", PCScreenFont.Default, COL_GREEN, 12, 144);
            canvas.DrawString("llegir", PCScreenFont.Default, COL_GREEN, 12, 159);
            canvas.DrawString("calc", PCScreenFont.Default, COL_GREEN, 12, 174);
            canvas.DrawString("history", PCScreenFont.Default, COL_GREEN, 12, 189);
            canvas.DrawString("clear", PCScreenFont.Default, COL_GREEN, 12, 204);
            canvas.DrawString("status", PCScreenFont.Default, COL_GREEN, 12, 219);
            canvas.DrawString("reboot", PCScreenFont.Default, COL_GREEN, 12, 234);
            canvas.DrawString("shutdown", PCScreenFont.Default, COL_GREEN, 12, 249);

            // Área terminal
            canvas.DrawRectangle(COL_GRAY, 192, 35, W - 197, H - 70);

            canvas.DrawString(
                "REDos Terminal",
                PCScreenFont.Default,
                COL_RED,
                200,
                42
            );

            canvas.DrawLine(COL_RED, 192, 55, W - 5, 55);

            // Barra inferior
            canvas.DrawFilledRectangle(COL_GRAY, 0, H - 30, W, 30);

            canvas.DrawString(
                "REDos  |  'help' per veure les comandes",
                PCScreenFont.Default,
                COL_BG,
                10,
                H - 22
            );

            canvas.Display();

            System.Console.SetCursorPosition(25, 8);
        }
    }
}


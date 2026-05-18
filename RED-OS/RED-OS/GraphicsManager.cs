// GraphicsManager.cs

using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System.Collections.Generic;
using System.Drawing;

namespace CosmosKernel1
{
    public static class GraphicsManager
    {
        private static Canvas canvas;

        private static List<string> terminalLines = new List<string>();

        public static void Init()
        {
            canvas = FullScreenCanvas.GetFullScreenCanvas(
                new Mode(800, 600, ColorDepth.ColorDepth32)
            );

            Render();
        }

        public static void WriteLine(string text)
        {
            terminalLines.Add(text);

            if (terminalLines.Count > 25)
            {
                terminalLines.RemoveAt(0);
            }

            Render();
        }

        public static void Clear()
        {
            terminalLines.Clear();

            Render();
        }

        public static void Render()
        {
            canvas.Clear(Color.Black);

            // Barra superior
            canvas.DrawFilledRectangle(
                Color.DarkRed,
                0,
                0,
                800,
                30
            );

            canvas.DrawString(
                "REDos Graphic Mode",
                PCScreenFont.Default,
                Color.White,
                10,
                8
            );

            // Terminal
            canvas.DrawFilledRectangle(
                Color.Black,
                20,
                50,
                760,
                520
            );

            canvas.DrawRectangle(
                Color.Red,
                20,
                50,
                760,
                520
            );

            int y = 60;

            foreach (string line in terminalLines)
            {
                canvas.DrawString(
                    line,
                    PCScreenFont.Default,
                    Color.Lime,
                    30,
                    y
                );

                y += 18;
            }

            canvas.Display();
        }

        public static void RenderInput(string input)
        {
            Render();

            canvas.DrawString(
                "REDos> " + input,
                PCScreenFont.Default,
                Color.White,
                30,
                540
            );

            canvas.Display();
        }
    }
}
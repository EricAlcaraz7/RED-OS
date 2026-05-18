// CommandManager.cs

using System;
using System.Collections.Generic;

namespace CosmosKernel1
{
    public static class CommandManager
    {
        private static List<string> history = new List<string>();

        public static void Save(string cmd)
        {
            if (!string.IsNullOrWhiteSpace(cmd))
                history.Add(cmd);
        }

        public static void Show()
        {
            GraphicsManager.WriteLine("");
            GraphicsManager.WriteLine("===== HISTORIAL =====");

            if (history.Count == 0)
            {
                GraphicsManager.WriteLine("No hi ha historial.");
                GraphicsManager.WriteLine("=====================");
                return;
            }

            for (int i = 0; i < history.Count; i++)
            {
                GraphicsManager.WriteLine(i + ": " + history[i]);
            }

            GraphicsManager.WriteLine("=====================");
            GraphicsManager.WriteLine("");
        }
    }
}
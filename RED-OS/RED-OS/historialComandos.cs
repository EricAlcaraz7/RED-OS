//historialComandos.cs
using System;
using System.Collections.Generic;

namespace CosmosKernel1
{
    public static class CommandManager
    {
        private static List<string> history = new List<string>();

        public static void Save(string cmd)
        {
            if (history.Count >= 5) history.RemoveAt(0);
            history.Add(cmd);
        }

        public static void Show()
        {
            Console.WriteLine("\n--- HISTORIAL ---");
            for (int i = 0; i < history.Count; i++) Console.WriteLine($"{i}: {history[i]}");
            Sound.SuccessSound();
        }

        public static string GetCommand()
        {
            Console.Write("Index del comando: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < history.Count)
                return history[index];

            Sound.ErrorSound();
            return null;
        }
    }
}
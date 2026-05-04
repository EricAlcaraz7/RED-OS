//HistoryManager.cs
using System;
using System.Collections.Generic;

namespace CosmosKernel1
{
    // Gestiona el historial de comandos (máximo 5)
    public static class HistoryManager
    {
        private static List<string> history = new List<string>();

        // Guarda un comando
        public static void Save(string cmd)
        {
            history.Add(cmd);

            if (history.Count > 5)
                history.RemoveAt(0);
        }

        // Muestra el historial
        public static void Show()
        {
            Console.WriteLine("\n--- HISTORIAL DE COMANDES ---");

            for (int i = 0; i < history.Count; i++)
                Console.WriteLine(i + ": " + history[i]);

            Console.WriteLine("-----------------------------\n");
        }

        // Obtiene comando por índice
        public static string Get(int index)
        {
            if (index >= 0 && index < history.Count)
                return history[index];

            return null;
        }

        // Pide al usuario qué comando ejecutar
        public static string AskCommand()
        {
            Console.Write("Numero de comando: ");
            string input = Console.ReadLine();

            int index;
            if (int.TryParse(input, out index))
                return Get(index);

            return null;
        }
    }
}
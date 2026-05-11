//ui.cs
using System;

namespace CosmosKernel1
{
    public static class UI
    {
        public static void ShowLogo()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"  ____  _____ ____             ");
            Console.WriteLine(@" |  _ \| ____|  _ \  ___  ___  ");
            Console.WriteLine(@" | |_) |  _| | | | |/ _ \/ __| ");
            Console.WriteLine(@" |  _ <| |___| |_| | (_) \__ \ ");
            Console.WriteLine(@" |_| \_\_____|____/ \___/|___/ ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" v1.5.0 - Mode Grafic Actiu");
            Console.WriteLine("--------------------------------");
        }

        public static void MostrarAyuda()
        {
            Console.WriteLine("\n--- COMANDES DISPONIBLES ---");
            Console.WriteLine("ls, crear, llegir, calc, clear, history, reboot, shutdown");
            Console.WriteLine("----------------------------");
            Sound.SuccessSound();
        }
    }
}
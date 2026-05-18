// UI.cs

using System;

namespace CosmosKernel1
{
    public static class UI
    {
        public static void MostrarAyuda()
        {
            Console.WriteLine("\n--- COMANDES ---");
            Console.WriteLine("help");
            Console.WriteLine("calc");
            Console.WriteLine("history");
            Console.WriteLine("clear");
            Console.WriteLine("reboot");
            Console.WriteLine("shutdown");

            Sound.SuccessSound();
        }
    }
}
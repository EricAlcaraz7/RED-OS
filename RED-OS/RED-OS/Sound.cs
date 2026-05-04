//Sound.cs
using System;

namespace CosmosKernel1
{
    // Gestiona los sonidos del sistema
    public static class Sound
    {
        public static void Beep(int frequency, int duration)
        {
            // Console.Beep puede no funcionar en Cosmos
            try { Console.Beep(frequency, duration); }
            catch { }
        }

        public static void StartupSound()
        {
            Beep(800, 150);
            Beep(1000, 150);
            Beep(1200, 200);
        }

        public static void SuccessSound()
        {
            Beep(1000, 100);
            Beep(1200, 100);
        }

        public static void ErrorSound()
        {
            Beep(400, 300);
        }
    }
}
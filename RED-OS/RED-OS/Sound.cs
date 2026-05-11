//sound.cs
using System;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public static class Sound
    {
        public static void Beep(uint freq, uint dur)
        {
            try { Sys.PCSpeaker.Beep(freq, dur); } catch { }
        }

        public static void StartupSound()
        {
            Beep(800, 100); Beep(1000, 100); Beep(1200, 150);
        }

        public static void SuccessSound()
        {
            Beep(1000, 100); Beep(1200, 100);
        }

        public static void ErrorSound() => Beep(400, 300);
    }
}
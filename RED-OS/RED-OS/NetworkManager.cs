using System;
using Cosmos.HAL;
using Cosmos.System.Network;
using Cosmos.System.Network.Config;
using Cosmos.System.Network.IPv4;

namespace CosmosKernel1
{
    public static class NetworkManager
    {
        public static void Init()
        {
            try
            {
                if (NetworkDevice.Devices.Count > 0)
                {
                    var device = NetworkDevice.Devices[0];

                    // Configuración IP Estática básica
                    IPConfig.Enable(device,
                        new Address(192, 168, 1, 100),  // IP de REDos
                        new Address(255, 255, 255, 0), // Máscara
                        new Address(192, 168, 1, 1));  // Gateway (Router)

                    Console.WriteLine("Red inicializada correctamente.");
                }
                else
                {
                    Console.WriteLine("Aviso: No se detectaron interfaces de red al arrancar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error de red al inicializar: " + ex.Message);
            }
        }

        public static void MostrarConfiguracion()
        {
            if (NetworkDevice.Devices.Count == 0)
            {
                Console.WriteLine("No se detectaron tarjetas de red.");
            }
            else
            {
                foreach (var config in NetworkConfiguration.NetworkConfigs)
                {
                    Console.WriteLine($"Interfaz: {config.Device.Name}");
                    Console.WriteLine($"IP: {config.IPConfig.IPAddress}");
                    Console.WriteLine($"Mascara: {config.IPConfig.SubnetMask}");
                }
            }
        }
    }
}
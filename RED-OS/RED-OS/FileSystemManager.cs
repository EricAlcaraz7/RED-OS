//FileSystemManager.cs
using System;
using System.IO;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public static class FileSystemManager
    {
        public static void ListarDirectorio(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);
                var dirs = Directory.GetDirectories(path);
                foreach (var d in dirs) Console.WriteLine("<DIR> " + d);
                foreach (var f in files) Console.WriteLine("      " + f);
                Sound.SuccessSound();
            }
            catch { Sound.ErrorSound(); Console.WriteLine("Error al llistar."); }
        }

        public static void CrearFitxer()
        {
            try
            {
                Console.Write("Nom del fitxer: ");
                string nom = Console.ReadLine();
                Console.Write("Contingut: ");
                string text = Console.ReadLine();
                File.WriteAllText(@"0:\" + nom, text);
                Console.WriteLine("Fitxer creat!");
                Sound.SuccessSound();
            }
            catch { Sound.ErrorSound(); Console.WriteLine("Error al crear."); }
        }

        public static void LlegirFitxer()
        {
            try
            {
                Console.Write("Fitxer a llegir: ");
                string file = Console.ReadLine();
                if (File.Exists(@"0:\" + file))
                {
                    Console.WriteLine("Contingut: " + File.ReadAllText(@"0:\" + file));
                    Sound.SuccessSound();
                }
                else { Console.WriteLine("No existeix."); Sound.ErrorSound(); }
            }
            catch { Sound.ErrorSound(); }
        }

        public static void MostrarStatus(Sys.FileSystem.CosmosVFS fs)
        {
            try
            {
                Console.WriteLine("Tipus: " + fs.GetFileSystemType(@"0:\"));
                Console.WriteLine("Espai lliure: " + fs.GetAvailableFreeSpace(@"0:\"));
                Sound.SuccessSound();
            }
            catch { Sound.ErrorSound(); }
        }
    }
}
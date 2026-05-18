// FileSystemManager.cs
// Sistema de archivos basico usando Cosmos VFS

using System;
using System.IO;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public static class FileSystemManager
    {
        private static Sys.FileSystem.CosmosVFS fs;

        public static void Init()
        {
            fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }

        public static void Listar(string path)
        {
            try
            {
                var dirs = Directory.GetDirectories(path);
                var files = Directory.GetFiles(path);

                GraphicsManager.WriteLine("");
                GraphicsManager.WriteLine("===== DIRECTORIO =====");

                foreach (var d in dirs)
                    GraphicsManager.WriteLine("<DIR> " + d);

                foreach (var f in files)
                    GraphicsManager.WriteLine("      " + f);

                GraphicsManager.WriteLine("======================");
            }
            catch
            {
                GraphicsManager.WriteLine("Error al llistar directori.");
                Sound.ErrorSound();
            }
        }

        public static void CrearFitxer()
        {
            try
            {
                GraphicsManager.WriteLine("Nom del fitxer:");

                string name = InputManager.ReadLine();
                name = Path.GetFileName(name);

                GraphicsManager.WriteLine("Contingut:");

                string content = InputManager.ReadLine();

                File.WriteAllText(@"0:\" + name, content);

                GraphicsManager.WriteLine("Fitxer creat correctament.");
                Sound.SuccessSound();
            }
            catch
            {
                GraphicsManager.WriteLine("Error creant fitxer.");
                Sound.ErrorSound();
            }
        }

        public static void LlegirFitxer()
        {
            try
            {
                GraphicsManager.WriteLine("Nom del fitxer:");

                string name = InputManager.ReadLine();
                string path = @"0:\" + Path.GetFileName(name);

                if (!File.Exists(path))
                {
                    GraphicsManager.WriteLine("El fitxer no existeix.");
                    Sound.ErrorSound();
                    return;
                }

                string content = File.ReadAllText(path);

                GraphicsManager.WriteLine("");
                GraphicsManager.WriteLine("===== CONTINGUT =====");
                GraphicsManager.WriteLine(content);
                GraphicsManager.WriteLine("=====================");
            }
            catch
            {
                GraphicsManager.WriteLine("Error llegint fitxer.");
                Sound.ErrorSound();
            }
        }

        public static void MostrarStatus()
        {
            try
            {
                GraphicsManager.WriteLine("");
                GraphicsManager.WriteLine("===== FS STATUS =====");

                GraphicsManager.WriteLine("Tipus: " + fs.GetFileSystemType(@"0:\"));
                GraphicsManager.WriteLine("Espai lliure: " + fs.GetAvailableFreeSpace(@"0:\"));

                GraphicsManager.WriteLine("====================");
            }
            catch
            {
                GraphicsManager.WriteLine("Error obtenint status FS.");
                Sound.ErrorSound();
            }
        }
    }
}
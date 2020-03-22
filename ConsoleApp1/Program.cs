using System;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    public static class Program
    {
        private static String initialDirectory;
        
        private static void Main(string[] args)
        {
            initialDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine($"Working directory: \n{initialDirectory}");
            
            var files = Directory
                .GetFiles(initialDirectory)
                .Where(x => x.EndsWith(".dds") || x.EndsWith(".bmp") || x.EndsWith(".cfg"))
                .ToList();
            
            Console.WriteLine($"Files: \n{String.Join("\n", files)}");

            var mainDirectory = initialDirectory + "\\..";
            var mainDirectoryTextureFolders =
                Directory.GetDirectories(mainDirectory).Where(x => x.ToLower().Contains("texture."));

            var workingFolders = ClassLibrary1.Class1.GetWorkingFolders(mainDirectoryTextureFolders);
            
            Console.WriteLine($"Texture folders: \n{String.Join("\n", workingFolders)}");
            Console.WriteLine("Working on:\n");
            
            foreach (var textureFolder in workingFolders)
            {
                foreach (var filePath in files)
                {
                    var fileName = Path.GetFileName(filePath);
                    Console.WriteLine($"Copying {filePath} to {textureFolder}");
                    File.Copy(
                        filePath, 
                        $"{textureFolder}\\{fileName}",
                        true);
                }
            }
            
            Console.WriteLine("Ready");
            Console.ReadKey();
        }
    }
}
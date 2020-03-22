using System;
using System.IO;
using System.Linq;

namespace ConsoleApp2
{
    static class Program
    {
        static void Main(string[] args)
        {
            var initialDirectory = Directory.GetCurrentDirectory();
            var textureFolders = Directory
                .GetDirectories(initialDirectory)
                .Where(x => new DirectoryInfo(x).Name.ToLower().StartsWith("texture."))
                .ToList();
            var workingFolders = ClassLibrary1.Class1.GetWorkingFolders(textureFolders);

            foreach (var workingFolder in workingFolders)
            {
                var files = Directory
                    .GetFiles(workingFolder)
                    .Select(Path.GetFileName)
                    .Select(x =>  x.Substring(0, x.Length - 4).ToLower())
                    .GroupBy(x => x)
                    .Where(x => x.Count() > 1)
                    .Select(group => group.Key);

                foreach (var file in files)
                {
                    var path = Path.Combine(workingFolder, file + ".bmp");
                    Console.Write($"Удаляем {path}: ");
                    try
                    {
                        File.Delete(path);
                        Console.Write("успех.\n");
                    }
                    catch
                    {
                        Console.Write("ошибка.\n");
                    }
                }
            }
            
            Console.WriteLine("Ready");
            Console.ReadKey();
        }
    }
}